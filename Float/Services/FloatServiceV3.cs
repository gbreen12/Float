﻿using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Float.Services
{
    public abstract class FloatServiceV3<T> : IFloatServiceV3<T>
        where T : class, new()
    {
        protected abstract string BaseEndpoint { get; }

        public IEnumerable<T> GetCollection(int? limit = null)
        {
            int totalResultCount = 0;
            var results = new List<T>();
            int page = 0;

            do
            {
                page++;
                var response = Rest.GetV3<List<T>>($"{BaseEndpoint}?page={page}&per-page=200");
                results.AddRange(response.Data);
                totalResultCount = GetTotalResultCount(limit, response.GetTotalResultCount());
            }
            while (results.Count < totalResultCount);

            return results.Take(limit ?? results.Count);
        }

        private int GetTotalResultCount(int? limit, int actualTotal)
        {
            if (limit.HasValue && limit.Value <= actualTotal)
                return limit.Value;
            else
                return actualTotal;
        }

        public IEnumerable<T> GetCollection(int page, int perPage)
        {
            var response = Rest.GetV3<List<T>>($"{BaseEndpoint}?page={page}&per-page={perPage}");
            return response.Data;
        }

        public T GetInstance(int id)
        {
            var response = Rest.GetV3<T>($"{BaseEndpoint}/{id}");

            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            return response.Data;
        }

        public T Create(T model)
        {
            var response = Rest.PostV3(BaseEndpoint, model);

            if ((int)response.StatusCode == 422)
                throw new ValidationException(response.Content);

            return response.Data;
        }

        public T Update(int id, T model)
        {
            var response = Rest.PatchV3($"{BaseEndpoint}/{id}", model);

            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            if ((int)response.StatusCode == 422)
                throw new ValidationException(response.Content);

            return response.Data;
        }

        public bool Delete(int id)
        {
            var response = Rest.Delete<T>($"{BaseEndpoint}/{id}");
            return response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.NotFound;
        }
    }

    public interface IFloatServiceV3<T>
        where T : class, new()
    {
        IEnumerable<T> GetCollection(int? limit = null);
        IEnumerable<T> GetCollection(int page, int perPage);
        T GetInstance(int id);
        T Create(T model);
        T Update(int id, T model);
        bool Delete(int id);
    }
}

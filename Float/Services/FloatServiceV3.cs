using System.Collections.Generic;
using System.Linq;

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
                totalResultCount = limit ?? int.Parse(response.Headers.Single(x => x.Name == Rest.TOTAL_COUNT).Value.ToString());
            }
            while (results.Count < totalResultCount);

            return results.Take(limit ?? results.Count);
        }

        public IEnumerable<T> GetCollection(int page, int perPage)
        {
            var response = Rest.GetV3<List<T>>($"{BaseEndpoint}?page={page}&per-page={perPage}");
            return response.Data;
        }

        public T GetInstance(int id)
        {
            var response = Rest.GetV3<T>($"{BaseEndpoint}/{id}");
            return response.Data;
        }

        public T Create(T model)
        {
            var response = Rest.PostV3(BaseEndpoint, model);
            return response.Data;
        }

        public T Update(int id, T model)
        {
            var response = Rest.PatchV3($"{BaseEndpoint}/{id}", model);
            return response.Data;
        }

        public T Delete(int id)
        {
            var response = Rest.Delete<T>($"{BaseEndpoint}/{id}");
            return response.Data;
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
        T Delete(int id);
    }
}

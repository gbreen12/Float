using RestSharp;

namespace Float
{
    internal static class Rest
    {
        internal const string CURRENT_PAGE = "X-Pagination-Current-Page";
        internal const string PAGE_COUNT = "X-Pagination-Page-Count";
        internal const string TOTAL_COUNT = "X-Pagination-Total-Count";
        private const string FLOAT_API = "https://api.float.com";

        private static readonly JsonSerializer jsonSerializer = new JsonSerializer();
        private static RestClient _v3;
        internal static RestClient V3 => _v3 = _v3 ?? new RestClient($"{FLOAT_API}/v3");

        internal static IRestResponse<T> GetV3<T>(string endpoint)
            where T : class, new()
        {
            return V3.Execute<T>(GetRequest(endpoint));
        }

        internal static IRestResponse<T> PostV3<T>(string endpoint, T model)
            where T : class, new()
        {
            return V3.Execute<T>(GetRequest(endpoint, Method.POST, model));
        }

        internal static IRestResponse<T> PatchV3<T>(string endpoint, T model)
            where T : class, new()
        {
            return V3.Execute<T>(GetRequest(endpoint, Method.PATCH, model));
        }

        internal static IRestResponse<T> Delete<T>(string endpoint)
            where T : class, new()
        {
            return V3.Execute<T>(GetRequest(endpoint, Method.DELETE));
        }

        private static IRestRequest GetRequest(string endpoint, Method method = Method.GET, object body = null)
        {
            var request = new RestRequest(endpoint, method)
            {
                JsonSerializer = jsonSerializer
            };
            request.AddHeader("Authorization", $"Bearer {FloatConfig.AuthToken}");
            request.AddHeader("User-Agent", FloatConfig.UserAgent);

            if (body != null)
            {
                request.RequestFormat = DataFormat.Json;
                request.AddBody(body);
            }

            return request;
        }
    }
}

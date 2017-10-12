using RestSharp;
using System.Linq;

namespace Float
{
    internal static class RestResponseExtensions
    {
        internal static int GetTotalResultCount(this IRestResponse response)
        {
            return int.Parse(response.Headers.Single(x => x.Name == Rest.TOTAL_COUNT).Value.ToString());
        }
    }
}

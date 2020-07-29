using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ServiceLocationAndDecoupling.Services;

namespace ServiceLocationAndDecoupling
{
    public  class WeatherEndpoint
    {

        public static async Task Endpoint(HttpContext context, IResponseFormatter formatter)
        {
            await formatter.Format(context, "It is raining in Vancouver");
        }
    }
}

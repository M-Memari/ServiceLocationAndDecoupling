using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceLocationAndDecoupling.Services
{
    public static class EndpointExtensions
    {
        public static void MapWeather(this IEndpointRouteBuilder endpoint, string path)
        {
            var formatter = endpoint.ServiceProvider.GetRequiredService<IResponseFormatter>();
            endpoint.MapGet(path, context => WeatherEndpoint.Endpoint(context, formatter));
        }
    }
}

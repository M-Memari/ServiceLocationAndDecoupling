using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceLocationAndDecoupling.Services;

namespace ServiceLocationAndDecoupling
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IResponseFormatter, TextFormatter>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env
        ,IResponseFormatter formatter)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<WeatherMiddleware>();
            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/middleware/function")
                {
                    await formatter.Format(context, "It is snowing in Toronto");
                }
                else
                {
                    await next();
                }
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/endpoint/class", WeatherEndpoint.Endpoint);
                endpoints.MapWeather("/endpoint/class");
            });
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Response From Terminal Middlware");
            });
        }
    }
}

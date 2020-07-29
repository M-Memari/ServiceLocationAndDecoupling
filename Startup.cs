using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            IResponseFormatter formatter = new TextFormatter();
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
                endpoints.MapGet("/endpoint/class", WeatherEndpoint.Endpoint);
            });
            app.Run(async (context) =>
            {
                await formatter.Format(context, "Terminal middleware reached");
            });
        }
    }
}

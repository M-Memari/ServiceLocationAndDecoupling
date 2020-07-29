using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ServiceLocationAndDecoupling.Services;

namespace ServiceLocationAndDecoupling
{
    public class WeatherMiddleware
    {
        private readonly RequestDelegate _next;

        public WeatherMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            IResponseFormatter formatter = new TextFormatter();
            if (context.Request.Path =="/middleware/class")
            {
                await formatter.Format(context, "It is sunny in LA");
            }
            else
            {
                await _next(context);
            }
        }
    }
}

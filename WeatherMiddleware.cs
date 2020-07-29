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
        private readonly IResponseFormatter _formatter;

        public WeatherMiddleware(RequestDelegate next, IResponseFormatter formatter)
        {
            _next = next;
            _formatter = formatter;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path =="/middleware/class")
            {
                await _formatter.Format(context, "It is sunny in LA");
            }
            else
            {
                await _next(context);
            }
        }
    }
}

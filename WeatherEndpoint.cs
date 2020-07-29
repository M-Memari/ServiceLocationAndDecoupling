using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ServiceLocationAndDecoupling.Services;

namespace ServiceLocationAndDecoupling
{
    public  class WeatherEndpoint
    {

        public static async Task Endpoint(HttpContext context)
        {
            var formatter = context.RequestServices.GetRequiredService<IResponseFormatter>();
            await formatter.Format(context, "It is raining in Vancouver");
        }
    }
}

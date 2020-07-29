using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ServiceLocationAndDecoupling.Services;

namespace ServiceLocationAndDecoupling
{
    public static class WeatherEndpoint
    {
        public static async Task Endpoint(HttpContext context)
        {
            
            await TextFormatter.Singleton.Format(context, "It is raining in Vancouver");
        }
    }
}

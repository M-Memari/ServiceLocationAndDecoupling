using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ServiceLocationAndDecoupling.Services
{
    public  class TextFormatter : IResponseFormatter
    {
        private int _count;
        public async Task Format(HttpContext context, string content)
        {
            await context.Response.WriteAsync($"Response: {++_count}\n{content}");
        }
    }
}

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ServiceLocationAndDecoupling.Services
{
    public interface IResponseFormatter
    {
        Task Format(HttpContext context, string content);
    }
}

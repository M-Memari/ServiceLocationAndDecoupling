using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ServiceLocationAndDecoupling.Services
{
    public interface IResponseFormatter
    {
        Task Format(HttpContext context, string content);
    }
}

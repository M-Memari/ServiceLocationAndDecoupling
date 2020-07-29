using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLocationAndDecoupling.Services
{
    public static class TypeBroker
    {
        public static IResponseFormatter Formatter { get; } = new TextFormatter();
    }
}

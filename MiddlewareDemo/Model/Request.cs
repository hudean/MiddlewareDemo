using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareDemo
{
    public class Request
    {
        public DateTime DT { get; set; }
        public string MiddlewareActivation { get; set; }

        public string Value { get; set; }

    }
}

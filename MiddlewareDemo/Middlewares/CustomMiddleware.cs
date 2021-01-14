using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareDemo
{
    #region 按请求中间件依赖项

    public class GetValue
    {
        public static int Value { get; set; }
    }

    public interface IMyScopedService
    {

        void SetMyProperty(int value);

    }

    public class MyScopedService : IMyScopedService
    {
        public void SetMyProperty(int value)
        {
            GetValue.Value = value;
        }
    }

    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // IMyScopedService is injected into Invoke
        public async Task Invoke(HttpContext httpContext, IMyScopedService svc)
        {
            svc.SetMyProperty(1000);
            string str = $" GetValue.Value : { GetValue.Value } \t";
            await httpContext.Response.WriteAsync(str, Encoding.UTF8);
            await _next(httpContext);
        }
    }


    #endregion
}

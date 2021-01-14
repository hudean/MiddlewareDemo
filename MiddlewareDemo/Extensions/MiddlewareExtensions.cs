using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareDemo
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseConventionalMiddleware(
       this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ConventionalMiddleware>();
        }

        public static IApplicationBuilder UseFactoryActivatedMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FactoryActivatedMiddleware>();
        }

        //    public static IApplicationBuilder UseFactoryActivatedMiddleware(
        //this IApplicationBuilder builder, bool option)
        //    {
        //        // Passing 'option' as an argument throws a NotSupportedException at runtime.
        //        return builder.UseMiddleware<FactoryActivatedMiddleware>(option);
        //    }
    }
}

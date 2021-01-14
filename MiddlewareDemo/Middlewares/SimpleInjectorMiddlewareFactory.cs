using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareDemo
{
    #region

    ///// <summary>
    ///// 使用 ASP.NET Core 中的第三方容器激活中间件
    ///// IMiddlewareFactory 提供中间件的创建方法。
    /////在示例应用中，实现了中间件工厂以创建 SimpleInjectorActivatedMiddleware 实例。 中间件工厂使用 Simple Injector 容器来解析中间件：
    ///// </summary>
    //public class SimpleInjectorMiddlewareFactory : IMiddlewareFactory
    //{
    //    private readonly Container _container;

    //    public SimpleInjectorMiddlewareFactory(Container container)
    //    {
    //        _container = container;
    //    }

    //    public IMiddleware Create(Type middlewareType)
    //    {
    //        return _container.GetInstance(middlewareType) as IMiddleware;
    //    }

    //    /// <summary>
    //    /// 释放
    //    /// </summary>
    //    /// <param name="middleware">中间件</param>
    //    public void Release(IMiddleware middleware)
    //    {
    //        // The container is responsible for releasing resources.
    //    }
    //}



    //public class SimpleInjectorActivatedMiddleware : IMiddleware
    //{
    //    private readonly AppDbContext _db;

    //    public SimpleInjectorActivatedMiddleware(AppDbContext db)
    //    {
    //        _db = db;
    //    }

    //    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    //    {
    //        var keyValue = context.Request.Query["key"];

    //        if (!string.IsNullOrWhiteSpace(keyValue))
    //        {
    //            _db.Add(new Request()
    //            {
    //                DT = DateTime.UtcNow,
    //                MiddlewareActivation = "SimpleInjectorActivatedMiddleware",
    //                Value = keyValue
    //            });
    //            await context.Response.WriteAsync($"SimpleInjectorActivatedMiddleware count : {DB.DbList.Count.ToString()} \t");
    //            // await _db.SaveChangesAsync();
    //        }

    //        await next(context);
    //    }
    //}


    ///// <summary>
    ///// 为中间件创建扩展 (Middleware/MiddlewareExtensions.cs) ：
    ///// </summary>
    //public static class MiddlewareExtensions2
    //{
    //    public static IApplicationBuilder UseSimpleInjectorActivatedMiddleware(
    //        this IApplicationBuilder builder)
    //    {
    //        return builder.UseMiddleware<SimpleInjectorActivatedMiddleware>();
    //    }
    //}


    #endregion

}

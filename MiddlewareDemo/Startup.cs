using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareDemo
{
    public class Startup
    {
        private readonly Container _container;
        public Startup(IConfiguration configuration, Container container)
        {
            Configuration = configuration;
            _container = container;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IMyScopedService, MyScopedService>();
            services.AddScoped<AppDbContext>();
            services.AddTransient<FactoryActivatedMiddleware>();
            services.AddControllers();

            #region
            //Startup.ConfigureServices 必须执行多项任务：
            //设置 Simple Injector 容器。
            //注册工厂和中间件。
            //使 Simple Injector 容器提供应用的数据库上下文。



            // Replace the default middleware factory with the 
            // SimpleInjectorMiddlewareFactory.
            //services.AddTransient<IMiddlewareFactory>(_ =>
            //{
            //    return new SimpleInjectorMiddlewareFactory(_container);
            //});

            // Wrap ASP.NET Core requests in a Simple Injector execution 
            // context.
           // services.UseSimpleInjectorAspNetRequestScoping(_container);

            // Provide the database context from the Simple 
            // Injector container whenever it's requested from 
            // the default service container.
            //services.AddScoped<AppDbContext>(provider =>
            //    _container.GetInstance<AppDbContext>());

            //_container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            //_container.Register<AppDbContext2>(() =>
            //{
            //    var optionsBuilder = new DbContextOptionsBuilder<DbContext>();
                
            //    optionsBuilder.UseInMemoryDatabase("InMemoryDb");
            //    return new AppDbContext2(optionsBuilder.Options);
            //}, Lifestyle.Scoped);

            //_container.Register<SimpleInjectorActivatedMiddleware>();

            //_container.Verify();

            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //中间件在 Startup.Configure 的请求处理管道中注册：第三方容器激活中间件
            //app.UseSimpleInjectorActivatedMiddleware();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            #region 自定义中间件

            #region 1、直接在Configure 方法中用app.Use自定义中间件
            //app.Use(async (context, next) =>
            //{
            //    var cultureQuery = context.Request.Query["culture"];
            //    if (!string.IsNullOrWhiteSpace(cultureQuery))
            //    {
            //        await context.Response.WriteAsync($"{cultureQuery} \t ");

            //        //var culture = new CultureInfo(cultureQuery);
            //        //CultureInfo.CurrentCulture = culture;
            //        //CultureInfo.CurrentUICulture = culture;
            //    }
            //    // Call the next delegate/middleware in the pipeline
            //    //调用管道中的下一个委托/中间件
            //    await next();
            //});
            #endregion

            #region 2、使用中间件写在类中的

            //app.UseMiddleware<RequestCultureMiddleware>();
            //app.UseMiddleware<CustomMiddleware>();

            #endregion
            //app.UseRequestCulture();
          

            #region 基于工厂的中间件
            app.UseConventionalMiddleware();
            app.UseFactoryActivatedMiddleware();
            //app.UseFactoryActivatedMiddleware(false);
            #endregion


            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello, World!");
            });

            #endregion

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

}

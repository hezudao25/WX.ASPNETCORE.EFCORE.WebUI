using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Asp.NetCore.Business.Service;
using Asp.NetCore.Business.Interface;
using Asp.NetCore.EFCore.Models;
using Asp.NetCore.EFCore.Models.Extend;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Autofac;
using Microsoft.Extensions.Configuration.Json;
using Asp.NetCore.Web.Utility;
using Autofac.Configuration;
using Asp.NetCore.Business.Service;

namespace Asp.NetCore.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        { 
            ///使用.NetCore的默认容器：
            ///1.注册服务（需要把依赖的所有服务全部注册）
            ///2.直接在控制器中通过构造函数注入
            services.AddControllersWithViews();
            //services.AddScoped<IDbContextFactory, DbContextFactory>();
            //services.AddScoped<IUserService, UserService>();
            //services.AddScoped<ICompanyService, CompanyService>();
            //services.AddScoped<ICompanyUserService, CompanyUserService>(); 
        }

        /// <summary>
        /// CLR调用
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {

            #region 手动注册
            builder.RegisterModule(new AutofacModule());
            //在这里添加服务注册
            builder.RegisterType<DbContextFactory>().As<IDbContextFactory>();//注册 
            builder.RegisterType<UserService>().As<IUserService>();//注册 
            builder.RegisterType<CompanyService>().As<ICompanyService>();//注册 
            builder.RegisterType<CompanyUserService>().As<ICompanyUserService>();//注册 
            #endregion

            #region 配置文件注册 

            //上端和下端 完全断开耦合

            //IConfigurationBuilder config = new ConfigurationBuilder();
            //IConfigurationSource autofacJsonConfigSource = new JsonConfigurationSource()
            //{
            //    Path = "Autofac.json",
            //    Optional = false,//boolean,默认就是false,可不写
            //    ReloadOnChange = false,//同上
            //};
            //config.Add(autofacJsonConfigSource);
            //var module = new ConfigurationModule(config.Build());
            //builder.RegisterModule(module);
            #endregion 
        }




        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

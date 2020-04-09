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
            ///ʹ��.NetCore��Ĭ��������
            ///1.ע�������Ҫ�����������з���ȫ��ע�ᣩ
            ///2.ֱ���ڿ�������ͨ�����캯��ע��
            services.AddControllersWithViews();
            //services.AddScoped<IDbContextFactory, DbContextFactory>();
            //services.AddScoped<IUserService, UserService>();
            //services.AddScoped<ICompanyService, CompanyService>();
            //services.AddScoped<ICompanyUserService, CompanyUserService>(); 
        }

        /// <summary>
        /// CLR����
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {

            #region �ֶ�ע��
            builder.RegisterModule(new AutofacModule());
            //��������ӷ���ע��
            builder.RegisterType<DbContextFactory>().As<IDbContextFactory>();//ע�� 
            builder.RegisterType<UserService>().As<IUserService>();//ע�� 
            builder.RegisterType<CompanyService>().As<ICompanyService>();//ע�� 
            builder.RegisterType<CompanyUserService>().As<ICompanyUserService>();//ע�� 
            #endregion

            #region �����ļ�ע�� 

            //�϶˺��¶� ��ȫ�Ͽ����

            //IConfigurationBuilder config = new ConfigurationBuilder();
            //IConfigurationSource autofacJsonConfigSource = new JsonConfigurationSource()
            //{
            //    Path = "Autofac.json",
            //    Optional = false,//boolean,Ĭ�Ͼ���false,�ɲ�д
            //    ReloadOnChange = false,//ͬ��
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

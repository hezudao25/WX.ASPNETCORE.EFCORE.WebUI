using Asp.NetCore.Business.Interface;
//using Asp.NetCore.Business.Service;
using Asp.NetCore.EFCore.Models.Extend;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore.Web.Utility
{
     
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<CompanyService>().As<ICompanyService>();
            //builder.RegisterType<CompanyUserService>().As<ICompanyUserService>();
            //builder.RegisterType<UserService>().As<IUserService>();
            //builder.RegisterType<DbContextFactory>().As<IDbContextFactory>();
        }
    }
}

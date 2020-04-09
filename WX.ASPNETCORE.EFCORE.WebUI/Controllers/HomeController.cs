using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Asp.NetCore.Web.Models;
using Asp.NetCore.EFCore.Models;
using Asp.NetCore.EFCore.Models.Models;
using Asp.NetCore.EFCore.Models.Extend;
using Microsoft.Extensions.Configuration;
using System.IO;
using Asp.NetCore.Business.Interface;
using System.Linq.Expressions;
//using Asp.NetCore.Business.Service;

namespace Asp.NetCore.Web.Controllers
{
    /// <summary>
    /// .NetCore  默认容器
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _IUserService;
        private readonly ICompanyService _ICompanyService;
        private readonly ICompanyUserService _ICompanyUserService;

        public HomeController(ILogger<HomeController> logger, IUserService userService, ICompanyService companyService, ICompanyUserService companyuserService)
        {
            _logger = logger;
            this._IUserService = userService;
            this._ICompanyService = companyService;
            this._ICompanyUserService = companyuserService;
        }

        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            {
                //var configura = new ConfigurationBuilder()
                //      .SetBasePath(Directory.GetCurrentDirectory())
                //      .AddJsonFile("appsettings.json")
                //      .Build(); 
                //IDbContextFactory contextFactory = new DbContextFactory(configura); 
                //{
                //    IUserService userService = new UserService(contextFactory);
                //    SysUserInfo userInfo = userService.Find<SysUserInfo>(6);
                //}
                ////如果需要查询Company；再来一个CompanyService 
                //{
                //    ICompanyService companyService = new CompanyService(contextFactory);
                //    Company company = companyService.Find<Company>(1);
                //}
                ////发现代码重复很多  UserSercie 和CompanyService 都有增删改查方法； 就来一个父类/继承一下； 
                ////难道每一个对表的操作都需要来一个Service吗？
                ////有些操作如果需要多个表同时来呢？ 删除公司的时候，也需要把公司下的用户删除掉：
                //{
                //    ICompanyUserService companyuserService = new CompanyUserService(contextFactory);
                //    companyuserService.DeleteCompanyAndUser(123);
                //} 
            }
            {
                SysUserInfo userInfo = _IUserService.Find<SysUserInfo>(6,WriteAndReadEnum.Write);
                Company company = _ICompanyService.Find<Company>(1);
                // _ICompanyUserService.DeleteCompanyAndUser(123);


                //var userInfoList = _IUserService.PagingQuery

                ////分页之前先排序
                //userInfoList = userInfoList.OrderByDescending(q => q.USERID);
               
                Expression<Func<SysUserInfo, bool>> expression = c => c.Id > 0;
                PageInfo<SysUserInfo> dto = _IUserService.PagingQuery(expression, 1, 20, WriteAndReadEnum.Write);
                //base.ViewBag.ReadWriteList = _IUserService.GetList<SysUserInfo>(10, expression, WriteAndReadEnum.Read);
                base.ViewBag.ReadWriteList = dto.Result;
            }
            #region MyRegion
            ////{
            ////    //1.增删改
            ////    EFCoreContextWrite01 context = new EFCoreContextWrite01();
            ////    context.UserInfo.Add(new UserInfo()
            ////    {
            ////        UserName = "肖工",
            ////        UserAge = 25,
            ////        Description = "高级班体验课学员"
            ////    });
            ////    context.SaveChanges(); 
            ////}
            ////{
            ////    EFCoreContextRead02 contextRead02 = new EFCoreContextRead02(); 
            ////    UserInfo user = contextRead02.UserInfo.OrderByDescending(a => a.UserId).FirstOrDefault(); 
            ////}
            ////{
            ////    EFCoreContextRead03 contextRead03 = new EFCoreContextRead03();
            ////    UserInfo user = contextRead03.UserInfo.OrderByDescending(a => a.UserId).FirstOrDefault();

            ////}
            ////{
            ////    //EFCoreContext context = new EFCoreContext();
            ////    //context.Database.EnsureDeleted();
            ////    //context.Database.EnsureCreated(); 
            ////}
            //{
            //    //var configura = new ConfigurationBuilder()
            //    //     .SetBasePath(Directory.GetCurrentDirectory())
            //    //     .AddJsonFile("appsettings.json")
            //    //     .Build();
            //    //IDbContextFactory dbContextFactory = new DbContextFactory(configura);
            //    //{
            //    //    EFCoreAllContext context = dbContextFactory.CreateContext(WriteAndReadEnum.Write);
            //    //    context.UserInfo.Add(new UserInfo()
            //    //    {
            //    //        UserName = "我不会走~",
            //    //        UserAge = 26,
            //    //        Description = "高级的Vip学员"
            //    //    });
            //    //    context.SaveChanges();
            //    //}
            //    ////多连接  对应多个Context的实例
            //    //{
            //    //    EFCoreAllContext context = dbContextFactory.CreateContext(WriteAndReadEnum.Read);
            //    //    UserInfo user = context.UserInfo.OrderByDescending(a => a.UserId).FirstOrDefault(); 
            //    //}

            //    {
            //        EFCoreAllContext writecontext = _DbContextFactory.CreateContext(WriteAndReadEnum.Write);
            //        writecontext.UserInfo.Add(new UserInfo()
            //        {
            //            UserName = "我不会走~",
            //            UserAge = 26,
            //            Description = "高级的Vip学员"
            //        });
            //        writecontext.SaveChanges();


            //        EFCoreAllContext queyrcontext = _DbContextFactory.CreateContext(WriteAndReadEnum.Read);
            //        UserInfo user = queyrcontext.UserInfo.OrderByDescending(a => a.UserId).FirstOrDefault();


            //    }


            //}
            #endregion



            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

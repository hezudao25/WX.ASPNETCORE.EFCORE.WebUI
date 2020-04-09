using Asp.NetCore.Business.Interface;
using Asp.NetCore.Business.Service;
using Asp.NetCore.EFCore.Models;
using Asp.NetCore.EFCore.Models.Extend;
using Asp.NetCore.EFCore.Models.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Asp.NetCore.EFCore.ConsoleShow
{
    public class LayeredTest
    {

        //UI  上端是直接使用Context吗？
        public static void Show()
        {
            #region 初始化主库的数据
            {
                var configura = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();

                IDbContextFactory contextFactory = new DbContextFactory(configura);
                //using (EFCoreAllContext context = contextFactory.CreateContext(WriteAndReadEnum.Read))
                //{
                //    SysUserInfo user = context.SysUserInfo.Find(1);
                //    SysUserInfo user1 = context.Set<SysUserInfo>().FirstOrDefault();
                //}

                //项目不会直接调用Context  项目会分层 
                {
                    IUserService userService = new UserService(contextFactory);
                    SysUserInfo userInfo = userService.Find<SysUserInfo>(6);
                }
                //如果需要查询Company；再来一个CompanyService

                {
                    ICompanyService companyService = new CompanyService(contextFactory);
                    Company company = companyService.Find<Company>(1);
                }
                //发现代码重复很多  UserSercie 和CompanyService 都有增删改查方法； 就来一个父类/继承一下； 
                //难道每一个对表的操作都需要来一个Service吗？
                //有些操作如果需要多个表同时来呢？ 删除公司的时候，也需要把公司下的用户删除掉：
                {
                    ICompanyUserService companyuserService = new CompanyUserService(contextFactory);
                    companyuserService.DeleteCompanyAndUser(123); 
                }

            }
            #endregion
        }
    }
}

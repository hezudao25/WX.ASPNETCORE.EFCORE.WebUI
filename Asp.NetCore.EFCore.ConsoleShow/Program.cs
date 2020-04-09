using Asp.NetCore.EFCore.Models.Migrations;
using Asp.NetCore.EFCore.Models.Migrations.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Asp.NetCore.EFCore.ConsoleShow
{
    class Program
    {
        static void Main(string[] args)
        {
             
            {
                LayeredTest.Show();
            
            }
            #region MyRegion
            {

                //QueryTest.Show();
                //Console.Read();
            }

            #region EF初始化数据， 数据库关系联系 

            //EFCoreMigrationContext context = new EFCoreMigrationContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //{
            //    #region 一对一 
            //    context.Company.Add(new Company()
            //    {
            //        Name = "EFCORE",
            //        Description = "EFcore"
            //    });
            //    context.SysUserInfo.Add(new SysUserInfo()
            //    {
            //        CompanyId = 1,
            //        Name = "王一",
            //        Password = "123456",
            //        Status = 1,
            //        Phone = "15729131",
            //        Mobile = "15729131",
            //        Address = "ASPNETCORE",
            //        Email = "15729131@163.com",
            //        QQ = 823626085,
            //        WeChat = "15729131",
            //        Sex = 1,
            //        LastLoginTime = DateTime.Now,
            //        CreateTime = DateTime.Now,
            //        CreateId = 1,
            //        LastModifyTime = DateTime.Now,
            //        SysUserInfoDetail = new SysUserInfoDetail()
            //        {
            //            Description = "一对一关系测试",
            //        }
            //    });
            //    context.SaveChanges();
            //    SysUserInfo user = context.SysUserInfo.FirstOrDefault();
            //    Company company = context.Company.FirstOrDefault();
            //    #endregion
            //}

            //{
            //    #region 一对多
            //    context.Company.Add(new Company()
            //    {
            //        Name = "EFCORE",
            //        Description = "腾讯课堂持续101火箭机构",
            //        SysUsers = new List<SysUserInfo>()
            //        {
            //            new SysUserInfo()
            //            {
            //                Name = "张三",
            //                Password = "123456",
            //                Status = 1,
            //                Phone = "15729131",
            //                Mobile = "15729131",
            //                Address = "ASPNETCORE",
            //                Email = "15729131@163.com",
            //                QQ = 823626085,
            //                WeChat = "15729131",
            //                Sex = 1,
            //                LastLoginTime = DateTime.Now,
            //                CreateTime = DateTime.Now,
            //                CreateId = 1,
            //                LastModifyTime = DateTime.Now
            //            }
            //        }
            //    });
            //    context.SaveChanges();
            //    Company company = context.Company.OrderByDescending(c => c.Id).FirstOrDefault();
            //    #endregion
            //}

            //{
            //    //多对多的关系 
            //    context.SysUserRoleMapping.Add(new SysUserRoleMapping()
            //    {
            //        SysRole = new SysRole()
            //        {
            //            Name = "高级班讲师",
            //            Status = 1
            //        },
            //        SysUserInfo = new SysUserInfo()
            //        {
            //            Company = new Company()
            //            {
            //                Name = "EFCORE001"
            //            },
            //            Name = "Richard老师",
            //            Password = "123456",
            //            Status = 1,
            //            Phone = "15729131",
            //            Mobile = "15729131",
            //            Address = "ASPNETCORE",
            //            Email = "15729131@163.com",
            //            QQ = 823626085,
            //            WeChat = "15729131",
            //            Sex = 1,
            //            LastLoginTime = DateTime.Now,
            //            CreateTime = DateTime.Now,
            //            CreateId = 1,
            //            LastModifyTime = DateTime.Now

            //        }
            //    });

            //    context.SysUserInfo.Add(new SysUserInfo()
            //    {
            //        Company = new Company()
            //        {
            //            Name = "EFCORE002"
            //        },
            //        Name = "张三",
            //        Password = "123456",
            //        Status = 1,
            //        Phone = "15729131",
            //        Mobile = "15729131",
            //        Address = "ASPNETCORE",
            //        Email = "15729131@163.com",
            //        QQ = 823626085,
            //        WeChat = "15729131",
            //        Sex = 1,
            //        LastLoginTime = DateTime.Now,
            //        CreateTime = DateTime.Now,
            //        CreateId = 1,
            //        LastModifyTime = DateTime.Now,
            //        SysUserRoleMapping = new List<SysUserRoleMapping>()
            //            {
            //                  new SysUserRoleMapping()
            //                  {
            //                     SysRole=new SysRole(){
            //                         Name="助教"
            //                     }
            //                  },
            //                  new SysUserRoleMapping()
            //                  {
            //                     SysRole=new SysRole(){
            //                         Name="讲师"
            //                     }
            //                  },
            //                  new SysUserRoleMapping()
            //                  {
            //                     SysRole=new SysRole(){
            //                         Name="校长"
            //                     }
            //                  }
            //            }
            //    });

            //    context.SysRole.Add(new SysRole()
            //    {
            //        Name = "高级班学员",
            //        SysUserRoleMapping = new List<SysUserRoleMapping>()
            //            {
            //                 new SysUserRoleMapping()
            //                 {
            //                    SysUserInfo=new SysUserInfo(){
            //                        CompanyId=1,
            //                        Name = "fresh",
            //                        Password = "123456",
            //                        Status = 1,
            //                        Phone = "13972713698",
            //                        Mobile = "13972713698",
            //                        Address = "北京市",
            //                        Email = "13972713698@163.com",
            //                        QQ = 823626085,
            //                        WeChat = "13972713698",
            //                        Sex = 1,
            //                        LastLoginTime = DateTime.Now,
            //                        CreateTime = DateTime.Now,
            //                        CreateId = 1,
            //                        LastModifyTime = DateTime.Now

            //                    }
            //                 },
            //                new SysUserRoleMapping()
            //                 {
            //                    SysUserInfo=new SysUserInfo(){
            //                        CompanyId=1,
            //                        Name = "我不会走",
            //                        Password = "123456",
            //                        Status = 1,
            //                        Phone = "18612345698",
            //                        Mobile = "18612345698",
            //                        Address = "北京市",
            //                        Email = "18612345698@163.com",
            //                        QQ = 823626085,
            //                        WeChat = "18612345698",
            //                        Sex = 1,
            //                        LastLoginTime = DateTime.Now,
            //                        CreateTime = DateTime.Now,
            //                        CreateId = 1,
            //                        LastModifyTime = DateTime.Now

            //                    }
            //                 }
            //            }
            //    });
            //    context.SaveChanges();
            //}
            #endregion

            #region Context 
            ContextLifeTimeTest.Show();
            #endregion

            #endregion


        }
    }
}

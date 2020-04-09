using Asp.NetCore.EFCore.Models.Migrations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Asp.NetCore.EFCore.Models.Migrations.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System.Transactions;

namespace Asp.NetCore.EFCore.ConsoleShow
{
    public class ContextLifeTimeTest
    {
        public static void Show()
        {

            ///一次SaveChanges  多个数据操作都生效了
            ///事务
            //using (EFCoreMigrationContext context = new EFCoreMigrationContext())
            //{
            //    SysUserInfo sysUserInfo1 = context.SysUserInfo.FirstOrDefault(a => a.Id == 6);
            //    SysUserInfo sysUserInfo2 = context.Set<SysUserInfo>().Find(5);
            //    sysUserInfo1.Name += "-AA";
            //    sysUserInfo2.Name += "-BB";
            //    context.SaveChanges();
            //}

            ///DbContext SaveChanges 事务提交  事务提交
            ///事务特点：要不都成功  要么都知道
            //using (EFCoreMigrationContext context = new EFCoreMigrationContext())
            //{
            //    SysLog log = context.SysLog.FirstOrDefault(l => l.Id == 1);
            //    context.SysLog.Remove(log); 
            //    SysUserInfo sysUserInfo1 = context.SysUserInfo.FirstOrDefault(a => a.Id == 6);
            //    SysUserInfo sysUserInfo2 = context.Set<SysUserInfo>().Find(5);
            //    sysUserInfo1.Name += "-AA";
            //    sysUserInfo2.Name += "-BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB";

            //    context.SysLog.Add(new SysLog()
            //    {
            //        UserName = "这里就是测试一下罢了",
            //         Introduction="描述一下"
            //    });

            //    context.SaveChanges();
            //}

            //1.单例 DbContext 整个进程中就只有一个实例    不行；
            //2.多线程中  是不是可以使用同一个DbContext 实例？  一般情况下不要使用同一个实例；除非（特定业务下）

            //一个请求一个DbContext实例！

            #region  扩展SaveChanges
            {
                //using (EFCoreMigrationContext context = new EFCoreMigrationContext())
                //{
                //    context.SysLog.Add(new SysLog()
                //    {
                //        UserName = "这里就是测试一下罢了",
                //        Introduction = "描述一下",
                //        CreateTime = DateTime.Now
                //    });

                //    context.SaveChanges();

                //    SysLog log = context.SysLog.OrderByDescending(a => a.Id).FirstOrDefault();
                //    log.UserName = "这里就是想要修改一下";
                //    //log.LastModifyTime = DateTime.Now;
                //    //log.CreateTime
                //    //每修改一次都需要重新设置值 
                //    ///能不能从框架层面扩展后来自动维护呢？
                //    context.SaveChanges();
                //}
            }

            #endregion

            {
                /////如果我需要把两个SaveChange 事务一下的？
                using (EFCoreMigrationContext context = new EFCoreMigrationContext())
                { 
                    IDbContextTransaction tans = null;
                    try
                    {
                        tans = context.Database.BeginTransaction(); //框架对事务的支持
                        context.SysLog.Add(new SysLog()
                        {
                            UserName = "第一次SaveChanges",
                            Introduction = "第一次SaveChanges",
                            CreateTime = DateTime.Now
                        });
                        context.SaveChanges();

                        context.SysLog.Add(new SysLog()
                        {
                            UserName = "第二次SaveChanges",
                            Introduction = "第二次SaveChanges",
                            CreateTime = DateTime.Now
                        });
                        context.SaveChanges();
                        tans.Commit();  //代码只有执行到这里事务才能生效
                    }
                    catch (Exception ex)
                    {
                        if (tans != null)
                        {
                            tans.Rollback();//事务回退
                        }
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        tans.Dispose();
                    }
                }
            }
            //{

            //    ///如果我需要把两个SaveChange 事务一下的？
            //    using (EFCoreMigrationContext context1 = new EFCoreMigrationContext())  //招商银行的数据库
            //    using (EFCoreMigrationContext context2 = new EFCoreMigrationContext())////腾讯平台的数据库
            //    {
            //        //需要引入System.Transactions.Local.dll
            //        using (TransactionScope transactionScope = new TransactionScope())
            //        { 
            //            try
            //            { 
            //                context1.SysLog.Add(new SysLog()
            //                {
            //                    UserName = "context1新增一条测试数据",
            //                    Introduction = "context1新增一条测试数据",
            //                    CreateTime = DateTime.Now
            //                });
            //                context1.SaveChanges();

            //                context2.SysLog.Add(new SysLog()
            //                {
            //                    UserName = "context2新增一条测试数据",
            //                    Introduction = "context2新增一条测试数据",
            //                    CreateTime = DateTime.Now
            //                });
            //                context2.SaveChanges();
            //                transactionScope.Complete();//提交事务

            //            }
            //            catch (Exception ex)
            //            {
            //                Console.WriteLine(ex.Message);
            //            }
            //        }
            //    }
            //}

        }
    }
}

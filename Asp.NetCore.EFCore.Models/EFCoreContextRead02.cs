using Asp.NetCore.EFCore.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.NetCore.EFCore.Models
{
    /// <summary>
    /// 数据库操作上下文
    /// 
    /// 
    /// Nuget引入：Microsoft.EntityFrameworkCore
    ///     
    /// </summary>
    public class EFCoreContextRead02 : DbContext
    {
        private string strConn = "Server=.;Database=ReadAspNetCoreDataBase001;Trusted_Connection=True;";

        //public EFCoreContext(string conn)
        //{
        //    strConn = conn;
        //}

        public DbSet<UserInfo> UserInfo { get; set; }
         
        /// <summary>
        /// 配置连接数据库  
        /// 数据库连接 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Nuget引入：Microsoft.EntityFrameworkCore.SqlServer
            ///SqlServer
            optionsBuilder.UseSqlServer(strConn);//数据库连接 
        }


        /// <summary>
        /// 配置数据库结构，关系映射
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ///初始化数据
            modelBuilder.Entity<UserInfo>().HasData(new List<UserInfo>() {
              new UserInfo(){
                UserId=1,
                UserName="王一",
                 Description="王一",
                  UserAge=36
              },
              new UserInfo(){
                UserId=2,
                UserName="赵二",
                 Description="赵二",
                  UserAge=23
              },
              new UserInfo(){
                UserId=3,
                UserName="张三",
                 Description="张三",
                  UserAge=25
              },
              new UserInfo(){
                UserId=4,
                UserName="李四",
                 Description="李四",
                  UserAge=34
              }

            });
        }
    }
}

using Asp.NetCore.EFCore.Models.Migrations.Extend;
using Asp.NetCore.EFCore.Models.Migrations.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Asp.NetCore.EFCore.Models.Migrations
{
    /// <summary>
    /// 迁移的Context
    /// </summary>
    public class EFCoreMigrationContext : DbContext
    {


        public static readonly ILoggerFactory MyLoggerFactory
    = LoggerFactory.Create(builder => { builder.AddConsole(); });


        private string strConn = "Server=.;Database=WriteAspNetCoreDataBaseMigration;Trusted_Connection=True;";

        public DbSet<Company> Company { get; set; }

        public DbSet<SysUserInfo> SysUserInfo { get; set; }

        public DbSet<SysUserRoleMapping> SysUserRoleMapping { get; set; }

        public DbSet<SysRole> SysRole { get; set; }

        public DbSet<SysMenu> SysMenu { get; set; }
         
        public DbSet<SysLog> SysLog { get; set; }

        /// <summary>
        /// 配置连接数据库  
        /// 数据库连接 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(strConn).UseLoggerFactory(MyLoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().ToTable("ConmpanyInfo", "Zhaoxi");
            modelBuilder.HasDefaultSchema("Zhaoxi");
            modelBuilder.Entity<Company>().Property(p => p.Name).HasColumnName("CompanyName");


            #region 一对一的关系 
            modelBuilder.Entity<SysUserInfo>().HasOne(u => u.SysUserInfoDetail).WithOne().HasForeignKey<SysUserInfoDetail>(a => a.SysUserInfoDetailId);
            #endregion

            #region 一对多的关系
            modelBuilder.Entity<SysUserInfo>().HasOne(u => u.Company).WithMany(u => u.SysUsers).HasForeignKey(a => a.CompanyId);
            #endregion


            #region 多对多的关系

            modelBuilder.Entity<SysUserRoleMapping>().HasOne(p => p.SysUserInfo)
                .WithMany(u => u.SysUserRoleMapping).HasForeignKey(u => u.SysUserId);

            modelBuilder.Entity<SysUserRoleMapping>().HasOne(p => p.SysRole)
                .WithMany(r => r.SysUserRoleMapping).HasForeignKey(s => s.SysRoleId);

            modelBuilder.Entity<SysUserRoleMapping>().HasKey(p => new { p.SysUserId, p.SysRoleId }); //设置联合主键

            #endregion

            #region 索引
            modelBuilder.Entity<SysUserInfo>().HasIndex(a => new { a.Name, a.Phone });

            modelBuilder.Entity<SysRole>().HasIndex(u => u.Name).IsUnique();
            //.HasName("UserInfoInde_IsUnique");//定义索引名称

            modelBuilder.Entity<SysUserInfo>().HasIndex(a => new { a.Name, a.Phone });
            #endregion

            #region 初始化数据
            modelBuilder.Entity<SysLog>().HasData(new List<SysLog>() {
               new SysLog()
               {
                   Id=1,
                 UserName="测试1",
                 CreateTime=DateTime.Now,
                 CreatorId=1,
                 Introduction="Introduction1",
                 LastModifyTime=DateTime.Now
               },
               new SysLog()
               {
                    Id=2,
                 UserName="测试2",
                 CreateTime=DateTime.Now,
                 CreatorId=1,
                 Introduction="Introduction2",
                 LastModifyTime=DateTime.Now
               },
               new SysLog()
               {
                    Id=3,
                 UserName="测试3",
                 CreateTime=DateTime.Now,
                 CreatorId=1,
                 Introduction="Introduction3",
                 LastModifyTime=DateTime.Now
               }
            });

            #endregion


           


        }


        public override int SaveChanges()
        {
            {
                //在这里就可以扩展点东西
                Console.WriteLine("****************************************************************");
                ChangeTracker.Entries().Where(e => (e.State == EntityState.Modified) && (e.Entity is IBaseEntity)).ToList().ForEach(e => {
                    ((IBaseEntity)e.Entity).LastModifyTime = DateTime.Now;
                }); 
                ChangeTracker.Entries().Where(e => (e.State == EntityState.Added) && (e.Entity is IBaseEntity)).ToList().ForEach(e => {
                    ((IBaseEntity)e.Entity).CreateTime = DateTime.Now;
                });
            }
            return base.SaveChanges();  
        }
    }
}

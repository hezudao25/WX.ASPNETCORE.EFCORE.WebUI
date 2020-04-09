using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.NetCore.EFCore.Models.Extend
{
    public class DbContextFactory : IDbContextFactory
    {
        private IConfiguration _Configuration;

        private string[] ReadConn = null;

        public DbContextFactory(IConfiguration configuration)
        {
            _Configuration = configuration;
            ReadConn = _Configuration.GetConnectionString
                        ("ReadAspNetCoreDataBase").Split(",");
        }
        public EFCoreAllContext CreateContext(WriteAndReadEnum writeAndRead)
        {
            string sqlConn = string.Empty;
            switch (writeAndRead)
            {
                case WriteAndReadEnum.Write:
                    sqlConn = _Configuration.GetConnectionString("WriteAspNetCoreDataBase");
                    break;
                case WriteAndReadEnum.Read:
                    sqlConn = GetReadConn();
                    break;
                default:
                    break;
            }
            return new EFCoreAllContext(sqlConn);
        }

        /// <summary>
        /// 可以自定义  从库的数据库连接策略
        /// </summary>
        /// <returns></returns>
        private string GetReadConn()
        {
            ///随机策略
            //{ string conn = null;
            //    int index = new Random().Next(0, ReadConn.Length - 1);
            //    conn = ReadConn[index];
            //    return conn;
            //}
            //权重策略
            //轮询策略
            {
                string conn = null;              
                conn = ReadConn[iIndex++ % ReadConn.Length];
                return conn;
            }
        }

        private int iIndex = 0;
    }
}

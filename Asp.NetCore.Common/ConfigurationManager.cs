using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Asp.NetCore.Common
{
    /// <summary>
    ///配置文件的读取
    ///Nuget引入程序包：
    ///     Microsoft.Extensions.Configuration
    ///     Microsoft.Extensions.Configuration.FileExtensions
    ///     Microsoft.Extensions.Configuration.Json
    ///     
    /// 如下代码获取配置文件
    /// </summary>
    public static class ConfigurationManager
    {
        public static IConfigurationRoot GetConfig()
        {
            var configura = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json")
                       .Build();
            return configura;
        }
    }
}

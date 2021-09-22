using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Infrastructure
{
    public class ReadConfig
    {
        /// <summary>
        /// 读取appsettings.json配置文件
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        public static string GetConfigSection(string section)
        {

            IConfiguration Configuration;
            Configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true })
            .Build();
            return Configuration.GetSection(section).Value;
        }
    }
}

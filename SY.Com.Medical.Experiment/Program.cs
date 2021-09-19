using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace SY.Com.Medical.Experiment
{
    class Program
    {
        static void Main(string[] args)
        {
            // IConfiguration  Configuration = new ConfigurationBuilder()
            ////.SetBasePath(Directory.GetCurrentDirectory())
            ////AppDomain.CurrentDomain.BaseDirectory是程序集基目录，所以appsettings.json,需要复制一份放在程序集目录下，
            //.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            //.Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true })
            //.Build();
            // var conStr = Configuration.GetSection("DBConnectionStrings").Value;
            // var conStr2 = Configuration.GetSection("DBIDs").Value;
            Console.WriteLine($"Hello World");
        }
    }
}

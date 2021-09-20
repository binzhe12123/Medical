using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using SY.Com.Medical.BLL.Platform;
using SY.Com.Medical.Model;

namespace SY.Com.Medical.Experiment
{
    class Program
    {
        static void Main(string[] args)
        {

            PlatformCReq request = new PlatformCReq() { PlatformName = "test", VersionId=1};
            Platform service = new Platform();
            service.initEntity(request);
            service.Entity.CreateTime = DateTime.Now;
            var result= service.insert();            
            Console.WriteLine($"Hello World{result.Data.PlatformId}");
        }
    }
}

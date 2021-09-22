using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using SY.Com.Medical.BLL.Platform;
using SY.Com.Medical.Entity;
using SY.Com.Medical.Model;

namespace SY.Com.Medical.Experiment
{
    class Program
    {
        static void Main(string[] args)
        {
            Platform bll = new Platform();
            //{
            //    PlatformCReq request = new PlatformCReq() { PlatformName = "test", VersionId = 1 };
            //    Platform service = new Platform();
            //    service.initEntity(request);
            //    service.Entity.CreateTime = DateTime.Now;
            //    var result = service.insert();
            //}
            //
            //{
            //    Platform bll = new Platform();
            //    bll.initEntity(new PlatformQReq() { PlatformId = 0 });
            //    bll.Entity.IsDelete = Enum.Delete.正常;
            //    var response = bll.Get();
            //    Console.WriteLine($"Hello World{response.Data.PlatformName}");
            //}


            //{
            //    bll.initEntity(new PlatformQReq() { PlatformId = 0, PlatformName = "hello" });
            //    bll.Entity.CreateTime = DateTime.Now;
            //    bll.Update();
            //    Console.WriteLine($"Hello World");
            //}


            //{
            //    bll.initEntity(new PlatformQReq() { PlatformId = 0, PlatformName = "hello" });
            //    bll.Entity.IsDelete = Enum.Delete.删除;
            //    bll.Delete();
            //    Console.WriteLine($"Hello World");
            //}

            //{
            //    bll.initEntity(new PlatformQReq() { PlatformId = 0});
            //    var temp = bll.Gets();
            //    foreach(var item in temp)
            //    {
            //        Console.WriteLine($"{item.PlatformName}"); 
            //    }
            //    Console.WriteLine($"Hello World");
            //}

            //{
            //    bll.initEntity(new PlatformQReq() { PlatformId = 0 });
            //    var temp = bll.GetsPage(bll.Entity, 3, 2);
            //    foreach (var item in temp.Item1)
            //    {
            //        Console.WriteLine($"{item.PlatformName}");
            //    }
            //    Console.WriteLine($"记录数:{temp.Item2}");
            //    Console.WriteLine($"Hello World");
            //}


        //{
        //    bll.initEntity(new PlatformQReq() { PlatformId = 0 });
        //    var temp = bll.GetsPage(bll.Entity, 1, 1);
        //    foreach (var item in temp.Item1)
        //    {
        //        item.Record = "我是魔王";
        //    }
        //    bll.UpdateBatch(temp.Item1);
        //    Console.WriteLine($"Hello World");
        //}

        //{
        //    IEnumerable<PlatformsEntity> collection =new List<PlatformsEntity>
        //    {
        //        new PlatformsEntity { PlatformName = "wudi1",CreateTime = DateTime.Now},
        //          new PlatformsEntity{ PlatformName = "wudi2", CreateTime = DateTime.Now },
        //          new PlatformsEntity{ PlatformName = "wudi3", CreateTime = DateTime.Now }
        //    };
        //    bll.InsertBatch(collection);
        //    Console.WriteLine($"Hello World");
        //}

        //{
        //    {
        //        Platform bll = new Platform();
        //        bll.initEntity(new PlatformQReq() { PlatformId = 0 });
        //        bll.Entity.IsDelete = Enum.Delete.正常;
        //        var response = bll.Get();
        //        Console.WriteLine($"Hello World{response.Data.PlatformName}");
        //    }
        //}


    }
    }
}

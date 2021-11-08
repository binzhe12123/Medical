using SY.Com.Medical.Enum;
using SY.Com.Medical.Model;
using System;
using System.Reflection;

namespace Play
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 枚举测试
            {
                var obj = Assembly.Load("SY.Com.Medical.Enum").CreateInstance("SY.Com.Medical.Enum.TenantType", false);
                foreach (var prop in obj.GetType().GetEnumNames())
                {
                    Console.WriteLine(prop);
                }
            }
            #endregion

            Console.WriteLine("Hello World!");
        }


    }

    public class wuha
    {
        public wuha()
        {

        }
    }
}

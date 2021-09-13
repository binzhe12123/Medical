using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Infrastructure
{
    public class ReflectionExtention
    {
        /// <summary>
        /// 克隆
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static U Clone<T, U>(T t) where U : class where T : class
        {
            Type intype = t.GetType();
            Type outtype = typeof(U);
            var result = Activator.CreateInstance(outtype);
            foreach( var props in intype.GetProperties())
            {
                var outpro = outtype.GetProperty(props.Name);
                if(outpro != null && outpro.CanWrite)
                {
                    //类型相同直接转,类型不同就跳过
                    if(outpro.PropertyType == props.PropertyType)
                    {
                        outpro.SetValue(result, props.GetValue(t));
                    }               
                }
            }
            return result as U;
        }

    }
}

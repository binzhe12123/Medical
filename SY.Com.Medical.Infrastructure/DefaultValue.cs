using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Infrastructure
{
    /// <summary>
    /// 默认值
    /// </summary>
    public class DefaultValue
    {
       /// <summary>
       /// 判断值是否是默认值
       /// </summary>
       /// <param name="t"></param>
       /// <param name="obj"></param>
       /// <returns></returns>
        public static bool IsDefaultValue(Type t,object obj)
        {
            if (t == typeof(Int32))
            {
                return (int)obj == 0;
            }
            else if (t == typeof(long))
            {
                return (long)obj == 0;
            }
            else if (t == typeof(decimal))
            {
                return (decimal)obj == 0;
            }
            else if (t == typeof(string))
            {
                return string.IsNullOrEmpty((string)obj);
            }
            else if (t == typeof(DateTime))
            {
                return (DateTime?)obj == null;
            }
            else if (t == typeof(float))
            {
                return (float)obj == 0;
            }
            else if (t == typeof(double))
            {
                return (double)obj == 0;
            }
            else if (t == typeof(bool))
            {
                return (bool)obj;
            }
            else if (t == typeof(uint))
            {
                return (uint)obj == 0;
            }
            else if (t == typeof(ulong))
            {
                return (ulong)obj == 0;
            }
            else if (t == typeof(ushort))
            {
                return (ushort)obj == 0;
            }
            else if (t == typeof(short))
            {
                return (short)obj == 0;
            }
            else if (t == typeof(Nullable<Int32>))
            {
                return (Nullable<Int32>)obj == null;
            }
            else if (t == typeof(Nullable<long>))
            {
                return (Nullable<long>)obj == null;

            }
            else if (t == typeof(Nullable<decimal>))
            {
                return (Nullable<decimal>)obj == null;

            }
            else if (t == typeof(Nullable<bool>))
            {
                return (Nullable<bool>)obj == null;
            }
            else if (t == typeof(Nullable<DateTime>))
            {
                return (Nullable<DateTime>)obj == null;
            }
            return false;
        }
    }
}

using SY.Com.Medical.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Attribute
{
    /// <summary>
    /// db给默认值
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class DB_DefaultAttribute : DBBaseAttribute
    {
        public object value;
        public DB_DefaultAttribute(Type t) 
        {
            if (t == typeof(Int32))
            {
                value = "0";
            }else if(t == typeof(DateTime))
            {
                value = DateTime.Now;
            }else if(t == typeof(Enable))
            {
                value = (int)Enable.无用;
            }else if(t == typeof(Delete))
            {
                value = (int)Delete.无用;
            }
            else if (t == typeof(IsBoss))
            {
                value = (int)IsBoss.无用;
            }else if(t == typeof(Sex))
            {
                value = (int)Sex.全部;
            }
        }

        public object getDefault() => value;
    }
}

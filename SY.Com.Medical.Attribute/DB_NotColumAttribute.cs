using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Attribute
{
    /// <summary>
    /// 数据库忽略的字段
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class DB_NotColumAttribute : DBBaseAttribute
    {
        public override object GetKey()
        {
            return null;
        }
    }
}

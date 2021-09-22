using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Attribute
{
    /// <summary>
    /// 数据库唯一键值(用于查询单条记录)
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property, Inherited = false, AllowMultiple = false)]

    public class DB_KeyAttribute : DBBaseAttribute
    {
        public DB_KeyAttribute(string key)
        {
            Name = key;
        }
    }
}

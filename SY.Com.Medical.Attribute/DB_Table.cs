using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Attribute
{
    /// <summary>
    /// 数据库表名
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct
        ,Inherited = false,AllowMultiple =false)]
    public class DB_TableAttribute : BaseAttribute
    {
        private string tablename;
        public DB_TableAttribute(string name) : base(name)
        {
            tablename = name;
        }
    }

    /// <summary>
    /// 数据库唯一键值(用于查询单条记录)
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Property , Inherited = false, AllowMultiple = false)]

    public class DB_KeyAttribute : BaseAttribute
    {
        private string keyname;
        public DB_KeyAttribute(string key) :base(key)
        {
            keyname = key;
        }
    }



}

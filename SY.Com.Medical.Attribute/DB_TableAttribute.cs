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
    public class DB_TableAttribute : DBBaseAttribute
    {
        public DB_TableAttribute(string tableName)
        {
            Name = tableName;
        }
    }





}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Attribute
{
    /// <summary>
    /// like条件
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class DB_LikeAttribute : DBBaseAttribute
    {
        public override SqlWhereMod GetWhere(object t,object v)
        {
            PropertyInfo prop = (PropertyInfo)t;
            return new SqlWhereMod { Column = prop.Name, Param = $"'%{ prop.GetValue(v) }%'", Operator = "Like" };            
        }
    }
}

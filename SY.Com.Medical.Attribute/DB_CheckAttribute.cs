using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Attribute
{
    /// <summary>
    /// 复选属性,对一些枚举的字段,可以直接设置等价的where条件
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class DB_CheckAttribute : DBBaseAttribute
    {
        public string realValue { get; set; }
        public string dbValue { get; set; }
        public DB_CheckAttribute(string rv,string dv)
        {
            realValue = rv;
            dbValue = dv;
        }

        public override SqlWhereMod GetWhere(object t, object v)
        {
            PropertyInfo prop = (PropertyInfo)t;
            var result = new SqlWhereMod();
            if (prop.GetValue(v).ToString() == realValue)
            {
                var temp = dbValue.Split(',');
                var value = "";
                for (int i = 0; i < temp.Length; i++)
                {
                    value += "'" + temp[i] + "'" + ",";
                }
                value = value.Substring(0, value.Length - 1);
                result.SetSql($"{ prop.Name } in ({value})");
            }
            else {
                result = new SqlWhereMod { Column = prop.Name, Param = $" @{prop.Name} ", Operator = " = " };
            }
            
            return result;
            //return new SqlWhereMod { Column = prop.Name, Param = $"'%{ prop.GetValue(v) }%'", Operator = "Like" };
        }
    }
}

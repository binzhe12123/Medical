using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Attribute
{
    /// <summary>
    /// 
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class DB_LimitAttribute : DBBaseAttribute
    {        
        public DB_LimitAttribute(string start,string end)
        {
            dic = new Dictionary<string, object>();
            dic.Add("start", start);
            dic.Add("end", end);
        }

        public override object GetKey()
        {
            return null;
        }

        public override SqlWhereMod GetWhere(object t,object v)
        {
            SqlWhereMod result = new SqlWhereMod();            
            foreach(var prop in t.GetType().GetProperties())
            {
                if(prop.Name.ToLower() == dic["start"].ToString())
                {
                    result.Column = prop.Name;
                    result.Param = $"'{prop.GetValue(v)}'";
                    result.Operator = ">=";
                }else if (prop.Name.ToLower() == dic["end"].ToString())
                {
                    result.Column = prop.Name;
                    result.Param = $"'{prop.GetValue(v)}'";
                    result.Operator = "<=";                    
                }
            }
            return result;
        }
    }
}

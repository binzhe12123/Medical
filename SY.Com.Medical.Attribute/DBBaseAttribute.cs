using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Attribute
{
    /// <summary>
    /// 数据库Attribute基类
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct
    | System.AttributeTargets.Property | AttributeTargets.Method
    | AttributeTargets.Field | AttributeTargets.Delegate
, Inherited = true, AllowMultiple = true)]
    public class DBBaseAttribute : System.Attribute
    {
        protected string Name { get; set; }
        protected Dictionary<string, object> dic;
        protected virtual IEnumerable<string> GetKeys() => dic.Keys.AsEnumerable();
        public virtual object GetKey() => Name;
        protected virtual object GetValue(string key) => dic[key];
        public virtual string GetWhere(object t) => "";
    }
}

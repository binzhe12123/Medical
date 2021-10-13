using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Attribute
{
    /// <summary>
    /// 用来标识是否必须需要TenantId,如果需要但是未提供或者提供的是0就要报错
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Class  | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class Api_TenantAttribute : System.Attribute
    {
    }
}

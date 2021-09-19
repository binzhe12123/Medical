using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Attribute
{
    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct 
        | System.AttributeTargets.Property | AttributeTargets.Method 
        | AttributeTargets.Field | AttributeTargets.Delegate
    , Inherited = true, AllowMultiple = true)]
    public class BaseAttribute : System.Attribute
    {
        public string strResult { get; set; }
        public BaseAttribute()
        { 
            
        }
        public BaseAttribute(string input)
        {
            strResult = input;
        }


    }
}

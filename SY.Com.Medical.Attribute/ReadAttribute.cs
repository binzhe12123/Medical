using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Attribute
{
    public class ReadAttribute<T> where T : BaseAttribute
    {
        /// <summary>
        /// 获取属性的唯一字符串
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string getString<S>(S t)
        {            
            // Using reflection.  
            System.Attribute[] attrs = System.Attribute.GetCustomAttributes(t.GetType());  // Reflection.  
            // Displaying output.  
            foreach (System.Attribute attr in attrs)
            {
                if (attr is T)
                {
                    return ((T)attr).strResult ?? throw new NullReferenceException("Attribute查找失败");
                }
            }
            return "";
        }
    }
}

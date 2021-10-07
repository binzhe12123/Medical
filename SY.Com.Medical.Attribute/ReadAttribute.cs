using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Attribute
{
    /// <summary>
    /// 处理自定义DBAttribu的一些场景
    /// 比如读取Table属性名称
    /// 读取key属性名称
    /// 读取Limit属性start和end
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ReadAttribute<T> where T : DBBaseAttribute
    {
        /// <summary>
        /// 读取自定义DBAttribu的名称,适用于Table/Key
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static object getKey<S>(S s) where S:Type
        {            
            // Using reflection.  
            System.Attribute[] attrs = System.Attribute.GetCustomAttributes(s);  // Reflection.  
            // Displaying output.  
            foreach (System.Attribute attr in attrs)
            {                
                if (attr is T)
                {
                    return ((T)attr).GetKey();                    
                }
            }
            return "";
        }

        public static string getWhere<S>(S s,object v,T t)
        {
            //System.Attribute[] attrs = System.Attribute.GetCustomAttributes(s.GetType());
            return t.GetWhere(s,v);
        }



    }
}

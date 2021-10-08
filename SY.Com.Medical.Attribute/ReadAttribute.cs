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


        public static SqlWhereMod getWhere<S>(S s,object v,T t)
        {
            //System.Attribute[] attrs = System.Attribute.GetCustomAttributes(s.GetType());
            return t.GetWhere(s,v);
        }

        /// <summary>
        /// 读取导航属性
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Dictionary<string,List<string>> getNavigate<S>(S s) where S :Type
        {
            Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();
            System.Attribute[] attrs = System.Attribute.GetCustomAttributes(s);
            // Displaying output.  
            foreach (System.Attribute attr in attrs)
            {
                if (attr is DB_Navigate)
                {
                    string tablename = ((DB_Navigate)attr)._navigateTable;
                    List<string> tableOnSplit = ((DB_Navigate)attr)._linkProperty;
                    if(!result.ContainsKey(tablename))
                    {
                        result.Add(tablename, tableOnSplit);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 获取property的具有某个attribute的property
        /// 没有找到返回null
        /// </summary>
        /// <returns></returns>
        public static Type getPropertyType<S>(S s) where S : Type
        {
            var properties = s.GetProperties();
            foreach(var prop in properties)
            {
                if(prop.IsDefined(typeof(T),false))
                {
                    return prop.GetType();
                }
            }
            return null;
        }

    }
}

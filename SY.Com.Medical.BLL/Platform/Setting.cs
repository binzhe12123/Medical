using SY.Com.Medical.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.BLL.Platform
{
    public class Setting
    {
        /// <summary>
        /// 获取枚举的键值对
        /// </summary>
        /// <param name="EnumName"></param>
        /// <returns></returns>
        public List<KeyValueModel> getEnum(string EnumName)
        {
            List<KeyValueModel> result = new List<KeyValueModel>();
            var obj = Assembly.Load("SY.Com.Medical.Enum").CreateInstance($"SY.Com.Medical.Enum.{EnumName}", false);
            if(obj == null)
            {
                throw new MyException("未找到所需要的字典值,请检查输入是否正确");
            }
            foreach (var prop in obj.GetType().GetEnumValues())
            {                
                KeyValueModel mod = new KeyValueModel() { key = prop.ToString(), value = ((int)prop).ToString() };
                result.Add(mod);
            }
            return result;
        }
    }
}

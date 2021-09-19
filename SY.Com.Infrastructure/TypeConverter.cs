// ====================================================================== 
// 
// Copyright (C) 2012-2013 CCHMIS. All rights reserved. 
// 
// CLR Version: 4.0.30319.1 
// NameSpace: CchMis.Common 
// FileName: TypeConverter 
// 
// Author: TD.Shaw 
// CreateTime: 2012-04-28 17:37:52
// UpdateRecord:
//
// ====================================================================== 

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SY.Com.Infrastructure
{
    /// <summary>
    /// 类型转换类
    /// </summary>
    public class TypeConverter
    {
        /// <summary>
        /// string型转换为bool型
        /// </summary>
        /// <param name="value">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的bool类型结果</returns>
        public static bool StringToBool(string value, bool defValue)
        {
            if (string.IsNullOrEmpty(value))
            {
                return defValue;
            }

            if (string.Compare(value, "true", true) == 0)
            {
                return true;
            }
            else if (string.Compare(value, "false", true) == 0)
            {
                return false;
            }

            return defValue;
        }

        /// <summary>
        /// 将对象转换为Int32类型
        /// </summary>
        /// <param name="value">要转换的字符串</param>
        /// <returns>转换后的int类型结果</returns>
        public static int ObjectToInt(object value)
        {
            return ObjectToInt(value, 0);
        }

        /// <summary>
        /// 将对象转换为String类型
        /// </summary>
        /// <param name="value">要转换的字符串</param>
        /// <returns>转换后的String类型结果</returns>
        public static string ObjectToString(object value)
        {
            if (value == null)
            {
                return string.Empty;
            }

            return value.ToString();
        }

        /// <summary>
        /// 将对象转换为Decimal类型
        /// </summary>
        /// <param name="value">要转换的字符串</param>
        /// <returns>转换后的Decimal类型结果</returns>
        public static decimal ObjectToDecimal(object value)
        {
            if (value == null)
            {
                return 0;
            }
            decimal d = 0m;
            decimal.TryParse(value.ToString(), out d);
            return d;
        }

        /// <summary>
        /// 将对象转换为Int32类型
        /// </summary>
        /// <param name="value">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static int ObjectToInt(object value, int defValue)
        {
            if (value != null)
            {
                return StringToInt(value.ToString(), defValue);
            }

            return defValue;
        }

        /// <summary>
        /// 将对象转换为Int32类型,转换失败返回0
        /// </summary>
        /// <param name="value">要转换的字符串</param>
        /// <returns>转换后的int类型结果</returns>
        public static int StringToInt(string value)
        {
            return StringToInt(value, 0);
        }

        /// <summary>
        /// 将对象转换为Int32类型
        /// </summary>
        /// <param name="value">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static int StringToInt(string value, int defValue)
        {
            if (string.IsNullOrEmpty(value) || value.Trim().Length >= 11 ||
                !Regex.IsMatch(value.Trim(), @"^([-]|[0-9])[0-9]*(\.\w*)?$"))
            {
                return defValue;
            }

            int rv;
            if (int.TryParse(value, out rv))
            {
                return rv;
            }

            return Convert.ToInt32(StringToFloat(value, defValue));
        }

        /// <summary>
        /// string型转换为float型
        /// </summary>
        /// <param name="value">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static float StringToFloat(object value, float defValue)
        {
            if (value == null)
            {
                return defValue;
            }

            return StringToFloat(value.ToString(), defValue);
        }

        /// <summary>
        /// string型转换为float型
        /// </summary>
        /// <param name="value">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static float StringToFloat(string value, float defValue)
        {
            if (string.IsNullOrEmpty(value) || (value.Length > 10))
            {
                return defValue;
            }

            float intValue = defValue;
            bool isFloat = Regex.IsMatch(value, @"^([-]|[0-9])[0-9]*(\.\w*)?$");

            if (isFloat)
            {
                float.TryParse(value, out intValue);
            }

            return intValue;
        }

        /// <summary>
        /// string型转换为float型
        /// </summary>
        /// <param name="value">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static float ObjectToFloat(object value, float defValue)
        {
            if (value == null)
            {
                return defValue;
            }

            return StringToFloat(value.ToString(), defValue);
        }

        /// <summary>
        /// 将对象转换为Decimal类型
        /// </summary>
        /// <param name="value">要转换的字符串</param>
        /// <returns>转换后的int类型结果</returns>
        public static decimal StringToDecimal(string value)
        {
            if (string.IsNullOrEmpty(value) ||
                !Regex.IsMatch(value.Trim(), @"^([-]|[0-9])[0-9]*(\.\w*)?$"))
            {
                return 0;
            }

            decimal rv;
            if (decimal.TryParse(value, out rv))
            {
                return rv;
            }

            return Convert.ToDecimal(value);
        }

        /// <summary>
        /// 将对象转换为Int64类型
        /// </summary>
        /// <param name="value">要转换的字符串</param>
        /// <returns>转换后的int64类型结果</returns>
        public static long StringToLong(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Trim().Length == 0 ||
                !Regex.IsMatch(value.Trim(), @"^([-]|[0-9])[0-9]*(\.\w*)?$"))
            {
                return 0;
            }

            long rv;
            if (long.TryParse(value, out rv))
            {
                return rv;
            }

            return Convert.ToInt64(value);
        }

        /// <summary>
        /// 将字符串转换成Byte类型
        /// </summary>
        /// <param name="value">要转换的字符串</param>
        /// <returns>返回转换后的 <see cref="Byte"/> 类型</returns>
        public static byte StringToByte(string value)
        {
            byte b = 0;
            if (value.Length == 0 || value == null)
            {
                return b;
            }

            if (byte.TryParse(value, out b))
            {
                return b;
            }

            return Convert.ToByte(value);
        }

        /// <summary>
        /// 将对象转换成 <see cref="Byte"/> 类型
        /// </summary>
        /// <param name="obj">需要转换的对象</param>
        /// <returns>返回转换后的 <see cref="Byte"/> 类型</returns>
        public static byte ObjToByte(object obj)
        {
            byte b = 0;
            if (obj == null || obj == DBNull.Value)
            {
                return b;
            }

            if (obj.ToString().Length == 0)
            {
                return b;
            }

            if (byte.TryParse(obj.ToString(), out b))
            {
                return b;
            }

            return Convert.ToByte(obj);
        }

        /// <summary>
        /// string型转换城DateTime型
        /// </summary>
        /// <param name="value">要转换的字符串</param>
        /// <returns>转换后的时间</returns>
        public static DateTime StringToDateTime(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return DateTime.Now;
            }

            DateTime dt;
            if (DateTime.TryParse(value, out dt))
            {
                return dt;
            }

            return Convert.ToDateTime(value);
        }

        //非接口
        public static SortedDictionary<string, object> ToDictionary(Object data)
        {
            //类型转SortedDictionary
            SortedDictionary<string, object> result = JsonConvert.DeserializeObject<SortedDictionary<string, object>>(JsonConvert.SerializeObject(data));
            List<string> keys = new List<string>();
            foreach (KeyValuePair<string, object> item in result)
            {
                if (item.Value == null || item.Value.ToString() == "")
                {
                    keys.Add(item.Key);
                }
            }
            for (int i = 0; i < keys.Count; i++)
            {
                result.Remove(keys[i]);
            }
            return result;
        }
    }
}

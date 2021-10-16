using Microsoft.International.Converters.PinYinConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Extension
{
    /// <summary>
    /// 字符串的一些扩展
    /// </summary>
    public static class MyStringExtension
    {
        /// <summary>
        /// 字符串装换成拼音
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetPinYin(this String str)
        {
            string result = string.Empty;
            foreach (char item in str)
            {
                try
                {
                    ChineseChar cc = new ChineseChar(item);
                    if (cc.Pinyins.Count > 0 && cc.Pinyins[0].Length > 0)
                    {
                        string temp = cc.Pinyins[0].ToString();
                        result += temp.Substring(0, temp.Length - 1);
                    }
                }
                catch (Exception)
                {
                    result += item.ToString();
                }
            }
            return result;
        }

        /// <summary>
        /// 字符串转成拼音首字母
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetPinYinHead(this String str)
        {
            string result = string.Empty;
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }
            foreach (char item in str)
            {
                if (('a' <= item && item <= 'z') || ('A' <= item && item <= 'Z'))
                {
                    result += item;
                }
                else
                {
                    try
                    {
                        ChineseChar cc = new ChineseChar(item);
                        if (cc.Pinyins.Count > 0 && cc.Pinyins[0].Length > 0)
                        {
                            result += cc.Pinyins[0][0];
                        }
                    }
                    catch
                    {
                        result += item;
                    }
                }
            }
            return result;
        }

    }
}

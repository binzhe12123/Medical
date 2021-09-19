using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SY.Com.Infrastructure
{
    /// <summary>
    /// 字符串帮助类
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// 把字符串转换成日期
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static DateTime SToDateTime(this string s)
        {
            return Convert.ToDateTime(s);
        }

        /// <summary>
        /// 把字符串转换成int
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int SToInt(this string s)
        {
            return Convert.ToInt32(s);
        }

        /// <summary>
        /// 把字符串转换成可供SQL IN('A','B','C')的语句
        /// </summary>
        /// <param name="s">格式A,B,C</param>
        /// <returns></returns>
        public static string ToSqlInStr(this string s)
        {
            string rv = string.Empty;

            if (!string.IsNullOrEmpty(s))
            {
                string[] arr = s.Split(new char[] { ',' });
                if (arr.Length > 0)
                {
                    foreach (string st in arr)
                    {
                        if (rv == "")
                        {
                            rv += "'" + st + "'";
                        }
                        else
                        {
                            rv += ",'" + st + "'";
                        }
                    }
                }
            }
            return rv;
        }

        /// <summary>
        /// 增加一个空白的字符
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string AddSplaceWord(this string s)
        {
            return s + "&nbsp;";
        }

        /// <summary>
        /// 过滤关键字
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string FilterKeyWord(this string s)
        {
            return s.Replace("[", "[[ ").Replace("]", " ]]").Replace("*", "[*]").Replace("%", "[%]").Replace("[[ ", "[[]").Replace(" ]]", "[]]").Replace("\'", "''");
        }

        /// <summary>
        /// 从字符串中获取手机号码
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string GetTelCode(this string s)
        {
            string rv = string.Empty;
            Regex reg = new Regex("\\d{11}");
            if (reg.IsMatch(s))
            {
                Match m = reg.Match(s);
                rv = m.Value;
            }
            return rv;
        }

        /// <summary>
        /// 特殊字符处理
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string JsonSpecialWord(this string s)
        {
            return s.Replace("\t", "\\t").Replace("\n", "\\n").Replace("\r\n", "\\r\\n").Replace("\r", "\\r");
        }

        /// <summary>
        /// 过滤特殊字符(包含对SQL的支持)
        /// </summary>
        /// <param name="searchString">搜索关键字</param>
        /// <returns></returns>
        public static string CleanSearchString(this string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return "";
            }

            //过滤 *
            searchString = searchString.Replace("*", " ");

            //过滤% ，并截取后部分
            int hasBFH=searchString.IndexOf("%");
            int sLen=searchString.Length;
            if (hasBFH!=searchString.Length - 1 && hasBFH>0)
            {
               searchString= searchString.Substring(hasBFH, sLen-hasBFH);
            }
           
            // xml 标签过滤
            searchString = searchString.Replace("<[^>]+>", "");

            //过滤掉中括号
            searchString = searchString.Replace("[", "[[ ").Replace("]", " ]]").Replace("[[ ", "[[]").Replace(" ]]", "[]]").Replace("\'", "''");

            // 过滤一部分sql注释
            searchString = Regex.Replace(searchString, "--|;|'|\"", " ", RegexOptions.Compiled | RegexOptions.Multiline);
            //防止sql语句注入的替换
            searchString = ProcessSqlStr(searchString.ToLower()) == true ? searchString : "";

            return searchString.Trim();
        }


        public static bool ProcessSqlStr(string Str)
        {
            bool ReturnValue = true;
            try
            {
                if (Str != "")
                {
                    string SqlStr = @"exec|insert|delete|update|select*|select|drop|truncate|xp_cmdshell|alter|master.|restore|from|dropview|exists|or|print|print@";

                    string[] anySqlStr = SqlStr.Split('|');

                    foreach (string ss in anySqlStr)
                    {

                        if (Str.IndexOf(" " + ss + " ") >= 0)
                        {

                            ReturnValue = false;
                            break;
                        }

                    }
                }

            }
            catch
            {
                ReturnValue = false;
            }
            return ReturnValue;

        }

    }

}
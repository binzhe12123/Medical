using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;
using System.Net;

namespace SY.Com.Infrastructure
{
    public class HttpHelper
    {
        /// <summary>
        /// Url编码
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public static string UrlEncode(string strValue)
        {
            return HttpUtility.UrlEncode(strValue);
        }

        /// <summary>
        /// Url解码
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public static string UrlDecode(string strValue)
        {
            return HttpUtility.UrlDecode(strValue);
        }

        /// <summary>
        /// 写Cookie
        /// </summary>
        /// <param name="strName">键</param>
        /// <param name="strValue">值</param>
        /// <param name="strDay">设置失效天数</param>
        /// <returns></returns>
        public static bool WriteCookie(string strName, string strValue)
        {
            try
            {
                HttpCookie Cookie = new HttpCookie(strName);
                //Cookie.Domain = ".xxx.com";//当要跨域名访问的时候,给cookie指定域名即可,格式为.xxx.com
                //Cookie.Expires = DateTime.Now.AddDays(strDay);
                Cookie.Value = UrlEncode(strValue);
                System.Web.HttpContext.Current.Response.Cookies.Add(Cookie);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 写Cookie
        /// </summary>
        /// <param name="strName">键</param>
        /// <param name="strValue">值</param>
        /// <param name="strDay">设置失效天数</param>
        /// <returns></returns>
        public static bool WriteCookie(string strName, string strValue, int strDay)
        {
            try
            {
                HttpCookie Cookie = new HttpCookie(strName);
                //Cookie.Domain = ".xxx.com";//当要跨域名访问的时候,给cookie指定域名即可,格式为.xxx.com
                Cookie.Expires = DateTime.Now.AddDays(strDay);
                Cookie.Value = UrlEncode(strValue);
                System.Web.HttpContext.Current.Response.Cookies.Add(Cookie);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 读取Cookies
        /// </summary>
        /// <param name="strName">key值</param>
        /// <returns></returns>
        public static string GetCookie(string strName)
        {
            HttpCookie Cookie = System.Web.HttpContext.Current.Request.Cookies[strName];
            if (Cookie != null)
            {
                return UrlDecode(Cookie.Value.ToString());
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 删除Cookie
        /// </summary>
        /// <param name="strName"></param>
        /// <returns></returns>
        public static bool DelCookie(string strName)
        {
            try
            {
                HttpCookie Cookie = new HttpCookie(strName);
                //Cookie.Domain = ".xxx.com";//当要跨域名访问的时候,给cookie指定域名即可,格式为.xxx.com
                Cookie.Expires = DateTime.Now.AddDays(-1);
                System.Web.HttpContext.Current.Response.Cookies.Add(Cookie);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string BinarySerialize(object obj)
        {
            IFormatter formatter = new BinaryFormatter();
            string result = string.Empty;
            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, obj);
                byte[] byt = new byte[stream.Length];
                byt = stream.ToArray();
                result = Convert.ToBase64String(byt);  //result = Encoding.UTF8.GetString(byt, 0, byt.Length);
                stream.Flush();
            }
            return result;
        }
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static object DeSerialize2(string str)
        {
            IFormatter formatter = new BinaryFormatter();
            byte[] byt = Convert.FromBase64String(str);  //byte[] byt = Encoding.UTF8.GetBytes(str);  
            object obj = null;
            using (Stream stream = new MemoryStream(byt, 0, byt.Length))
            {
                obj = formatter.Deserialize(stream);
            }
            return obj;
        }

        /// <summary>
        /// string转换bytes
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] String2Bytes(string strNum)
        {
            byte[] value = null;
            if (!string.IsNullOrWhiteSpace(strNum))
            {
                value = Encoding.Unicode.GetBytes(strNum);
            }
            return value;
        }
        /// <summary>
        ///bytes转换string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string BytesToString(byte[] strNum)
        {
            string value = null;
            if (strNum.Length > 0)
            {
                value = Encoding.Unicode.GetString(strNum, 0, strNum.Length);
            }
            return value;
        }

        public static string GetIpAddress()
        {
            string strIpAddress;
            strIpAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (strIpAddress == null)
            {
                strIpAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            return strIpAddress;
        }

        public static string GetIP()
        {
            string ip = string.Empty;
            try {
                if (string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]))
                {
                    ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString(); //While it can't get the Client IP, it will return proxy IP.             
                }
                else
                {
                    ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
                }
            } catch (Exception ex)
            {
                throw ex;
            }            
            return ip;
        }



        /// <summary>
        /// 检测用户是否使用默认模板
        /// </summary>
        /// <param name="fileUrl"></param>
        /// <returns></returns>
        private bool RemoteFileExists(string fileUrl)
        {
            bool result = false;//下载结果
            WebResponse response = null;
            try
            {
                WebRequest req = WebRequest.Create(fileUrl);
                response = req.GetResponse();
                result = response == null ? false : true;

            }
            catch (Exception ex)
            {
                result = false;
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
            }
            return result;
        }

    }
}

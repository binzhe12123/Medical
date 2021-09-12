using LitJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SY.Com.Infrastructure
{
    public class WXPayClass
    {


        public static string WXPay_MCHID = "";//商户号

        public static string WXPay_APPID = "";//微信公众号ID

        public static string WXPay_KEY = "";

        public static string WXPay_APPSECRET = "";

        //public static string WXPay_Callback_Domain = "http://m.zsyzg.cn/";

        public static string WXPay_Callback_Domain = "http://edu.zslbzj.com/";

        public static string WXPay_OAuth_Uri = "";

        public static string GenerateTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }


        public static string GenerateTimeStampMilliseconds()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();
        }

    }

    public class WXPayData
    {
        private SortedDictionary<string, object> my_paras = new SortedDictionary<string, object>();
        

        public void SetValue(string key, object value)
        {
            my_paras.Add(key, value);
        }

        public object GetValue(string key)
        {
            object o = null;
            my_paras.TryGetValue(key, out o);
            return o;
        }

        public bool RemoveValue(string key)
        {
            return my_paras.Remove(key);
        }

        public void ChangeValue(string key,object value)
        {
            //先remove再set
            RemoveValue(key);
            SetValue(key, value);
        }
        public SortedDictionary<string, object> FromXml(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                Log4Net.LogHelper.Error("统一下单接口xml字符串为空");
                throw new Exception("统一下单接口xml字符串为空");
            }

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(xml);
            
            XmlNode xmlNode = xmldoc.FirstChild;//获取到根节点<xml>
            XmlNodeList nodes = xmlNode.ChildNodes;
            foreach (XmlNode xn in nodes)
            {
                XmlElement xe = (XmlElement)xn;
                my_paras[xe.Name] = xe.InnerText;//获取xml的键值对到WxPayData内部的数据中
            }

            try
            {
                //2015-06-29 错误是没有签名
                if (my_paras["return_code"].ToString() != "SUCCESS")
                {
                    return my_paras;
                }
                //CheckSign();//验证签名
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return my_paras;
        }

        public string ToJson()
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(my_paras);
            //string json = JsonMapper.ToJson(my_paras);
            return json;
        }

        public string ToXML()
        {
            if (0 == this.my_paras.Count)
            {
                Log4Net.LogHelper.Error("WXPay参数为空！");
                throw new Exception("WXPay参数为空！");
            }
            string xml = "<xml>";
            foreach (KeyValuePair<string, object> para in my_paras)
            {
                if (para.Value == null)
                {
                    Log4Net.LogHelper.Error("WXPay参数值为null！" + para.Key);
                    throw new Exception("WXPay参数值为null！" + para.Key);
                }
                if (para.Value.GetType() == typeof(int))
                {
                    xml += "<" + para.Key + ">" + para.Value + "</" + para.Key + ">";
                }
                else if (para.Value.GetType() == typeof(string))
                {
                    xml += "<" + para.Key + "><![CDATA[" + para.Value + "]]></" + para.Key + ">";
                }
                else
                {
                    Log4Net.LogHelper.Error("非法的WXPay参数值类型！" + para.Key);
                    throw new Exception("非法的WXPay参数值类型！" + para.Key);
                }
            }
            xml += "</xml>";
            return xml;
        }

        public string ToUrl()
        {
            string uri_paras = "";
            foreach (KeyValuePair<string, object> para in my_paras)
            {
                if (para.Value == null)
                {
                    Log4Net.LogHelper.Error("WXPay参数值为null！" + para.Key);
                    throw new Exception("WXPay参数值为null！");
                }
                if (para.Key != "sing" && para.Value.ToString() != "")
                {
                    uri_paras += para.Key + "=" + para.Value + "&";
                }
            }
            uri_paras = uri_paras.Trim('&');
            return uri_paras;
        }

        public string Sign()
        {
            string str = ToUrl();
            str += "&key=" + WXPayClass.WXPay_KEY;
            var md5 = MD5.Create();
            var bs = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            var sb = new StringBuilder();
            foreach (byte b in bs)
            {
                sb.Append(b.ToString("x2"));
            }
            //所有字符转为大写
            return sb.ToString().ToUpper();
        }

        public string Sign(string key)
        {
            string str = ToUrl();
            str += "&key=" + key;
            var md5 = MD5.Create();
            var bs = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            var sb = new StringBuilder();
            foreach (byte b in bs)
            {
                sb.Append(b.ToString("x2"));
            }
            //所有字符转为大写
            return sb.ToString().ToUpper();
        }

        public string wxMD5(string key)
        {
            var md5 = MD5.Create();
            var bs = md5.ComputeHash(Encoding.UTF8.GetBytes(key));
            var sb = new StringBuilder();
            foreach (byte b in bs)
            {
                sb.Append(b.ToString("x2"));
            }
            //所有字符转为大写
            return sb.ToString().ToUpper();
        }

        //加密算法HmacSHA256  
        public  string HmacSHA256(string secret, string signKey)
        {
            string signRet = string.Empty;
            using (HMACSHA256 mac = new HMACSHA256(Encoding.UTF8.GetBytes(secret)))
            {
                byte[] hash = mac.ComputeHash(Encoding.UTF8.GetBytes(signKey));
                signRet = Convert.ToBase64String(hash);
                //signRet = ToHexString(hash); ;
            }
            return signRet;
        }

        public string HmacSHA256_Encrypt(string secret, string message)
        {
            secret = secret ?? "";
            var encoding = new System.Text.UTF8Encoding();
            byte[] keyByte = encoding.GetBytes(secret);
            byte[] messageBytes = encoding.GetBytes(message);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashmessage.Length; i++)
                {
                    builder.Append(hashmessage[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }


        //byte[]转16进制格式string
        public  string ToHexString(byte[] bytes)
        {
            string hexString = string.Empty;
            if (bytes != null)
            {
                StringBuilder strB = new StringBuilder();
                foreach (byte b in bytes)
                {
                    strB.AppendFormat("{0:x2}", b);
                }
                hexString = strB.ToString();
            }
            return hexString;


        }

        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public string GenerateTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }


        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public string GenerateTimeStampMilliseconds()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();
        }

    }    


}

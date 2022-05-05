using YB.FrameWork;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using Client.Model;


namespace Client.Controllers
{
    public class SYBController : ApiController
    {
       
        [HttpGet]
        public static string HttpPost(string url, string param, Dictionary<string, string> headers = null)
        {
            string retText = string.Empty;
            byte[] bs = Encoding.UTF8.GetBytes(param);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | (SecurityProtocolType)192 | (SecurityProtocolType)768 | (SecurityProtocolType)3072;
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = bs.Length;
            string paasid = ConfigurationManager.AppSettings["paasid"];
            string secret = ConfigurationManager.AppSettings["secretKey"];
            string timestamp = DateTimeEx.DateTimeToStamp(DateTime.Now).ToString();
            request.Headers.Add("x-tif-paasid", paasid);//省医保在创建请求应用账户时自动生成应用账户编码和密钥（secretKey私钥）                         
            request.Headers.Add("x-tif-timestamp", timestamp);
            Random ran = new Random();
            int a = ran.Next(1, 11);
            int rep = 0;
            string str = string.Empty;
            long num2 = DateTime.Now.Ticks + rep;
            rep++;
            Random random = new Random(((int)(((ulong)num2) & 0xffffffffL)) | ((int)(num2 >> rep)));
            for (int i = 0; i < a; i++)
            {
                int num = random.Next();
                str = str + ((char)(0x30 + ((ushort)(num % 10)))).ToString();
            }//sha256(x-tif-timestamp + secretKey+ x-tif-nonce + xtif-timestamp
            request.Headers.Add("x-tif-nonce", str);
            string temp = timestamp + secret + str + timestamp;
            string xRioSignature = Sha256(temp);
            request.Headers.Add("x-tif-signature", xRioSignature);//
            LogHelper.Debug("header：" + "x-tif-paasid=" + paasid + ";x-tif-timestamp=" + timestamp + ";x-tif-nonce=" + str + ";x-tif-signature=" + xRioSignature);
            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
            }
            using (WebResponse wr = request.GetResponse())
            {
                //在这里对接收到的页面内容进行处理 
                Stream respStream = wr.GetResponseStream();
                StreamReader respStreamReader = new StreamReader(respStream, Encoding.UTF8);
                retText = respStreamReader.ReadToEnd();
                //解析json 》》strBuff
            }
            return retText;
        }

        public static string Sha256(string str)
        {
            //如果str有中文，不同Encoding的sha是不同的！！
            byte[] SHA256Data = Encoding.UTF8.GetBytes(str);

            SHA256Managed Sha256 = new SHA256Managed();
            byte[] by = Sha256.ComputeHash(SHA256Data);

            return BitConverter.ToString(by).Replace("-", "").ToLower(); //64
                                                                        //return Convert.ToBase64String(by);   
        }

        [HttpGet]
        public static string HttpPostFile(string url, string param, Dictionary<string, string> headers = null)
        { 
            string retText = string.Empty;
            byte[] bs = Encoding.UTF8.GetBytes(param);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | (SecurityProtocolType)192 | (SecurityProtocolType)768 | (SecurityProtocolType)3072;
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = bs.Length;
            string paasid = ConfigurationManager.AppSettings["paasid"];
            string secret = ConfigurationManager.AppSettings["secretKey"];
            string timestamp = DateTimeEx.DateTimeToStamp(DateTime.Now).ToString();
            request.Headers.Add("x-tif-paasid", paasid);//省医保在创建请求应用账户时自动生成应用账户编码和密钥（secretKey私钥）                         
            request.Headers.Add("x-tif-timestamp", timestamp);
            Random ran = new Random();
            int a = ran.Next(1, 11);
            int rep = 0;
            string str = string.Empty;
            long num2 = DateTime.Now.Ticks + rep;
            rep++;
            Random random = new Random(((int)(((ulong)num2) & 0xffffffffL)) | ((int)(num2 >> rep)));
            for (int i = 0; i < a; i++)
            {
                int num = random.Next();
                str = str + ((char)(0x30 + ((ushort)(num % 10)))).ToString();
            }//sha256(x-tif-timestamp + secretKey+ x-tif-nonce + xtif-timestamp
            request.Headers.Add("x-tif-nonce", str);
            string temp = timestamp + secret + str + timestamp;
            string xRioSignature = Sha256(temp);
            request.Headers.Add("x-tif-signature", xRioSignature);//
            LogHelper.Debug("header：" + "x-tif-paasid=" + paasid + ";x-tif-timestamp=" + timestamp + ";x-tif-nonce=" + str + ";x-tif-signature=" + xRioSignature);
            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
            }            
            string tempFile = System.AppDomain.CurrentDomain.BaseDirectory + "Down\\"  + "file.zip";
            if(System.IO.File.Exists(tempFile))
            {
                System.IO.File.Delete(tempFile);
            }
            using (WebResponse wr = request.GetResponse())
            {
                //在这里对接收到的页面内容进行处理 
                Stream respStream = wr.GetResponseStream();
                //创建本地文件写入流
                //Stream stream = new FileStream(tempFile, FileMode.Create);
                byte[] bArr = new byte[1024];
                int size = respStream.Read(bArr, 0, (int)bArr.Length);
                FileStream fs = File.Create(tempFile);  // new FileStream(tempFile, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                while (size > 0)
                {
                    //stream.Write(bArr, 0, size);
                    fs.Write(bArr, 0, size);
                    size = respStream.Read(bArr, 0, (int)bArr.Length);
                }
                //stream.Close();
                fs.Close();
                respStream.Close();                             

                //StreamReader respStreamReader = new StreamReader(respStream, Encoding.UTF8);
                //retText = respStreamReader.ReadToEnd();
                //解析json 》》strBuff
            }
            return tempFile ;
        }
        [HttpPost]
        public HttpResponseMessage Down([FromBody]string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return new HttpResponseMessage { Content = new StringContent("入参为null", Encoding.GetEncoding("UTF-8"), "application/json") };
            }
            //else
            //{
            //    return new HttpResponseMessage { Content = new StringContent(data, Encoding.GetEncoding("UTF-8"), "application/json") };
            //}            
            SYBCommon.OutCommon rd = new SYBCommon.OutCommon();
            ReturnData<SYBCommon.InCommon> rd1 = new ReturnData<SYBCommon.InCommon>();
            HttpResponseMessage responseMessage;
            try
            {
                rd1.Data = Newtonsoft.Json.JsonConvert.DeserializeObject<SYBCommon.InCommon>(data);
                //rd1.Data = JSONHelper.JSONToObject<InCommon>(data);                                
                string url = ConfigurationManager.AppSettings["SYBUrl"].ToString() + rd1.Data.infno;                
                LogHelper.Debug(rd1.Data.infno + url + "入参：" + data);
                string result = "";
                if (rd1.Data.infno == "9102")
                {
                    result = HttpPostFile(url, data);
                    result = "{\"infcode\":0,\"file\":\"" + result.Replace("\\","\\\\") + "\"}";
                    //result = "{\"filepath\":\""+ result+"\"}"; 
;               }
                else {
                    result = HttpPost(url, data);
                }                
                LogHelper.Debug(rd1.Data.infno + "出参：" + result);                                
                //rd.Data = Newtonsoft.Json.JsonConvert.DeserializeObject<OutCommon>(result);
                //rd.Data = JSONHelper.JSONToObject<OutCommon>(result);                
                responseMessage = new HttpResponseMessage { Content = new StringContent(result, Encoding.GetEncoding("UTF-8"), "application/json") };
            }
            catch (Exception ex)
            {
                responseMessage = new HttpResponseMessage { Content = new StringContent(ex.Message + ":-" + data, Encoding.GetEncoding("UTF-8"), "application/json") };
                return responseMessage;
            }

            return responseMessage;

        }
        [HttpGet]
        public string getMac()
        {
            try
            {
                string mac = "";
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                    if ((bool)mo["IPEnabled"] == true)
                    {
                        mac = mo["MacAddress"].ToString();
                        break;
                    }
                moc = null;
                mc = null;
                return mac.Trim().Replace(':', '-');
            }
            catch (Exception e)
            {
                return "error:" + e.Message;
            }
        }
    }
}

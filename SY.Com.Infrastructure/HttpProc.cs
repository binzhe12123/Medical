using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.IO.Compression;
using System.Net.Cache;
using System.Collections.Generic;
using com.pasc.medical.dc.clinic.sdk.common.utils.security;

namespace SY.Com.Infrastructure
{   
    /// <summary>    
    /// 上传数据参数    
    /// </summary>    
    public class UploadEventArgs : EventArgs
    {
        int bytesSent;
        int totalBytes;
        /// <summary>    
        /// 已发送的字节数    
        /// </summary>    
        public int BytesSent
        {
            get { return bytesSent; }
            set { bytesSent = value; }
        }
        /// <summary>    
        /// 总字节数    
        /// </summary>    
        public int TotalBytes
        {
            get { return totalBytes; }
            set { totalBytes = value; }
        }
    }
    /// <summary>    
    /// 下载数据参数    
    /// </summary>    
    public class DownloadEventArgs : EventArgs
    {
        int bytesReceived;
        int totalBytes;
        byte[] receivedData;
        /// <summary>    
        /// 已接收的字节数    
        /// </summary>    
        public int BytesReceived
        {
            get { return bytesReceived; }
            set { bytesReceived = value; }
        }
        /// <summary>    
        /// 总字节数    
        /// </summary>    
        public int TotalBytes
        {
            get { return totalBytes; }
            set { totalBytes = value; }
        }
        /// <summary>    
        /// 当前缓冲区接收的数据    
        /// </summary>    
        public byte[] ReceivedData
        {
            get { return receivedData; }
            set { receivedData = value; }
        }
    }

    public class WebClient
    {
        Encoding encoding = Encoding.Default;
        string respHtml = "";
        WebProxy proxy;
        static CookieContainer cc;
        WebHeaderCollection requestHeaders;
        WebHeaderCollection responseHeaders;
        int bufferSize = 15240;
        public event EventHandler<UploadEventArgs> UploadProgressChanged;
        public event EventHandler<DownloadEventArgs> DownloadProgressChanged;
        static WebClient()
        {
            LoadCookiesFromDisk();
        }
        /// <summary>    
        /// 创建WebClient的实例    
        /// </summary>    
        public WebClient()
        {
            requestHeaders = new WebHeaderCollection();
            responseHeaders = new WebHeaderCollection();
        }
        /// <summary>    
        /// 设置发送和接收的数据缓冲大小    
        /// </summary>    
        public int BufferSize
        {
            get { return bufferSize; }
            set { bufferSize = value; }
        }
        /// <summary>    
        /// 获取响应头集合    
        /// </summary>    
        public WebHeaderCollection ResponseHeaders
        {
            get { return responseHeaders; }
        }
        /// <summary>    
        /// 获取请求头集合    
        /// </summary>    
        public WebHeaderCollection RequestHeaders
        {
            get { return requestHeaders; }
        }
        /// <summary>    
        /// 获取或设置代理    
        /// </summary>    
        public WebProxy Proxy
        {
            get { return proxy; }
            set { proxy = value; }
        }
        /// <summary>    
        /// 获取或设置请求与响应的文本编码方式    
        /// </summary>    
        public Encoding Encoding
        {
            get { return encoding; }
            set { encoding = value; }
        }
        /// <summary>    
        /// 获取或设置响应的html代码    
        /// </summary>    
        public string RespHtml
        {
            get { return respHtml; }
            set { respHtml = value; }
        }
        /// <summary>    
        /// 获取或设置与请求关联的Cookie容器    
        /// </summary>    
        public CookieContainer CookieContainer
        {
            get { return cc; }
            set { cc = value; }
        }
        /// <summary>    
        ///  获取网页源代码    
        /// </summary>    
        /// <param name="url">网址</param>    
        /// <returns></returns>    
        public string GetHtml(string url)
        {
            HttpWebRequest request = CreateRequest(url, "GET");
            respHtml = encoding.GetString(GetData(request));
            return respHtml;
        }
        /// <summary>    
        /// 下载文件    
        /// </summary>    
        /// <param name="url">文件URL地址</param>    
        /// <param name="filename">文件保存完整路径</param>    
        public void DownloadFile(string url, string filename)
        {
            FileStream fs = null;
            try
            {
                HttpWebRequest request = CreateRequest(url, "GET");
                byte[] data = GetData(request);
                fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
                fs.Write(data, 0, data.Length);
            }
            finally
            {
                if (fs != null) fs.Close();
            }
        }
        /// <summary>    
        /// 从指定URL下载数据    
        /// </summary>    
        /// <param name="url">网址</param>    
        /// <returns></returns>    
        public byte[] GetData(string url)
        {
            HttpWebRequest request = CreateRequest(url, "GET");
            return GetData(request);
        }
        /// <summary>    
        /// 向指定URL发送文本数据    
        /// </summary>    
        /// <param name="url">网址</param>    
        /// <param name="postData">urlencode编码的文本数据</param>    
        /// <returns></returns>    
        public string Post(string url, string postData)
        {
            byte[] data = encoding.GetBytes(postData);
            return Post(url, data);
        }
        /// <summary>    
        /// 向指定URL发送字节数据    
        /// </summary>    
        /// <param name="url">网址</param>    
        /// <param name="postData">发送的字节数组</param>    
        /// <returns></returns>    
        public string Post(string url, byte[] postData)
        {
            HttpWebRequest request = CreateRequest(url, "POST");
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postData.Length;
            request.KeepAlive = true;
            PostData(request, postData);
            respHtml = encoding.GetString(GetData(request));
            return respHtml;
        }
        /// <summary>    
        /// 向指定网址发送mulitpart编码的数据    
        /// </summary>    
        /// <param name="url">网址</param>    
        /// <param name="mulitpartForm">mulitpart form data</param>    
        /// <returns></returns>    
        public string Post(string url, MultipartForm mulitpartForm)
        {
            HttpWebRequest request = CreateRequest(url, "POST");
            request.ContentType = mulitpartForm.ContentType;
            request.ContentLength = mulitpartForm.FormData.Length;
            request.KeepAlive = true;
            PostData(request, mulitpartForm.FormData);
            respHtml = encoding.GetString(GetData(request));
            return respHtml;
        }

        /// <summary>    
        /// 向指定网址发送mulitpart编码的数据    
        /// </summary>    
        /// <param name="url">网址</param>    
        /// <param name="mulitpartForm">mulitpart form data</param>    
        /// <returns></returns>    
        public string Post(string url, byte[] mulitpartForm,string ContentType,Encoding _encode)
        {
            HttpWebRequest request = CreateRequest(url, "POST");
            request.ContentType = ContentType;
            request.ContentLength = mulitpartForm.Length;
            request.KeepAlive = true;
            PostData(request, mulitpartForm);
            respHtml = _encode.GetString(GetData(request));
            return respHtml;
        }

        /// <summary>    
        /// 读取请求返回的数据    
        /// </summary>    
        /// <param name="request">请求对象</param>    
        /// <returns></returns>    
        private byte[] GetData(HttpWebRequest request)
        {
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            responseHeaders = response.Headers; 
            //SaveCookiesToDisk();

            DownloadEventArgs args = new DownloadEventArgs();
            if (responseHeaders[HttpResponseHeader.ContentLength] != null)
                args.TotalBytes = Convert.ToInt32(responseHeaders[HttpResponseHeader.ContentLength]);

            MemoryStream ms = new MemoryStream();
            int count = 0;
            byte[] buf = new byte[bufferSize];
            while ((count = stream.Read(buf, 0, buf.Length)) > 0)
            {
                ms.Write(buf, 0, count);
                if (this.DownloadProgressChanged != null)
                {
                    args.BytesReceived += count;
                    args.ReceivedData = new byte[count];
                    Array.Copy(buf, args.ReceivedData, count);
                    this.DownloadProgressChanged(this, args);
                }
            }
            stream.Close();
            //解压    
            if (ResponseHeaders[HttpResponseHeader.ContentEncoding] != null)
            {
                MemoryStream msTemp = new MemoryStream();
                count = 0;
                buf = new byte[100];
                switch (ResponseHeaders[HttpResponseHeader.ContentEncoding].ToLower())
                {
                    case "gzip":
                        GZipStream gzip = new GZipStream(ms, CompressionMode.Decompress);
                        while ((count = gzip.Read(buf, 0, buf.Length)) > 0)
                        {
                            msTemp.Write(buf, 0, count);
                        }
                        return msTemp.ToArray();
                    case "deflate":
                        DeflateStream deflate = new DeflateStream(ms, CompressionMode.Decompress);
                        while ((count = deflate.Read(buf, 0, buf.Length)) > 0)
                        {
                            msTemp.Write(buf, 0, count);
                        }
                        return msTemp.ToArray();
                    default:
                        break;
                }
            }
            return ms.ToArray();
        }
        /// <summary>    
        /// 发送请求数据    
        /// </summary>    
        /// <param name="request">请求对象</param>    
        /// <param name="postData">请求发送的字节数组</param>    
        private void PostData(HttpWebRequest request, byte[] postData)
        {
            int offset = 0;
            int sendBufferSize = bufferSize;
            int remainBytes = 0;
            Stream stream = request.GetRequestStream();
            UploadEventArgs args = new UploadEventArgs();
            args.TotalBytes = postData.Length;
            while ((remainBytes = postData.Length - offset) > 0)
            {
                if (sendBufferSize > remainBytes) sendBufferSize = remainBytes;
                stream.Write(postData, offset, sendBufferSize);
                offset += sendBufferSize;
                if (this.UploadProgressChanged != null)
                {
                    args.BytesSent = offset;
                    this.UploadProgressChanged(this, args);
                }
            }
            stream.Close();
        }
        /// <summary>    
        /// 创建HTTP请求    
        /// </summary>    
        /// <param name="url">URL地址</param>    
        /// <returns></returns>    
        private HttpWebRequest CreateRequest(string url, string method)
        {
            Uri uri = new Uri(url);

            if (uri.Scheme == "https")
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(this.CheckValidationResult);

            // Set a default policy level for the "http:" and "https" schemes.    
            HttpRequestCachePolicy policy = new HttpRequestCachePolicy(HttpRequestCacheLevel.Revalidate);
            HttpWebRequest.DefaultCachePolicy = policy;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AllowAutoRedirect = false;
            request.AllowWriteStreamBuffering = false;
            request.Method = method;
            if (proxy != null) 
                request.Proxy = proxy;
            request.CookieContainer = cc;
            foreach (string key in requestHeaders.Keys)
            {
                request.Headers.Add(key, requestHeaders[key]);
            }
            requestHeaders.Clear();
            return request;
        }
        private bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }
        /// <summary>    
        /// 将Cookie保存到磁盘    
        /// </summary>    
        private static void SaveCookiesToDisk()
        {
            string cookieFile = System.Environment.GetFolderPath(Environment.SpecialFolder.Cookies) + "\\webclient.cookie";
            FileStream fs = null;
            try
            {
                fs = new FileStream(cookieFile, FileMode.Create);
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formater = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                formater.Serialize(fs, cc);
            }
            finally
            {
                if (fs != null) fs.Close();
            }
        }
        /// <summary>    
        /// 从磁盘加载Cookie    
        /// </summary>    
        private static void LoadCookiesFromDisk()
        {
            cc = new CookieContainer();
            string cookieFile = System.Environment.GetFolderPath(Environment.SpecialFolder.Cookies) + "\\webclient.cookie";
            if (!File.Exists(cookieFile))
                return;
            FileStream fs = null;
            try
            {
                fs = new FileStream(cookieFile, FileMode.Open, FileAccess.Read, FileShare.Read);
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formater = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                cc = (CookieContainer)formater.Deserialize(fs);
            }
            finally
            {
                if (fs != null) fs.Close();
            }
        }

        /// <summary>
        /// POST请求数据返回结果
        /// </summary>
        /// <param name="uri">请求地址</param>
        /// <param name="param">参数 user=123123&pwd=12312</param>
        /// <returns></returns>
        public static string HttpRequest(string uri, string param,Dictionary<string,string> headers = null)
        {
            string retText = string.Empty;
            byte[] bs = Encoding.UTF8.GetBytes(param);    //参数转化为ascii码
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(uri);//创建请求
            req.Method = "POST";
            req.ContentType = "application/json";
            req.ContentLength = bs.Length;
            if (headers != null)
            {
                req.Headers = new WebHeaderCollection();
                foreach (var item in headers)
                {
                    req.Headers.Add(item.Key, item.Value);
                }
            }
           using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
            }
            using (WebResponse wr = req.GetResponse())
            {
                //在这里对接收到的页面内容进行处理 
                Stream respStream = wr.GetResponseStream();
                StreamReader respStreamReader = new StreamReader(respStream, Encoding.UTF8);
                retText = respStreamReader.ReadToEnd();
                //解析json 》》strBuff
            }
            return retText;
        }

        /// <summary>
        /// POST请求数据返回结果,增加Tls12
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="param"></param>
        /// <param name="headers"></param>
        /// <param name="safe"></param>
        /// <returns></returns>
        public static string HttpRequest(string uri, string param,  bool safe,Dictionary<string, string> headers = null)
        {
            string retText = string.Empty;
            byte[] bs = Encoding.UTF8.GetBytes(param);    //参数转化为ascii码
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(uri);//创建请求
            req.Method = "POST";
            req.ContentType = "application/json";
            req.ContentLength = bs.Length;
            if (safe)
            {
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            }
            if (headers != null)
            {
                req.Headers = new WebHeaderCollection();
                foreach (var item in headers)
                {
                    req.Headers.Add(item.Key, item.Value);
                }
            }
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
            }
            using (WebResponse wr = req.GetResponse())
            {
                //在这里对接收到的页面内容进行处理 
                Stream respStream = wr.GetResponseStream();
                StreamReader respStreamReader = new StreamReader(respStream, Encoding.UTF8);
                retText = respStreamReader.ReadToEnd();
                //解析json 》》strBuff
            }
            return retText;
        }

        /// <summary>
        /// POST请求数据返回结果(Buffer类型)
        /// </summary>
        /// <param name="uri">请求地址</param>
        /// <param name="param">参数 user=123123&pwd=12312</param>        
        /// <returns></returns>
        public static WebResponse HttpRequestBuffer(string uri, string param)
        {
            string retText = string.Empty;
            byte[] bs = Encoding.UTF8.GetBytes(param);    //参数转化为ascii码
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(uri);//创建请求
            req.Method = "POST";
            req.ContentType = "application/json";
            req.ContentLength = bs.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
            }
            return req.GetResponse();
        }

        public static string HttpRequestAgent(string uri, string param)
        {
            string retText = string.Empty;
            byte[] bs = Encoding.UTF8.GetBytes(param);    //参数转化为ascii码
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(uri);//创建请求
            req.Method = "POST";
            req.ContentType = "application/json";
            req.ContentLength = bs.Length;
            req.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2490.80 Safari/537.36";
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
            }
            using (WebResponse wr = req.GetResponse())
            {
                //在这里对接收到的页面内容进行处理 
                Stream respStream = wr.GetResponseStream();
                StreamReader respStreamReader = new StreamReader(respStream,System.Text.Encoding.Default);
                retText = respStreamReader.ReadToEnd();
                //解析json 》》strBuff
            }
            return retText;
        }
        public static string HttpRequestX(string uri, string param)
        {
            string retText = string.Empty;
            byte[] bs = Encoding.UTF8.GetBytes(param);    //参数转化为ascii码
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(uri);//创建请求
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = bs.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
            }
            using (WebResponse wr = req.GetResponse())
            {
                //在这里对接收到的页面内容进行处理 
                Stream respStream = wr.GetResponseStream();
                StreamReader respStreamReader = new StreamReader(respStream, Encoding.UTF8);
                retText = respStreamReader.ReadToEnd();
                //解析json 》》strBuff
            }
            return retText;
        }

        //可以控制编码的form提交格式
        public static string HttpRequestX(string uri, string param,Encoding myencoding)
        {
            string retText = string.Empty;
            byte[] bs = myencoding.GetBytes(param);    //参数转化为ascii码
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(uri);//创建请求
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = bs.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
            }
            using (WebResponse wr = req.GetResponse())
            {
                //在这里对接收到的页面内容进行处理 
                Stream respStream = wr.GetResponseStream();
                StreamReader respStreamReader = new StreamReader(respStream, myencoding);
                retText = respStreamReader.ReadToEnd();
                //解析json 》》strBuff
            }
            return retText;
        }

        //可以控制编码的form提交格式
        public static string HttpRequestX(string uri, string param, Dictionary<string, string> headers, Encoding myencoding,bool safe = false)
        {
            string retText = string.Empty;
            byte[] bs = myencoding.GetBytes(param);    //参数转化为ascii码
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(uri);//创建请求
            if (safe)
            {
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            }
            if (headers != null)
            {
                req.Headers = new WebHeaderCollection();
                foreach (var item in headers)
                {
                    req.Headers.Add(item.Key, item.Value);
                }
            }
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = bs.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
            }
            using (WebResponse wr = req.GetResponse())
            {
                //在这里对接收到的页面内容进行处理 
                Stream respStream = wr.GetResponseStream();
                StreamReader respStreamReader = new StreamReader(respStream, myencoding);
                retText = respStreamReader.ReadToEnd();
                //解析json 》》strBuff
            }
            return retText;
        }

        //可以控制编码的form提交格式
        public static string HttpRequestX(string uri, string param, Encoding myencoding,bool isUseCert,string CertPath,string Password)
        {
            string retText = string.Empty;
            byte[] bs = myencoding.GetBytes(param);    //参数转化为ascii码
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(uri);//创建请求
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = bs.Length;
            //是否使用证书
            if (isUseCert)
            {
                try {
                    X509Certificate2 cert = new X509Certificate2(CertPath, Password);
                    req.ClientCertificates.Add(cert);
                } catch (Exception ex)
                {
                    throw new Exception(ex.Message + CertPath);
                }
            }
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
            }
            using (WebResponse wr = req.GetResponse())
            {
                //在这里对接收到的页面内容进行处理 
                Stream respStream = wr.GetResponseStream();
                StreamReader respStreamReader = new StreamReader(respStream, myencoding);
                retText = respStreamReader.ReadToEnd();
                //解析json 》》strBuff
            }
            return retText;
        }

        /// <summary>
        /// GET请求数据返回结果
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <returns></returns>
        public static string HttpRequest(string uri)
        {
            string retText = string.Empty;
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(uri);
            req.Method = "GET";
            using (WebResponse wr = req.GetResponse())
            {
                //在这里对接收到的页面内容进行处理 
                Stream respStream = wr.GetResponseStream();
                StreamReader respStreamReader = new StreamReader(respStream, Encoding.UTF8);
                retText = respStreamReader.ReadToEnd();
            }
            return retText;
        }

        /// <summary>
        /// GET请求数据返回结果
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <returns></returns>
        public static string HttpRequest(string uri,Encoding encod)
        {
            string retText = string.Empty;
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(uri);
            req.Method = "GET";
            using (WebResponse wr = req.GetResponse())
            {
                //在这里对接收到的页面内容进行处理 
                Stream respStream = wr.GetResponseStream();
                StreamReader respStreamReader = new StreamReader(respStream, encod);
                retText = respStreamReader.ReadToEnd();
            }
            return retText;
        }

        /// <summary>
        /// post数据
        /// </summary>
        /// <param name="strUrl"></param>
        /// <param name="postParaList"></param>
        /// <param name="isFile">true:用multipart/form-data发送，false：默认格式</param>
        /// <returns></returns>
        public static string postMessage(string strUrl, List<PostDateClass> postParaList,Dictionary<string,string> headers = null,bool safe = false, bool isFile = false)
        {
            if (safe)
            {
                //System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            }
            if (isFile == true)
            {
                return postFileMessage(strUrl, postParaList,headers);
            }
            else
            {
                StringBuilder strPost = new StringBuilder();
                for (int i = 0; i < postParaList.Count; i++)
                {
                    if (i != 0)
                    {
                        strPost.Append("&");
                    }
                    strPost.Append(postParaList[i].Prop);
                    strPost.Append("=");
                    strPost.Append(postParaList[i].Value);
                }
                return postMessage(strUrl, strPost.ToString(),headers);
            }
        }

        public static string postFileMessage(string strUrl, List<PostDateClass> postParaList,Dictionary<string,string> headers)
        {
            try
            {
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                System.Net.ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult2);                
                //HttpRequestCachePolicy policy = new HttpRequestCachePolicy(HttpRequestCacheLevel.Revalidate);
                //HttpWebRequest.DefaultCachePolicy = policy;
                string responseContent = "";
                var memStream = new MemoryStream();
                var webRequest = (HttpWebRequest)WebRequest.Create(strUrl);
                
                //webRequest.CachePolicy = policy;
                if (headers != null)
                {
                    webRequest.Headers = new WebHeaderCollection();
                    foreach (var item in headers)
                    {
                        webRequest.Headers.Add(item.Key, item.Value);
                    }
                }
                // 边界符
                var boundary =  DateTime.Now.Ticks.ToString("x");
                // 边界符
                var beginBoundary = Encoding.ASCII.GetBytes("\r\n------WebKitFormBoundary" + boundary + "\r\n");
                // 最后的结束符
                var endBoundary = Encoding.ASCII.GetBytes("\r\n------WebKitFormBoundary" + boundary + "--\r\n");
                memStream.Write(beginBoundary, 0, beginBoundary.Length);
                // 设置属性
                webRequest.Method = "POST";
                webRequest.Timeout = 120000;
                webRequest.ContentType = "multipart/form-data;charset=utf-8; boundary=----WebKitFormBoundary" + boundary;
                for (int i = 0; i < postParaList.Count; i++)
                {
                    PostDateClass temp = postParaList[i];
                    if (temp.Type == 1)
                    {
                        Stream fileStream;
                        string filename = "";
                        if (temp.Value.ToLower().IndexOf("http") >= 0 || temp.Value.ToLower().IndexOf("https") >= 0)
                        {                            
                            fileStream = WebRequest.Create(new Uri(temp.Value)).GetResponse().GetResponseStream();
                            filename = temp.filename;
                        }
                        else {
                            fileStream = new FileStream(temp.Value, FileMode.Open, FileAccess.Read);
                            filename = Path.GetFileName(temp.Value);
                        }
                        //var fileStream = new FileStream(temp.Value, FileMode.Open, FileAccess.Read);
                        // 写入文件
                        const string filePartHeader =
                            "Content-Disposition:form-data;name=\"{0}\";filename=\"{1}\"\r\n" +
                            "Content-Type:{2}\r\n\r\n";
                        var header = string.Format(filePartHeader, temp.Prop, filename, temp.contentType);
                        var headerbytes = Encoding.UTF8.GetBytes(header);
                        memStream.Write(headerbytes, 0, headerbytes.Length);
                        var buffer = new byte[1024];
                        int bytesRead; // =0
                        while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            memStream.Write(buffer, 0, bytesRead);
                        }
                        string end = "\r\n";
                        headerbytes = Encoding.UTF8.GetBytes(end);
                        memStream.Write(headerbytes, 0, headerbytes.Length);
                        fileStream.Close();
                    } else if(temp.Type == 2){
                        if (temp.bytes == null)
                        {
                            throw new Exception("没有输入任何字节");
                        }
                        // 写入文件
                        const string filePartHeader =
                            "Content-Disposition:form-data;name=\"{0}\";filename=\"{1}\"\r\n" +
                            "Content-Type:{2}\r\n\r\n";
                        var header = string.Format(filePartHeader, temp.Prop, temp.filename,temp.contentType);
                        var headerbytes = Encoding.UTF8.GetBytes(header);
                        memStream.Write(headerbytes, 0, headerbytes.Length);
                        memStream.Write(temp.bytes, 0, temp.bytes.Length);                        
                        //string end = "\r\n";
                        //headerbytes = Encoding.UTF8.GetBytes(end);
                        //memStream.Write(headerbytes, 0, headerbytes.Length);
                    }
                    else if (temp.Type == 0)
                    {
                        // 写入字符串的Key
                        var stringKeyHeader = "Content-Disposition: form-data; name=\"{0}\"" +
                                       "\r\n\r\n{1}\r\n";
                        var header = string.Format(stringKeyHeader, temp.Prop, temp.Value);
                        var headerbytes = Encoding.UTF8.GetBytes(header);
                        memStream.Write(headerbytes, 0, headerbytes.Length);
                    }
                    if (i == postParaList.Count - 1)
                        // 写入最后的结束边界符
                        memStream.Write(endBoundary, 0, endBoundary.Length);
                }
                webRequest.ContentLength = memStream.Length;
                var requestStream = webRequest.GetRequestStream();
                memStream.Position = 0;
                var tempBuffer = new byte[memStream.Length];
                memStream.Read(tempBuffer, 0, tempBuffer.Length);
                memStream.Close();
                requestStream.Write(tempBuffer, 0, tempBuffer.Length);
                requestStream.Close();                
                using (HttpWebResponse res = (HttpWebResponse)webRequest.GetResponse())
                {
                    using (Stream resStream = res.GetResponseStream())
                    {
                        byte[] buffer = new byte[1024];
                        int read;
                        while ((read = resStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            responseContent += Encoding.UTF8.GetString(buffer, 0, read);
                        }
                    }
                    res.Close();
                }
                return responseContent;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static bool CheckValidationResult2(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }

        public static string postMessage(string strUrl, string strPost,Dictionary<string,string> headers)
        {
            try
            {
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                CookieContainer objCookieContainer = null;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strUrl);
                if (headers != null)
                {
                    request.Headers = new WebHeaderCollection();
                    foreach (var item in headers)
                    {
                        request.Headers.Add(item.Key, item.Value);
                    }
                }
                request.Method = "Post";
                request.Accept = "*/*";
                request.Headers.Add("Accept-Language: zh-CN,zh;q=0.8");
                request.Headers.Add("Accept-Charset: GBK,utf-8;q=0.7,*;q=0.3");
                request.ContentType = "application/x-www-form-urlencoded";
                request.Timeout = 10000;

                request.Referer = strUrl;//.Remove(strUrl.LastIndexOf("/"));
                //Console.WriteLine(strUrl);
                if (objCookieContainer == null)
                    objCookieContainer = new CookieContainer();

                request.CookieContainer = objCookieContainer;
                //Console.WriteLine(objCookieContainer.ToString());
                if (!string.IsNullOrEmpty(strPost))
                {
                    byte[] byteData = Encoding.UTF8.GetBytes(strPost.ToString().TrimEnd('&'));
                    request.ContentLength = byteData.Length;
                    using (Stream reqStream = request.GetRequestStream())
                    {
                        reqStream.Write(byteData, 0, byteData.Length);
                        reqStream.Close();
                    }
                }

                string strResponse = "";
                using (HttpWebResponse res = (HttpWebResponse)request.GetResponse())
                {
                    objCookieContainer = request.CookieContainer;
                    //QueryRecordForm.LoginCookie = objCookieContainer.GetCookies(new Uri(strUrl));
                    res.Cookies = objCookieContainer.GetCookies(new Uri(strUrl));
                    foreach (Cookie c in res.Cookies)
                    {

                    }

                    using (Stream resStream = res.GetResponseStream())
                    {
                        byte[] buffer = new byte[1024];
                        int read;
                        while ((read = resStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            strResponse += Encoding.UTF8.GetString(buffer, 0, read);
                        }
                    }
                    res.Close();
                }
                return strResponse;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static string sendMessageCookie(string strUrl, string strPost, CookieContainer cookieContainer)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strUrl);
                if (cookieContainer != null)
                {
                    request.CookieContainer = cookieContainer;
                }
                request.Method = "Post";
                request.Accept = "*/*";
                request.Headers.Add("Accept-Language: zh-CN,zh;q=0.8");
                request.Headers.Add("Accept-Charset: GBK,utf-8;q=0.7,*;q=0.3");
                request.Headers.Add("Cache-Control: max-age=0");
                request.Accept = "text/xml,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/31.0.1650.63 Safari/537.36";
                request.Timeout = 10000;
                request.Referer = strUrl;//.Remove(strUrl.LastIndexOf("/"));

                if (!string.IsNullOrEmpty(strPost))
                {
                    request.ContentType = "application/json; text/html; charset=UTF-8";

                    byte[] byteData = Encoding.UTF8.GetBytes(strPost.ToString().TrimEnd('&'));
                    request.ContentLength = byteData.Length;
                    using (Stream reqStream = request.GetRequestStream())
                    {
                        reqStream.Write(byteData, 0, byteData.Length);
                        reqStream.Close();
                    }
                }

                string strResponse = "";
                using (HttpWebResponse res = (HttpWebResponse)request.GetResponse())
                {
                    if (cookieContainer != null)
                    {
                        cookieContainer = request.CookieContainer;
                    }
                    using (Stream resStream = res.GetResponseStream())
                    {
                        byte[] buffer = new byte[1024];
                        int read;
                        while ((read = resStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            strResponse += Encoding.UTF8.GetString(buffer, 0, read);
                        }
                    }
                    res.Close();
                }
                return strResponse;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        //2.提交表单主逻辑实现
        /// <summary>
        /// 使用Post方法获取字符串结果
        /// </summary>
        /// <param name="url"></param>
        /// <param name="formItems">Post表单内容</param>
        /// <param name="cookieContainer"></param>
        /// <param name="timeOut">默认20秒</param>
        /// <param name="encoding">响应内容的编码类型（默认utf-8）</param>
        /// <returns></returns>
        public static string PostForm(string url, List<FormItemModel> formItems,Dictionary<string,string> headers = null, CookieContainer cookieContainer = null, string refererUrl = null, Encoding encoding = null, int timeOut = 20000)
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            //System.Net.ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult2);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            #region 初始化请求对象
            if (headers != null)
            {
                request.Headers = new WebHeaderCollection();
                foreach (var item in headers)
                {
                    request.Headers.Add(item.Key, item.Value);
                }
            }
            request.Method = "POST";
            request.Timeout = timeOut;
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            request.KeepAlive = true;
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/31.0.1650.57 Safari/537.36";
            if (!string.IsNullOrEmpty(refererUrl))
                request.Referer = refererUrl;
            if (cookieContainer != null)
                request.CookieContainer = cookieContainer;
            #endregion

            string boundary = "----" + DateTime.Now.Ticks.ToString("x");//分隔符
            request.ContentType = string.Format("multipart/form-data; boundary={0}", boundary);
            //请求流
            var postStream = new MemoryStream();
            #region 处理Form表单请求内容
            //是否用Form上传文件
            var formUploadFile = formItems != null && formItems.Count > 0;
            if (formUploadFile)
            {
                //文件数据模板
                string fileFormdataTemplate =
                    "\r\n--" + boundary +
                    "\r\nContent-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"" +
                    "\r\nContent-Type: application/octet-stream" +
                    "\r\n\r\n";
                //文本数据模板
                string dataFormdataTemplate =
                    "\r\n--" + boundary +
                    "\r\nContent-Disposition: form-data; name=\"{0}\"" +
                    "\r\n\r\n{1}";
                foreach (var item in formItems)
                {
                    string formdata = null;
                    if (item.IsFile)
                    {
                        //上传文件
                        formdata = string.Format(
                            fileFormdataTemplate,
                            item.Key, //表单键
                            item.FileName);
                    }
                    else
                    {
                        //上传文本
                        formdata = string.Format(
                            dataFormdataTemplate,
                            item.Key,
                            item.Value);
                    }

                    //统一处理
                    byte[] formdataBytes = null;
                    //第一行不需要换行
                    if (postStream.Length == 0)
                        formdataBytes = Encoding.UTF8.GetBytes(formdata.Substring(2, formdata.Length - 2));
                    else
                        formdataBytes = Encoding.UTF8.GetBytes(formdata);
                    postStream.Write(formdataBytes, 0, formdataBytes.Length);

                    //写入文件内容
                    if (item.FileContent != null && item.FileContent.Length > 0)
                    {
                        using (var stream = item.FileContent)
                        {
                            byte[] buffer = new byte[1024];
                            int bytesRead = 0;
                            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                            {
                                postStream.Write(buffer, 0, bytesRead);
                            }
                        }
                    }
                }
                //结尾
                var footer = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");
                postStream.Write(footer, 0, footer.Length);

            }
            else
            {
                request.ContentType = "application/x-www-form-urlencoded";
            }
            #endregion

            request.ContentLength = postStream.Length;

            #region 输入二进制流
            if (postStream != null)
            {
                postStream.Position = 0;
                //直接写入流
                Stream requestStream = request.GetRequestStream();

                byte[] buffer = new byte[1024];
                int bytesRead = 0;
                while ((bytesRead = postStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    requestStream.Write(buffer, 0, bytesRead);
                }

                ////debug
                //postStream.Seek(0, SeekOrigin.Begin);
                //StreamReader sr = new StreamReader(postStream);
                //var postStr = sr.ReadToEnd();
                postStream.Close();//关闭文件访问
            }
            #endregion

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (cookieContainer != null)
            {
                response.Cookies = cookieContainer.GetCookies(response.ResponseUri);
            }

            using (Stream responseStream = response.GetResponseStream())
            {
                using (StreamReader myStreamReader = new StreamReader(responseStream, encoding ?? Encoding.UTF8))
                {
                    string retString = myStreamReader.ReadToEnd();
                    return retString;
                }
            }
        }


    }

    public class PostDateClass
    {
        String prop;

        public String Prop
        {
            get { return prop; }
            set { prop = value; }
        }
        String value;

        public String Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        /// <summary>
        /// 0为字符串，1为文件,2:文件字节数组
        /// </summary>
        int type;

        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        public byte[] bytes { get; set; }

        public string contentType { get; set; }
        public string filename { get; set; }


        public PostDateClass(String prop, String value, int type = 0,byte[] bytes = null,string contentType="",string filename="")
        {
            this.prop = prop;
            this.value = value;
            this.type = type;
            this.bytes = bytes;
            this.contentType = contentType;
            this.filename = filename;
        }


    }

    //1.表示一个表单项的对象
    /// <summary>
    /// 表单数据项
    /// </summary>
    public class FormItemModel
    {
        /// <summary>
        /// 表单键，request["key"]
        /// </summary>
        public string Key { set; get; }
        /// <summary>
        /// 表单值,上传文件时忽略，request["key"].value
        /// </summary>
        public string Value { set; get; }
        /// <summary>
        /// 是否是文件
        /// </summary>
        public bool IsFile
        {
            get
            {
                if (FileContent == null || FileContent.Length == 0)
                    return false;

                if (FileContent != null && FileContent.Length > 0 && string.IsNullOrWhiteSpace(FileName))
                    throw new Exception("上传文件时 FileName 属性值不能为空");
                return true;
            }
        }
        /// <summary>
        /// 上传的文件名
        /// </summary>
        public string FileName { set; get; }
        /// <summary>
        /// 上传的文件内容
        /// </summary>
        public Stream FileContent { set; get; }
    }

    /// <summary>    
    /// 对文件和文本数据进行Multipart形式的编码    
    /// </summary>    
    public class MultipartForm
    {
        private Encoding encoding;
        private MemoryStream ms;
        private string boundary;
        private byte[] formData;
        /// <summary>    
        /// 获取编码后的字节数组    
        /// </summary>    
        public byte[] FormData
        {
            get
            {
                if (formData == null)
                {
                    byte[] buffer = encoding.GetBytes("--" + this.boundary + "--\r\n");
                    ms.Write(buffer, 0, buffer.Length);
                    formData = ms.ToArray();
                }
                return formData;
            }
        }
        /// <summary>    
        /// 获取此编码内容的类型    
        /// </summary>    
        public string ContentType
        {
            get { return string.Format("multipart/form-data; boundary={0}", this.boundary); }
        }
        /// <summary>    
        /// 获取或设置对字符串采用的编码类型    
        /// </summary>    
        public Encoding StringEncoding
        {
            set { encoding = value; }
            get { return encoding; }
        }
        /// <summary>    
        /// 实例化    
        /// </summary>    
        public MultipartForm()
        {
            boundary = string.Format("--{0}--", Guid.NewGuid());
            ms = new MemoryStream();
            encoding = Encoding.Default;
        }
        /// <summary>    
        /// 添加一个文件    
        /// </summary>    
        /// <param name="name">文件域名称</param>    
        /// <param name="filename">文件的完整路径</param>    
        public void AddFlie(string name, string filename)
        {
            if (!File.Exists(filename))
                throw new FileNotFoundException("尝试添加不存在的文件。", filename);
            FileStream fs = null;
            byte[] fileData = { };
            try
            {
                fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
                fileData = new byte[fs.Length];
                fs.Read(fileData, 0, fileData.Length);
                this.AddFlie(name, Path.GetFileName(filename), fileData, fileData.Length);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (fs != null) fs.Close();
            }
        }
        /// <summary>    
        /// 添加一个文件    
        /// </summary>    
        /// <param name="name">文件域名称</param>    
        /// <param name="filename">文件名</param>    
        /// <param name="fileData">文件二进制数据</param>    
        /// <param name="dataLength">二进制数据大小</param>    
        public void AddFlie(string name, string filename, byte[] fileData, int dataLength)
        {
            if (dataLength <= 0 || dataLength > fileData.Length)
            {
                dataLength = fileData.Length;
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("--{0}\r\n", this.boundary);
            sb.AppendFormat("Content-Disposition: form-data; name=\"{0}\";filename=\"{1}\"\r\n", name, filename);
            sb.AppendFormat("Content-Type: {0}\r\n", this.GetContentType(filename));
            sb.Append("\r\n");
            byte[] buf = encoding.GetBytes(sb.ToString());
            ms.Write(buf, 0, buf.Length);
            ms.Write(fileData, 0, dataLength);
            byte[] crlf = encoding.GetBytes("\r\n");
            ms.Write(crlf, 0, crlf.Length);
        }
        /// <summary>    
        /// 添加字符串    
        /// </summary>    
        /// <param name="name">文本域名称</param>    
        /// <param name="value">文本值</param>    
        public void AddString(string name, string value)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("--{0}\r\n", this.boundary);
            sb.AppendFormat("Content-Disposition: form-data; name=\"{0}\"\r\n", name);
            sb.Append("\r\n");
            sb.AppendFormat("{0}\r\n", value);
            byte[] buf = encoding.GetBytes(sb.ToString());
            ms.Write(buf, 0, buf.Length);
        }
        /// <summary>    
        /// 从注册表获取文件类型    
        /// </summary>    
        /// <param name="filename">包含扩展名的文件名</param>    
        /// <returns>如：application/stream</returns>    
        private string GetContentType(string filename)
        {
            Microsoft.Win32.RegistryKey fileExtKey = null; ;
            string contentType = "application/stream";
            try
            {
                fileExtKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(Path.GetExtension(filename));
                contentType = fileExtKey.GetValue("Content Type", contentType).ToString();
            }
            finally
            {
                if (fileExtKey != null) fileExtKey.Close();
            }
            return contentType;
        }               
    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Infrastructure
{
    public class HttpClientHelper
    {
        /// <summary>
         /// get请求
         /// </summary>
         /// <param name="url"></param>
         /// <returns></returns>
         public static string GetResponse(string url)
         {
             if (url.StartsWith("https"))
                 System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

             HttpClient httpClient = new HttpClient();
             httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
             HttpResponseMessage response = httpClient.GetAsync(url).Result;

             if (response.IsSuccessStatusCode)
             {
                 string result = response.Content.ReadAsStringAsync().Result;
                 return result;
             }
             return null;
         }


         /// <summary>
         /// post请求
         /// </summary>
         /// <param name="url"></param>
         /// <param name="postData">post数据</param>
         /// <returns></returns>
         public static string PostResponse(string url, string postData)
         {
             if (url.StartsWith("https"))
                 System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

             HttpContent httpContent = new StringContent(postData);
             httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
             HttpClient httpClient = new HttpClient();

             HttpResponseMessage response = httpClient.PostAsync(url, httpContent).Result;

             if (response.IsSuccessStatusCode)
             {
                 string result = response.Content.ReadAsStringAsync().Result;
                 return result;
             }
             return null;
         }

    }
}

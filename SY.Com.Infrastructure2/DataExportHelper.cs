using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Infrastructure
{
    public static class DataExportHelper
    {
        /// <summary>
        /// 导出excel
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="expStream">文件流</param>
        /// <returns></returns>
        public static HttpResponseMessage ExportDataOfExcel(string fileName, Stream expStream)
        {
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new StreamContent(expStream);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.ms-excel");
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            result.Content.Headers.ContentDisposition.FileName = fileName + ".xls";
            return result;
        }

        public static HttpResponseMessage ExportDataOfExcel2007(string fileName, Stream expStream)
        {
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new StreamContent(expStream);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/ms-excel");
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            result.Content.Headers.ContentDisposition.FileName = fileName + ".xlsx";
            return result;
        }

    }
}

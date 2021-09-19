using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;

namespace SY.Com.Infrastructure
{
    public class UploadHelper
    {
        /// <summary>
        /// 上传文件帮助类
        /// </summary>
        /// <param name="fu"></param>
        /// <param name="uploadHandleurl"></param>
        /// <param name="filename"></param>
        /// <param name="dirname"></param>
        public static void Upload(FileUpload fu, string uploadHandleurl, string filename, string dirname)
        {
            byte[] bt = fu.FileBytes;//获取文件的Byte[]
            Upload(bt, uploadHandleurl, filename, dirname);
        }

        public static void Upload(byte[] sbt, string uploadHandleurl, string filename, string dirname)
        {
            byte[] bt = sbt;
            UriBuilder url = new UriBuilder(uploadHandleurl);//上传路径
            url.Query = string.Format("filename={0}&dirname={1}", filename, dirname);//上传url参数
            System.Net.WebClient wc = new System.Net.WebClient();
            Stream s = wc.OpenWrite(url.Uri);
            s.Write(bt, 0, bt.Length);
            s.Close();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.BLL.Platform
{
    /// <summary>
    /// 图片上传
    /// </summary>
    public class ImgFileUpload : FileUpload
    {
        private List<string> format = new List<string> { ".jpeg",".jpg", ".png", ".gif", ".bmp" };
        public ImgFileUpload(FileBus filebus,string extension) : base(filebus)
        {
            if(!format.Contains(extension))
            {
                throw new MyException("文件格式不匹配本业务");
            }
            _extension = extension;
        }

        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="mstream"></param>
        /// <returns></returns>
        public override string SaveFile(MemoryStream mstream)
        {
            if(mstream.Length > 1024 * 1024 * 10)//超过10M的文件不允许
            {
                throw new MyException("图片不能超过10M");
            }
            string dir = System.Environment.CurrentDirectory + "/File/";
            string sortpath = fb.getPath();//获取路径
            string strDateTime = DateTime.Now.ToString("yyMMddhhmmssfff"); //取得时间字符串
            string strRan = Convert.ToString(new Random().Next(100, 999)); //生成三位随机数
            string filename = strDateTime + strRan + _extension;
            string filepath = dir + sortpath;
            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }
            FileStream fs = new FileStream(filepath + filename, FileMode.OpenOrCreate);
            mstream.CopyTo(fs);
            fs.Flush();
            fs.Close();
            mstream.Close();
            return sortpath + filename;
        }

    }
}

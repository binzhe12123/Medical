using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Client.Model
{
    public class Up9101
    {
        public class In9101
        {
           // public string in	文件数据 字节数组            Y
            public string filename { get; set; }// 文件名 字符型	200		Y
            public string fixmedins_code { get; set; }//  医药机构编号 字符型	30	　	Y
        }
        public class Out9101
        {
            public string file_qury_no { get; set; }//  文件查询号 字符型	30		Y
            public string filename { get; set; }//   文件名 字符型	200		Y
            public string fixmedins_code { get; set; }// 医药机构编号 字符型	30	　	Y
            public DateTime dld_endtime { get; set; } //截止时间 字符型	30		

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB.JBXX
{
    /// <summary>
    /// 目录下载
    /// </summary>
    public class ML1301
    {
        public class In1301 
        {
           public string ver { get; set; }// 版本号 字符型	20		Y 本地最大版本号
        }
        public class Out1301
        {
            public string file_qury_no { get; set; }// 文件查询号   字符型	40		Y
            public string filename { get; set; }//    文件名 字符型	100		Y
            public DateTime dld_end_time { get; set; }//   下载截止日期 日期型	20		Y yyyy-MM-dd
            public int data_cnt { get; set; }//    数据量 数值型
        }
    }
}
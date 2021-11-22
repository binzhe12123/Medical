using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB.XXCX
{
    public class MB5301
    {
        public class In5301
        {
            public string psn_no { get; set; }//    人员编号 字符型	30		Y
        }

        public class Out5301
        {
            public string opsp_dise_code { get; set; }// 门慢门特病种目录代码  字符型	30	　	Y
            public string opsp_dise_name { get; set; }//  门慢门特病种名称 字符型	300	　	Y
            public DateTime begndate { get; set; }//    开始日期 日期型         Y yyyy-MM-dd
            public DateTime enddate { get; set; }// 结束日期 日期型             yyyy-MM-dd

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB.XXCX
{
    public class RY5302
    {
        public class In5302data
        {
           public In5302 data { get; set; }
        }
        public class In5302
        {
            public string psn_no { get; set; }//   人员编号 字符型	30	Y
            public string biz_appy_type { get; set; }//   业务申请类型 字符型	3	Y

        }
        public class Out5302
        {
            public string psn_no { get; set; }//    人员编号 字符型	30	　	Y
            public string insutype { get; set; }//   险种类型 字符型	6	Y
            public string fix_srt_no { get; set; }//  定点排序号 字符型	3	　	Y
            public string fixmedins_code { get; set; }//  定点医药机构编号 字符型	12	　	Y
            public string fixmedins_name { get; set; }//  定点医药机构名称 字符型	200	　	Y
            public DateTime begndate { get; set; }//    开始日期 日期型         Y yyyy-MM-dd
            public DateTime enddate { get; set; }// 结束日期 日期型             yyyy-MM-dd
            public string memo { get; set; }//    备注 字符型	500	　	　	　

        }
    }
}
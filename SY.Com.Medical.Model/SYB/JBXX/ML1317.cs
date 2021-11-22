using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB.JBXX
{
    public class ML1317
    {
        public class In1317
        {
            public DateTime query_date { get; set; }// 查询时间点 日期型
            public string fixmedins_code { get; set; }// 定点医药机构编号    字符型	30			
            public string medins_list_codg { get; set; }// 定点医药机构目录编号  字符型	30			
            public string medins_list_name { get; set; }// 定点医药机构目录名称  字符型	200			
            public string insu_admdvs { get; set; }// 参保机构医保区划    字符型	6	Y
            public string list_type { get; set; }//   目录类别 字符型	30			
            public string med_list_codg { get; set; }// 医疗目录编码  字符型	30			
            public DateTime begndate { get; set; }// 开始日期    日期型
            public string vali_flag { get; set; }//   有效标志 字符型	3	Y
            public DateTime updt_time { get; set; }//   更新时间 日期型         Y
            public int page_num { get; set; }//    当前页数 数值型	4		Y
            public int page_size { get; set; }  //本页数据量 数值型	4		Y


        }
    }
}
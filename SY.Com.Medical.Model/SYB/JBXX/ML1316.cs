using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB.JBXX
{
    /// <summary>
    /// 
    /// </summary>
    public class ML1316
    {
        /// <summary>
        /// 
        /// </summary>
        public class In1316
        {
            /// <summary>
            /// 
            /// </summary>
            public DateTime query_date { get; set; }//   查询时间点 日期型
            /// <summary>
            /// 
            /// </summary>
            public string medins_list_codg { get; set; }// 定点医药机构目录编号  字符型	30		
            /// <summary>
            /// 
            /// </summary>
            public string hilist_code { get; set; }// 医保目录编码  字符型	30		
            /// <summary>
            /// 
            /// </summary>
            public string list_type { get; set; }// 目录类别    字符型	30		
            /// <summary>
            /// 
            /// </summary>
            public string insu_admdvs { get; set; }// 参保机构医保区划    字符型	6	Y
            /// <summary>
            /// 
            /// </summary>
            public DateTime begndate { get; set; }//    开始日期 日期型
            /// <summary>
            /// 
            /// </summary>
            public string vali_flag { get; set; }// 有效标志    字符型	3	Y
            /// <summary>
            /// 
            /// </summary>
            public DateTime updt_time { get; set; }//   更新时间 日期型         Y
            /// <summary>
            /// 
            /// </summary>
            public int page_num { get; set; }//    当前页数 数值型	4		Y
            /// <summary>
            /// 
            /// </summary>
            public int page_size { get; set; }//   本页数据量 数值型	4		Y


        }
        /// <summary>
        /// 
        /// </summary>
        public class Out1316
        {
            /// <summary>
            /// 
            /// </summary>
            public string med_list_codg { get; set; }// 医疗目录编码 字符型	30	　	Y
            /// <summary>
            /// 
            /// </summary>
            public string hilist_code { get; set; }// 医保目录编码 字符型	30	　	Y
            /// <summary>
            /// 
            /// </summary>
            public string list_type { get; set; }//   目录类别 字符型	3	Y Y
            /// <summary>
            /// 
            /// </summary>
            public string insu_admdvs { get; set; }// 参保机构医保区划    字符型	6	Y Y
            /// <summary>
            /// 
            /// </summary>
            public DateTime begndate { get; set; }// 开始日期    日期型 Y
            /// <summary>
            /// 
            /// </summary>
            public DateTime enddate { get; set; }//结束日期    日期型 N
            /// <summary>
            /// 
            /// </summary>
            public string memo { get; set; }//备注  字符型	500	　	N
            /// <summary>
            /// 
            /// </summary>
            public string vali_flag { get; set; }//   有效标志 字符型	3	Y Y
            /// <summary>
            /// 
            /// </summary>
            public string rid { get; set; }// 唯一记录号   字符型	40	　	Y
            /// <summary>
            /// 
            /// </summary>
            public DateTime updt_time { get; set; }//   更新时间 日期型         Y
            /// <summary>
            /// 
            /// </summary>
            public string crter_id { get; set; }//    创建人 字符型	20	　	N
            /// <summary>
            /// 
            /// </summary>
            public string crter_name { get; set; }//  创建人姓名 字符型	50	　	N
            /// <summary>
            /// 
            /// </summary>
            public DateTime crte_time { get; set; }//   创建时间 日期型         Y
            /// <summary>
            /// 
            /// </summary>
            public string crte_optins_no { get; set; }//  创建机构 字符型	20	　	N
            /// <summary>
            /// 
            /// </summary>
            public string opter_id { get; set; }//    经办人 字符型	20	　	N
            /// <summary>
            /// 
            /// </summary>
            public string opter_name { get; set; }//  经办人姓名 字符型	50	　	N
            /// <summary>
            /// 
            /// </summary>
            public DateTime opt_time { get; set; }   //经办时间 日期型         N
            /// <summary>
            /// 
            /// </summary>
            public string optins_no { get; set; }//   经办机构 字符型	20	　	N
            /// <summary>
            /// 
            /// </summary>
            public string poolarea_no { get; set; }// 统筹区 字符型	6	Y N
        }
    }
}
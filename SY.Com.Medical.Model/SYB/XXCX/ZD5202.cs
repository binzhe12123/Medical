using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB.YYJGFW
{
    /// <summary>
    /// 
    /// </summary>
    public class ZD5202
    {
        /// <summary>
        /// 
        /// </summary>
        public class In5202
        {
            /// <summary>
            /// 
            /// </summary>
            public string mdtrt_id { get; set; }//  就诊ID 字符型	30	　	Y
            /// <summary>
            /// 
            /// </summary>
            public string psn_no { get; set; }//  人员编号 字符型	30		Y

        }
        /// <summary>
        /// 
        /// </summary>
        public class Out5202 
        {
            /// <summary>
            /// 
            /// </summary>
            public string diag_info_id { get; set; }//  诊断信息ID 字符型	30		Y
            /// <summary>
            /// 
            /// </summary>
            public string mdtrt_id { get; set; }//    就诊ID 字符型	30		Y
            /// <summary>
            /// 
            /// </summary>
            public string psn_no { get; set; }//  人员编号 字符型	30		Y
            /// <summary>
            /// 
            /// </summary>
            public string inout_diag_type { get; set; }// 出入院诊断类别 字符型	3	Y Y
            /// <summary>
            /// 
            /// </summary>
            public string diag_type { get; set; }// 诊断类别    字符型	3	Y Y
            /// <summary>
            /// 
            /// </summary>
            public string maindiag_flag { get; set; }// 主诊断标志   字符型	3	Y Y
            /// <summary>
            /// 
            /// </summary>
            public string diag_srt_no { get; set; }// 诊断排序号   数值型	2		Y
            /// <summary>
            /// 
            /// </summary>
            public string diag_code { get; set; }//   诊断代码 字符型	20		Y
            /// <summary>
            /// 
            /// </summary>
            public string diag_name { get; set; }//   诊断名称 字符型	100		Y
            /// <summary>
            /// 
            /// </summary>
            public string adm_cond { get; set; }//    入院病情 字符型	500			　
            /// <summary>
            /// 
            /// </summary>
            public string diag_dept { get; set; }// 诊断科室    字符型	50		Y
            /// <summary>
            /// 
            /// </summary>
            public string dise_dor_no { get; set; }// 诊断医生编码 字符型	30		Y
            /// <summary>
            /// 
            /// </summary>
            public string dise_dor_name { get; set; }//   诊断医生姓名 字符型	50		Y
            /// <summary>
            /// 
            /// </summary>
            public DateTime diag_time { get; set; }//   诊断时间 日期时间型           Y yyyy-MM-dd HH:mm:ss
            /// <summary>
            /// 
            /// </summary>
            public string opter_id { get; set; }//   经办人ID 字符型	20			　
            /// <summary>
            /// 
            /// </summary>
            public string opter_name { get; set; }// 经办人姓名   字符型	50			　
            /// <summary>
            /// 
            /// </summary>
            public DateTime opt_time { get; set; }//经办时间    日期时间型 yyyy-MM-dd HH:mm:ss


        }
    }
}
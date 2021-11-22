using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB.YYJGFW
{
    public class ZD5202
    {
        public class In5202
        {
            public string mdtrt_id { get; set; }//  就诊ID 字符型	30	　	Y
            public string psn_no { get; set; }//  人员编号 字符型	30		Y

        }
        public class Out5202 
        {
            public string diag_info_id { get; set; }//  诊断信息ID 字符型	30		Y
            public string mdtrt_id { get; set; }//    就诊ID 字符型	30		Y
            public string psn_no { get; set; }//  人员编号 字符型	30		Y
            public string inout_diag_type { get; set; }// 出入院诊断类别 字符型	3	Y Y
            public string diag_type { get; set; }// 诊断类别    字符型	3	Y Y
            public string maindiag_flag { get; set; }// 主诊断标志   字符型	3	Y Y
            public string diag_srt_no { get; set; }// 诊断排序号   数值型	2		Y
            public string diag_code { get; set; }//   诊断代码 字符型	20		Y
            public string diag_name { get; set; }//   诊断名称 字符型	100		Y
            public string adm_cond { get; set; }//    入院病情 字符型	500			　
            public string diag_dept { get; set; }// 诊断科室    字符型	50		Y
            public string dise_dor_no { get; set; }// 诊断医生编码 字符型	30		Y
            public string dise_dor_name { get; set; }//   诊断医生姓名 字符型	50		Y
            public DateTime diag_time { get; set; }//   诊断时间 日期时间型           Y yyyy-MM-dd HH:mm:ss
            public string opter_id { get; set; }//   经办人ID 字符型	20			　
            public string opter_name { get; set; }// 经办人姓名   字符型	50			　
            public DateTime opt_time { get; set; }//经办时间    日期时间型 yyyy-MM-dd HH:mm:ss


        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB.XXCX
{
    public class ZY5304
    {
        public class In5304
        {
            public string psn_no { get; set; }//   人员编号 字符型	30		
            public DateTime begntime { get; set; }// 开始时间    日期时间型 Y
            public DateTime endtime { get; set; }// 结束时间    日期时间型 Y

        }
        public class Out5304
        {
            public string insutype { get; set; }// 险种类型    字符型	6	Y Y
            public string dcla_souc { get; set; }// 申报来源    字符型	6	Y
            public string psn_no { get; set; }//  人员编号 字符型	30	　	Y
            public string psn_cert_type { get; set; }//   人员证件类型 字符型	6	Y Y
            public string certno { get; set; }// 证件号码    字符型	50	　	Y
            public string psn_name { get; set; }//    人员姓名 字符型	50	　	Y
            public string gend { get; set; }// 性别 字符型	6	Y Y
            public DateTime brdy { get; set; }// 出生日期    日期型 yyyy-MM-dd
            public string tel { get; set; }// 联系电话 字符型	50	　	　	　
            public string addr { get; set; }// 联系地址    字符型	200	　	　	　
            public string insu_optins { get; set; }// 参保机构医保区划    字符型	6		　	
            public string emp_name { get; set; }// 单位名称    字符型	200	　	　	　
            public string diag_code { get; set; }// 诊断代码    字符型	20	　	　	　
            public string diag_name { get; set; }// 诊断名称    字符型	100	　	　	　
            public string dise_cond_dscr { get; set; }// 疾病病情描述  字符型	2000	　	　	　
            public string reflin_medins_no { get; set; }// 转往定点医药机构编号  字符型	30	　	　	　
            public string reflin_medins_name { get; set; }//转往医院名称  字符型	200	　	Y
            public string out_flag { get; set; }//    异地标志 字符型	3	Y	　	0-否；1-是
            public DateTime refl_date { get; set; }//   转院日期 日期型         Y yyyy-MM-dd
            public string refl_rea { get; set; }//   转院原因 字符型	100	　	Y
            public DateTime begndate { get; set; }//    开始日期 日期型         Y yyyy-MM-dd
            public DateTime enddate { get; set; }// 结束日期 日期型             yyyy-MM-dd
            public string hosp_agre_refl_flag { get; set; }// 医院同意转院标志 字符型	3	Y Y
            public string opter_id { get; set; }// 经办人ID   字符型	20	　		
            public string opter_name { get; set; }// 经办人姓名   字符型	50	　		
            public DateTime opt_time { get; set; }// 经办时间    日期时间型 yyyy-MM-dd HH:mm:ss

        }
    }
}
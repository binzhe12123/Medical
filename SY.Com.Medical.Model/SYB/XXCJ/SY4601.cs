using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB.XXCJ
{
    /// <summary>
    /// 
    /// </summary>
    public class SY4601
    {
        /// <summary>
        /// 
        /// </summary>
        public class In4601
        {
            /// <summary>
            /// 
            /// </summary>
            public string mdtrt_sn { get; set; }//  就医流水号 字符型	30		Y 院内唯一号
            /// <summary>
            /// 
            /// </summary>
            public string mdtrt_id { get; set; }// 就诊ID    字符型	30			医保病人必填
            /// <summary>
            /// 
            /// </summary>
            public string psn_no { get; set; }//  人员编号 字符型	30			医保病人必填
            /// <summary>
            /// 
            /// </summary>
            public string abo_code { get; set; }//    ABO血型代码 字符型	2			
            /// <summary>
            /// 
            /// </summary>
            public string rh_code { get; set; }// Rh血型代码  字符型	1			
            /// <summary>
            /// 
            /// </summary>
            public string bld_natu_code { get; set; }// 输血性质代码  字符型	2			
            /// <summary>
            /// 
            /// </summary>
            public string bld_abo_code { get; set; }// 输血 ABO血型代码 字符型	3	Y 参照blotype_abo
            /// <summary>
            /// 
            /// </summary>
            public string bld_rh_code { get; set; }// 输血Rh血型代码    字符型	3	Y 参照blotype_abo
            /// <summary>
            /// 
            /// </summary>
            public string bld_cat_code { get; set; }// 输血品种代码  字符型	2			
            /// <summary>
            /// 
            /// </summary>
            public decimal bld_amt { get; set; }// 输血量 数值型	7,0			
            /// <summary>
            /// 
            /// </summary>
            public string bld_amt_unt { get; set; }// 输血量计量单位 字符型	10			
            /// <summary>
            /// 
            /// </summary>
            public string bld_defs_type_code { get; set; }// 输血反应类型代码    字符型	1			
            /// <summary>
            /// 
            /// </summary>
            public decimal bld_cnt { get; set; }// 输血次数    数值型	2,0			
            /// <summary>
            /// 
            /// </summary>
            public DateTime bld_time { get; set; }// 输血时间    日期时间型
            /// <summary>
            /// 
            /// </summary>
            public string bld_rea { get; set; }// 输血原因 字符型	100			
            /// <summary>
            /// 
            /// </summary>
            public string vali_flag { get; set; }// 有效标志    字符型	3	Y Y

        }
    }
}
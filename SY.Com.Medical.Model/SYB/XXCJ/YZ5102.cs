using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB.XXCJ
{
    /// <summary>
    /// 
    /// </summary>
    public class YZ5102
    {
        /// <summary>
        /// 
        /// </summary>
        public class In5102
        {
            /// <summary>
            /// 
            /// </summary>
            public string prac_psn_type { get; set; }// 执业人员分类 字符型	6	Y Y 参照医务人员类别(medins_psn_type)
            /// <summary>
            /// 
            /// </summary>
            public string psn_cert_type { get; set; }// 人员证件类型  字符型	6	Y
            /// <summary>
            /// 
            /// </summary>
            public string certno { get; set; }//  证件号码 字符型	50	　	　	
            /// <summary>
            /// 
            /// </summary>
            public string prac_psn_name { get; set; }// 执业人员姓名  字符型	50			
            /// <summary>
            /// 
            /// </summary>
            public string prac_psn_code { get; set; }// 执业人员代码  字符型	20	　	　	参照标准编码：医保医师编码、医保护士编码、医保药师编码
        }
        /// <summary>
        /// 
        /// </summary>
        public class Out5102
        {
            /// <summary>
            /// 
            /// </summary>
            public string psn_cert_type { get; set; }// 人员证件类型 字符型	6	Y Y
            /// <summary>
            /// 
            /// </summary>
            public string certno { get; set; }// 证件号码    字符型	50	　	Y
            /// <summary>
            /// 
            /// </summary>
            public string prac_psn_no { get; set; }// 执业人员自编号 字符型	20	　	　	　
            /// <summary>
            /// 
            /// </summary>
            public string prac_psn_code { get; set; }// 执业人员代码  字符型	20	　	Y 参照标准编码：医保医师编码、医保护士编码、医保药师编码
            /// <summary>
            /// 
            /// </summary>
            public string prac_psn_name { get; set; }//   执业人员姓名 字符型	50	　	Y
            /// <summary>
            /// 
            /// </summary>
            public string prac_psn_type { get; set; }//   执业人员分类 字符型	6	Y Y   参照医务人员类别(medins_psn_type)
            /// <summary>
            /// 
            /// </summary>
            public string prac_psn_cert { get; set; }// 执业人员资格证书编码  字符型	30	　	　	　
            /// <summary>
            /// 
            /// </summary>
            public string prac_cert_no { get; set; }// 执业证书编号  字符型	30	　	　	　
            /// <summary>
            /// 
            /// </summary>
            public string hi_dr_flag { get; set; }// 医保医师标志  字符型	3	Y Y
            /// <summary>
            /// 
            /// </summary>
            public DateTime begntime { get; set; }// 开始时间    日期时间型 Y
            /// <summary>
            /// 
            /// </summary>
            public DateTime endtime { get; set; }// 结束时间    日期时间型
            /// <summary>
            /// 
            /// </summary>
            public string chg_rea { get; set; }// 变更原因 字符型	200	　	　	　

        }

    }
}
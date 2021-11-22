using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB.XXCJ
{
    public class YZ5102
    {
        public class In5102
        {
            public string prac_psn_type { get; set; }// 执业人员分类 字符型	6	Y Y 参照医务人员类别(medins_psn_type)
            public string psn_cert_type { get; set; }// 人员证件类型  字符型	6	Y
            public string certno { get; set; }//  证件号码 字符型	50	　	　	
            public string prac_psn_name { get; set; }// 执业人员姓名  字符型	50			
            public string prac_psn_code { get; set; }// 执业人员代码  字符型	20	　	　	参照标准编码：医保医师编码、医保护士编码、医保药师编码
        }

        public class Out5102
        {
            public string psn_cert_type { get; set; }// 人员证件类型 字符型	6	Y Y
            public string certno { get; set; }// 证件号码    字符型	50	　	Y
            public string prac_psn_no { get; set; }// 执业人员自编号 字符型	20	　	　	　
            public string prac_psn_code { get; set; }// 执业人员代码  字符型	20	　	Y 参照标准编码：医保医师编码、医保护士编码、医保药师编码
            public string prac_psn_name { get; set; }//   执业人员姓名 字符型	50	　	Y
            public string prac_psn_type { get; set; }//   执业人员分类 字符型	6	Y Y   参照医务人员类别(medins_psn_type)
            public string prac_psn_cert { get; set; }// 执业人员资格证书编码  字符型	30	　	　	　
            public string prac_cert_no { get; set; }// 执业证书编号  字符型	30	　	　	　
            public string hi_dr_flag { get; set; }// 医保医师标志  字符型	3	Y Y
            public DateTime begntime { get; set; }// 开始时间    日期时间型 Y
            public DateTime endtime { get; set; }// 结束时间    日期时间型
            public string chg_rea { get; set; }// 变更原因 字符型	200	　	　	　

        }

    }
}
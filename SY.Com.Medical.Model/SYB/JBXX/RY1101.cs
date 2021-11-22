using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB
{
    /// <summary>
    /// 人员信息获取
    /// </summary>
        public class In1101 
        {
            public In1101data data { get; set; }         
        }
        public class In1101data
        {
            public string mdtrt_cert_type { get; set; }// 就诊凭证类型	字符型	“01”时填写电子凭证令牌，为“02”时填写身份证号，为“03”时填写社会保障卡卡号
            public string mdtrt_cert_no { get; set; }// 就诊凭证编号  字符型	Y 
            public string card_sn { get; set; }// 卡识别码 字符型	32			就诊凭证类型为“03”时必填
            public DateTime begntime { get; set; } //   开始时间 日期时间型               获取历史参保信息时传入
            public string psn_cert_type { get; set; } //  人员证件类型 字符型	6	Y
            public string certno { get; set; }//  证件号码 字符型	50		
            public string psn_name { get; set; }// 人员姓名    字符型	50		
        }
        public class Out1101
        {
           
            public BaseInfo baseinfo { get; set; }
            public InsuInfo insuinfo { get; set; }
            public IdetInfo idetinfo { get; set; }

        }
        public class BaseInfo
        {
            public string psn_no { get; set; } //人员编号    字符型	30		Y
            public string psn_cert_type { get; set; }// 人员证件类型 字符型	6	Y Y
            public string certno { get; set; }// 证件号码    字符型	50		Y
            public string psn_name { get; set; }   //人员姓名 字符型	50		Y
            public string gend { get; set; } // 性别 字符型	6	Y Y
            public string naty { get; set; }// 民族  字符型	3	Y
            public DateTime brdy { get; set; }//   出生日期 日期型  yyyy-MM-dd
            public string age { get; set; }// 年龄 数值型	4,1	　	Y
        }
        public class InsuInfo
        {
            public string balc { get;set;}// 余额  数值型	16,2		Y
            public string insutype { get; set; }//    险种类型 字符型	6	Y Y
            public string psn_type { get; set; }// 人员类别    字符型	6	Y Y
            public string psn_insu_stas { get; set; }// 人员参保状态  字符型	6	Y
            public DateTime psn_insu_date { get; set; }//   个人参保日期 日期型
            public DateTime paus_insu_date { get; set; }// 暂停参保日期  日期型
            public string cvlserv_flag { get; set; } //   公务员标志 字符型	3	Y Y
            public string insuplc_admdvs { get; set; }// 参保地医保区划 字符型	6		Y
            public string emp_name { get; set; } //   单位名称 字符型	200	　		　

        }
    public class IdetInfo
    {
        public string psn_idet_type { get; set; }// 人员身份类别  字符型	3	Y Y
        public string psn_type_lv { get; set; }// 人员类别等级  字符型	3	Y 详见残疾等级字典
        public string memo { get; set; }// 备注  字符型	500	　	　	
        public DateTime begntime { get; set; }// 开始时间    日期时间型 Y   yyyy-MM-dd HH:mm:ss
        public DateTime endtime { get; set; }// 结束时间 日期时间型               yyyy-MM-dd HH:mm:ss

    }
}
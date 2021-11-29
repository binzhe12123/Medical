using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB.CFZX
{
    /// <summary>
    /// 
    /// </summary>
    public class DZCF7202
    {
        /// <summary>
        /// 
        /// </summary>
        public class In7202
        {
            /// <summary>
            /// 
            /// </summary>
            public string mdtrt_cert_type { get; set; }//   就诊凭证类型 字符型	3	Y Y
            /// <summary>
            /// 
            /// </summary>
            public string mdtrt_cert_no { get; set; }// 就诊凭证编号  字符型	50		Y 就诊凭证类型为“01”时填写电子凭证令牌，为“03”时填写社会保障卡卡号
            /// <summary>
            /// 
            /// </summary>
            public string card_sn { get; set; }// 卡识别码 字符型	32			就诊凭证类型为“03”时必填
            /// <summary>
            /// 
            /// </summary>
            public string insuplc_admdvs { get; set; }//  参保地医保区划 字符型	6	Y Y
            /// <summary>
            /// 
            /// </summary>
            public string ip_info { get; set; }// 终端IP    字符型	64		Y
            /// <summary>
            /// 
            /// </summary>
            public string opter { get; set; }//  操作人ID 字符型	20		Y
            /// <summary>
            /// 
            /// </summary>
            public string opter_name { get; set; }//  操作人姓名 字符型	50		Y
            /// <summary>
            /// 
            /// </summary>
            public string optins { get; set; }//  操作机构 字符型	20		Y
        }

        /// <summary>
        /// 
        /// </summary>
        public class Out7202
        {
            /// <summary>
            /// 
            /// </summary>
            public string auth_rxno { get; set; }// 医保处方授权编号 字符型	30		Y 授权临时处方编号，只一次使用
            /// <summary>
            /// 
            /// </summary>
            public string diag_name { get; set; }//  主诊断名称 字符型	40		Y
            /// <summary>
            /// 
            /// </summary>
            public string fixmedins_code { get; set; }// 定点医疗机构编号 字符型	20		Y
            /// <summary>
            /// 
            /// </summary>
            public string fixmedins_name { get; set; }//  定点医疗机构名称 字符型	200		Y
            /// <summary>
            /// 
            /// </summary>
            public DateTime prsc_time { get; set; }//   开方时间 日期时间型           Y
            /// <summary>
            /// 
            /// </summary>
            public string dept_name { get; set; }//   科室名称 字符型	50		Y
            /// <summary>
            /// 
            /// </summary>
            public DateTime valid_end_time { get; set; }//  有效截止时间 日期时间型           Y

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB.CFZX
{
    /// <summary>
    /// 
    /// </summary>
    public class CFJX7201
    {
        /// <summary>
        /// 
        /// </summary>
        public class In7201
        {
            /// <summary>
            /// 
            /// </summary>
            public string app_chnl_id { get; set; }// 应用渠道ID  字符型	40		Y
            /// <summary>
            /// 
            /// </summary>
            public string app_chnl_user_id { get; set; }//    应用渠道用户ID 字符型	40		Y
            /// <summary>
            /// 
            /// </summary>
            public string auth_code { get; set; }//   授权码 字符型	40			
            /// <summary>
            /// 
            /// </summary>
            public string dev_info { get; set; }// 终端信息    字符型	255		Y
            /// <summary>
            /// 
            /// </summary>
            public string epc_qrcd { get; set; }//    电子处方二维码值 字符型	27		Y
            /// <summary>
            /// 
            /// </summary>
            public string ip_info { get; set; }// 终端IP 字符型	64		Y
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
        public class Out7201
        {
            /// <summary>
            /// 
            /// </summary>
            public string epc_token { get; set; }// 电子处方令牌  字符型	64		Y
            /// <summary>
            /// 
            /// </summary>
            public string cert_type { get; set; }//   证件类型 字符型	6	Y Y
            /// <summary>
            /// 
            /// </summary>
            public string name { get; set; }// 用户姓名    字符型	50		Y
            /// <summary>
            /// 
            /// </summary>
            public string certno { get; set; }//  证件号码 字符型	50		Y
            /// <summary>
            /// 
            /// </summary>
            public string insuplc_admdvs { get; set; }//  参保地医保区划 字符型	6	Y Y

        }
    }
}
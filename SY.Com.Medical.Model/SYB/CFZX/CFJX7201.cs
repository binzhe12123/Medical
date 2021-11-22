using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB.CFZX
{
    public class CFJX7201
    {
        public class In7201
        {
            public string app_chnl_id { get; set; }// 应用渠道ID  字符型	40		Y
            public string app_chnl_user_id { get; set; }//    应用渠道用户ID 字符型	40		Y
            public string auth_code { get; set; }//   授权码 字符型	40			
            public string dev_info { get; set; }// 终端信息    字符型	255		Y
            public string epc_qrcd { get; set; }//    电子处方二维码值 字符型	27		Y
            public string ip_info { get; set; }// 终端IP 字符型	64		Y
            public string opter { get; set; }//  操作人ID 字符型	20		Y
            public string opter_name { get; set; }//  操作人姓名 字符型	50		Y
            public string optins { get; set; }//  操作机构 字符型	20		Y

        }
        public class Out7201
        {
            public string epc_token { get; set; }// 电子处方令牌  字符型	64		Y
            public string cert_type { get; set; }//   证件类型 字符型	6	Y Y
            public string name { get; set; }// 用户姓名    字符型	50		Y
            public string certno { get; set; }//  证件号码 字符型	50		Y
            public string insuplc_admdvs { get; set; }//  参保地医保区划 字符型	6	Y Y

        }
    }
}
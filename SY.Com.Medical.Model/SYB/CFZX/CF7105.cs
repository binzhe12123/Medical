using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB.CFZX
{
    public class CF7105
    {
        public class In7105
        {
            public string hi_rxno { get; set; }// 医保处方编号  字符型	30		Y
            public string hosp_rxno { get; set; } // 定点医疗机构处方编号 字符型	40		Y
            public string rx_pay_status_code { get; set; }//  处方支付状态 字符型	6	Y Y   支付成功字符限制，逻辑处理，便于扩展
            public DateTime pay_time { get; set; }//    支付时间 日期时间型           Y

        }
    }
}
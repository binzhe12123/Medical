using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB
{
    /// <summary>
    /// 挂号撤销
    /// </summary>
    public class GH2202
    {
        public class In2202
        {
            public In2202data data { get; set; }
        }
        public class In2202data
        {
            public string psn_no { get; set; }// 人员编号    字符型	30	　	Y
            public string mdtrt_id { get; set; }//    就诊ID 字符型	30	　	Y
            public string ipt_otp_no { get; set; } // 住院/门诊号 字符型	30	　	Y

        }

    }
}
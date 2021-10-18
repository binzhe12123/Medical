using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB.YBJS
{
    public class CZ2601
    {
        public class In2601
        {
            public string psn_no { get; set; }//   人员编号 字符型	30	　	Y
            public string omsgid { get; set; }// 原发送方报文ID 字符型	30		Y
            public string oinfno { get; set; } // 原交易编号 字符型	4		Y
        }

    }
}
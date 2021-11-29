using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB.YBJS
{
    /// <summary>
    /// 
    /// </summary>
    public class CZ2601
    {
        /// <summary>
        /// 
        /// </summary>
        public class In2601data
        {
            /// <summary>
            /// 
            /// </summary>
            public In2601 data { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        public class In2601
        {
            /// <summary>
            /// 
            /// </summary>
            public string psn_no { get; set; }//   人员编号 字符型	30	　	Y
            /// <summary>
            /// 
            /// </summary>
            public string omsgid { get; set; }// 原发送方报文ID 字符型	30		Y
            /// <summary>
            /// 
            /// </summary>
            public string oinfno { get; set; } // 原交易编号 字符型	4		Y
        }

    }
}
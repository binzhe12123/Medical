using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

namespace SZSI_Smart.Model.SYB
{
    /// <summary>
    /// 
    /// </summary>
    public class ZJ2205
    {
        /// <summary>
        /// 
        /// </summary>
        public class In2205data
        {
            /// <summary>
            /// 
            /// </summary>
            public In2205 data { get; set; }
        }
        /// <summary>
        /// 诊间撤销
        /// </summary>
        public class In2205
        {
            /// <summary>
            /// 医保门诊号
            /// </summary>
            public string mdtrt_id { get; set; }// 就诊ID    字符型	30		Y
            /// <summary>
            /// 医保收费批次
            /// </summary>
            [JsonIgnore]
            public string chrg_bchno { get; set; }// 收费批次号 字符型	30		Y 传入“0000”删除所有未结算明细
            /// <summary>
            /// 医保人员编号
            /// </summary>
            public string psn_no { get; set; }//  人员编号 字符型	30		Y
        }


    }
}
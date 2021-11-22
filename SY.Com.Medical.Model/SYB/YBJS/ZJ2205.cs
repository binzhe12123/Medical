using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB
{
    public class ZJ2205
    {
        public class In2205data
        { 
            public In2205 data { get; set; }
        }
        /// <summary>
        /// 诊间撤销
        /// </summary>
        public class In2205
        {
            public string mdtrt_id { get; set; }// 就诊ID    字符型	30		Y
            public string chrg_bchno { get; set; }// 收费批次号 字符型	30		Y 传入“0000”删除所有未结算明细
            public string psn_no { get; set; }//  人员编号 字符型	30		Y
        }


    }
}
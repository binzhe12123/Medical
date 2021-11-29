using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB.XXCX
{
    /// <summary>
    /// 
    /// </summary>
    public class MB5301
    {
        /// <summary>
        /// 
        /// </summary>
        public class In5301
        {
            /// <summary>
            /// 
            /// </summary>
            public string psn_no { get; set; }//    人员编号 字符型	30		Y
        }

        /// <summary>
        /// 
        /// </summary>
        public class Out5301
        {
            /// <summary>
            /// 
            /// </summary>
            public string opsp_dise_code { get; set; }// 门慢门特病种目录代码  字符型	30	　	Y
            /// <summary>
            /// 
            /// </summary>
            public string opsp_dise_name { get; set; }//  门慢门特病种名称 字符型	300	　	Y
            /// <summary>
            /// 
            /// </summary>
            public DateTime begndate { get; set; }//    开始日期 日期型         Y yyyy-MM-dd
            /// <summary>
            /// 
            /// </summary>
            public DateTime enddate { get; set; }// 结束日期 日期型             yyyy-MM-dd

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB.XXCX
{
    /// <summary>
    /// 
    /// </summary>
    public class RY5302
    {
        /// <summary>
        /// 
        /// </summary>
        public class In5302data
        {
            /// <summary>
            /// 
            /// </summary>
            public In5302 data { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        public class In5302
        {
            /// <summary>
            /// 
            /// </summary>
            public string psn_no { get; set; }//   人员编号 字符型	30	Y
            /// <summary>
            /// 
            /// </summary>
            public string biz_appy_type { get; set; }//   业务申请类型 字符型	3	Y
        }
        /// <summary>
        /// 
        /// </summary>
        public class Out5302
        {
            /// <summary>
            /// 
            /// </summary>
            public string psn_no { get; set; }//    人员编号 字符型	30	　	Y
            /// <summary>
            /// 
            /// </summary>
            public string insutype { get; set; }//   险种类型 字符型	6	Y
            /// <summary>
            /// 
            /// </summary>
            public string fix_srt_no { get; set; }//  定点排序号 字符型	3	　	Y
            /// <summary>
            /// 
            /// </summary>
            public string fixmedins_code { get; set; }//  定点医药机构编号 字符型	12	　	Y
            /// <summary>
            /// 
            /// </summary>
            public string fixmedins_name { get; set; }//  定点医药机构名称 字符型	200	　	Y
            /// <summary>
            /// 
            /// </summary>
            public DateTime begndate { get; set; }//    开始日期 日期型         Y yyyy-MM-dd
            /// <summary>
            /// 
            /// </summary>
            public DateTime enddate { get; set; }// 结束日期 日期型             yyyy-MM-dd
            /// <summary>
            /// 
            /// </summary>
            public string memo { get; set; }//    备注 字符型	500	　	　	　

        }
    }
}
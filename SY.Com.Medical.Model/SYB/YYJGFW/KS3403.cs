using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SY.Com.Medical.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class KS3403
    {
        /// <summary>
        /// 
        /// </summary>
        public class In3403
        {
            /// <summary>
            /// 
            /// </summary>
            public string hosp_dept_codg { get; set; }//   医院科室编码 字符型	20		Y
            /// <summary>
            /// 
            /// </summary>
            public string hosp_dept_name { get; set; }//  医院科室名称 字符型	100		Y
            /// <summary>
            /// 
            /// </summary>
            public DateTime begntime { get; set; }//    开始时间 日期型         Y

        }
        /// <summary>
        /// 
        /// </summary>
        public class In3403data
        {
            /// <summary>
            /// 
            /// </summary>
            public In3403 data { get; set; }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB.XXCX
{
    /// <summary>
    /// 
    /// </summary>
    public class RY5206
    {
        /// <summary>
        /// 
        /// </summary>
        public class In5206data
        {
            /// <summary>
            /// 
            /// </summary>
            public In5206 data { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        public class In5206
        {
            /// <summary>
            /// 
            /// </summary>
            public string psn_no { get; set; }//   人员编号 字符型	30		Y
            /// <summary>
            /// 
            /// </summary>
            public string cum_ym { get; set; }//  累计年月 字符型	6			

        }
        /// <summary>
        /// 
        /// </summary>
        public class Out5206 
        {
            /// <summary>
            /// 
            /// </summary>
            public string insutype { get; set; }//  险种类型 字符型	6	Y Y
            /// <summary>
            /// 
            /// </summary>
            public string year { get; set; }// 年度  字符型	4	　	Y
            /// <summary>
            /// 
            /// </summary>
            public string cum_ym { get; set; }//  累计年月 字符型	6	　	Y
            /// <summary>
            /// 
            /// </summary>
            public string cum_type_code { get; set; }//  累计类别代码 字符型	10	　	Y
            /// <summary>
            /// 
            /// </summary>
            public decimal cum { get; set; }// 累计值 数值型	16,2	　	Y

        }

    }
}
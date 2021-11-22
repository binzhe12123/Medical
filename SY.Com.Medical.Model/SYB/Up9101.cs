using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SY.Com.Medical.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Up9101
    {
        /// <summary>
        /// 
        /// </summary>
        public class In9101
        {
            /// <summary>
            /// 
            /// </summary>
            // public string in	文件数据 字节数组            Y
            public string filename { get; set; }// 文件名 字符型	200		Y
            /// <summary>
            /// 
            /// </summary>
            public string fixmedins_code { get; set; }//  医药机构编号 字符型	30	　	Y
        }
        /// <summary>
        /// 
        /// </summary>
        public class Out9101
        {
            /// <summary>
            /// 
            /// </summary>
            public string file_qury_no { get; set; }//  文件查询号 字符型	30		Y
            /// <summary>
            /// 
            /// </summary>
            public string filename { get; set; }//   文件名 字符型	200		Y
            /// <summary>
            /// 
            /// </summary>
            public string fixmedins_code { get; set; }// 医药机构编号 字符型	30	　	Y
            /// <summary>
            /// 
            /// </summary>
            public DateTime dld_endtime { get; set; } //截止时间 字符型	30		

        }
    }
}
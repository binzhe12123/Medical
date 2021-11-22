using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SY.Com.Medical.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Down9102
    {
        /// <summary>
        /// 
        /// </summary>
        public class In9102
        {
            /// <summary>
            /// 
            /// </summary>
            public FsDownloadIn fsDownloadIn { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        public class FsDownloadIn
        {
            /// <summary>
            /// 
            /// </summary>
            public string file_qury_no { get; set; }//  文件查询号 字符型	30		Y
            /// <summary>
            /// 
            /// </summary>
            public string filename { get; set; }//    文件名 字符型	200		Y 下载【1301-1319】生成的文件，固定传入“plc”
            /// <summary>
            /// 
            /// </summary>
            public string fixmedins_code { get; set; } //医药机构编号  字符型	30	　	Y

        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SY.Com.Medical.Model
{

    /// <summary>
    /// 
    /// </summary>
    public class In9001
    {
        /// <summary>
        /// 
        /// </summary>
        public In9001model signIn { get; set; }


    }

    /// <summary>
    /// 
    /// </summary>
    public class In9001model
    {
        /// <summary>
        /// 
        /// </summary>
        public string opter_no { get; set; }// 操作员编号   字符型	20		Y
        /// <summary>
        /// 
        /// </summary>
        public string mac { get; set; }// 签到MAC地址 字符型	20		Y
        /// <summary>
        /// 
        /// </summary>
        public string ip { get; set; }// 签到IP地址 字符型	20		Y
    }
    /// <summary>
    /// 
    /// </summary>
    public class Out9001
        {
        /// <summary>
        /// 
        /// </summary>
        public DateTime sign_time { get; set; }//  签到时间 日期型         Y yyyy-MM-dd HH:mm:ss
        /// <summary>
        /// 
        /// </summary>
        public string sign_no { get; set; }// 签到编号 字符型	30		Y

        }
    /// <summary>
    /// 
    /// </summary>
    public class CheckIn
        {
        /// <summary>
        /// 
        /// </summary>

        public string sign_no { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime sign_time { get; set;  }

        }
   
}
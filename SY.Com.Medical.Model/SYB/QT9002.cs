using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SY.Com.Medical.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class QT9002
    {
        /// <summary>
        /// 
        /// </summary>
        public class In9002
        {
            /// <summary>
            /// 
            /// </summary>
            public In9002model signOut { get; set; }            

        }
        /// <summary>
        /// 
        /// </summary>
        public class In9002model
        {
            /// <summary>
            /// 
            /// </summary>
            public string sign_no { get; set; }//   签到编号 字符型	30		
            /// <summary>
            /// 
            /// </summary>
            public string opter_no { get; set; }//    操作员编号 字符型	20		Y
        }
        /// <summary>
        /// 
        /// </summary>
        public class Out9002
        {
            /// <summary>
            /// 
            /// </summary>
            public Signoutoutb signoutoutb { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public class Signoutoutb
            {
                /// <summary>
                /// 
                /// </summary>
                public DateTime sign_time { get; set; }// 签退时间    日期型 Y   yyyy-MM-dd HH:mm:ss
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MK.Clinic.Model
{
   
        public class In9001
        {
            public string opter_no { get; set; }// 操作员编号   字符型	20		Y
            public string mac { get; set; }// 签到MAC地址 字符型	20		Y
            public string ip { get; set; }// 签到IP地址 字符型	20		Y

        }
        public class Out9001
        {
            public DateTime sign_time { get; set; }//  签到时间 日期型         Y yyyy-MM-dd HH:mm:ss
            public string sign_no { get; set; }// 签到编号 字符型	30		Y

        }
        public class CheckIn
        {
            
            public string sign_no { get; set; }
            public DateTime sign_time { get; set;  }

        }
   
}
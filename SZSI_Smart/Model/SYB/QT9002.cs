using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MK.Clinic.Model
{
    public class QT9002
    {
        public class In9002
        {
            public string sign_no { get; set; }//   签到编号 字符型	30		
            public string opter_no { get; set; }//    操作员编号 字符型	20		Y

        }
        public class Out9002
        {
           public DateTime sign_time { get; set; }// 签退时间    日期型 Y   yyyy-MM-dd HH:mm:ss
        }
    }
}
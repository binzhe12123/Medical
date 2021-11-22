using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB.XXCX
{
    public class ZY5303
    {
        public class In5303
        {
            public string psn_no { get; set; }//   人员编号 字符型	30		
            public DateTime begntime { get; set; }// 开始时间    日期时间型 Y
            public DateTime endtime { get; set; }// 结束时间    日期时间型 Y

        }
        public class Out5303
        {
            public string mdtrt_id { get; set; }//  就诊ID 字符型	30	　	Y
            public string psn_no { get; set; }//  人员编号 字符型	30	　	Y
            public string psn_cert_type { get; set; }//   人员证件类型 字符型	6	Y Y
            public string certno { get; set; }// 证件号码    字符型	50		Y
            public string psn_name { get; set; }//   人员姓名 字符型	50		Y
            public string gend { get; set; }//  性别 字符型	6	Y Y
            public DateTime brdy { get; set; }// 出生日期    日期型 yyyy-MM-dd
            public int age { get; set; }// 年龄 数值型	4,1	　	Y
            public string insutype { get; set; }//   险种类型 字符型	6	Y Y
            public DateTime begndate { get; set; }// 开始日期    日期型 Y   入院日期
            public string med_type { get; set; }//    医疗类别 字符型	6	Y Y
            public string ipt_otp_no { get; set; }// 住院/门诊号 字符型	30			
            public string out_flag { get; set; }// 异地标志    字符型	3			

        }
    }
}
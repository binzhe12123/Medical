using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MK.Clinic.Model
{
    public class KS3403
    {
        public class In3403
        {
            public string hosp_dept_codg { get; set; }//   医院科室编码 字符型	20		Y
            public string hosp_dept_name { get; set; }//  医院科室名称 字符型	100		Y
            public DateTime begntime { get; set; }//    开始时间 日期型         Y

        }
    }
}
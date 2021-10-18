using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB
{
    /// <summary>
    /// 门诊挂号
    /// </summary>
    public class GH2201
    {
        public class In2201
        {
            public In2201data data { get; set; }

        }
        public class In2201data
        {
            public string psn_no { get; set; }// 人员编号    字符型	30	　	Y
            public string insutype { get; set; }//    险种类型 字符型	6	Y Y
            public DateTime begntime { get; set; }// 开始时间    日期时间型 Y   挂号时间yyyy-MM-dd HH:mm:ss
            public string mdtrt_cert_type { get; set; }// 就诊凭证类型 字符型	3	Y Y
            public string mdtrt_cert_no { get; set; }//就诊凭证编号就诊凭证类型为“01”时填写电子凭证令牌，为“02”时填写身份证号，为“03”时填写社会保障卡卡号
            public string ipt_otp_no { get; set; }//  住院/门诊号 字符型	30	　	Y 院内唯一流水
            public string atddr_no { get; set; } //医师编码    字符型	30	　	Y
            public string dr_name { get; set; }//医师姓名 字符型	50	　	Y
            public string dept_code { get; set; } // 科室编码 字符型	30	　	Y
            public string dept_name { get; set; } //  科室名称 字符型	100	　	Y
            public string caty { get; set; }//    科别 字符型	6	Y Y
        }
        public class Out2201
        {
            public Out2201data data { get; set; }
        }
        public class Out2201data 
        {
            public string mdtrt_id { get; set; }// 就诊ID    字符型	30	　	Y 医保返回唯一流水
            public string psn_no { get; set; } //人员编号    字符型	30	　	Y
            public string ipt_otp_no { get; set; }//  住院/门诊号 字符型	30	　	Y 院内唯一流水

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB.XXCJ
{
    public class HL4602
    {
        public class In4602
        {
            public string mdtrt_sn { get; set; }//  就医流水号 字符型	30		Y 院内唯一号
            public string mdtrt_id { get; set; }// 就诊ID    字符型	30			医保病人必填
            public string psn_no { get; set; }//  人员编号 字符型	30			医保病人必填
            public string dept_code { get; set; }//   科室代码 字符型	30	Y Y   参照科室代码（dept）
            public string dept_name { get; set; }// 科室名称    字符型	50		Y
            public string wardarea_name { get; set; }//   病区名称 字符型	50		Y
            public string bedno { get; set; }//   病床号 字符型	10		Y
            public string diag_code { get; set; }//  诊断代码 字符型	20		Y
            public DateTime adm_time { get; set; }//   入院时间 日期时间型           Y
            public decimal act_ipt_days { get; set; }//    实际住院天数 数值型	3,0		Y
            public decimal afpn_days { get; set; }//   手术后天数 数值型	5,0		Y
            public DateTime rcd_time { get; set; }//  记录日期时间 日期型         Y
            public decimal vent_frqu { get; set; }//   呼吸频率（次/min）	数值型	3,0		Y
            public string use_vent_flag { get; set; }//   使用呼吸机标志 字符型	1		Y
            public decimal pule { get; set; }//   脉率（次/min）	数值型	3,0		Y
            public decimal pat_heart_rate { get; set; }//  起搏器心率（次/min）	数值型	3,0		Y
            public decimal tprt { get; set; }//   体温（℃）	数值型	5,1		Y
            public string systolic_pre { get; set; }//    收缩压（mmHg）	字符型	3		Y
            public string dstl_pre { get; set; }//    舒张压（mmHg）	字符型	3		Y
            public decimal wt { get; set; }//  体重（kg）	数值型	7,1		Y
            public decimal abde { get; set; }//    腹围（cm）	数值型	6,1		Y
            public string nurscare_obsv_item_name { get; set; }//护理观察项目名称 字符型	30		Y
            public string nurscare_obsv_rslt { get; set; }//  护理观察结果 字符型	1000		Y
            public string nurs_name { get; set; }//   护士姓名 字符型	50		Y
            public DateTime sign_time { get; set; }//   签字时间 日期时间型           Y
            public string vali_flag { get; set; }//   有效标志 字符型	3	Y Y

        }
    }
}
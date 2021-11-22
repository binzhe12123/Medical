using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB
{
    /// <summary>
    /// 诊间结算
    /// </summary>
    public class ZJ2203
    {
        public class In2203
        {
            public MdtrtInfo mdtrtinfo { get; set; }
            public List<Diseinfo> diseinfo { get; set; }
        }
        public class MdtrtInfo 
        {
            public string mdtrt_id { get; set; }//  就诊ID 字符型	30	　	Y
            public string psn_no { get; set; }//  人员编号 字符型	30	　	Y
            public string med_type { get; set; }//   医疗类别 字符型	6	Y Y
            public string begntime { get; set; }// 开始时间    日期时间型 Y   就诊时间
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string main_cond_dscr { get; set; } // 主要病情描述 字符型	1000	　	　	
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string dise_codg { get; set; }// 病种编码    字符型	30	　	　
            //按照标准编码填写：按病种结算病种目录代码(bydise_setl_list_code)、门诊慢特病病种目录代码(opsp_dise_cod)、
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string dise_name { get; set; }// 病种名称   字符型 500
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string birctrl_type { get; set; }// 计划生育手术类别    字符型	6	Y 生育门诊按需录入
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string birctrl_matn_date { get; set; }// 计划生育手术或生育日期 日期型 生育门诊按需录入，yyyy-MM-dd
        }
        public class Diseinfo 
        {
            public string diag_type { get; set; }//诊断类别    字符型	3	　Y Y
            public string diag_srt_no { get; set; }// 诊断排序号   数值型	2	　	　Y
            public string diag_code { get; set; }//   诊断代码 字符型	20	　	　Y
            public string diag_name { get; set; }//   诊断名称 字符型	100	　	　Y
            public string diag_dept { get; set; }//   诊断科室 字符型	50	　	　Y
            public string dise_dor_no { get; set; }// 诊断医生编码 字符型	30	　	　Y
            public string dise_dor_name { get; set; }// 诊断医生姓名 字符型	50	　	　Y
            public string diag_time { get; set; }//   诊断时间 日期时间型   Y yyyy-MM-dd HH:mm:ss
            public string vali_flag { get; set; } //  有效标志 字符型	3	Y Y

        }
    }
}
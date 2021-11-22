using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Model.SYB
{
    /// <summary>
    /// 
    /// </summary>
    public class RYBA2505
    {
        /// <summary>
        /// 
        /// </summary>
        public class In2505data
        {
            /// <summary>
            /// 
            /// </summary>
            public In2505 data { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        public class In2505
        {
            /// <summary>
            /// 
            /// </summary>
            public string psn_no { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string tel { get; set; }//tel 联系电话 字符型	50	
                                           //            /// <summary>
            /// <summary>
            /// 
            /// </summary>　	　
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string addr { get; set; }//addr 联系地址    字符型	200	　	　
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string biz_appy_type { get; set; }//biz_appy_type 业务申请类型  字符型	3	Y Y            
            /// <summary>
            /// 
            /// </summary>
            public string begndate { get; set; }//begndate 开始日期    日期型 Y
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string enddate { get; set; }//enddate 结束日期    日期型
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string agnter_name { get; set; }//agnter_name 代办人姓名 字符型	50	　	　
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string agnter_cert_type { get; set; }// 代办人证件类型 字符型	6	Y
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string agnter_certno { get; set; }//   代办人证件号码 字符型	50	　	　
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string agnter_tel { get; set; }// 代办人联系方式 字符型	30	　	　
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string agnter_addr { get; set; }// 代办人联系地址 字符型	200	　	　
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string agnter_rlts { get; set; }// 代办人关系   字符型	3	Y
            /// <summary>
            /// 
            /// </summary>
            public string fix_srt_no { get; set; }//  定点排序号 字符型	3	　	Y
            /// <summary>
            /// 
            /// </summary>
            public string fixmedins_code { get; set; }//  定点医药机构编号 字符型	12	　	Y
            /// <summary>
            /// 
            /// </summary>
            public string fixmedins_name { get; set; }//  定点医药机构名称 字符型	200	　	Y
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string memo { get; set; }//    备注 字符型	500	　	　

        }

        /// <summary>
        /// 
        /// </summary>
        public class Out2505 {
            /// <summary>
            /// 
            /// </summary>
            public string trt_dcla_detl_sn { get; set; }//待遇申报明细流水号	字符型	30		Y
        }

    }
}

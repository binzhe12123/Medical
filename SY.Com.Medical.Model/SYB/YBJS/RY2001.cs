using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB.YBJS
{
    /// <summary>
    /// 
    /// </summary>
    public class RY2001
    {
        /// <summary>
        /// 
        /// </summary>
        public class In2001data 
        {
            /// <summary>
            /// 
            /// </summary>
            public In2001 data { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        public class In2001
        {
            /// <summary>
            /// 
            /// </summary>
            public string psn_no { get; set; }//   人员编号 字符型	30	　	Y
            /// <summary>
            /// 
            /// </summary>
            public string insutype { get; set; }//    险种类型 字符型	6	Y Y
            /// <summary>
            /// 
            /// </summary>
            public string fixmedins_code { get; set; }// 定点医药机构编号    字符型	12	　	Y
            /// <summary>
            /// 
            /// </summary>
            public string med_type { get; set; }//    医疗类别 字符型	6	Y Y
            /// <summary>
            /// 
            /// </summary>
            public DateTime begntime { get; set; }// 开始时间    日期时间型 Y   yyyy-MM-dd HH:mm:ss
            /// <summary>
            /// 
            /// </summary>
            public DateTime endtime { get; set; }// 结束时间 日期时间型               yyyy-MM-dd HH:mm:ss
            /// <summary>
            /// 
            /// </summary>
            public string dise_codg { get; set; }//   病种编码 字符型	30	　	　
            /// <summary>
            /// 
            /// </summary>
            public string dise_name { get; set; }// 病种名称    字符型	500	　	　	　
            /// <summary>
            /// 
            /// </summary>
            public string oprn_oprt_code { get; set; }// 手术操作代码  字符型	30	　	　	日间手术病种时必填
            /// <summary>
            /// 
            /// </summary>
            public string oprn_oprt_name { get; set; }// 手术操作名称 字符型	500	　	　	　
            /// <summary>
            /// 
            /// </summary>
            public string matn_type { get; set; }// 生育类别    字符型	6	Y
            /// <summary>
            /// 
            /// </summary>
            public string birctrl_type { get; set; }//    计划生育手术类别 字符型	6	Y

        }
        /// <summary>
        /// 
        /// </summary>
        public class Out2001
        {
            /// <summary>
            /// 
            /// </summary>
            public string psn_no { get; set; }//    人员编号 字符型	30	　	　Y
            /// <summary>
            /// 
            /// </summary>
            public string trt_chk_type { get; set; }//   待遇检查类型 字符型	6	　Y Y
            /// <summary>
            /// 
            /// </summary>
            public string fund_pay_type { get; set; }// 基金支付类型  字符型	6	　Y Y
            /// <summary>
            /// 
            /// </summary>
            public string trt_enjymnt_flag { get; set; }//基金款项待遇享受标志  字符型	3	　Y Y
            /// <summary>
            /// 
            /// </summary>
            public DateTime begndate { get; set; }// 开始日期    日期型 Y
            /// <summary>
            /// 
            /// </summary>
            public DateTime enddate { get; set; }// 结束日期    日期型
            /// <summary>
            /// 
            /// </summary>
            public string trt_chk_rslt { get; set; }//    待遇检查结果 字符型	500	　	　	返回不享受待遇原因。

        }
    }
}
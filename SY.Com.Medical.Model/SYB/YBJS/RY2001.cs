using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB.YBJS
{
    public class RY2001
    {
        public class In2001data 
        {
            public In2001 data { get; set; }
        }
        public class In2001
        {
            public string psn_no { get; set; }//   人员编号 字符型	30	　	Y
            public string insutype { get; set; }//    险种类型 字符型	6	Y Y
            public string fixmedins_code { get; set; }// 定点医药机构编号    字符型	12	　	Y
            public string med_type { get; set; }//    医疗类别 字符型	6	Y Y
            public DateTime begntime { get; set; }// 开始时间    日期时间型 Y   yyyy-MM-dd HH:mm:ss
            public DateTime endtime { get; set; }// 结束时间 日期时间型               yyyy-MM-dd HH:mm:ss
            public string dise_codg { get; set; }//   病种编码 字符型	30	　	　
            public string dise_name { get; set; }// 病种名称    字符型	500	　	　	　
            public string oprn_oprt_code { get; set; }// 手术操作代码  字符型	30	　	　	日间手术病种时必填
            public string oprn_oprt_name { get; set; }// 手术操作名称 字符型	500	　	　	　
            public string matn_type { get; set; }// 生育类别    字符型	6	Y
            public string birctrl_type { get; set; }//    计划生育手术类别 字符型	6	Y

        }
        public class Out2001
        { 
            public string psn_no { get; set; }//    人员编号 字符型	30	　	　Y
            public string trt_chk_type { get; set; }//   待遇检查类型 字符型	6	　Y Y
            public string fund_pay_type { get; set; }// 基金支付类型  字符型	6	　Y Y
            public string trt_enjymnt_flag { get; set; }//基金款项待遇享受标志  字符型	3	　Y Y
            public DateTime begndate { get; set; }// 开始日期    日期型 Y
            public DateTime enddate { get; set; }// 结束日期    日期型
            public string trt_chk_rslt { get; set; }//    待遇检查结果 字符型	500	　	　	返回不享受待遇原因。

        }
    }
}
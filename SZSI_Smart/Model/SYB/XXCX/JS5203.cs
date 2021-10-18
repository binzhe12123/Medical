using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB.XXCX
{
    public class JS5203
    {
        public class In5203
        {
            public string psn_no { get; set; }//   人员编号 字符型	30		Y
            public string setl_id { get; set; }// 结算ID 字符型	30	　	Y
            public string mdtrt_id { get; set; }//    就诊ID 字符型	30	　	Y
            
        }
        public class Out5203
        {
            public Setlinfo setlinfo { get; set; }
            public Setldetail setldetail { get; set; }
        }
        public class Setlinfo
        {
            public string setl_id { get; set; }// 结算ID    字符型	30	　	Y
            public string mdtrt_id { get; set; }//   就诊ID 字符型	30	　	Y
            public string psn_no { get; set; }// 人员编号 字符型	30	　	Y
            public string psn_name { get; set; }//   人员姓名 字符型	50	　	Y
            public string psn_cert_type { get; set; }//  人员证件类型 字符型	6	Y Y
            public string certno { get; set; }// 证件号码    字符型	50	　	Y
            public string gend { get; set; }//    性别 字符型	6	Y Y
            public string naty { get; set; }// 民族  字符型	3	Y
            public DateTime brdy { get; set; }//    出生日期 日期型             yyyy-MM-dd
            public decimal age { get; set; }// 年龄 数值型	4,1	　	　	　
            public string insutype { get; set; }// 险种类型    字符型	6	Y Y
            public string psn_type { get; set; }// 人员类别    字符型	6	Y Y
            public string cvlserv_flag { get; set; }// 公务员标志   字符型	3	Y Y
            public string flxempe_flag { get; set; }// 灵活就业标志  字符型	3	Y
            public string nwb_flag { get; set; }//    新生儿标志 字符型	3	Y
            public string insu_optins { get; set; }// 参保机构医保区划 字符型	6	　	　	　
            public string emp_name { get; set; }// 单位名称    字符型	200	　	　	　
            public string pay_loc { get; set; }//支付地点类别  字符型	6	Y Y
            public string fixmedins_code { get; set; }// 定点医药机构编号    字符型	12	　	Y
            public string fixmedins_name { get; set; }//  定点医药机构名称 字符型	200	　	Y
            public string hosp_lv { get; set; }// 医院等级 字符型	6	Y
            public string fixmedins_poolarea { get; set; }//  定点归属机构 字符型	6	　	　	　
            public string lmtpric_hosp_lv { get; set; }// 限价医院等级  字符型	6	Y
            public string dedc_hosp_lv { get; set; }//    起付线医院等级 字符型	6	Y
            public DateTime begndate { get; set; }//   开始日期 日期型         Y yyyy-MM-dd
            public DateTime enddate { get; set; }// 结束日期 日期型         Y yyyy-MM-dd
            public DateTime setl_time { get; set; }//   结算时间 日期时间型           Y yyyy-MM-dd HH:mm:ss
            public string mdtrt_cert_type { get; set; }// 就诊凭证类型 字符型	3	Y
            public string med_type { get; set; }//    医疗类别 字符型	6	Y Y
            public string clr_type { get; set; }// 清算类别    字符型	6	Y Y
            public string clr_way { get; set; }// 清算方式    字符型	6	Y
            public string clr_optins { get; set; }//  清算经办机构 字符型	6		　	　
            public decimal medfee_sumamt { get; set; }// 医疗费总额   数值型	16,2	　	Y
            public decimal fulamt_ownpay_amt { get; set; }//  全自费金额 数值型	16,2	　	Y
            public decimal overlmt_selfpay { get; set; }// 超限价自费费用 数值型	16,2	　	Y
            public decimal preselfpay_amt { get; set; }//  先行自付金额 数值型	16,2	　	Y
            public decimal inscp_scp_amt { get; set; }  //符合政策范围金额 数值型	16,2	　	Y
            public decimal act_pay_dedc { get; set; }//    实际支付起付线 数值型	16,2	　	Y
            public decimal hifp_pay { get; set; }//   基本医疗保险统筹基金支出 数值型	16,2	　	Y
            public decimal pool_prop_selfpay { get; set; }//   基本医疗保险统筹基金支付比例 数值型	5,4	　	Y
            public decimal cvlserv_pay { get; set; }// 公务员医疗补助资金支出 数值型	16,2	　	Y
            public decimal hifes_pay { get; set; }//   企业补充医疗保险基金支出 数值型	16,2	　	Y
            public decimal hifmi_pay { get; set; }//   居民大病保险资金支出 数值型	16,2	　	Y
            public decimal hifob_pay { get; set; }//  职工大额医疗费用补助基金支出 数值型	16,2	　	Y
            public decimal maf_pay { get; set; }// 医疗救助基金支出 数值型	16,2	　	Y
            public decimal oth_pay { get; set; }// 其他支出 数值型	16,2	　	Y
            public decimal fund_pay_sumamt { get; set; }// 基金支付总额 数值型	16,2	　	Y
            public decimal psn_pay { get; set; }// 个人支付金额 数值型	16,2	　	Y
            public decimal acct_pay { get; set; }//    个人账户支出 数值型	16,2	　	Y
            public decimal cash_payamt { get; set; }// 现金支付金额 数值型	16,2	　	Y
            public decimal balc { get; set; }    //余额 数值型	16,2		Y
            public decimal acct_mulaid_pay { get; set; }// 个人账户共济支付金额 数值型	16,2		Y
            public string medins_setl_id { get; set; }//  医药机构结算ID 字符型	30		Y 存放发送方报文ID
            public string refd_setl_flag { get; set; }// 退费结算标志  字符型	3	Y Y
            public string year { get; set; }// 年度  字符型	4	　	Y
            public string dise_codg { get; set; }//   病种编码 字符型	30			参照标准编码：按病种结算病种目录代码(bydise_setl_list_code)、门诊慢特病病种目录代码(opsp_dise_cod)、日间手术病种目录代码(daysrg_dise_list_code)
            public string dise_name { get; set; }// 病种名称    字符型	500	　		　
            public string invono { get; set; }//发票号 字符型	20	　	　	　
            public string opter_id { get; set; }// 经办人ID   字符型	20	　	　	　
            public string opter_name { get; set; }// 经办人姓名   字符型	50	　	　	　
            public DateTime opt_time { get; set; }// 经办时间    日期时间型 yyyy-MM-dd HH:mm:ss

        }
        public class Setldetail
        {
            public string fund_pay_type { get; set; }// 基金支付类型  字符型	6	Y Y
            public decimal inscp_scp_amt { get; set; }// 符合政策范围金额    数值型	16,2	　	Y
            public decimal crt_payb_lmt_amt { get; set; }//   本次可支付限额金额 数值型	16,2	　	Y
            public decimal fund_payamt { get; set; }// 基金支付金额 数值型	16,2	　	Y
            public string fund_pay_type_name { get; set; }//  基金支付类型名称 字符型	200		
            public string setl_proc_info { get; set; }// 结算过程信息  字符型	4000	　	　
        }
    }
}
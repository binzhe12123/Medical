using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB
{
    public class ZJCX2208
    {
        public class In2208
        {
            public string setl_id { get; set; }// 结算ID    字符型	30	　	Y
            public string mdtrt_id { get; set; }//   就诊ID 字符型	30	　	Y
            public string psn_no { get; set; } // 人员编号 字符型	30	　	Y
        }
        public class Out2208
        {
            public SetlInfo setlinfo { get; set; }
            public SetlDetail setldetail { get; set; }
        }
        public class SetlInfo
        {
            public string mdtrt_id { get; set; }//            就诊ID    字符型	30	　	Y
            public string setl_id { get; set; }// 结算ID 字符型	30		Y
            public string clr_optins { get; set; }//  清算经办机构 字符型	6		　	
            public DateTime setl_time { get; set; }// 结算时间    日期时间型 Y   yyyy-MM-dd HH:mm:ss
            public decimal medfee_sumamt { get;set; }//   医疗费总额 数值型	16,2	　	Y
            public decimal fulamt_ownpay_amt { get; set; }//   全自费金额 数值型	16,2	　	Y
            public decimal overlmt_selfpay { get; set; }//超限价自费费用 数值型	16,2	　	Y
            public decimal preselfpay_amt { get; set; }//  先行自付金额 数值型	16,2	　	Y
            public decimal inscp_scp_amt { get; set; }// 符合政策范围金额 数值型	16,2	　	Y
            public decimal act_pay_dedc { get; set; } //  实际支付起付线 数值型	16,2	　	　	　
            public decimal hifp_pay { get; set; }// 基本医疗保险统筹基金支出    数值型	16,2	　	Y
            public double pool_prop_selfpay { get; set; }//   基本医疗保险统筹基金支付比例 数值型	5,4	　	Y
            public string cvlserv_pay { get; set; }// 公务员医疗补助资金支出 数值型	16,2	　	Y
            public decimal hifes_pay { get; set; }//  企业补充医疗保险基金支出 数值型	16,2	　	Y
            public decimal hifmi_pay { get; set; }//   居民大病保险资金支出 数值型	16,2	　	Y
            public decimal hifob_pay { get; set; }// 职工大额医疗费用补助基金支出 数值型	16,2	　	Y
            public decimal maf_pay { get; set; }// 医疗救助基金支出 数值型	16,2	　	Y
            public decimal oth_pay { get; set; }// 其他支出 数值型	16,2	　	Y
            public decimal fund_pay_sumamt { get; set; }// 基金支付总额 数值型	16,2	　	Y
            public decimal psn_part_amt { get; set; }//   个人负担总金额 数值型	16,2	　	Y
            public decimal acct_pay { get; set; }//    个人账户支出 数值型	16,2	　	Y
            public decimal balc { get; set; }//    余额 数值型	16,2		Y
            public decimal acct_mulaid_pay { get; set; }// 个人账户共济支付金额 数值型	16,2		Y
            public decimal hosp_part_amt { get; set; }//   医院负担金额 数值型	16,2		Y
            public string medins_setl_id { get; set; }//  医药机构结算ID 字符型	30		Y 存放发送方报文ID
            public decimal pdn_cash_pay { get; set; } //个人现金支出  数值型	16,2	　	Y

        }
        public class SetlDetail
        {
            public decimal fund_pay_type { get; set; }// 基金支付类型  字符型	6	Y Y
            public decimal inscp_scp_amt { get; set; }// 符合政策范围金额    数值型	16,2	　	Y
            public decimal crt_payb_lmt_amt { get; set; }//    本次可支付限额金额 数值型	16,2	　	Y
            public decimal fund_payamt { get; set; }// 基金支付金额 数值型	16,2	　	Y
            public string fund_pay_type_name { get; set; } //基金支付类型名称 字符型	200		
            public string setl_proc_info { get; set; }// 结算过程信息  字符型	4000	　	　

        }

    }
}
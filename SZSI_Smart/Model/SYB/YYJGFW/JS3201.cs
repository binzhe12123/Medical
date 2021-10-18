using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MK.Clinic.Model
{
    public class JS3201
    {
        public class In3201
        {
            public string insutype { get; set; }//  险种 字符型	6	Y Y
            public string clr_type { get; set; }// 清算类别    字符型	6	Y Y
            public string setl_optins { get; set; }//结算经办机构  字符型	6	　	Y
            public DateTime stmt_begndate { get; set; }//对账开始日期 日期型         Y
            public DateTime stmt_enddate { get; set; }//    对账结束日期 日期型         Y
            public decimal medfee_sumamt { get; set; }//   医疗费总额 数值型	16,2	　	Y
            public decimal fund_pay_sumamt { get; set; }// 基金支付总额 数值型	16,2	　	Y
            public decimal acct_pay { get; set; }//    个人账户支付金额 数值型	16,2	　	Y
            public int fixmedins_setl_cnt { get; set; }//  定点医药机构结算笔数 数值型	10	　	Y
        }
        public class Out3201
        {
            public string setl_optins { get; set; }// 结算经办机构  字符型	6	　	　
            public string stmt_rslt { get; set; }// 对账结果    字符型	6	Y Y
            public string stmt_rslt_dscr { get; set; }// 对账结果说明  字符型	200		

        }
    }
}
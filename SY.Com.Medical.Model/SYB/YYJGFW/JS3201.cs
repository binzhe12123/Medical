using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SY.Com.Medical.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class JS3201
    {
        /// <summary>
        /// 
        /// </summary>
        public class In3201
        {
            /// <summary>
            /// 
            /// </summary>
            public string insutype { get; set; }//  险种 字符型	6	Y Y
            /// <summary>
            /// 
            /// </summary>
            public string clr_type { get; set; }// 清算类别    字符型	6	Y Y
            /// <summary>
            /// 
            /// </summary>
            public string setl_optins { get; set; }//结算经办机构  字符型	6	　	Y
            /// <summary>
            /// 
            /// </summary>
            public DateTime stmt_begndate { get; set; }//对账开始日期 日期型         Y
            /// <summary>
            /// 
            /// </summary>
            public DateTime stmt_enddate { get; set; }//    对账结束日期 日期型         Y
            /// <summary>
            /// 
            /// </summary>
            public decimal medfee_sumamt { get; set; }//   医疗费总额 数值型	16,2	　	Y
            /// <summary>
            /// 
            /// </summary>
            public decimal fund_pay_sumamt { get; set; }// 基金支付总额 数值型	16,2	　	Y
            /// <summary>
            /// 
            /// </summary>
            public decimal acct_pay { get; set; }//    个人账户支付金额 数值型	16,2	　	Y
            /// <summary>
            /// 
            /// </summary>
            public int fixmedins_setl_cnt { get; set; }//  定点医药机构结算笔数 数值型	10	　	Y
        }
        /// <summary>
        /// 
        /// </summary>
        public class Out3201
        {
            /// <summary>
            /// 
            /// </summary>
            public string setl_optins { get; set; }// 结算经办机构  字符型	6	　	　
            /// <summary>
            /// 
            /// </summary>
            public string stmt_rslt { get; set; }// 对账结果    字符型	6	Y Y
            /// <summary>
            /// 
            /// </summary>
            public string stmt_rslt_dscr { get; set; }// 对账结果说明  字符型	200		

        }
    }
}
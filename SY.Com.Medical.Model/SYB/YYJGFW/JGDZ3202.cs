using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB.YYJGFW
{
    /// <summary>
    /// 
    /// </summary>
    public class JGDZ3202
    {
        /// <summary>
        /// 
        /// </summary>
        public class In3202
        {
            /// <summary>
            /// 
            /// </summary>
            public string setl_optins { get; set; }// 结算经办机构  字符型	6	　	Y
            /// <summary>
            /// 
            /// </summary>
            public string file_qury_no { get; set; }//    文件查询号 字符型	30		Y 上传明细文件后返回的号码
            /// <summary>
            /// 
            /// </summary>
            public DateTime stmt_begndate { get; set; }// 对账开始日期  日期型 Y   yyyy-MM-dd
            /// <summary>
            /// 
            /// </summary>
            public DateTime stmt_enddate { get; set; }//    对账结束日期 日期型         Y yyyy-MM-dd
            /// <summary>
            /// 
            /// </summary>
            public decimal medfee_sumamt { get; set; }//  医疗费总额 数值型	16,2	　	Y
            /// <summary>
            /// 
            /// </summary>
            public decimal fund_pay_sumamt { get; set; }// 基金支付总额 数值型	16,2	　	Y
            /// <summary>
            /// 
            /// </summary>
            public decimal cash_payamt { get; set; }// 现金支付金额 数值型	16,2	　	Y
            /// <summary>
            /// 
            /// </summary>
            public decimal fixmedins_setl_cnt { get; set; }//  定点医药机构结算笔数 数值型	10	　	Y
            //public string setl_id { get; set; }//   结算ID 字符型	30	　	Y
            //public string mdtrt_id { get; set; }//   就诊ID 字符型	30	　	Y
            //public string psn_no { get; set; }//  人员编号 字符型	30	　	Y
            //public decimal medfee_sumamt { get; set; }//   医疗费总额 数值型	16,2	　	Y
            //public decimal fund_pay_sumamt { get; set; }// 基金支付总额 数值型	16,2	　	Y
            //public decimal acct_pay { get; set; }//   个人账户支出 数值型	16,2	　	Y
            //public string refd_setl_flag { get; set; }//  退费结算标志 字符型	3	Y Y
        }
        /// <summary>
        /// 
        /// </summary>
        public class Out3202
        {
            /// <summary>
            /// 
            /// </summary>
            public string file_qury_no { get; set; }//  文件查询号 字符型	30		Y 用于下载明细对账结果文件
            /// <summary>
            /// 
            /// </summary>
            public string filename { get; set; }// 文件名称    字符型	200		Y
            /// <summary>
            /// 
            /// </summary>
            public DateTime dld_endtime { get; set; }// 下载截止时间 日期时间型           Y yyyy-MM-dd HH:mm:ss
            //public string psn_no { get; set; }//    人员编号 字符型	30	　	Y
            //public string mdtrt_id { get; set; }//    就诊ID 字符型	30	
            //public string setl_id { get; set; }// 结算ID    字符型	30			
            //public string msgid { get; set; }// 发送方报文ID 字符型	30		Y 用于冲正时填写原发送方报文ID
            //public string stmt_rslt { get; set; }// 对账结果    字符型	6	Y Y
            //public string refd_setl_flag { get; set; }// 退费结算标志  字符型	3	Y Y
            //public string memo { get; set; }// 备注  字符型	500	　	　	　



        }
    }
}
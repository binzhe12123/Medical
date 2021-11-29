using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB.CFZX
{
    /// <summary>
    /// 处方购药结果反馈
    /// </summary>
    public class CF7103
    {
        /// <summary>
        /// 
        /// </summary>
        public class In7103
        {
            /// <summary>
            /// 
            /// </summary>
            public In7103data data { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public SeltDelts seltdelts { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        public class In7103data 
        {
            /// <summary>
            /// 
            /// </summary>
            public string hi_rxno { get; set; }// 医保处方编号  字符型	30		Y
            /// <summary>
            /// 
            /// </summary>
            public decimal fund_pay_sumamt { get; set; }// 基金支付总额 数值型	16,2		Y
            /// <summary>
            /// 
            /// </summary>
            public decimal psn_part_amt { get; set; }//    个人负担总金额 数值型	16,2		Y
            /// <summary>
            /// 
            /// </summary>
            public decimal acct_pay { get; set; }//    个人账户支出 数值型	16,2		Y
            /// <summary>
            /// 
            /// </summary>
            public decimal psn_cash_pay { get; set; }  // 个人现金支出 数值型	16,2		Y
            /// <summary>
            /// 
            /// </summary>
            public DateTime setl_time { get; set; }//  结算时间 日期时间型           Y yyyy-MM-dd HH:mm:ss

        }
        /// <summary>
        /// 
        /// </summary>
        public class SeltDelts
        {
            /// <summary>
            /// 
            /// </summary>
            public string medins_drug_no { get; set; }// 医药机构药品编号    字符型	36		
            /// <summary>
            /// 
            /// </summary>
            public string drug_genname { get; set; }// 通用名 字符型	100		
            /// <summary>
            /// 
            /// </summary>
            public string drug_prodname { get; set; }// 药品商品名   字符型	100		
            /// <summary>
            /// 
            /// </summary>
            public string drug_dosform { get; set; }// 剂型  字符型	50		Y
            /// <summary>
            /// 
            /// </summary>
            public string drug_spec { get; set; } //  规格 字符型	50		Y
            /// <summary>
            /// 
            /// </summary>
            public double drug_totlcnt { get; set; }//    数量 数值型	16,4		Y
            /// <summary>
            /// 
            /// </summary>
            public string aprvno { get; set; }//  批准文号 字符型	30		
            /// <summary>
            /// 
            /// </summary>
            public string bchno { get; set; }// 批次号 字符型	30		
            /// <summary>
            /// 
            /// </summary>
            public string fixmedins_code { get; set; }// 定点医药机构编号(结算)    字符型	50		Y
            /// <summary>
            /// 
            /// </summary>
            public string fixmedins_name { get; set; }//  定点医药机构名称(结算)    字符型	50		Y
            /// <summary>
            /// 
            /// </summary>
            public string manu_lot_num { get; set; }  // 生产批号 字符型	30	
            /// <summary>
            /// 
            /// </summary>
            public string prdr_name { get; set; }//生厂厂家    字符型	100		Y
            /// <summary>
            /// 
            /// </summary>
            public decimal pric { get; set; }//    单价 数值型	16,4		Y
            /// <summary>
            /// 
            /// </summary>
            public string total_unit { get; set; }//  总计单位 字符型	20		Y
            /// <summary>
            /// 
            /// </summary>
            public decimal sumamt { get; set; }//  合计金额 数值型	16,2		Y
        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB.CFZX
{
    public class CFHX7206
    {
        public class In7206
        {
            public In7206data data { get; set;  }
        }
        public class  In7206data
        {
            public string hi_rxno { get; set; }// 医保处方编号  字符型	30		Y
            public string phar_cert_type { get; set; }//  审核药师证件类型 字符型	6	Y 参照人员证件类型
            public string phar_certno { get; set; }// 审核药师证件号码    字符型	50	　	　	　
            public string phar_name { get; set; }// 审核药师姓名  字符型	50	　	Y
            public string phar_prac_cert_no { get; set; }//   审核药师执业资格证号 字符型	50	　	Y
            public string dspeer_cert_type { get; set; }//    配药人证件类型 字符型	6	Y 参照人员证件类型
            public string dspeer_certno { get; set; }// 配药人证件编号 字符型	50			
            public string dspeer_name { get; set; }// 配药人姓名   字符型	40		Y
            public string pro__cert_type { get; set; }//  核对、发药人证件类型 字符型	6	Y 参照人员证件类型
            public string pro_certno { get; set; }// 核对、发药人证件编码 字符型	50			
            public string pro_name { get; set; }// 核对、发药人姓名 字符型	40		Y
            public string hi_feesetl_type { get; set; }// 医保费用结算类型 字符型	6	Y
            public string setl_id { get; set; }//   结算ID 字符型	30	　	　	医保病人必填
            public DateTime sel_retn_time { get; set; }//   销售时间 日期时间型           Y yyyy-MM-dd HH:mm:ss
            public string memo { get; set; }//    备注 字符型	500	　	　	　
            public string download_ide_code { get; set; }// 下载处方时的识别码 字符型	50		Y 电子处方令牌或医保处方授权编号
            public string payMode { get; set; }// 支付方式    字符型	3			1:自费         2:医保 3：自费+医保注：线下药店购药必填
            public decimal fund_pay_sumamt { get; set; }// 基金支付总额 数值型	16,2		Y
            public decimal psn_part_amt { get; set; }//    个人负担总金额 数值型	16,2		Y
            public decimal acct_pay { get; set; }//    个人账户支出 数值型	16,2		Y
            public decimal psn_cash_pay { get; set; }//    个人现金支出 数值型	16,2		Y
            public DateTime setl_time { get; set; }//   结算时间 日期时间型           Y yyyy-MM-dd HH:mm:ss

        }
        public class Selinfo
        {
            public string med_list_codg { get; set; }// 医疗目录编码  字符型	50	　	Y
            public string fixmedins_hilist_id { get; set; }// 定点医药机构目录编号 字符型	30	　	Y
            public string fixmedins_hilist_name { get; set; }//   定点医药机构目录名称 字符型	200	　	Y
            public string drug_genname { get; set; }//    通用名 字符型	100			
            public string drug_prodname { get; set; }// 药品商品名   字符型	100			
            public string drug_dosform { get; set; }// 剂型  字符型	50		Y
            public string drug_spec { get; set; }//   规格 字符型	50		Y
            public string aprvno { get; set; }//  批准文号 字符型	30			
            public string manu_lotnum { get; set; }// 生产批号    字符型	30	　	Y
            public string prdr_name { get; set; }//   生厂厂家 字符型	100		Y
            public DateTime manu_date { get; set; }//   生产日期 日期型         Y yyyy-MM-dd
            public DateTime expy_end { get; set; }//    有效期止 日期型             yyyy-MM-dd
            public string rx_flag { get; set; }// 处方药标志 字符型	3	Y Y
            public string trdn_flag { get; set; }// 拆零标志    字符型	3	Y Y　	0-否；1-是
            public decimal finl_trns_pric { get; set; }//  最终成交单价 数值型	16,6	　	Y
            public string bchno { get; set; }//   批次号 字符型	30			
            public string drug_trac_codg { get; set; }// 药品追溯码   字符型	30			
            public string drug_prod_barc { get; set; }// 药品条形码   字符型	30			
            public string shelf_posi { get; set; }// 货架位 字符型	20			\
            public decimal sel_retn_cnt { get; set; }// 销售数量    数值型	16,4	　	Y
            public string drug_cnt_unit { get; set; }//   药品数量单位 字符型	20		Y
            public decimal sumamt { get; set; }//  合计金额 数值型	16,2		Y

        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SY.Com.Medical.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class YPXS3505
    {
        /// <summary>
        /// 
        /// </summary>
        public class In3505
        {
            /// <summary>
            /// 
            /// </summary>
            public string med_list_codg { get; set; }// 医疗目录编码 字符型	50	　	Y
            /// <summary>
            /// 
            /// </summary>
            public string fixmedins_hilist_id { get; set; }// 定点医药机构目录编号 字符型	30	　	Y
            /// <summary>
            /// 
            /// </summary>
            public string fixmedins_hilist_name { get; set; }//   定点医药机构目录名称 字符型	200	　	Y
            /// <summary>
            /// 
            /// </summary>
            public string fixmedins_bchno { get; set; }// 定点医药机构批次流水号 字符型	30	　	Y
            /// <summary>
            /// 
            /// </summary>
            public string prsc_dr_cert_type { get; set; }//   开方医师证件类型 字符型	6	Y 参照人员证件类型
            /// <summary>
            /// 
            /// </summary>
            public string prsc_dr_certno { get; set; }// 开方医师证件号码    字符型	50	　	　	　
            /// <summary>
            /// 
            /// </summary>
            public string prsc_dr_name { get; set; }// 开方医师姓名  字符型	50	　	Y
            /// <summary>
            /// 
            /// </summary>
            public string phar_cert_type { get; set; }//  药师证件类型 字符型	6	Y 参照人员证件类型
            /// <summary>
            /// 
            /// </summary>
            public string phar_certno { get; set; }// 药师证件号码  字符型	50	　	　	　
            /// <summary>
            /// 
            /// </summary>
            public string phar_name { get; set; }// 药师姓名    字符型	50	　	Y
            /// <summary>
            /// 
            /// </summary>
            public string phar_prac_cert_no { get; set; }//   药师执业资格证号 字符型	50	　	Y
            /// <summary>
            /// 
            /// </summary>
            public string hi_feesetl_type { get; set; }// 医保费用结算类型 字符型	6	Y
            /// <summary>
            /// 
            /// </summary>
            public string setl_id { get; set; }// 结算ID 字符型	30	　	　	医保病人必填
            /// <summary>
            /// 
            /// </summary>
            public string mdtrt_sn { get; set; }//    就医流水号 字符型	30	　	Y 机构生成内唯一就诊流水
            /// <summary>
            /// 
            /// </summary>
            public string psn_no { get; set; }// 人员编号    字符型	30	　	　	　
            /// <summary>
            /// 
            /// </summary>
            public string psn_cert_type { get; set; }//人员证件类型  字符型	6	Y
            /// <summary>
            /// 
            /// </summary>
            public string certno { get; set; }//  证件号码 字符型	50	　	　	　
            /// <summary>
            /// 
            /// </summary>
            public string psn_name { get; set; }// 人员姓名    字符型	50	　	　	　
            /// <summary>
            /// 
            /// </summary>
            public string manu_lotnum { get; set; }// 生产批号    字符型	30	　	Y
            /// <summary>
            /// 
            /// </summary>
            public DateTime manu_date { get; set; }//  生产日期 日期型         Y yyyy-MM-dd
            /// <summary>
            /// 
            /// </summary>
            public DateTime expy_end { get; set; }//   有效期止 日期型             yyyy-MM-dd
            /// <summary>
            /// 
            /// </summary>
            public string rx_flag { get; set; }// 处方药标志 字符型	3	Y Y
            /// <summary>
            /// 
            /// </summary>
            public string trdn_flag { get; set; }//拆零标志    字符型	3	Y Y　	0-否；1-是
            /// <summary>
            /// 
            /// </summary>
            public decimal finl_trns_pric { get; set; }//  最终成交单价 数值型	16,6	　	　	　
            /// <summary>
            /// 
            /// </summary>
            public string rxno { get; set; }// 处方号 字符型	40		
            /// <summary>
            /// 
            /// </summary>
            public string rx_circ_flag { get; set; }// 外购处方标志  字符型	3	Y
            /// <summary>
            /// 
            /// </summary>
            public string rtal_docno { get; set; }//  零售单据号 字符型	40		Y
            /// <summary>
            /// 
            /// </summary>
            public string stoout_no { get; set; }//   销售出库单据号 字符型	40			
            /// <summary>
            /// 
            /// </summary>
            public string bchno { get; set; }// 批次号 字符型	30			
            /// <summary>
            /// 
            /// </summary>
            public string drug_trac_codg { get; set; }// 药品追溯码   字符型	30			
            /// <summary>
            /// 
            /// </summary>
            public string drug_prod_barc { get; set; }// 药品条形码   字符型	30			
            /// <summary>
            /// 
            /// </summary>
            public string shelf_posi { get; set; }// 货架位 字符型	20			
            /// <summary>
            /// 
            /// </summary>
            public decimal sel_retn_cnt { get; set; }// 销售/退货数量 数值型	16,4	　	Y
            /// <summary>
            /// 
            /// </summary>
            public DateTime sel_retn_time { get; set; }//   销售/退货时间 日期时间型           Y yyyy-MM-dd HH:mm:ss
            /// <summary>
            /// 
            /// </summary>
            public string sel_retn_opter_name { get; set; }// 销售/退货经办人姓名 字符型	50	　	Y
            /// <summary>
            /// 
            /// </summary>
            public string memo { get; set; }//    备注 字符型	500	　	　	　

        }
    }
}
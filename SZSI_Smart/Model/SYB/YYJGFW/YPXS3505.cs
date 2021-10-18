using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MK.Clinic.Model
{
    public class YPXS3505
    {
        public class In3505
        {
            public string med_list_codg { get; set; }// 医疗目录编码 字符型	50	　	Y
            public string fixmedins_hilist_id { get; set; }// 定点医药机构目录编号 字符型	30	　	Y
            public string fixmedins_hilist_name { get; set; }//   定点医药机构目录名称 字符型	200	　	Y
            public string fixmedins_bchno { get; set; }// 定点医药机构批次流水号 字符型	30	　	Y
            public string prsc_dr_cert_type { get; set; }//   开方医师证件类型 字符型	6	Y 参照人员证件类型
            public string prsc_dr_certno { get; set; }// 开方医师证件号码    字符型	50	　	　	　
            public string prsc_dr_name { get; set; }// 开方医师姓名  字符型	50	　	Y
            public string phar_cert_type { get; set; }//  药师证件类型 字符型	6	Y 参照人员证件类型
            public string phar_certno { get; set; }// 药师证件号码  字符型	50	　	　	　
            public string phar_name { get; set; }// 药师姓名    字符型	50	　	Y
            public string phar_prac_cert_no { get; set; }//   药师执业资格证号 字符型	50	　	Y
            public string hi_feesetl_type { get; set; }// 医保费用结算类型 字符型	6	Y
            public string setl_id { get; set; }// 结算ID 字符型	30	　	　	医保病人必填
            public string mdtrt_sn { get; set; }//    就医流水号 字符型	30	　	Y 机构生成内唯一就诊流水
            public string psn_no { get; set; }// 人员编号    字符型	30	　	　	　
            public string psn_cert_type { get; set; }//人员证件类型  字符型	6	Y
            public string certno { get; set; }//  证件号码 字符型	50	　	　	　
            public string psn_name { get; set; }// 人员姓名    字符型	50	　	　	　
            public string manu_lotnum { get; set; }// 生产批号    字符型	30	　	Y
            public DateTime manu_date { get; set; }//  生产日期 日期型         Y yyyy-MM-dd
            public DateTime expy_end { get; set; }//   有效期止 日期型             yyyy-MM-dd
            public string rx_flag { get; set; }// 处方药标志 字符型	3	Y Y
            public string trdn_flag { get; set; }//拆零标志    字符型	3	Y Y　	0-否；1-是
            public decimal finl_trns_pric { get; set; }//  最终成交单价 数值型	16,6	　	　	　
            public string rxno { get; set; }// 处方号 字符型	40		
            public string rx_circ_flag { get; set; }// 外购处方标志  字符型	3	Y
            public string rtal_docno { get; set; }//  零售单据号 字符型	40		Y
            public string stoout_no { get; set; }//   销售出库单据号 字符型	40			
            public string bchno { get; set; }// 批次号 字符型	30			
            public string drug_trac_codg { get; set; }// 药品追溯码   字符型	30			
            public string drug_prod_barc { get; set; }// 药品条形码   字符型	30			
            public string shelf_posi { get; set; }// 货架位 字符型	20			
            public decimal sel_retn_cnt { get; set; }// 销售/退货数量 数值型	16,4	　	Y
            public DateTime sel_retn_time { get; set; }//   销售/退货时间 日期时间型           Y yyyy-MM-dd HH:mm:ss
            public string sel_retn_opter_name { get; set; }// 销售/退货经办人姓名 字符型	50	　	Y
            public string memo { get; set; }//    备注 字符型	500	　	　	　

        }
    }
}
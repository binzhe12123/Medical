using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB.XXCX
{
    public class FY5204
    {
        public class In5204
        {
            public string psn_no { get; set; }//   人员编号 字符型	30		Y
            public string setl_id { get; set; }// 结算ID 字符型	30		
            public string mdtrt_id { get; set; }// 就诊ID    字符型	30		Y

        }
        public class Out5204
        {
            public string mdtrt_id { get; set; }//  就诊ID 字符型	30	　	Y\
            public string setl_id { get; set; }// 结算ID 字符型	30	　	Y
            public string feedetl_sn { get; set; }// 费用明细流水号 字符型	30	　	Y
            public string rx_drord_no { get; set; }// 处方/医嘱号 字符型	30	　	　	　
            public string med_type { get; set; }// 医疗类别    字符型	6	Y Y
            public DateTime fee_ocur_time { get; set; }// 费用发生时间  日期时间型 Y   yyyy-MM-dd HH:mm:ss
            public decimal cnt { get; set; }// 数量 数值型	16,4	　	Y
            public decimal pric { get; set; }//    单价 数值型	16,6	　	Y
            public string sin_dos_dscr { get; set; }//    单次剂量描述 字符型	200			
            public string used_frqu_dscr { get; set; }// 使用频次描述  字符型	200			
            public int prd_days { get; set; }// 周期天数    数值型	4,2			
            public string medc_way_dscr { get; set; }// 用药途径描述  字符型	200			
            public decimal det_item_fee_sumamt { get; set; }// 明细项目费用总额    数值型	16,2	　	Y
            public decimal pric_uplmt_amt { get; set; }//  定价上限金额 数值型	16,6	　	Y
            public decimal selfpay_prop { get; set; }//    自付比例 数值型	5,4	　	　	　
            public decimal fulamt_ownpay_amt { get; set; }// 全自费金 额   数值型	16,2	　	　	　
            public decimal overlmt_amt { get; set; }// 超限价金额   数值型	16,2	　	　	　
            public decimal preselfpay_amt { get; set; }// 先行自付金额  数值型	16,2	　	　	　
            public decimal inscp_scp_amt { get; set; }// 符合政策范围金额    数值型	16,2	　	　	　
            public string chrgitm_lv { get; set; }// 收费项目等级  字符型	3	Y Y
            public string hilist_code { get; set; }// 医保目录编码  字符型	50	　	Y
            public string hilist_name { get; set; }// 医保目录名称 字符型	200	　	Y
            public string list_type { get; set; }//   目录类别 字符型	6	Y Y
            public string med_list_codg { get; set; }// 医疗目录编码  字符型	50	　	Y
            public string medins_list_codg { get; set; }//   医药机构目录编码 字符型	150	　	Y
            public string medins_list_name { get; set; }//    医药机构目录名称 字符型	100	　	Y
            public string med_chrgitm_type { get; set; }//    医疗收费项目类别 字符型	6	Y Y
            public string prodname { get; set; }// 商品名 字符型	200	　	　	　
            public string spec { get; set; }// 规格  字符型	200	　	　	　
            public string dosform_name { get; set; }// 剂型名称    字符型	200	　	Y
            public string bilg_dept_codg { get; set; }//  开单科室编码 字符型	30	　	　	　
            public string bilg_dept_name { get; set; }// 开单科室名称  字符型	100	　	　	　
            public string bilg_dr_codg { get; set; }// 开单医生编码  字符型	30	　	　	
            public string bilg_dr_name { get; set; }// 开单医师姓名  字符型	50	　	　	　
            public string acord_dept_codg { get; set; }// 受单科室编码  字符型	30	　	　
            public string acord_dept_name { get; set; }// 受单科室名称  字符型	100	　	　	　
            public string orders_dr_code { get; set; }//受单医生编码  字符型	30	　	　	
            public string orders_dr_name { get; set; }// 受单医生姓名  字符型	50	　	　	　
            public string lmt_used_flag { get; set; }// 限制使用标志  字符型	3	Y
            public string hosp_prep_flag { get; set; }//  医院制剂标志 字符型	3	Y
            public string hosp_appr_flag { get; set; }// 医院审批标志 字符型	3	Y
            public string tcmdrug_used_way { get; set; }//    中药使用方式 字符型	6	Y
            public string prodplac_type { get; set; }//   生产地类别 字符型	6	Y
            public string bas_medn_flag { get; set; }//  基本药物标志 字符型	3	Y
            public string hi_nego_drug_flag { get; set; }//   医保谈判药品标志 字符型	3	Y
            public string chld_medc_flag { get; set; }//  儿童用药标志 字符型	3	Y
            public string etip_flag { get; set; }//   外检标志 字符型	3	Y
            public string etip_hosp_code { get; set; }//  外检医院编码 字符型	30		　	
            public string dscg_tkdrug_flag { get; set; }// 出院带药标志  字符型	3	Y\
            public string list_sp_item_flag { get; set; }//   目录特项标志 字符型	3	Y 特检特治项目或特殊药品
            public string matn_fee_flag { get; set; }// 生育费用标志  字符型	6	Y
            public string drt_reim_flag { get; set; }//   直报标志 字符型	3	Y
            public string memo { get; set; }//   备注 字符型	500	　	　	　
            public string opter_id { get; set; }// 经办人ID   字符型	20	　	　	　
            public string opter_name { get; set; }// 经办人姓名   字符型	50	　	　	　
            public DateTime opt_timeP { get; set; }// 经办时间    日期时间型 yyyy-MM-dd HH:mm:ss

        }
    }
}
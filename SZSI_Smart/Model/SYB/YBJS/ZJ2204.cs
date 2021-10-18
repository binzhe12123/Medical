﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB
{
    public class ZJ2204
    {
        public class In2204
        {
            public FeeDetail feedetail { get; set; }        

        }
        public class FeeDetail
        {
            public string feedetl_sn { get; set; }// 费用明细流水号 字符型	30	　	Y 单次就诊内唯一
            public string mdtrt_id { get; set; }// 就诊ID    字符型	30		Y
            public string psn_no { get; set; }//  人员编号 字符型	30	　	Y
            public string chrg_bchno { get; set; }//  收费批次号 字符型	30		Y 同一收费批次号病种编号必须一致
            public string dise_codg { get; set; }// 病种编码  按照标准编码填写：按病种结算病种目录代码(bydise_setl_list_code)、门诊慢特病病种目录代码(opsp_dise_cod)
            public string rxno { get; set; }// 处方号 字符型	30	　		外购处方时，传入外购处方的处方号；非外购处方，传入医药机构处方号
            public string rx_circ_flag { get; set; } //   外购处方标志 字符型	3	Y Y
            public DateTime fee_ocur_time { get; set; }// 费用发生时间  日期时间型 Y   yyyy-MM-dd HH:mm:ss
            public string med_list_codg { get; set; } //  医疗目录编码 字符型	50	　	Y
            public string medins_list_codg { get; set; }//    医药机构目录编码 字符型	150	　	Y
            public decimal det_item_fee_sumamt { get; set; }// 明细项目费用总额 数值型	16,2	　	Y
            public double cnt { get; set; } //数量 数值型	16,4	　	Y
            public decimal pric { get; set; }// 单价 数值型	16,6	　	Y
            public string sin_dos_dscr { get; set; }// 单次剂量描述 字符型	200		
            public string used_frqu_dscr { get; set; }// 使用频次描述  字符型	200			
            public int prd_days { get; set; }// 周期天数    数值型	4,2			
            public string medc_way_dscr { get; set; }// 用药途径描述  字符型	200			
            public string bilg_dept_codg { get; set; }// 开单科室编码  字符型	30	　	Y
            public string bilg_dept_name { get; set; } // 开单科室名称 字符型	100	　	Y
            public string bilg_dr_codg { get; set; }//    开单医生编码 字符型	30	　	Y 按照标准编码填写
            public string bilg_dr_name { get; set; }// 开单医师姓名  字符型	50	　	Y
            public string acord_dept_codg { get; set; }// 受单科室编码 字符型	30	　	　	
            public string acord_dept_name { get; set; }// 受单科室名称  字符型	100	　	　	　
            public string orders_dr_code { get; set; }// 受单医生编码  字符型	30	　	　	按照标准编码填写
            public string orders_dr_name { get; set; }//  受单医生姓名 字符型	50	　	　	　
            public string hosp_appr_flag { get; set; }// 医院审批标志  字符型	3	Y Y
            public string tcmdrug_used_way { get; set; }// 中药使用方式  字符型	6	Y
            public string etip_flag { get; set; }// 外检标志 字符型	3	Y
            public string etip_hosp_code { get; set; }//  外检医院编码 字符型	30	　	　	按照标准编码填写
            public string dscg_tkdrug_flag { get; set; }//    出院带药标志 字符型	3	Y
            public string matn_fee_flag { get; set; }//  生育费用标志 字符型	6	Y
        }
        public class Out2204
        {
            public Result result { get; set; }
        }
        public class Result 
        {
            public string feedetl_sn { get; set; }// 费用明细流水号 字符型	30	　	Y
            public decimal det_item_fee_sumamt { get; set; } //明细项目费用总额 数值型	16,2	　	Y
            public double cnt { get; set; }//数量 数值型	16,4	　	Y
            public decimal pric { get; set; }//   单价 数值型	16,6	　	Y
            public decimal pric_uplmt_amt { get; set; }//  定价上限金额 数值型	16,6	　	Y
            public double selfpay_prop { get; set; }//    自付比例 数值型	5,4	　	　
            public decimal fulamt_ownpay_amt { get; set; }// 全自费金额   数值型	16,2	　	　	　
            public decimal overlmt_amt { get; set; }// 超限价金额   数值型	16,2	　	　	　
            public decimal preselfpay_amt { get; set; }// 先行自付金额  数值型	16,2	　	　	　
            public decimal inscp_scp_amt { get; set; }// 符合政策范围金额    数值型	16,2	　	　	　
            public string chrgitm_lv { get; set; } //收费项目等级  字符型	3	Y Y
            public string med_chrgitm_type { get; set; }// 医疗收费项目类别    字符型	6	Y Y
            public string bas_medn_flag { get; set; }// 基本药物标志  字符型	3	Y
            public string hi_nego_drug_flag { get; set; }//   医保谈判药品标志 字符型	3	Y
            public string chld_medc_flag { get; set; }//  儿童用药标志 字符型	3	Y
            public string list_sp_item_flag { get; set; }//   目录特项标志 字符型	3	Y 特检特治项目或特殊药品
            public string lmt_used_flag { get; set; }// 限制使用标志  字符型	3	Y Y
            public string drt_reim_flag { get; set; }//直报标志    字符型	3	Y
            public string memo { get; set; }//   备注 字符型	500	　	　	明细分割错误信息

        }
    }
}
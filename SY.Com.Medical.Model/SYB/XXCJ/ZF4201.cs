﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB.XXCJ
{
    /// <summary>
    /// 
    /// </summary>
    public class ZF4201
    {
        /// <summary>
        /// 
        /// </summary>
        public class In4201 
        {
            /// <summary>
            /// 
            /// </summary>
            public string mdtrt_sn { get; set; }// 就医流水号   字符型	30	　	Y 机构生成内唯一就诊流水
            /// <summary>
            /// 
            /// </summary>
            public string ipt_otp_no { get; set; }// 住院/门诊号 字符型	30	　	Y 院内唯一流水
            /// <summary>
            /// 
            /// </summary>
            public string med_type { get; set; }// 医疗类别    字符型	6	Y Y
            /// <summary>
            /// 
            /// </summary>
            public string chrg_bchno { get; set; }// 收费批次号   字符型	30		Y 同一收费批次号病种编号必须一致
            /// <summary>
            /// 
            /// </summary>
            public string feedetl_sn { get; set; }// 费用明细流水号 字符型	30	　	Y 单次就诊内唯一
            /// <summary>
            /// 
            /// </summary>
            public string psn_cert_type { get; set; }// 人员证件类型  字符型	6	Y Y
            /// <summary>
            /// 
            /// </summary>
            public string certno { get; set; }// 证件号码    字符型	50		Y
            /// <summary>
            /// 
            /// </summary>
            public string psn_name { get; set; }//    人员姓名 字符型	50		Y
            /// <summary>
            /// 
            /// </summary>
            public DateTime fee_ocur_time { get; set; }//   费用发生时间 日期时间型           Y yyyy-MM-dd HH:mm:ss
            /// <summary>
            /// 
            /// </summary>
            public double cnt { get; set; }// 数量 数值型	16,4	　	Y
            /// <summary>
            /// 
            /// </summary>
            public decimal pric { get; set; }//    单价 数值型	16,6	　	Y
            /// <summary>
            /// 
            /// </summary>
            public string det_item_fee_sumamt { get; set; }// 明细项目费用总额 数值型	16,2	　	Y
            /// <summary>
            /// 
            /// </summary>
            public string med_list_codg { get; set; }//  医疗目录编码 字符型	50	　	Y
            /// <summary>
            /// 
            /// </summary>
            public string medins_list_codg { get; set; }//    医药机构目录编码 字符型	150	　	Y
            /// <summary>
            /// 
            /// </summary>
            public string medins_list_name { get; set; }//     医药机构目录名称 字符型	100	　	Y
            /// <summary>
            /// 
            /// </summary>
            public string med_chrgitm_type { get; set; }//  医疗收费项目类别 字符型	6	　Y Y
            /// <summary>
            /// 
            /// </summary>
            public string prodname { get; set; }//商品名 字符型	200	　	Y
            /// <summary>
            /// 
            /// </summary>
            public string bilg_dept_codg { get; set; }//  开单科室编码 字符型	30	　	Y
            /// <summary>
            /// 
            /// </summary>
            public string bilg_dept_name { get; set; }//  开单科室名称 字符型	100	　	Y
            /// <summary>
            /// 
            /// </summary>
            public string bilg_dr_codg { get; set; }//   开单医生编码 字符型	30	　	Y
            /// <summary>
            /// 
            /// </summary>
            public string bilg_dr_name { get; set; }//    开单医师姓名 字符型	50	　	Y
            /// <summary>
            /// 
            /// </summary>
            public string acord_dept_codg { get; set; }// 受单科室编码 字符型	30	　	　	　
            /// <summary>
            /// 
            /// </summary>
            public string acord_dept_name { get; set; }// 受单科室名称  字符型	100		　	　
            /// <summary>
            /// 
            /// </summary>
            public string orders_dr_code { get; set; }// 受单医生编码  字符型	30	　	　	
            /// <summary>
            /// 
            /// </summary>
            public string orders_dr_name { get; set; }// 受单医生姓名  字符型	50	　	　	　
            /// <summary>
            /// 
            /// </summary>
            public string tcmdrug_used_way { get; set; }// 中药使用方式  字符型	6	　Y
            /// <summary>
            /// 
            /// </summary>
            public string etip_flag { get; set; }// 外检标志 字符型	3	　Y
            /// <summary>
            /// 
            /// </summary>
            public string etip_hosp_code { get; set; }// 外检医院编码 字符型	30	　	　	
            /// <summary>
            /// 
            /// </summary>
            public string dscg_tkdrug_flag { get; set; }// 出院带药标志  字符型	3	　Y
            /// <summary>
            /// 
            /// </summary>
            public string memo { get; set; }//    备注 字符型	500	　	　	　

        }
    }
}
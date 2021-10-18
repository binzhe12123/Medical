using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB.XXCJ
{
    public class MJZ4301
    {
        public class In4301
        {
            public Rgstinfo rgstinfo { get; set; }
            public CaseInfo caseinfo { get; set; }
            public DiseInfo diseInfo { get; set; }
            public RxInfo rxInfo { get; set; }


        }
        public class Rgstinfo 
        {
            public string mdtrt_sn { get; set; }// 就医流水号   字符型	30		Y 院内唯一号
            public string mdtrt_id { get; set; }// 就诊ID    字符型	30			医保病人必填
            public string psn_no { get; set; }//  人员编号 字符型	30			医保病人必填
            public string rgst_type_code { get; set; }//  挂号类别代码 字符型	6	Y
            public string rgst_way_code { get; set; }//  挂号方式代码 字符型	6	Y
            public string rgst_serv_fee { get; set; }//  挂号费/医事服务费 数值型	16,2			
            public string ordr_way_code { get; set; }//  预约途径代码  字符型	30			
            public string retnr_flag { get; set; }//   退号标志    字符型	3			0-否、1-是
            public string fstdiag_flag { get; set; }//      初诊标志 字符型	3			0-否、1-是
            public string mdtrt_flag { get; set; }//   就诊标志 字符型	3			0-否、1-是
            public DateTime  rgst_retnr_time { get; set; }//  rgst_retnr_time 挂号/退号时间 日期时间型
            public string medfee_paymtd_code { get; set; }// medfee_paymtd_code 医疗费用支付方式代码  字符型	3	Y
            public string vali_flag { get; set; }//     有效标志 字符型	3	Y Y

        }
        public class CaseInfo 
        {
            public DateTime mdtrt_date { get; set; }//mdtrt_date 就诊日期    日期型
            public string chfcomp { get; set; }//  主诉 字符型	2000		
            public DateTime  attk_date_time { get; set; }//  发病日期时间  日期时间型				
            public string mdtrt_rea { get; set; }// 就诊原因 字符型	200		
            public string illhis { get; set; }// 病史  字符型	2000
            public string algs { get; set; }// 过敏史 字符型	2000	
            public string aise_code { get; set; }//aise_code 过敏源代码   字符型	30	
            public string phex { get; set; }// 查体  字符型	2000	
            public string disa_info_code { get; set; }// 残疾情况代码  字符型	30	
            public string symp_name { get; set; }// 症状名称    字符型	1000	
            public string symp_code { get; set; }// 症状代码    字符型	50			最多五个症状
            public string dspo_opnn { get; set; }//   处置意见 字符型	1000
            public string dept_code { get; set; }//   科室代码    字符型	30			
            public string dept_name { get; set; }//  科室名称    字符型	50			
            public string vali_flag { get; set; }//   有效标志    字符型	3	Y Y

        }
        public class DiseInfo 
        {
            public string tcm_diag_flag { get; set; }//  中医诊断标志  字符型	30		
            public string maindiag_flag { get; set; }//  主诊断标志   字符型	30		
            public string diag_code { get; set; }// 诊断代码    字符型	20		
            public string diag_name { get; set; }// 诊断名称    字符型	100		
            public string tcm_dise_code { get; set; }// 中医病名代码  字符型	20		
            public string tcm_dise_name { get; set; }// 中医病名名称  字符型	300		
            public string tcmsymp_code { get; set; }// 中医证候代码  字符型	20		
            public string tcmsymp { get; set; }// 中医证候    字符型	300		
            public string vali_flag { get; set; }//vali_flag 有效标志    字符型	3	Y Y

        }
        public class RxInfo
        {
            public string rxno { get; set; }// 处方号 字符型	30			
            public string rx_prsc_time { get; set; }// 处方开方时间  日期时间型
            public string rx_type_code { get; set; }//     处方类别代码 字符型	30			
            public string rx_item_type_code { get; set; }// 处方项目分类代码    字符型	30			
            public string rx_item_type_name { get; set; }// 处方项目分类名称    字符型	100			
            public string rx_detl_id { get; set; }// 处方明细代码  字符型	30			医院内部药品编码
            public string rx_detl_name { get; set; }//    处方明细名称 字符型	100			医院内部药品名称
            public string tcmdrug_type_name { get; set; }//   中药类别名称 字符型	20			
            public string tcmdrug_type_code { get; set; }// 中药类别代码  字符型	30			
            public string tcmherb_foote { get; set; }// 草药脚注    字符型	200			
            public string medn_type_code { get; set; }// 药物类型代码  字符型	100			
            public string medn_type_name { get; set; }// 药物类型    字符型	100			
            public string drug_dosform { get; set; }// 药品剂型    字符型	30			【dosform】代码
            public string drug_dosform_name { get; set; }//   药品剂型名称 字符型	200			
            public string drug_spec { get; set; }// 药品规格    字符型	255			
            public string drug_used_frqu { get; set; }// 药物使用-频率 字符型	30			
            public int drug_used_idose { get; set; }// 药物使用-总剂量 数值型	16，4			
            public int drug_used_sdose { get; set; }//drug_used_sdose 药物使用-次剂量 数值型	30			
            public string drug_used_dosunt { get; set; }// 药物使用-剂量单位 字符型	30			
            public string drug_used_way_code { get; set; }// 药物使用-途径代码 字符型	30			
            public string drug_medc_way { get; set; }// 药物使用-途径 字符型	100			
            public string skintst_dicm { get; set; }// 皮试判别    字符型	30			
            public DateTime medc_begntime { get; set; }// 用药开始时间  日期时间型
            public DateTime medc_endtime { get; set; }//     用药停止日期时间 日期时间型
            public string medc_days { get; set; }//  用药天数    数值型	5,0			
            public string main_medc_flag { get; set; }// 主要用药标志  字符型	30			
            public string urgt_flag { get; set; }// 加急标志    字符型	30			
            public string unif_purc_drug { get; set; }// 统一采购药品  字符型	30			
            public string drug_purc_code { get; set; }// 药品采购代码  字符型	30			
            public string drug_mgt_plaf_code { get; set; }// 药品管理平台代码    字符型	50			
            public string bas_medn_flag { get; set; }// 基本药物标志  字符型	3	Y
            public string vali_flag { get; set; }//   有效标志 字符型	3	Y Y

        }
    }
}
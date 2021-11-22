﻿using System;

namespace SY.Com.Medical.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class SQMX3101
    {
        /// <summary>
        /// 
        /// </summary>
        public class In3101
        {
            /// <summary>
            /// 
            /// </summary>
            public In3101data data{get;set;}
            /// <summary>
            /// 
            /// </summary>
            public Patient_Dtos patient_dtos { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Fsi_Encounter_Dtos fsi_encounter_dtos { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Fsi_Diagnose_Dtos fsi_diagnose_dtos { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Fsi_Order_Dtos fsi_order_dtos { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Fsi_Operation_Dtos fsi_operation_dtos { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        public class In3101data 
        {
            /// <summary>
            /// 
            /// </summary>
            public string syscode { get; set; }// 系统编码    字符型	10		Y 调用方系统简码标识
            /// <summary>
            /// 
            /// </summary>
            public string patient_dtos { get; set; }//参保人信息   参保人信息集合 Y
            /// <summary>
            /// 
            /// </summary>
            public string rule_ids { get; set; }// 规则标识集合  规则标识集合
            /// <summary>
            /// 
            /// </summary>
            public string task_id { get; set; }// 任务ID 字符型             每次请求的唯一标识
            /// <summary>
            /// 
            /// </summary>
            public string trig_scen { get; set; }//   触发场景 字符型	3			此值与ruleIds指定其一即可,请优先指定此值

        }
        /// <summary>
        /// 
        /// </summary>
        public class Patient_Dtos
        {
            /// <summary>
            /// 
            /// </summary>
            public string patn_id { get; set; }// 参保人标识   字符型	50		Y 参保人唯一ID
            /// <summary>
            /// 
            /// </summary>
            public string patn_name { get; set; }// 姓名  字符型	50		Y
            /// <summary>
            /// 
            /// </summary>
            public string gend { get; set; }//   性别 字符型	3		Y 参考字典表
            /// <summary>
            /// 
            /// </summary>
            public DateTime brdy { get; set; }//出生日期    日期型 Y   格式：yyyy-MM-dd
            /// <summary>
            /// 
            /// </summary>
            public string poolarea { get; set; }//    统筹区编码 字符型	10		Y 参保人所属统筹区
            /// <summary>
            /// 
            /// </summary>
            public string curr_mdtrt_id { get; set; }// 当前就诊标识  字符型	50		Y 本次就诊记录唯一ID
            /// <summary>
            /// 
            /// </summary>
            public string fsi_encounter_dtos { get; set; }// 就诊信息集合  就诊信息集合 Y
            /// <summary>
            /// 
            /// </summary>
            public string fsi_his_data_dto { get; set; }// 医院信息集合  医院信息集合

        }
        /// <summary>
        /// 
        /// </summary>
        public class Fsi_Encounter_Dtos
        {
            /// <summary>
            /// 
            /// </summary>
            public string mdtrt_id { get; set; } //就诊标识    字符型	50		Y 就诊记录唯一ID
            /// <summary>
            /// 
            /// </summary>
            public string medins_id { get; set; }// 医疗服务机构标识    字符型	50		Y 定点医疗机构ID
            /// <summary>
            /// 
            /// </summary>
            public string medins_name { get; set; }// 医疗机构名称  字符型	200		Y
            /// <summary>
            /// 
            /// </summary>
            public string medins_admdvs { get; set; }//   医疗机构行政区划编码 字符型	6		Y
            /// <summary>
            /// 
            /// </summary>
            public string medins_type { get; set; }// 医疗服务机构类型 字符型	3	Y Y   参考字典表
            /// <summary>
            /// 
            /// </summary>
            public string medins_lv { get; set; }//   医疗机构等级 字符型	3		Y 参考字典表
            /// <summary>
            /// 
            /// </summary>
            public string wardarea_codg { get; set; }// 病区标识    字符型	20			　
            /// <summary>
            /// 
            /// </summary>
            public string wardno { get; set; }// 病房号 字符型	20			　
            /// <summary>
            /// 
            /// </summary>
            public string bedno { get; set; }// 病床号 字符型	20			　
            /// <summary>
            /// 
            /// </summary>
            public DateTime adm_date { get; set; }// 入院日期    日期型 Y   格式：yyyy-MM-dd HH:mm:ss
            /// <summary>
            /// 
            /// </summary>
            public DateTime dscg_date { get; set; }//  出院日期 日期型         Y 格式：yyyy-MM-dd HH:mm:ss
            /// <summary>
            /// 
            /// </summary>
            public string dscg_main_dise_codg { get; set; }// 主诊断编码 字符型	20		Y 例如：I63.9
            /// <summary>
            /// 
            /// </summary>
            public string dscg_main_dise_name { get; set; }// 主诊断名称   字符型	50		Y 例如：脑梗塞
            /// <summary>
            /// 
            /// </summary>
            public string fsi_diagnose_dtos { get; set; }//   诊断信息DTO 诊断信息集合          Y
            /// <summary>
            /// 
            /// </summary>
            public string dr_codg { get; set; }// 医师标识 字符型	20		Y 医生唯一ID
            /// <summary>
            /// 
            /// </summary>
            public string adm_dept_codg { get; set; }// 入院科室标识  字符型	20		Y 科室唯一ID
            /// <summary>
            /// 
            /// </summary>
            public string adm_dept_name { get; set; }// 入院科室名称  字符型	50		Y
            /// <summary>
            /// 
            /// </summary>
            public string dscg_dept_codg { get; set; }//  出院科室标识 字符型	20		Y 科室唯一ID
            /// <summary>
            /// 
            /// </summary>
            public string dscg_dept_name { get; set; }// 出院科室名称  字符型	50		Y
            /// <summary>
            /// 
            /// </summary>
            public string med_mdtrt_type { get; set; }//  就诊类型 字符型	3	Y Y   参考字典表
            /// <summary>
            /// 
            /// </summary>
            public string med_type { get; set; }   // 医疗类别 字符型	3	Y Y   参考字典表
            /// <summary>
            /// 
            /// </summary>
            public string fsi_order_dtos { get; set; }//处方(医嘱)信息 处方信息集合          Y
            /// <summary>
            /// 
            /// </summary>
            public string matn_stas { get; set; }//  生育状态 字符型	3	Y Y   参考字典表
            /// <summary>
            /// 
            /// </summary>
            public decimal medfee_sumamt { get; set; }//   总费用 数值型	16,2		Y
            /// <summary>
            /// 
            /// </summary>
            public decimal ownpay_amt { get; set; }//  自费金额 数值型	16,2		Y
            /// <summary>
            /// 
            /// </summary>
            public decimal selfpay_amt { get; set; }// 自付金额 数值型	16,2		Y
            /// <summary>
            /// 
            /// </summary>
            public decimal acct_payamt { get; set; }// 个人账户支付金额 数值型	16,2	
            /// <summary>
            /// 
            /// </summary>
            public decimal ma_amt { get; set; }// 救助金支付金额 数值型	16,2			　
            /// <summary>
            /// 
            /// </summary>
            public decimal hifp_payamt { get; set; }//统筹金支付金额 数值型	16,2			　
            /// <summary>
            /// 
            /// </summary>
            public int setl_totlnum { get; set; }// 结算总次数   数值型	4		Y
            /// <summary>
            /// 
            /// </summary>
            public string insutype { get; set; }//    险种 字符型	3	Y Y   参考字典表
            /// <summary>
            /// 
            /// </summary>
            public string reim_flag { get; set; }//   报销标志 字符型	3	Y Y   参考字典表
            /// <summary>
            /// 
            /// </summary>
            public string out_setl_flag { get; set; }//   异地结算标志 字符型	3	Y Y   参考字典表
            /// <summary>
            /// 
            /// </summary>
            public string fsi_operation_dtos { get; set; }//  手术操作集合 手术操作集合

        }
        /// <summary>
        /// 
        /// </summary>
        public class Fsi_Diagnose_Dtos 
        {
            /// <summary>
            /// 
            /// </summary>
            public string mdtrt_id { get; set; }// 就诊标识    字符型	50		Y 就诊记录唯一ID
            /// <summary>
            /// 
            /// </summary>
            public string medins_id { get; set; } //医疗服务机构标识    字符型	50		Y 定点医疗机构ID
            /// <summary>
            /// 
            /// </summary>
            public string medins_name { get; set; }// 医疗机构名称  字符型	200		Y
            /// <summary>
            /// 
            /// </summary>
            public string medins_admdvs { get; set; }//  医疗机构行政区划编码 字符型	6		Y
            /// <summary>
            /// 
            /// </summary>
            public string medins_type { get; set; }// 医疗服务机构类型 字符型	3	Y Y   参考字典表
            /// <summary>
            /// 
            /// </summary>
            public string medins_lv { get; set; }//   医疗机构等级 字符型	3		Y 参考字典表
            /// <summary>
            /// 
            /// </summary>
            public string wardarea_codg { get; set; }// 病区标识    字符型	20			　
            /// <summary>
            /// 
            /// </summary>
            public string wardno { get; set; }// 病房号 字符型	20			　
            /// <summary>
            /// 
            /// </summary>
            public string bedno { get; set; }// 病床号 字符型	20			　
            /// <summary>
            /// 
            /// </summary>
            public DateTime adm_date { get; set; }// 入院日期    日期型 Y   格式：yyyy-MM-dd HH:mm:ss
            /// <summary>
            /// 
            /// </summary>
            public DateTime dscg_date { get; set; }//   出院日期 日期型         Y 格式：yyyy-MM-dd HH:mm:ss
            /// <summary>
            /// 
            /// </summary>
            public string dscg_main_dise_codg { get; set; }// 主诊断编码 字符型	20		Y 例如：I63.9
            /// <summary>
            /// 
            /// </summary>
            public string dscg_main_dise_name { get; set; }// 主诊断名称   字符型	50		Y 例如：脑梗塞
            /// <summary>
            /// 
            /// </summary>
            public string fsi_diagnose_dtos { get; set; }//   诊断信息DTO 诊断信息集合          Y
            /// <summary>
            /// 
            /// </summary>
            public string dr_codg { get; set; }// 医师标识 字符型	20		Y 医生唯一ID
            /// <summary>
            /// 
            /// </summary>
            public string adm_dept_codg { get; set; }// 入院科室标识  字符型	20		Y 科室唯一ID
            /// <summary>
            /// 
            /// </summary>
            public string adm_dept_name { get; set; }// 入院科室名称  字符型	50		Y
            /// <summary>
            /// 
            /// </summary>
            public string dscg_dept_codg { get; set; }//  出院科室标识 字符型	20		Y 科室唯一ID
            /// <summary>
            /// 
            /// </summary>
            public string dscg_dept_name { get; set; }//出院科室名称  字符型	50		Y
            /// <summary>
            /// 
            /// </summary>
            public string med_mdtrt_type { get; set; }//  就诊类型 字符型	3	Y Y   参考字典表
            /// <summary>
            /// 
            /// </summary>
            public string med_type { get; set; }//    医疗类别 字符型	3	Y Y   参考字典表
            /// <summary>
            /// 
            /// </summary>
            public string fsi_order_dtos { get; set; }//处方(医嘱)信息 处方信息集合          Y
            /// <summary>
            /// 
            /// </summary>
            public string matn_stas { get; set; }//   生育状态 字符型	3	Y Y   参考字典表
            /// <summary>
            /// 
            /// </summary>
            public decimal medfee_sumamt { get; set; }//   总费用 数值型	16,2		Y
            /// <summary>
            /// 
            /// </summary>
            public decimal ownpay_amt { get; set; }//  自费金额 数值型	16,2		Y
            /// <summary>
            /// 
            /// </summary>
            public decimal selfpay_amt { get; set; }// 自付金额 数值型	16,2		Y
            /// <summary>
            /// 
            /// </summary>
            public decimal acct_payamt { get; set; }//个人账户支付金额 数值型	16,2			　
            /// <summary>
            /// 
            /// </summary>
            public decimal ma_amt { get; set; }// 救助金支付金额 数值型	16,2			　
            /// <summary>
            /// 
            /// </summary>
            public decimal hifp_payamt { get; set; }// 统筹金支付金额 数值型	16,2			　
            /// <summary>
            /// 
            /// </summary>
            public int setl_totlnum { get; set; }// 结算总次数   数值型	4		Y
            /// <summary>
            /// 
            /// </summary>
            public string insutype { get; set; }//    险种 字符型	3	Y Y   参考字典表
            /// <summary>
            /// 
            /// </summary>
            public string reim_flag { get; set; }//   报销标志 字符型	3	Y Y   参考字典表
            /// <summary>
            /// 
            /// </summary>
            public string out_setl_flag { get; set; }//   异地结算标志 字符型	3	Y Y   参考字典表
            /// <summary>
            /// 
            /// </summary>
            public string fsi_operation_dtos { get; set; }//  手术操作集合 手术操作集合
        }
        /// <summary>
        /// 
        /// </summary>
        public class Fsi_Order_Dtos
        {
            /// <summary>
            /// 
            /// </summary>
            public string rx_id { get; set; }// 处方(医嘱)标识 字符型	50		Y 处方(医嘱)记录唯一ID
            /// <summary>
            /// 
            /// </summary>
            public string rxno { get; set; }//    处方号 字符型	20		Y
            /// <summary>
            /// 
            /// </summary>
            public string grpno { get; set; }//   组编号 字符型	20			　
            /// <summary>
            /// 
            /// </summary>
            public string long_drord_flag { get; set; }// 是否为长期医嘱 字符型	3		Y[1 = 是, 0 = 否]
            /// <summary>
            /// 
            /// </summary>
            public string hilist_type { get; set; }// 目录类别 字符型	3	Y Y   参考字典表
            /// <summary>
            /// 
            /// </summary>
            public string chrg_type { get; set; }//  收费类别 字符型	3	Y Y   参考字典表
            /// <summary>
            /// 
            /// </summary>
            public string drord_bhvr { get; set; }// 医嘱行为 字符型	3	Y Y   参考字典表
            /// <summary>
            /// 
            /// </summary>
            public string hilist_code { get; set; }// 医保目录代码 字符型	20		Y 国家统一标准编码
            /// <summary>
            /// 
            /// </summary>
            public string hilist_name { get; set; }// 医保目录名称  字符型	50		Y 国家统一标准名称
            /// <summary>
            /// 
            /// </summary>
            public string hilist_dosform { get; set; }// 医保目录(药品)剂型 字符型	50			国家统一标准药品剂型
            /// <summary>
            /// 
            /// </summary>
            public string hilist_lv { get; set; }//   医保目录等级 字符型	3		Y
            /// <summary>
            /// 
            /// </summary>
            public decimal hilist_pric { get; set; }// 医保目录价格 数值型	16,2		Y
            /// <summary>
            /// 
            /// </summary>
            public decimal lv1_hosp_item_pric { get; set; }//  一级医院目录价格 数值型	16,2			　
            /// <summary>
            /// 
            /// </summary>
            public decimal lv2_hosp_item_pric { get; set; }// 二级医院目录价格    数值型	16,2			　
            /// <summary>
            /// 
            /// </summary>
            public decimal lv3_hosp_item_pric { get; set; }// 三级医院目录价格    数值型	16,2			　
            /// <summary>
            /// 
            /// </summary>
            public string hilist_memo { get; set; }// 医保目录备注  字符型	200			　
            /// <summary>
            /// 
            /// </summary>
            public string hosplist_code { get; set; }// 医院目录代码  字符型	20		Y
            /// <summary>
            /// 
            /// </summary>
            public string hosplist_name { get; set; }//   医院目录名称 字符型	50		Y
            /// <summary>
            /// 
            /// </summary>            
            public string hosplist_dosform { get; set; }// 医院目录(药品)剂型 字符型	20			　
            /// <summary>
            /// 
            /// </summary>
            public double cnt { get; set; }// 数量  数值型	6,2		Y
            /// <summary>
            /// 
            /// </summary>
            public decimal pric { get; set; }//   单价 数值型	16,2		Y
            /// <summary>
            /// 
            /// </summary>
            public decimal sumamt { get; set; }// 总费用 数值型	16,2		Y
            /// <summary>
            /// 
            /// </summary>
            public decimal ownpay_amt { get; set; }// 自费金额 数值型	16,2		Y
            /// <summary>
            /// 
            /// </summary>
            public decimal selfpay_amt { get; set; }// 自付金额 数值型	16,2		Y
            /// <summary>
            /// 
            /// </summary>
            public string spec { get; set; }//    规格 字符型	100		Y 例如:0.25g×12片/盒
            /// <summary>
            /// 
            /// </summary>
            public string spec_unt { get; set; }//    数量单位 字符型	20		Y 例如：盒
            /// <summary>
            /// 
            /// </summary>
            public DateTime drord_begn_date { get; set; }//医嘱开始日期 日期型         Y 格式：yyyy-MM-dd HH:mm:ss
            /// <summary>
            /// 
            /// </summary>
            public DateTime drord_stop_date { get; set; }// 医嘱停止日期 日期型             格式：yyyy-MM-dd HH:mm:ss
            /// <summary>
            /// 
            /// </summary>
            public string drord_dept_codg { get; set; }// 下达医嘱的科室标识 字符型	30		Y
            /// <summary>
            /// 
            /// </summary>
            public string drord_dept_name { get; set; }// 下达医嘱科室名称 字符型	50		Y
            /// <summary>
            /// 
            /// </summary>
            public string drord_dr_codg { get; set; }// 开处方(医嘱)医生标识 字符型	30		Y
            /// <summary>
            /// 
            /// </summary>
            public string drord_dr_name { get; set; }// 开处方(医嘱)医生姓名 字符型	30		Y
            /// <summary>
            /// 
            /// </summary>
            public string drord_dr_profttl { get; set; }// 开处方(医嘱)医职称 字符型	3	Y Y   参考字典表
            /// <summary>
            /// 
            /// </summary>
            public string curr_drord_flag { get; set; }// 是否当前处方(医嘱)  字符型	3		Y 本次处方(医嘱)标记[1 = 是, 0 = 否]

        }
        /// <summary>
        /// 
        /// </summary>
        public class Fsi_Operation_Dtos 
        {
            /// <summary>
            /// 
            /// </summary>
            public string setl_list_oprn_id { get; set; }// 手术操作ID  字符型	30		Y
            /// <summary>
            /// 
            /// </summary>
            public string oprn_code { get; set; }  // 手术操作代码 字符型	30			
            /// <summary>
            /// 
            /// </summary>
            public string oprn_name { get; set; }// 手术操作名称  字符型	500			
            /// <summary>
            /// 
            /// </summary>
            public string main_oprn_flag { get; set; }// 主手术操作标志 字符型	3		Y
            /// <summary>
            /// 
            /// </summary>
            public DateTime oprn_date { get; set; }//   手术操作日期 日期型
            /// <summary>
            /// 
            /// </summary>
            public DateTime anst_way { get; set; }// 麻醉方式    字符型	30			
            /// <summary>
            /// 
            /// </summary>
            public string oper_dr_name { get; set; }// 术者医师姓名  字符型	50			
            /// <summary>
            /// 
            /// </summary>
            public string oper_dr_code { get; set; }//术者医师代码  字符型	30			
            /// <summary>
            /// 
            /// </summary>
            public string anst_dr_name { get; set; }// 麻醉医师姓名  字符型	50			
            /// <summary>
            /// 
            /// </summary>
            public string anst_dr_code { get; set; }// 麻醉医师代码  字符型	30			

        }
        /// <summary>
        /// 
        /// </summary>
        public class Out3101
        {
            /// <summary>
            /// 
            /// </summary>
            public Result result { get; set; }
            
        }
        /// <summary>
        /// 
        /// </summary>
        public class Result 
        {
            /// <summary>
            /// 
            /// </summary>
            public string jr_id { get; set; }// 违规标识 字符型	50		Y 计算结果记录唯一ID
            /// <summary>
            /// 
            /// </summary>
            public string rule_id { get; set; }// 规则ID    字符型	50		Y 例如：R01
            /// <summary>
            /// 
            /// </summary>
            public string rule_name { get; set; }//   规则名称 字符型	200		Y 例如：配伍禁忌
            /// <summary>
            /// 
            /// </summary>
            public string vola_cont { get; set; }//   违规内容 字符型	500		Y 例如：患者处方中存在配伍禁忌的药品【A药】、【B药】。
            /// <summary>
            /// 
            /// </summary>
            public string patn_id { get; set; }// 参保人ID   字符型	50		Y	（注意：当是多患者导致违规时，这里是其中一个患者ID）
            /// <summary>
            /// 
            /// </summary>
            public string mdtrt_id { get; set; }// 就诊ID    字符型	50			（注意：当是多就诊导致违规时，这里是其中一个就诊ID）
            /// <summary>
            /// 
            /// </summary>
            public Judge_Result_Detail_Dtos judge_result_detail_dtos { get; set; }//违规明细    违规明细集合 Y
            /// <summary>
            /// 
            /// </summary>
            public decimal vola_amt { get; set; }// 违规金额    数值型	16,2		Y
            /// <summary>
            /// 
            /// </summary>
            public decimal vola_amt_stas { get; set; }//   违规金额计算状态 字符型	3		Y 参考字典表
            /// <summary>
            /// 
            /// </summary>
            public string sev_deg { get; set; }// 严重程度    字符型	3		Y 参考字典表
            /// <summary>
            /// 
            /// </summary>
            public string vola_evid { get; set; }// 违规依据    字符型	500			
            /// <summary>
            /// 
            /// </summary>
            public string vola_bhvr_type { get; set; }// 违规行为分类  字符型	3		Y 参考字典表
            /// <summary>
            /// 
            /// </summary>
            public string task_id { get; set; }// 任务ID    字符型
        }
        /// <summary>
        /// 
        /// </summary>
        public class Judge_Result_Detail_Dtos 
        {
            /// <summary>
            /// 
            /// </summary>
            public string jrd_id { get; set; }//违规明细标识  字符型	50		Y 违规明细唯一标识
            /// <summary>
            /// 
            /// </summary>
            public string patn_id { get; set; }//参保人标识   字符型	50		Y
            /// <summary>
            /// 
            /// </summary>
            public string mdtrt_id { get; set; }//  就诊标识 字符型	50			
            /// <summary>
            /// 
            /// </summary>
            public string rx_id { get; set; }// 处方(医嘱)标识 字符型	50			
            /// <summary>
            /// 
            /// </summary>
            public string vola_item_type { get; set; }// 违规明细类型  字符型	3		Y 参考字典表
            /// <summary>
            /// 
            /// </summary>
            public string vola_amt { get; set; }// 违规金额    数值型	16,2		Y

        }






    }
}
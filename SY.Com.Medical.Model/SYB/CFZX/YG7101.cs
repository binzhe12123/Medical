using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB
{
    /// <summary>
    /// 1.1.1.1 电子处方上传
    /// </summary>
    public class YG7101
    {
        /// <summary>
        /// 
        /// </summary>
        public class In7101
        {
            /// <summary>
            /// 
            /// </summary>
            public In7101data data { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<Rxdrugdetail> rxdrugdetail { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Mdtrtinfo mdtrtinfo { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<Diseinfo> diseinfo { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        public class In7101data
        {
            /// <summary>
            /// 
            /// </summary>
            public string hosp_rxno { get; set; }// 定点医疗机构处方编号  字符型	40		Y
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string init_rxno { get; set; }//  续方的原处方编号 字符型	40			
            /// <summary>
            /// 
            /// </summary>
            public string rx_type_code { get; set; }// 处方类别代码  字符型	3	Y Y
            /// <summary>
            /// 
            /// </summary>
            public string prsc_time { get; set; }// 开方时间    日期时间型 Y
            /// <summary>
            /// 
            /// </summary>
            public string rx_drug_nums { get; set; }//药品数量（剂数）	数值型	16,4		Y
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string rx_way_codg { get; set; }// 处方整剂用法编号 字符型	20	Y 参考药物使用-途径代码(drug_medc_way_code)
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string rx_way_name { get; set; }//处方整剂用法名称    字符型	40			
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string rx_freq_codg { get; set; }// 处方整剂频次编号    字符型	20	Y 参考使用频次（used_frqu）
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string rx_freq_name { get; set; }//处方整剂频次名称    字符型	40			
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string rx_dosunt { get; set; }// 处方整剂剂量单位    字符型	20			
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string rx_doscnt { get; set; }//处方整剂单次剂量数   数值型	16,2			
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string rx_drord_dscr { get; set; }// 处方整剂医嘱说明    字符型	400			
            /// <summary>
            /// 
            /// </summary>
            public string valid_days { get; set; }// 处方有效天数  数值型	10		Y
            /// <summary>
            /// 
            /// </summary>
            public string valid_end_time { get; set; } // 有效截止时间 日期时间型           Y
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string rept_flag { get; set; } //  复用（多次）使用标志 字符型	3	Y		0-否、1-是
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string max_rept_cnt { get; set; }//  最大使用次数 数值型	3,0			
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string reptd_cnt { get; set; }//已使用次数   数值型	3,0			
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string min_inrv_days { get; set; }// 使用最小间隔（天数）	数值型	3,0			
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string dr_sign_info { get; set; }// 开方医生电子签名信息  字符型	2000
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string phar_sign_info { get; set; }// 审方药师电子签名信息  字符型	2000			
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string fixmedins_sign_info { get; set; }//定点医疗机构签章信息  字符型	2000			
            /// <summary>
            /// 
            /// </summary>
            public string rx_cotn_flag { get; set; }//续方标志    字符型	1	Y Y
            /// <summary>
            /// 
            /// </summary>
            public string rx_file { get; set; }// 处方原件    大文本 Y   原件base64后的字符，
            /// <summary>
            /// 
            /// </summary>
            public string rx_circ_flag { get; set; } //外购处方标志  字符型	3	Y Y	0-不外购1-外购，默认为1

        }
        /// <summary>
        /// 
        /// </summary>
        public class Rxdrugdetail
        {
            /// <summary>
            /// 
            /// </summary>
            public string med_list_codg { get; set; }// 医疗目录编码  字符型	50		Y
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]            
            public string fixmedins_hilist_id { get; set; }// 定点医药机构目录编号 字符型	30			
            /// <summary>
            /// 
            /// </summary>

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string hosp_prep_flag { get; set; }// 医疗机构制剂标志    字符型	3	Y
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string rx_item_type_code { get; set; } //  处方项目分类代码 字符型	30	Y
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string rx_item_type_name { get; set; }//   处方项目分类名称 字符型	100			
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string tcmdrug_type_name { get; set; }// 中药类别名称  字符型	20			            
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string tcmdrug_type_code { get; set; }// 中药类别代码  字符型	30	Y
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string tcmherb_foote { get; set; }//   草药脚注 字符型	200	
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string medn_type_code { get; set; }// 药物类型代码  字符型	100	Y
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string medn_type_name { get; set; }//  药物类型 字符型	100			
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string main_medc_flag { get; set; }// 主要用药标志  字符型	30			
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string urgt_flag { get; set; } //加急标志    字符型	30			
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string bas_medn_flag { get; set; }// 基本药物标志  字符型	3	Y
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string imp_drug_flag { get; set; }//  是否进口药品 字符型	3	Y		0-否1-是
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string prod_barc { get; set; }//  药品条形编码 字符型	40			
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string drug_prodname { get; set; }// 药品商品名   字符型	255			
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string genname_codg { get; set; }// 通用名编码   字符型	50			
            /// <summary>
            /// 
            /// </summary>
            public string drug_genname { get; set; }// 药品通用名   字符型	500		Y
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string chemname { get; set; }//    化学名称 字符型	100			
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string drugstdcode { get; set; } //药品本位码   字符型	50			
            /// <summary>
            /// 
            /// </summary>
            public string drug_dosform { get; set; }// 药品剂型    字符型	30		Y
            /// <summary>
            /// 
            /// </summary>
            public string drug_spec { get; set; } //  药品规格 字符型	40		Y
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string prdr_name { get; set; }//   生厂厂家 字符型	100			
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string drug_pric { get; set; }// 药品单价    数值型	16,6	
            /// <summary>
            /// 
            /// </summary>

            public string drug_cnt { get; set; }// 药品数量    数值型	16,4		Y            
            /// <summary>
            /// 
            /// </summary>
            public string drug_cnt_unit { get; set; }//  药品数量单位 字符型	20		Y
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string drug_sumamt { get; set; }// 药品总金额 数值型	16,2		
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string medc_way_codg { get; set; }//用药途径代码  字符型	10	Y Y   参考药物使用-途径代码(drug_medc_way_code)
            /// <summary>
            /// 
            /// </summary>
            public string medc_way_dscr { get; set; }// 用药途径描述  字符型	100		Y
            /// <summary>
            /// 
            /// </summary>
            public string medc_starttime { get; set; }//  用药开始时间 日期时间型           Y
            /// <summary>
            /// 
            /// </summary>
            public string medc_endtime { get; set; }//    用药结束时间 日期时间型           Y
            /// <summary>
            /// 
            /// </summary>
            public string medc_days { get; set; }//  用药天数 数值型	8,2		Y
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string drug_dosunt { get; set; }// 药品剂量单位 字符型	20			
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string sin_doscnt { get; set; }// 单次用量    数值型	16,2			
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string sin_dosunt { get; set; }// 单次剂量单位  字符型	20			
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string used_frqu_codg { get; set; }// 使用频次编码  字符型	10	Y 参考使用频次（used_frqu）
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string used_frqu_name { get; set; }// 使用频次名称  字符型	30			
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string drug_totlnt { get; set; } //用药总量    字符型	40			
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string drug_totlnt_emp { get; set; }// 用药总量单位  字符型	40		
            /// <summary>
            /// 
            /// </summary>
            //按照标准代码填写：按病种结算病种目录代码(bydise_setl_list_code)、
            //门诊慢特病病种目录代码(opsp_dise_cod)、日间手术病种目录代码(daysrg_dise_list_code)
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string dise_codg { get; set; }// 病种编码    字符型	30	Y 

        }
        /// <summary>
        /// 
        /// </summary>
        public class Mdtrtinfo
        {
            /// <summary>
            /// 
            /// </summary>
            public string mdtrt_id { get; set; }// 就诊ID    字符型	30		Y
            /// <summary>
            /// 
            /// </summary>
            public string med_type { get; set; }//    医疗类别 字符型	6	Y Y
            /// <summary>
            /// 
            /// </summary>
            public string ipt_op_no { get; set; }// 住院/门诊号 字符型	30		Y
            /// <summary>
            /// 
            /// </summary>
            public string psn_no { get; set; }// 人员编号 字符型	30		Y
            /// <summary>
            /// 
            /// </summary>
            public string patn_name { get; set; }//  患者姓名 字符型	40		Y
            /// <summary>
            /// 
            /// </summary>
            public string age { get; set; } //年龄 数值型	4,1		Y
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string patn_ht { get; set; }// 患者身高 数值型	6,2			单位：cm
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string patn_wt { get; set; }// 患者体重 数值型	6,2			单位：kg
            /// <summary>
            /// 
            /// </summary>
            public string gend { get; set; }//    性别 字符型	6	Y Y
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string geso_val { get; set; }// 妊娠(孕周)  数值型	2			
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string nwb_flag { get; set; }// 新生儿标志   字符型	3	Y		0-否、1-是
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string nwb_age { get; set; }// 新生儿日、月龄 字符型	20			
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string suck_prd_flag { get; set; }// 哺乳期标志   数值型	3	Y		0-否、1-是
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string algs_his { get; set; }//    过敏史 字符型	1000			
            /// <summary>
            /// 
            /// </summary>
            public string insuplc_admdvs { get; set; }// 参保地医保区划 字符型	6		Y
            /// <summary>
            /// 
            /// </summary>
            public string psn_cert_type { get; set; }//   人员证件类型 字符型	6	Y Y
            /// <summary>
            /// 
            /// </summary>
            public string certno { get; set; }// 证件号码    字符型	50		Y
            /// <summary>
            /// 
            /// </summary>
            public string insutype { get; set; }//   险种类型 字符型	6	Y Y
            /// <summary>
            /// 
            /// </summary>
            public string prsc_dept_name { get; set; }// 开方科室名称  字符型	50		Y
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string prsc_dept_code { get; set; }//  开方科室编号 字符型	30		Y
            /// <summary>
            /// 
            /// </summary>
            public string prsc_dr_name { get; set; }//   开方医师姓名 字符型	50		Y
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string prsc_dr_cert_type { get; set; }//   开方医师证件类型 字符型	6	Y 参照人员证件类型
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string prsc_dr_certno { get; set; }// 开方医师证件号码    字符型	50			
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string dr_profttl_codg { get; set; }// 医生职称编码  字符型	20			参考开单医生编码
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string dr_profttl_name { get; set; }// 医生职称名称 字符型	20			
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string phar_cert_type { get; set; }// 药师证件类型  字符型	6	Y 参照人员证件类型
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string phar_certno { get; set; }// 药师证件号码  字符型	50			
            /// <summary>
            /// 
            /// </summary>
            public string phar_name { get; set; }// 药师姓名    字符型	50		Y
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string phar_prac_cert_no { get; set; }//   药师执业资格证号 字符型	50			
            /// <summary>
            /// 
            /// </summary>
            public string phar_chk_time { get; set; }// 医疗机构药师审方时间  日期时间型 Y
            /// <summary>
            /// 
            /// </summary>
            public string mdtrt_time { get; set; }// 就诊时间    日期时间型 Y
            /// <summary>
            /// 
            /// </summary>
            //按病种结算病种目录代码(bydise_setl_list_code)、
            //门诊慢特病病种目录代码(opsp_dise_cod)、日间手术病种目录代码(daysrg_dise_list_code)
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string dise_codg { get; set; }// 病种编码    字符型	30			按照标准编码填写：
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string dise_name { get; set; }// 病种名称    字符型	500	
            /// <summary>
            /// 
            /// </summary>
            public string sp_dise_flag { get; set; } //特殊病种标志  字符型	3	Y Y
            /// <summary>
            /// 
            /// </summary>
            public string diag_code { get; set; }// 主诊断代码   字符型	20		Y
            /// <summary>
            /// 
            /// </summary>
            public string diag_name { get; set; }//   主诊断名称 字符型	40		Y
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string dise_cond_dscr { get; set; }//  疾病病情描述 字符型	2000			
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string hi_feesetl_type { get; set; }// 医保费用结算类型    字符型	6	Y
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string hi_feesetl_name { get; set; }// 医保费用类别名称 字符型	20			
            /// <summary>
            /// 
            /// </summary>
            public string rgst_fee { get; set; }// 挂号费 数值型	16,2		Y
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string medfee_sumamt { get; set; } //  医疗费总额 数值型	16,2			本处方总金额
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string fstdiag { get; set; }// 是否初诊 字符型	3			0-否、1-是
        }
        /// <summary>
        /// 
        /// </summary>
        public class Diseinfo
        {
            /// <summary>
            /// 
            /// </summary>
            public string diag_type { get; set; }// 诊断类别    字符型	3	Y Y            
            /// <summary>
            /// 
            /// </summary>
            public string maindiag_flag { get; set; }// 主诊断标志   字符型	3	Y Y
            /// <summary>
            /// 
            /// </summary>
            public string diag_srt_no { get; set; }// 诊断排序号   数值型	2		Y
            /// <summary>
            /// 
            /// </summary>
            public string diag_code { get; set; }//   诊断代码 字符型	20	Y Y
            /// <summary>
            /// 
            /// </summary>
            public string diag_name { get; set; }//            诊断名称    字符型	100		Y
            /// <summary>
            /// 
            /// </summary>
            public string diag_dept { get; set; }//  诊断科室 字符型	50		Y
            /// <summary>
            /// 
            /// </summary>
            public string dise_dor_no { get; set; }// 诊断医生编码 字符型	30		Y
            /// <summary>
            /// 
            /// </summary>
            public string dise_dor_name { get; set; }//   诊断医生姓名 字符型	50		Y
            /// <summary>
            /// 
            /// </summary>
            public string diag_time { get; set; }//  诊断时间 日期时间型           Y yyyy-MM-ddHH:mm:ss
        }
        /// <summary>
        /// 
        /// </summary>
        public class Out7101
        {
            /// <summary>
            /// 
            /// </summary>
            public string hi_rxno { get; set; }//  医保处方编号 字符型	30		Y
        }
    }
}
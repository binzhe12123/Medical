using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB.CFZX
{
    public class CFXZ7203
    {
        public class In7203
        {
            public string epc_token { get; set; }// 电子处方令牌 字符型	64		N 电子处方令牌和医保处方授权编码，其中一个必填
            public string auth_rxno { get; set; }//   医保处方授权编号 字符型	30		N 电子处方查询【7202】时返回电子处方令牌和医保处方授权编码，其中一个必填
            public string insuplc_admdvs { get; set; }//  参保地医保区划 字符型	6	Y Y

        }
        public class Out7203
        {
            public Out7203data data { get; set; }
            public Rxdrugdetail rxdrugdetail { get; set; }
            public Mdtrtinfo mdtrtinfo { get; set; }
            public Diseinfo diseinfo { get; set; }

        }
        public class Out7203data 
        {
            public string hi_rxno { get; set; }//  医保处方编号 字符型	30		Y
            public string fixmedins_code { get; set; }//    定点医疗机构编号 字符型	12		Y
            public string fixmedins_name { get; set; }//    定点医疗机构名称 字符型	200		Y
            public DateTime prsc_time { get; set; }//   开方时间 日期时间型           Y
            public decimal rx_drug_nums { get; set; }//    药品数量（剂数）	数值型	16,2		Y
            public string rx_way_codg { get; set; }// 处方整剂用法编号 字符型	20	Y 参考药物使用-途径代码(drug_medc_way_code)
            public string rx_way_name { get; set; }// 处方整剂用法名称    字符型	40			
            public string rx_freq_codg { get; set; }// 处方整剂频次编号    字符型	20	Y 参考使用频次（used_frqu）
            public string rx_freq_name { get; set; }// 处方整剂频次名称    字符型	40			
            public string rx_dosunt { get; set; }// 处方整剂剂量单位    字符型	20			
            public decimal rx_doscnt { get; set; }// 处方整剂单次剂量数   数值型	16,2	
            public string rx_drord_dscr { get; set; }// 处方整剂医嘱说明    字符型	500			
            public decimal valid_days { get; set; }// 处方有效天数  数值型	10		Y
            public DateTime valid_end_time { get; set; }//  有效截止时间 日期时间型           Y
            public string rept_flag { get; set; }//   复用（多次）使用标志 字符型	3	Y Y	0-否、1-是
            public decimal max_rept_cnt { get; set; }//    最大复用次数 数值型	3,0			
            public decimal reptd_cnt { get; set; }// 已复用次数   数值型	3,0			
            public decimal min_inrv_days { get; set; }// 使用最小间隔（天数）	数值型	3,0			
            public string rx_file { get; set; }// 处方原件    大文本 Y   原件base64后的字符

        }
        public class Rxdrugdetail
        {
            public string med_list_codg { get; set; }// 医疗目录编码  字符型	50		Y
            public string fixmedins_hilist_id { get; set; }// 定点医药机构目录编号 字符型	30			
            public string hosp_prep_flag { get; set; }// 院内制剂标志  字符型	3	Y
            public string rx_item_type_code { get; set; }//  处方项目分类代码 字符型	30	Y
            public string rx_item_type_name { get; set; }//  处方项目分类名称 字符型	100			
            public string tcmdrug_type_name { get; set; }// 中药类别名称  字符型	20			
            public string tcmdrug_type_code { get; set; }// 中药类别代码  字符型	30	Y
            public string tcmherb_foote { get; set; }//  草药脚注 字符型	200			
            public string medn_type_code { get; set; }// 药物类型代码  字符型	100	Y
            public string medn_type_name { get; set; }// 药物类型 字符型	100			
            public string main_medc_flag { get; set; }// 主要用药标志  字符型	30			
            public string urgt_flag { get; set; }// 加急标志    字符型	30			
            public string bas_medn_flag { get; set; }// 基本药物标志  字符型	3	Y
            public string imp_drug_flag { get; set; }//  是否进口药品 字符型	3	Y		0-否、1-是
            public string prod_barc { get; set; }//  药品条形编码 字符型	40		
            public string drug_prodname { get; set; }// 药品商品名   字符型	255		Y
            public string genname_codg { get; set; }//    通用名编码 字符型	50			
            public string drug_genname { get; set; }// 药品通用名   字符型	500		Y
            public string chemname { get; set; }//    化学名称 字符型	100			
            public string drugstdcode { get; set; }//药品本位码   字符型	50			
            public string drug_dosform { get; set; }// 药品剂型    字符型	30		Y
            public string drug_spec { get; set; }//   药品规格 字符型	40		Y
            public string prdr_name{ get; set; }//   生厂厂家 字符型	100			
            public decimal drug_pric { get; set; }// 药品单价    数值型	16,6		N
            public decimal drug_cnt { get; set; }//    药品数量 数值型	16,4		Y
            public string drug_cnt_unit { get; set; }//  药品数量单位 字符型	20		Y
            public decimal drug_sumamt { get; set; }// 药品总金额 数值型	16,2		N
            public string medc_way_codg { get; set; }//   用药途径代码 字符型	10		Y
            public string medc_way_dscr { get; set; }// 用药途径描述 字符型	100		Y
            public DateTime medc_starttime { get; set; }//  用药开始时间 日期时间型           Y
            public DateTime medc_endtime { get; set; }//   用药结束时间 日期时间型           Y
            public decimal medc_days { get; set; }//   用药天数 数值型	8,2		Y
            public string drug_dosunt { get; set; }// 药品剂量单位 字符型	20			
            public decimal sin_doscnt { get; set; }// 单次用量    数值型	16,2			
            public string sin_dosunt { get; set; }// 单次剂量单位  字符型	20			
            public string used_frqu_codg { get; set; }// 使用频次编码  字符型	10			
            public string used_frqu_name { get; set; }// 使用频次名称  字符型	30			
            public string drug_totlnt { get; set; }// 用药总量    字符型	40			
            public string drug_totlnt_emp { get; set; }// 用药总量单位  字符型	40			
            public string dise_codg { get; set; }// 病种编码    字符型	30			按照标准编码填写：按病种结算病种目录代码(bydise_setl_list_code)、门诊慢特病病种目录代码(opsp_dise_cod)、日间手术病种目录代码(daysrg_dise_list_code)

        }
        public class Mdtrtinfo
        {
            public string mdtrt_id { get; set; }// 就诊ID    字符型	30		Y
            public string med_type { get; set; }//    医疗类别 字符型	6	Y Y
            public string ipt_op_no { get; set; }// 住院/门诊号 字符型	30		Y
            public string psn_no { get; set; }// 人员编号 字符型	30		Y
            public string patn_name { get; set; }//   患者姓名 字符型	40		Y
            public int age { get; set; }// 年龄 数值型	4,1		Y
            public decimal patn_ht { get; set; }// 患者身高 数值型	6,2			单位：cm
            public decimal patn_wt { get; set; }// 患者体重 数值型	6,2			单位：kg
            public string gend { get; set; }//    性别 字符型	6	Y Y
            public int geso_val { get; set; }//妊娠(孕周)  数值型	2			
            public string nwb_flag { get; set; }// 新生儿标志   字符型	3	Y		0-否、1-是
            public string nwb_age { get; set; }// 新生儿日、月龄 字符型	20			
            public decimal suck_prd_flag { get; set; }// 哺乳期标志   数值型	3	Y		0-否、1-是
            public string algs_his { get; set; }//    过敏史 字符型	1000			
            public string insuplc_admdvs { get; set; }// 参保地医保区划 字符型	6		Y
            public string psn_cert_type { get; set; }//   人员证件类型 字符型	6	Y Y
            public string certno { get; set; }// 证件号码    字符型	50		Y
            public string insutype { get; set; }//    险种类型 字符型	6	Y Y
            public string prsc_dept_name { get; set; }// 开方科室名称  字符型	50		Y
            public string prsc_dept_code { get; set; }//  开方科室编号 字符型	30		Y
            public string prsc_dr_name { get; set; }//   开方医师姓名 字符型	50		Y
            public string phar_name { get; set; }//   药师姓名 字符型	50		Y
            public DateTime phar_chk_time { get; set; }//   医疗机构药师审方时间 日期时间型           Y
            public DateTime mdtrt_time { get; set; }//  就诊时间 日期时间型           Y
            public string dise_codg { get; set; }//   病种编码 字符型	30			按照标准编码填写：按病种结算病种目录代码(bydise_setl_list_code)、门诊慢特病病种目录代码(opsp_dise_cod)、日间手术病种目录代码(daysrg_dise_list_code)
            public string dise_name { get; set; }// 病种名称    字符型	500			
            public string sp_dise_flag { get; set; }// 是否特殊病种  字符型	1		Y
            public string diag_code { get; set; }//   主诊断代码 字符型	20		Y
            public string diag_name { get; set; }//  主诊断名称 字符型	40		Y
            public string dise_cond_dscr { get; set; }// 疾病病情描述 字符型	2000			
            public string fstdiag { get; set; }// 是否初诊    字符型	3			0-否、1-是


        }
        public class Diseinfo
        {
            public string diag_type { get; set; }// 诊断类别    字符型	3	Y Y
            public string maindiag_flag { get; set; }//主诊断标志   字符型	3	Y Y
            public string diag_srt_no { get; set; }// 诊断排序号   数值型	2		Y
            public string diag_code { get; set; }//   诊断代码 字符型	20		Y
            public string diag_name { get; set; }//   诊断名称 字符型	100		Y
            public string diag_dept { get; set; }//   诊断科室 字符型	50		Y
            public string dise_dor_no { get; set; }// 诊断医生编码 字符型	30		Y
            public string dise_dor_name { get; set; }//   诊断医生姓名 字符型	50		Y
            public DateTime diag_time { get; set; }//   诊断时间 日期时间型           Y yyyy-MM-dd HH:mm:ss

        }
    }
}
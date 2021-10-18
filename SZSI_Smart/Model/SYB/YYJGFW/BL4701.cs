using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MK.Clinic.Model
{
    public class BL4701
    {
        public class In4701 
        {
            public Adminfo adminfo { get; set; }
            public Diseinfo diseinfo { get; set; }
            public Coursrinfo coursrinfo { get; set; }
            public Oprninfo oprninfo { get; set; }
            public Rescinfo rescinfo { get; set; }
            public Dieinfo dieinfo { get; set; }
            public Dscginfo dscginfo { get; set; }
        }
        public class Adminfo
        {
            public string mdtrt_sn { get; set; }// 就医流水号   字符型	30		Y 院内唯一号
            public string mdtrt_id { get; set; }//就诊ID    字符型	30			医保病人必填
            public string psn_no { get; set; }//  人员编号 字符型	30			医保病人必填
            public string mdtrtsn { get; set; }// 住院号 字符型	30		Y
            public string name { get; set; }//    姓名 字符型	50		Y
            public string gend { get; set; }//    性别 字符型	6	Y Y
            public int age { get; set; }// 年龄  数值型	4,1		
            public string adm_rec_no { get; set; }// 入院记录流水号 字符型	18		Y
            public string wardarea_name { get; set; }//   病区名称 字符型	50		Y
            public string dept_code { get; set; }//   科室代码 字符型	30	Y Y   参照科室代码（dept）
            public string dept_name { get; set; }// 科室名称    字符型	50		Y
            public string bedno { get; set; }// 病床号 字符型	10		Y
            public DateTime adm_time { get; set; }//    入院时间 日期时间型
            public string illhis_stte_name { get; set; }// 病史陈述者姓名 字符型	50		Y
            public string illhis_stte_rltl { get; set; }//    陈述者与患者关系代码 字符型	2		Y
            public string stte_rele { get; set; }//  陈述内容是否可靠标识 字符型	1		Y
            public string chfcomp { get; set; }// 主诉 字符型	100		Y
            public string dise_now { get; set; }//    现病史 字符型	100		Y
            public string hlcon { get; set; }//   健康状况 字符型	3		Y
            public string dise_his { get; set; }//    疾病史（含外伤）	字符型	100		Y
            public string ifet { get; set; }//    患者传染性标志 字符型	1		Y
            public string ifet_his { get; set; }//   传染病史 字符型	1000		Y
            public string prev_vcnt { get; set; }//   预防接种史 字符型	1000		Y
            public string oprn_his { get; set; }//    手术史 字符型	1000		Y
            public string bld_his { get; set; }// 输血史 字符型	1000		Y
            public string algs_his { get; set; }//    过敏史 字符型	1000		Y
            public string psn_his { get; set; }// 个人史 字符型	1000		Y
            public string mrg_his { get; set; }// 婚育史 字符型	1000		Y
            public string mena_his { get; set; }//    月经史 字符型	1000		Y
            public string fmhis { get; set; }//   家族史 字符型	1000		Y
            public decimal physexm_tprt { get; set; }//    体格检查--体温（℃）	数值型	5,0		Y
            public decimal physexm_pule { get; set; }//    体格检查 -- 脉率（次 /mi数字）	数值型	3		Y
            public decimal physexm_vent_frqu { get; set; }//   体格检查--呼吸频率 字符型	3		Y
            public decimal physexm_systolic_pre { get; set; }//    体格检查 -- 收缩压 （mmHg）	字符型	3		Y
            public decimal physexm_dstl_pre { get; set; }    //体格检查 -- 舒张压 （mmHg）	字符型	3		Y
            public decimal physexm_height { get; set; }//  体格检查--身高（cm）	数值型	6，1		Y
            public decimal physexm_wt { get; set; }//  体格检查--体重（kg）	数值型	7，2		Y
            public string  physexm_ordn_stas { get; set; }//   体格检查 -- 一般状况 检查结果   字符型	100		Y
            public string  physexm_skin_musl { get; set; }//  体格检查 -- 皮肤和黏膜检查结果 字符型	100		Y
            public string  physexm_spef_lymph { get; set; }//  体格检查 -- 全身浅表淋巴结检查结果 字符型	100		Y
            public string  physexm_head { get; set; }//   体格检查 -- 头部及其器官检查结果 字符型	100		Y
            public string  physexm_neck { get; set; }//   体格检查 -- 颈部检查结果 字符型	100		Y
            public string  physexm_chst { get; set; }//    体格检查 -- 胸部检查结果 字符型	100		Y
            public string  physexm_abd { get; set; }// 体格检查 -- 腹部检查结果 字符型	100		Y
            public string physexm_finger_exam { get; set; }// 体格检查 -- 肛门指诊检查结果描述 字符型	100		Y
            public string physexm_genital_area { get; set; }//   体格检查 -- 外生殖器检查结果 字符型	100		Y
            public string physexm_spin { get; set; }//    体格检查 -- 脊柱检查结果 字符型	100		Y
            public string physexm_all_fors { get; set; }//    体格检查 -- 四肢检查结果 字符型	100		Y
            public string nersys { get; set; }//  体格检查 -- 神经系统检查结果 字符型	100		Y
            public string spcy_info { get; set; }//   专科情况 字符型	100		Y
            public string asst_exam_rslt { get; set; }//  辅助检查结果 字符型	100		Y
            public string tcm4d_rslt { get; set; }//  中医“四诊”观察结果描述 字符型	100		N
            public string syddclft { get; set; }//    辨证分型代码 字符型	7		N
            public string syddclft_name { get; set; }//   辩证分型名称 字符型	50		N
            public string prnp_trt { get; set; }//    治则治法 字符型	100		N
            public string rec_doc_code { get; set; }//    接诊医生编号 字符型	30		Y
            public string rec_doc_name { get; set; }//    接诊医生姓名 字符型	50		Y
            public string ipdr_code { get; set; }//   住院医师编号 字符型	30		Y
            public string ipdr_name { get; set; }//   住院医师姓名 字符型	50		Y
            public string chfdr_code { get; set; }// 主任医师编号 字符型	30		Y
            public string chfdr_name { get; set; }//  主任医师姓名 字符型	50		Y
            public string chfpdr_code { get; set; }// 主诊医师代码 字符型	30		Y
            public string chfpdr_name { get; set; }// 主诊医师姓名 字符型	50		Y
            public string main_symp { get; set; }//   主要症状 字符型	50		Y
            public string adm_rea { get; set; }// 入院原因 字符型	1000		Y
            public string adm_way { get; set; }// 入院途径 字符型	1		Y
            public string apgr { get; set; }//评分值(Apgar)  字符型	2		Y
            public string diet_info { get; set; }//   饮食情况 字符型	1		Y
            public string growth_deg { get; set; }//  发育程度 字符型	1		Y
            public string mtl_stas_norm { get; set; }//  精神状态正常标志 字符型	1		Y
            public string slep_info { get; set; }//   睡眠状况 字符型	1000		Y
            public string sp_info { get; set; }// 特殊情况 字符型	1000		Y
            public string mind_info { get; set; }  // 心理状态 字符型	1		Y
            public string nurt { get; set; }//   营养状态 字符型	1		Y
            public string self_ablt { get; set; }//  自理能力 字符型	1		Y
            public string nurscare_obsv_item_name { get; set; }// 护理观察项目名称 字符型	30		Y
            public string nurscare_obsv_rslt { get; set; }//  护理观察结果 字符型	1000		Y
            public string smoke { get; set; }//   吸烟标志 字符型	1		Y
            public decimal? stop_smok_days { get; set; }//  停止吸烟天数 数值型	5		Y
            public string smok_info { get; set; }//   吸烟状况 字符型	1		Y
            public string smok_day { get; set; }//    日吸烟量（支）	字符型	3		Y
            public string drnk { get; set; }//   饮酒标志 字符型	1		Y
            public string drnk_frqu { get; set; }//   饮酒频率 字符型	1		Y
            public decimal drnk_day { get; set; }//    日饮酒量（mL）	数值型	3		Y
            public DateTime eval_time { get; set; }//   评估日期时间 数值型
            public string resp_nurs_name { get; set; }// 责任护士姓名  字符型	50		Y
            public string vali_flag { get; set; }//   有效标志 字符型	3	Y Y

        }
        public class Diseinfo 
        {
            public string inout_diag_type { get; set; }// 出入院诊断类别 字符型	3	Y Y
            public string maindiag_flag { get; set; }// 主诊断标志   字符型	3		Y
            public int diag_seq { get; set; }//    诊断序列号 数值型	2		Y
            public DateTime diag_time { get; set; }//   诊断时间 日期时间型           Y
            public string wm_diag_code { get; set; }//    西医诊断编码 字符型	20		Y
            public string wm_diag_name { get; set; }//    西医诊断名称 字符型	100		Y
            public string tcm_dise_code { get; set; }//   中医病名代码 字符型	9		N
            public string tcm_dise_name { get; set; }//   中医病名 字符型	100		N
            public string tcmsymp_code { get; set; }//   中医证候代码 字符型	9		N
            public string tcmsymp { get; set; }// 中医证候 字符型	100		N
            public string vali_flag { get; set; }//   有效标志 字符型	3	Y Y

        }
        public class Coursrinfo
        {
            public string dept_code { get; set; }// 科室代码    字符型	30		Y
            public string dept_name { get; set; }//  科室名称 字符型	50		Y
            public string wardarea_name { get; set; }//   病区名称 字符型	50		Y
            public string bedno { get; set; }//   病床号 字符型	10		Y
            public DateTime rcd_time { get; set; }//    记录日期时间 日期型
            public string chfcomp { get; set; }//主诉  字符型	100		Y
            public string cas_ftur { get; set; }//   病例特点 字符型	200		Y
            public string tcm4d_rslt { get; set; }//  中医“四诊”观察结果 字符型	1000		N
            public string dise_evid { get; set; }//   诊断依据 字符型	100		Y
            public string prel_wm_diag_code { get; set; }//   初步诊断-西医诊断编码 字符型	20		Y
            public string prel_tcm_dise_name { get; set; }//  初步诊断-西医诊断名称 字符型	100		Y
            public string prel_tcm_diag_code { get; set; }//  初步诊断-中医病名代码 字符型	20		N            
            public string prel_tcmsymp_code { get; set; }//   初步诊断-中医证候代码 字符型	9		N
            public string prel_tcmsymp { get; set; }//    初步诊断-中医证候 字符型	200		N
            public string finl_wm_diag_code { get; set; }//   鉴别诊断-西医诊断编码 字符型	20		Y
            public string finl_wm_diag_name { get; set; }//   鉴别诊断-西医诊断名称 字符型	100		Y
            public string finl_tcm_dise_code { get; set; }//  鉴别诊断-中医病名代码 字符型	9		N
            public string finl_tcm_dise_name { get; set; }//  鉴别诊断-中医病名 字符型	200		N
            public string finl_tcmsymp_code { get; set; }//   鉴别诊断-中医证候代码 字符型	9		N
            public string finl_tcmsymp { get; set; }//    鉴别诊断-中医证候 字符型	200		N
            public string dise_plan { get; set; }//   诊疗计划 字符型	2000		Y
            public string prnp_trt { get; set; }//    治则治法 字符型	100		N
            public string ipdr_code { get; set; }//   住院医师编号 字符型	30		Y
            public string ipdr_name { get; set; }//   住院医师姓名 字符型	50		Y
            public string prnt_doc_name { get; set; }//  上级医师姓名 字符型	50		Y
            public string vali_flag { get; set; }//  有效标志 字符型	3	Y Y

        }
        public class Oprninfo 
        {
            public string oprn_appy_id { get; set; }// 手术申请单号  字符型	30		Y
            public string oprn_seq { get; set; }//    手术序列号 字符型	16			
            public string blotype_abo { get; set; }// ABO血型代码 字符型	2	Y
            public DateTime oprn_time { get; set; }//   手术日期 日期型         Y
            public string oprn_type_code { get; set; }//  手术分类代码 字符型	1		Y 参照国家卫生健康委发布最新编码标准
            public string oprn_type_name { get; set; }// 手术分类名称  字符型	20			
            public string bfpn_diag_code { get; set; }// 术前诊断代码  字符型	100			
            public string bfpn_oprn_diag_name { get; set; }// 术前诊断名称  字符型	500			
            public string bfpn_inhosp_ifet { get; set; }// 术前是否发生院内感染  字符型	10	Y
            public string afpn_diag_code { get; set; }// 术后诊断代码 字符型	100			
            public string afpn_diag_name { get; set; }// 术后诊断名称  字符型	500			
            public string sinc_heal_lv { get; set; }// 手术切口愈合等级代码  字符型	5	Y
            public string sinc_heal_lv_code { get; set; }//   手术切口愈合等级 字符型	30			
            public string back_oprn { get; set; }// 是否重返手术（明确定义）	字符型	2			
            public string selv { get; set; }// 是否择期    字符型	2			
            public string prev_abtl_medn { get; set; }// 是否预防使用抗菌药物  字符型	2			
            public string abtl_medn_days { get; set; }// 预防使用抗菌药物天数  字符型	10			
            public string oprn_oprt_code { get; set; }// 手术操作代码  字符型	30		Y
            public string oprn_oprt_name { get; set; }//  手术操作名称 字符型	500		Y
            public string oprn_lv_code { get; set; }//    手术级别代码 字符型	10	Y
            public string oprn_lv_name { get; set; }//    手术级别名称 字符型	300	
            public string anst_mtd_code { get; set; }// 麻醉-方法代码 字符型	5			
            public string anst_mtd_name { get; set; }// 麻醉-方法名称 字符型	50			
            public string anst_lv_code { get; set; }// 麻醉分级代码  字符型	10	Y
            public string anst_lv_name { get; set; }//    麻醉分级名称 字符型	50			
            public string exe_anst_dept_code { get; set; }// 麻醉执行科室代码    字符型	30	Y 参照科室代码（dept）
            public string exe_anst_dept_name { get; set; }// 麻醉执行科室名称    字符型	50			
            public string anst_efft { get; set; }// 麻醉效果    字符型	100			
            public DateTime oprn_begntime { get; set; }// 手术开始时间  字符型	14		Y yyyyMMddHHmmss
            public DateTime oprn_endtime { get; set; }// 手术结束时间  字符型	14		Y yyyyMMddHHmmss
            public string oprn_asps { get; set; }// 是否无菌手术  字符型	2			
            public string oprn_asps_ifet { get; set; }// 无菌手术是否感染    字符型	2			
            public string afpn_info { get; set; }// 手术后情况   字符型	500			
            public string oprn_merg { get; set; }// 是否手术合并症 字符型	10			
            public string oprn_conc { get; set; }// 是否手术并发症 字符型	10			
            public string oprn_anst_dept_code { get; set; }// 手术执行科室代码    字符型	30	Y 参照科室代码（dept）
            public string oprn_anst_dept_name { get; set; }// 手术执行科室名称    字符型	50			
            public string palg_dise { get; set; }// 病理检查    字符型	500			
            public string oth_med_dspo { get; set; }// 其他医学处置  字符型	4000			
            public DateTime out_std_oprn_time { get; set; }// 是否超出标准手术时间  字符型	2			
            public string oprn_oper_name { get; set; }// 手术者姓名   字符型	50			
            public string oprn_asit_name1 { get; set; }// 助手I姓名   字符型	50			
            public string oprn_asit_name2 { get; set; }// 助手Ⅱ姓名   字符型	50			
            public string anst_dr_name { get; set; }// 麻醉医师姓名  字符型	50			
            public string anst_asa_lv_code { get; set; }// 麻醉ASA分级代码   字符型	50			参照国家卫生健康委下发的麻醉 ASA分级代码
            public string anst_asa_lv_name { get; set; }// 麻醉ASA分级名称   字符型	100			
            public string anst_medn_code { get; set; }// 麻醉药物代码  字符型	50	Y 参照国家卫生健康委下发的麻醉药物代码
            public string anst_medn_name { get; set; }// 麻醉药物名称  字符型	100			
            public string anst_medn_dos { get; set; }// 麻醉药物剂量  字符型	20			
            public string anst_dosunt { get; set; }// 计量单位    字符型	10			
            public DateTime anst_begntime { get; set; }// 麻醉开始时间  字符型	14			yyyyMMddHHmmss
            public DateTime anst_endtime { get; set; }//    麻醉结束时间 字符型	14			yyyyMMddHHmmss
            public string anst_merg_symp_code { get; set; }// 麻醉合并症代码 字符型	10			参照国家卫生健康委下发的麻醉合并症代码
            public string anst_merg_symp { get; set; }//  麻醉合并症名称 字符型	100			
            public string anst_merg_symp_dscr { get; set; }// 麻醉合并症描述 字符型	1K
            public DateTime pacu_begntime { get; set; }//   入复苏室时间 字符型	14			
            public DateTime pacu_endtime { get; set; }// 出复苏室时间  字符型	14			
            public string oprn_selv { get; set; }// 是否择期手术  字符型	1	Y
            public string canc_oprn { get; set; }//   是否择取消手术 字符型	1	Y
            public string vali_flag { get; set; }//   有效标志 字符型	3	Y Y

        }
        public class Rescinfo 
        {
            public string dept { get; set; }// 科室代码    字符型	30	Y Y   参照科室代码（dept）
            public string dept_name { get; set; }// 科室名称    字符型	50		Y
            public string wardarea_name { get; set; }//   病区名称 字符型	50		Y
            public string bedno { get; set; }//   病床号 字符型	10		Y
            public string diag_name { get; set; }//  诊断名称 字符型	100		Y
            public string diag_code { get; set; }//   诊断代码 字符型	20		Y
            public string cond_chg { get; set; }//   病情变化情况 字符型	1000		Y
            public string resc_mes { get; set; }//    抢救措施 字符型	1000		Y
            public string oprn_oprt_code { get; set; }//  手术操作代码 字符型	30		Y
            public string oprn_oprt_name { get; set; }//  手术操作名称 字符型	500		Y
            public string oprn_oper_part { get; set; }//  手术及操作目标部位名称 字符型	50		Y
            public string itvt_name { get; set; }//   介入物名称 字符型	100		Y
            public string oprt_mtd { get; set; }//    操作方法 字符型	200		Y
            public int oprt_cnt { get; set; }//    操作次数 数值型	3,0		Y
            public DateTime resc_begntime { get; set; }//   抢救开始日期时间 日期型         Y
            public DateTime resc_endtime { get; set; }//    抢救结束日期时间 日期型         Y
            public string dise_item_name { get; set; }//  检查/检验项目名称 字符型	80		Y
            public string dise_ccls { get; set; }//   检查/检验结果 字符型	1000		Y
            public int dise_ccls_qunt { get; set; }//  检查/检验定量结果 数值型	18，4		Y
            public string dise_ccls_code { get; set; }//  检查/检验结果代码 字符型	1		Y
            public string mnan { get; set; }//    注意事项 字符型	1000		Y
            public string resc_psn_list { get; set; }//   参加抢救人员名单 字符型	200		Y
            public string proftechttl_code { get; set; }//    专业技术职务类别代码 字符型	30		Y
            public string doc_code { get; set; }//    医师编号 字符型	30		Y\
            public string dr_name { get; set; }// 医师姓名 字符型	50		Y
            public string vali_flag { get; set; }//   有效标志 字符型	3	Y Y

        }
        public class Dieinfo
        {
            public string dept { get; set; }// 科室代码    字符型	30		Y
            public string dept_name { get; set; }//    科室名称 字符型	50		Y
            public string wardarea_name { get; set; }//    病区名称 字符型	50		Y
            public string bedno { get; set; }//    病床号 字符型	10		Y
            public DateTime adm_time { get; set; }//     入院时间 日期时间型           Y
            public string adm_dise { get; set; }//     入院诊断编码 字符型	20		Y
            public string adm_info { get; set; }//     入院情况 字符型	200		Y
            public string trt_proc_dscr { get; set; }//   诊疗过程描述 字符型	2000		Y
            public DateTime die_time { get; set; }//    死亡时间 日期时间型           Y
            public string die_drt_rea { get; set; }// 直接死亡原因名称 字符型	50		Y
            public string die_drt_rea_code { get; set; }//    直接死亡原因编码 字符型	10		Y
            public string die_dise_name { get; set; }//   死亡诊断名称 字符型	50		Y
            public string die_diag_code { get; set; }//    死亡诊断编码 字符型	20	Y Y
            public string agre_corp_dset { get; set; }// 家属是否同意尸体解剖标志    字符型	1		Y
            public string ipdr_name { get; set; }//   住院医师姓名 字符型	50		Y
            public string chfpdr_code { get; set; }// 主诊医师代码 字符型	30		Y
            public string chfpdr_name { get; set; }// 主诊医师姓名 字符型	50		Y
            public string chfdr_name { get; set; }//  主任医师姓名 字符型	50		Y
            public DateTime sign_time { get; set; }//   签字日期时间 日期型         Y
            public string vali_flag { get; set; }//   有效标志 字符型	3	Y Y

        }
        public class Dscginfo
        {
            public DateTime dscg_date { get; set; }// 出院日期    日期型
            public string adm_diag_dscr { get; set; }//  入院诊断描述 字符型	200			
            public string dscg_dise_dscr { get; set; }// 出院诊断    字符型	1000			
            public string adm_info { get; set; }// 入院情况    字符型	2000			
            public string trt_proc_rslt_dscr { get; set; }// 诊治经过及结果（含手术日期名称及结果）	字符型	2000			
            public string dscg_info { get; set; }// 出院情况（含治疗效果）	字符型	2000			
            public string dscg_drord { get; set; }// 出院医嘱    字符型	1000			
            public string caty { get; set; }// 科别  字符型	6	Y
            public string rec_doc { get; set; }// 记录医师 字符型	80			
            public string main_drug_name { get; set; }// 主要药品名称  字符型	1500			
            public string oth_imp_info { get; set; }// 其他重要信息  字符型	1500			
            public string vali_flag { get; set; }// 有效标志    字符型	3	Y Y

        }
    }
}
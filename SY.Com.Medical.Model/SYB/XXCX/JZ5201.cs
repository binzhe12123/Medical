using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB.YYJGFW
{
    public class JZ5201
    {
        public class In5201
        {
            public string psn_no { get; set; }// 人员编号    字符型	30		Y
            public DateTime begntime { get; set; }//    开始时间 日期时间型           Y yyyy-MM-dd HH:mm:ss
            public DateTime endtime { get; set; }// 结束时间 日期时间型           Y yyyy-MM-dd HH:mm:ss
            public string med_type { get; set; }//    医疗类别 字符型	6	Y Y
            public string mdtrt_id { get; set; }// 就诊ID    字符型	30			

        }
        public class Out5201
        {
            public string mdtrt_id { get; set; }// 就诊ID    字符型	30	　	Y	　
            public string psn_no { get; set; }// 人员编号    字符型	30	　	Y	　
            public string psn_cert_type { get; set; }// 人员证件类型  字符型	6	Y Y
            public string certno { get; set; }// 证件号码    字符型	50	　	Y
            public string psn_name { get; set; }//    人员姓名 字符型	50	　	Y
            public string gend { get; set; }//   性别 字符型	6	Y Y
            public string naty { get; set; }// 民族  字符型	3	Y
            public DateTime brdy { get; set; }//    出生日期 日期型             yyyy-MM-dd
            public decimal age { get; set; }// 年龄 数值型	4,1	　	　	　
            public string coner_name { get; set; }// 联系人姓名   字符型	50	　	　	　
            public string tel { get; set; }// 联系电话    字符型	50	　	　	　
            public string insutype { get; set; }//险种类型    字符型	6	Y Y
            public string psn_type { get; set; }// 人员类别    字符型	6	Y Y
            public string maf_psn_flag { get; set; }// 医疗救助对象标志    字符型	3	Y
            public string cvlserv_flag { get; set; }//   公务员标志 字符型	3	Y Y
            public string flxempe_flag { get; set; }//灵活就业标志  字符型	3	Y
            public string nwb_flag { get; set; }//    新生儿标志 字符型	3	Y
            public string insu_optins { get; set; }// 参保机构医保区划 字符型	6		　	　
            public string emp_name { get; set; }// 单位名称    字符型	200	　	　	　
            public DateTime begntime { get; set; }// 开始时间    日期时间型 Y   yyyy-MM-dd HH:mm:ss
            public DateTime endtime { get; set; }// 结束时间 日期时间型           Y yyyy-MM-dd HH:mm:ss
            public DateTime mdtrt_cert_type { get; set; }// 就诊凭证类型 字符型	3	Y
            public string med_type { get; set; }//   医疗类别 字符型	6	Y Y
            public string ars_year_ipt_flag { get; set; }// 跨年度住院标志 字符型	3	Y
            public string pre_pay_flag { get; set; }//   先行支付标志 字符型	3	Y
            public string ipt_otp_no { get; set; }//  住院/门诊号 字符型	30	　	　	　
            public string medrcdno { get; set; }// 病历号 字符型	30	　	　	　
            public string atddr_no { get; set; }// 主治医生编码  字符型	30	　	　	　
            public string chfpdr_name { get; set; }// 主诊医师姓名  字符型	50	　	　	　
            public string adm_dept_codg { get; set; }// 入院科室编码  字符型	30	　	　	　
            public string adm_dept_name { get; set; }// 入院科室名称  字符型	100	　	　	　
            public string adm_bed { get; set; }// 入院床位    字符型	30	　	　	　
            public string dscg_maindiag_code { get; set; }// 住院主诊断代码 字符型	20	　		　
            public string dscg_maindiag_name { get; set; }// 住院主诊断名称 字符型	300	　		　
            public string dscg_dept_codg { get; set; }// 出院科室编码  字符型	30	　	　	　
            public string dscg_dept_name { get; set; }// 出院科室名称  字符型	100	　	　	　
            public string dscg_bed { get; set; }//出院床位    字符型	30	　	　	　
            public string dscg_way { get; set; }// 离院方式    字符型	3	Y
            public string main_cond_dscr { get; set; }//  主要病情描述 字符型	1000
            //参照标准编码：按病种结算病种目录代码(bydise_setl_list_code)、门诊慢特病病种目录代码(opsp_dise_cod)、日间手术病种目录代码(daysrg_dise_list_code)
            public string dise_codg { get; set; }// 病种编码    字符型	30	　	　	
            public string dise_name { get; set; }// 病种名称    字符型	500	　	　	　
            public string oprn_oprt_code { get; set; }// 手术操作代码  字符型	30	　	　	　
            public string oprn_oprt_name { get; set; }// 手术操作名称  字符型	500	　
            public string otp_diag_info { get; set; }// 门诊诊断信息  字符型	200	　	　	　
            public string inhosp_stas { get; set; }// 在院状态    字符型	3	Y
            public DateTime die_date { get; set; }//    死亡日期 日期型             yyyy-MM-dd
            public decimal ipt_days { get; set; }//    住院天数 数值型	4,0	　	　	　
            public string fpsc_no { get; set; }// 计划生育服务证号    字符型	50	　	　	　
            public string matn_type { get; set; }// 生育类别    字符型	6	Y
            public string birctrl_type { get; set; }//    计划生育手术类别 字符型	6	Y
            public string latechb_flag { get; set; }// 晚育标志 字符型	3	Y
            public decimal geso_val { get; set; }//    孕周数 数值型	2	　	　	　
            public decimal fetts { get; set; } //次  数值型	3	　	　	　
            public decimal fetus_cnt { get; set; }// 胎儿数 数值型	3	　	　	　
            public string pret_flag { get; set; }//早产标志    字符型	3	Y
            public DateTime birctrl_matn_date { get; set; }//   计划生育手术或生育日期 日期型             yyyy-MM-dd
            public string cop_flag { get; set; }//    伴有并发症标志 字符型	3	Y
            public string opter_id { get; set; }//    经办人ID 字符型	20	　		
            public string opter_name { get; set; }// 经办人姓名   字符型	50	　		
            public DateTime opt_time { get; set; }// 经办时间    日期时间型 yyyy-MM-dd HH:mm:ss
            public string memo { get; set; }//    备注 字符型	500	　	　	　




        }
    }
}
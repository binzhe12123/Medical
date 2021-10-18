using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB.JBXX
{
    public class ML1312
    {
        public class In1312 
        {
            public DateTime query_date { get; set; }//    查询时间点 日期型
            public string hilist_code { get; set; }// 医保目录编码  字符型	30		
            public string insu_admdvs { get; set; }// 参保机构医保区划    字符型	6	Y
            public DateTime begndate { get; set; }//    开始日期 日期型
            public string hilist_name { get; set; }// 医保目录名称  字符型	200		
            public string wubi { get; set; }// 五笔助记码   字符型	30		
            public string pinyin { get; set; }// 拼音助记码   字符型	30		
            public string med_chrgitm_type { get; set; }// 医疗收费项目类别    字符型	6	Y
            public string chrgitm_lv { get; set; }// 收费项目等级 字符型	3	Y
            public string lmt_used_flag { get; set; }//   限制使用标志 字符型	3	Y
            public string list_type { get; set; }//   目录类别 字符型	30		
            public string med_use_flag { get; set; }// 医疗使用标志  字符型	3	Y
            public string matn_used_flag { get; set; }//  生育使用标志 字符型	3	Y
            public string hilist_use_type { get; set; }// 医保目录使用类别 字符型	3	Y
            public string lmt_cpnd_type { get; set; }//   限复方使用类型 字符型	3	Y
            public string vali_flag { get; set; }//   有效标志 字符型	3	Y
            public DateTime updt_time { get; set; }//更新时间 日期型         Y
            public int page_num { get; set; }//            当前页数    page_num 数值型	4		Y
            public int page_size { get; set; }// 本页数据量   page_size 数值型	4		Y

        }
        public class Out1312
        {
            public string hilist_code { get; set; }//   医保目录编码 字符型	30	　	Y
            public string hilist_name { get; set; }// 医保目录名称 字符型	200	　	Y
            public string insu_admdvs { get; set; }// 参保机构医保区划 字符型	6	Y Y
            public DateTime begndate { get; set; }// 开始日期    日期型 Y
            public DateTime enddate { get; set; }// 结束日期    日期型 N
            public string med_chrgitm_type { get; set; }// 医疗收费项目类别    字符型	6	Y Y
            public string chrgitm_lv { get; set; }// 收费项目等级  字符型	3	Y Y
            public string lmt_used_flag { get; set; }// 限制使用标志  字符型	3	Y Y
            public string list_type { get; set; }// 目录类别    字符型	3	Y Y
            public string med_use_flag { get; set; }// 医疗使用标志  字符型	3	Y Y
            public string matn_used_flag { get; set; }// 生育使用标志  字符型	3	Y Y
            public string hilist_use_type { get; set; }// 医保目录使用类别    字符型	3	Y Y
            public string lmt_cpnd_type { get; set; }// 限复方使用类型 字符型	3	Y Y
            public string wubi { get; set; }// 五笔助记码   字符型	30	　	N
            public string pinyin { get; set; }//  拼音助记码 字符型	30	　	N
            public string memo { get; set; }//   备注 字符型	500	　	N
            public string vali_flag { get; set; }//   有效标志 字符型	3	Y Y
            public string rid { get; set; }// 唯一记录号   字符型	40	　	Y
            public DateTime updt_time { get; set; }//   更新时间 日期型         Y
            public string crter_id { get; set; }//    创建人 字符型	20	　	N
            public string crter_name { get; set; }//  创建人姓名 字符型	50	　	N
            public DateTime crte_time { get; set; }//   创建时间 日期型         Y
            public string crte_optins_no { get; set; }//  创建机构 字符型	20	　	N
            public string opter_id { get; set; }//    经办人 字符型	20	　	N
            public string opter_name { get; set; }//  经办人姓名 字符型	50	　	N
            public DateTime opt_time { get; set; }//    经办时间 日期型         N
            public string optins_no { get; set; }//   经办机构 字符型	20	　	N
            public string poolarea_no { get; set; }// 统筹区 字符型	6	Y N

        }
    }
}
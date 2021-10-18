using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB.JBXX
{
    public class YP1304
    {
        public class In1304
        {
            public string med_list_codg { get; set; }//医疗目录编码 字符型	20		
            public string genname_codg { get; set; }//            通用名编号    字符型	100			
            public string drug_genname { get; set; }//           药品通用名   字符型	20
            public string drug_prodname { get; set; }//            药品商品名    字符型	500			
            public string reg_name { get; set; }//注册名称     字符型	500			
            public string tcmherb_name { get; set; }//中草药名称    字符型	30			
            public string mlms_name { get; set; }// 药材名称    字符型	255			
            public string vali_flag { get; set; }// 有效标志   字符型	3	Y
            public string rid { get; set; }//  唯一记录号    字符型	30			
            public string ver { get; set; }// 版本号  字符型	20			
            public string ver_name { get; set; }// 版本名称     字符型	30			
            public DateTime opt_begn_time { get; set; }//经办开始时间    日期型
            public DateTime opt_end_time { get; set; }//经办结束时间   日期型
            public DateTime updt_time { get; set; }//更新时间  日期型 Y
            public int page_num { get; set; }//当前页数    数值型	4		Y
            public int page_size { get; set; }//本页数据量    数值型	4		Y
        }
        public class Out1304
        {
            public string med_list_codg { get; set; }//医疗目录编码     字符型	50		Y
            public string drug_prodname { get; set; }//药品商品名    字符型	500			　
            public string genname_codg { get; set; }//通用名编号   字符型	20			
            public string drug_genname { get; set; }//药品通用名     字符型	500			
            public string ethdrug_type { get; set; }// 民族药种类 ethdrug_type    字符型	3	Y
            public string chemname { get; set; }// 化学名称    chemname 字符型	100			
            public string alis { get; set; }// 别名 alis    字符型	100			
            public string eng_name { get; set; }// 英文名称 eng_name    字符型	500			
            public string dosform { get; set; }// 剂型 dosform 字符型	500			
            public string each_dos { get; set; }// 每次用量 each_dos    字符型
            public string used_frqu { get; set; }// 使用频次    used_frqu 字符型	30			
            public string nat_drug_no { get; set; }// 国家药品编号 nat_drug_no 字符型	20			
            public string used_mtd { get; set; }// 用法 used_mtd    字符型
            public string ing { get; set; }// 成分  ing 字符型	500			
            public string chrt { get; set; }//性状 chrt    字符型	500			
            public string defs { get; set; }//不良反应 defs    字符型	1000			
            public string tabo { get; set; }//禁忌 tabo    字符型	500			
            public string mnan { get; set; }//注意事项 mnan    字符型	500			
            public string stog { get; set; }//贮藏 stog    字符型	500			
            public string drug_spec { get; set; }//药品规格 drug_spec   字符型	500			
            public string prcunt_type{ get; set; }// 计价单位类型 prcunt_type 字符型	3	Y
            public string otc_flag { get; set; }// 非处方药标志  otc_flag 字符型	3	Y
            public string pacmatl { get; set; }//包装材质    pacmatl 字符型	500			
            public string pacspec { get; set; }// 包装规格 pacspec 字符型	3			
            public string min_useunt { get; set; }//最小使用单位 min_useunt  字符型	30
            public string min_salunt { get; set; }// 最小销售单位 min_salunt  字符型	30			
            public string manl { get; set; }// 说明书 manl    字符型	2000			
            public string rute { get; set; }// 给药途径 rute    字符型	30		
            public DateTime begndate { get; set; }// 开始日期 begndate    日期型
            public DateTime enddate { get; set; }// 结束日期    enddate 日期型
            public string pham_type { get; set; }// 药理分类 pham_type   字符型	40			
            public string memo { get; set; }// 备注 memo    字符型	500			
            public string pac_cnt { get; set; }//包装数量 pac_cnt 字符型	20			
            public string min_unt { get; set; }//最小计量单位 min_unt 字符型	30			
            public int min_pac_cnt { get; set; }// 最小包装数量 min_pac_cnt 数值型	20			
            public string min_pacunt { get; set; }//最小包装单位 min_pacunt  字符型	30		
            public string min_prepunt { get; set; }//最小制剂单位 min_prepunt 字符型	30			
            public DateTime drug_expy { get; set; }//药品有效期 drug_expy   字符型	100			
            public string efcc_atd { get; set; }// 功能主治 efcc_atd    字符型
            public string min_prcunt { get; set; }//最小计价单位  min_prcunt 字符型	50			
            public string wubi { get; set; }//五笔助记码 wubi    字符型	30			
            public string pinyin { get; set; }//拼音助记码 pinyin  字符型	30			
            public string vail_flag { get; set; }//有效标志 vali_flag   字符型	3	Y Y
            public string rid { get; set; }// 唯一记录号 rid 字符型	40		Y
            public DateTime crte_time { get; set; }//数据创建时间  crte_time 日期型         Y
            public DateTime updt_time { get; set; }// 数据更新时间  updt_time 日期型         Y
            public string crter_id { get; set; }//创建人 crter_id 字符型	20		Y
            public string crter_name { get; set; }//创建人姓名   crter_name 字符型	50		Y
            public string crte_optins_no { get; set; }//创建经办机构  crte_optins_no 字符型	20		Y
            public string opter_id { get; set; }// 经办人 opter_id 字符型	20		Y
            public string opter_name { get; set; }// 经办人姓名   opter_name 字符型	50		Y
            public DateTime opt_time { get; set; }//经办时间    opt_time 日期型         Y
            public string optins_no { get; set; }// 经办机构    optins_no 字符型	20		Y
            public string ver { get; set; }//版本号 ver 字符型	20		Y

        }
    }
}
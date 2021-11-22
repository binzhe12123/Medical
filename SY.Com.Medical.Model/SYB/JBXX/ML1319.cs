using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB.JBXX
{
    public class In1319data
    {
        public In1319 data { get; set; }
    }
    
        public class In1319
        {
            public DateTime query_date { get; set; }// 查询时间点 日期型
            public string selfpay_prop_psn_type { get; set; }// 医保目录自付比例人员类别    字符型	6	Y
            public string selfpay_prop_type { get; set; }//   目录自付比例类别 字符型	6	Y
            public string insu_admdvs { get; set; }// 参保机构医保区划 字符型	6	Y         
            public DateTime begndate { get; set; }//    开始日期 日期型
            public DateTime enddate { get; set; }// 结束日期    日期型
            public string vali_flag { get; set; }//   有效标志 字符型	3	Y
            public string rid { get; set; }// 唯一记录号 字符型	40			
            public string tabname { get; set; }//表名  字符型	100			
            public string poolarea_no { get; set; }// 统筹区 字符型	6	Y
            public DateTime updt_time { get; set; }//   更新时间 日期型         Y
            public int page_num { get; set; }//    当前页数 数值型	4		Y
            public int page_size { get; set; }  //本页数据量 数值型	4		Y
        }
        public class Out1319
        {
            public string hilist_code { get; set; }//   医保目录编码 字符型	30	　	Y
            public string selfpay_prop_psn_type { get; set; }//   医保目录自付比例人员类别 字符型	6	Y Y
            public string selfpay_prop_type { get; set; }// 目录自付比例类别    字符型	6	Y Y
            public string insu_admdvs { get; set; }// 参保机构医保区划    字符型	6	Y Y
            public DateTime begndate { get; set; }// 开始日期    日期型 Y
            public DateTime enddate { get; set; }// 结束日期    日期型 N
            public string selfpay_prop { get; set; }// 自付比例    BigDecimal	5	Y Y
            public string vali_flag { get; set; }//有效标志    字符型	3	Y Y
            public string rid { get; set; }// 唯一记录号   字符型	40	　	Y
            public DateTime updt_time { get; set; }// 更新时间 日期型         Y
            public string crter_id { get; set; }//    创建人 字符型	20	　	N
            public string crter_name { get; set; }//  创建人姓名 字符型	50	　	N
            public DateTime crte_time { get; set; }//   创建时间 日期型         Y
            public string crte_optins_no { get; set; }// 创建机构 字符型	20	　	N
            public string opter_id { get; set; }//   经办人 字符型	20	　	N
            public string opter_name { get; set; }//  经办人姓名 字符型	50	　	N
            public DateTime opt_time { get; set; }//    经办时间 日期型         N
            public string optins_no { get; set; }//   经办机构 字符型	20	　	N
            public string tabname { get; set; }// 表名 字符型	100　	　	N
            public string poolarea_no { get; set; }// 统筹区 字符型	6	Y N

        }

    
}
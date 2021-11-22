using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SY.Com.Medical.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class KCBG3502
    {
        /// <summary>
        /// 
        /// </summary>
        public class In3502
        {
            /// <summary>
            /// 
            /// </summary>
            public string med_list_codg { get; set; }// 医疗目录编码 字符型	50	　	Y
            /// <summary>
            /// 
            /// </summary>
            public string inv_chg_type { get; set; }//    库存变更类型 字符型	6	Y Y
            /// <summary>
            /// 
            /// </summary>
            public string fixmedins_hilist_id { get; set; }// 定点医药机构目录编号  字符型	30	　	Y
            /// <summary>
            /// 
            /// </summary>
            public string fixmedins_hilist_name { get; set; }//   定点医药机构目录名称 字符型	200	　	Y
            /// <summary>
            /// 
            /// </summary>
            public string fixmedins_bchno { get; set; }// 定点医药机构批次流水号 字符型	30	　	Y
            /// <summary>
            /// 
            /// </summary>
            public decimal pric { get; set; }//    单价 数值型	16,6	　	Y
            /// <summary>
            /// 
            /// </summary>
            public decimal cnt { get; set; }// 数量 数值型	16,4	　	Y 按最小计价包装单位
            /// <summary>
            /// 
            /// </summary>
            public string rx_flag { get; set; }// 处方药标志   字符型	3	Y Y
            /// <summary>
            /// 
            /// </summary>
            public DateTime inv_chg_time { get; set; }// 库存变更时间  日期时间型 Y   yyyy-MM-dd HH:mm:ss
            /// <summary>
            /// 
            /// </summary>
            public string inv_chg_opter_name { get; set; }//  库存变更经办人姓名 字符型	50	　	　	　
            /// <summary>
            /// 
            /// </summary>
            public string memo { get; set; }// 备注  字符型	500	　	　	　
            /// <summary>
            /// 
            /// </summary>
            public string trdn_flag { get; set; }// 拆零标志    字符型	2			

        }
    }
}
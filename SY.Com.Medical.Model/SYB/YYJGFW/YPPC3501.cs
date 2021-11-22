using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SY.Com.Medical.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class YPPC3501
    {
        /// <summary>
        /// 
        /// </summary>
        public class In3501
        {
            /// <summary>
            /// 
            /// </summary>
            public string med_list_codg { get; set; }// 医疗目录编码  字符型	50	　	Y
            /// <summary>
            /// 
            /// </summary>
            public string fixmedins_hilist_id { get; set; }// 定点医药机构目录编号 字符型	30	　	Y
            /// <summary>
            /// 
            /// </summary>
            public string fixmedins_hilist_name { get; set; }//   定点医药机构目录名称 字符型	200	　	Y
            /// <summary>
            /// 
            /// </summary>
            public string rx_flag { get; set; }// 处方药标志 字符型	3	Y Y
            /// <summary>
            /// 
            /// </summary>
            public DateTime invdate { get; set; }// 盘存日期    日期型 Y   yyyy-MM-dd
            /// <summary>
            /// 
            /// </summary>
            public decimal inv_cnt { get; set; }// 库存数量 数值型	16,2	　	Y 按最小计价包装单位统计
            /// <summary>
            /// 
            /// </summary>
            public string manu_lotnum { get; set; }// 生产批号    字符型	30	　	　	　
            /// <summary>
            /// 
            /// </summary>
            public string fixmedins_bchno { get; set; }// 定点医药机构批次流水号 字符型	30	　	Y 医药机构自定义批次号
            /// <summary>
            /// 
            /// </summary>
            public DateTime manu_date { get; set; }// 生产日期    日期型 Y   yyyy-MM-dd
            /// <summary>
            /// 
            /// </summary>
            public DateTime expy_end { get; set; }//   有效期止 日期型         Y yyyy-MM-dd
            /// <summary>
            /// 
            /// </summary>
            public string memo { get; set; }//   备注 字符型	500	　	　	　

        }

    }
}
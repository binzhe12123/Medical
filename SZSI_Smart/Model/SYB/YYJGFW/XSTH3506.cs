using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MK.Clinic.Model
{
    public class XSTH3506
    {
        public class In3506
        {
            public string med_list_codg { get; set; }// 医疗目录编码 字符型	50	　	Y
            public string fixmedins_hilist_id { get; set; }// 定点医药机构目录编号 字符型	30	　	Y
            public string fixmedins_hilist_name { get; set; }//   定点医药机构目录名称 字符型	200	　	Y
            public string fixmedins_bchno { get; set; }// 定点医药机构批次流水号 字符型	30	　	Y
            public string setl_id { get; set; }// 结算ID 字符型	30	　	　	　
            public string psn_no { get; set; }// 人员编号    字符型	30	　	　	　
            public string psn_cert_type { get; set; }// 人员证件类型  字符型	6	Y
            public string certno { get; set; }//  证件号码 字符型	50		　	　
            public string psn_name { get; set; }// 人员姓名    字符型	50	　	　	　
            public string manu_lotnum { get; set; }// 生产批号    字符型	30	　	Y
            public DateTime manu_date { get; set; }//   生产日期 日期型         Y yyyy-MM-dd
            public DateTime expy_end { get; set; }//   有效期止 日期型             yyyy-MM-dd
            public string rx_flag { get; set; }// 处方药标志 字符型	3	Y Y
            public string trdn_flag { get; set; }// 拆零标志    字符型	3	Y Y　	0-否；1-是
            public decimal finl_trns_pric { get; set; }//  最终成交单价 数值型	16,6	　	　	　
            public decimal sel_retn_cnt { get; set; }//销售/退货数量 数值型	16,4	　	Y
            public DateTime sel_retn_time { get; set; }//  销售/退货时间 日期时间型           Y yyyy-MM-dd HH:mm:ss
            public string sel_retn_opter_name { get; set; }// 销售/退货经办人姓名 字符型	50	　	Y
            public string memo { get; set; }//   备注 字符型	500	　	　	　
            public string medins_prod_sel_no { get; set; }// 商品销售流水号 字符型	50			

        }
    }
}
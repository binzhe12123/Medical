using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MK.Clinic.Model
{
    public class YPCGTH3504
    {
        public class In3504
        {
            public string med_list_codg { get; set; }// 医疗目录编码 字符型	50	　	Y
            public string fixmedins_hilist_id { get; set; }// 定点医药机构目录编号 字符型	30	　	Y
            public string fixmedins_hilist_name { get; set; }//  定点医药机构目录名称 字符型	200	　	Y
            public string fixmedins_bchno { get; set; }// 定点医药机构批次流水号 字符型	30	　	Y
            public string spler_name { get; set; }//  供应商名称 字符型	200	　	Y
            public string spler_pmtno { get; set; }// 供应商许可证号 字符型	50	　	　	　
            public DateTime manu_date { get; set; }// 生产日期    日期型 Y   yyyy-MM-dd
            public DateTime expy_end { get; set; }//    有效期止 日期型         Y yyyy-MM-dd
            public decimal finl_trns_pric { get; set; }//  最终成交单价 数值型	16,6	　	　	采购/退货单价
            public decimal purc_retn_cnt { get; set; }//   采购/退货数量 数值型	16,4	　	Y
            public string purc_invo_codg { get; set; }//  采购发票编码 字符型	50	　	　	　
            public string purc_invo_no { get; set; }// 采购发票号   字符型	50	　	Y
            public string rx_flag { get; set; }//处方药标志 字符型	3	Y Y
            public DateTime purc_retn_stoin_time { get; set; } //采购/退货入库时间 日期时间型           Y yyyy-MM-dd HH:mm:ss
            public string purc_retn_opter_name { get; set; }//    采购/退货经办人姓名 字符型	50	　	Y
            public string memo { get; set; }//   备注 字符型	500	　	　	　
            public string medins_prod_purc_no { get; set; }// 商品采购流水号 字符型	50			

        }
    }
}
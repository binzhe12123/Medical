using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB.XXCJ
{
    public class LG4302
    {
        public class In4302
        {
            public OprnInfo oprninfo { get; set; }
            public RescInfo rescinfo { get; set; }
        }
        public class OprnInfo 
        {
            public string Ymdtrt_sn { get; set; }//   就医流水号   字符型	30		Y 院内唯一号
            public string Ymdtrt_id { get; set; }//   就诊ID    字符型	30			医保病人必填
            public string Ypsn_no { get; set; }//     人员编号 字符型	30			医保病人必填
            public string medrcdno { get; set; }//    Y     病历号 字符型	30			
            public int oprn_oprt_sn { get; set; }//     手术操作序号  数值型	2,0		Y
            public string oprn_oprt_code { get; set; }//   手术操作代码 字符型	30		Y
            public string oprn_oprt_name { get; set; }//   手术操作名称 字符型	500		Y
            public string oprn_oprt_tagt_part_name  { get; set; }// 手术操作目标部位名称  字符型	50		Y
            public string itvt_name { get; set; }//    介入物名称 字符型	100		Y
            public string oprn_oprt_mtd_dscr  { get; set; }// 手术及操作方法描述   字符型	200		Y
            public int oprn_oprt_cnt { get; set; }//    手术及操作次数 数值型	3,0		Y
            public DateTime oprn_oprt_time { get; set; }//   手术及操作时间 日期时间型           Y
            public string vali_flag { get; set; }// vali_flag   有效标志 字符型	3	Y Y

        }
        public class RescInfo
        {
            public DateTime resc_begntime { get; set; }// 抢救开始时间  日期时间型 Y
            public DateTime resc_endtime { get; set; } //抢救结束时间  日期时间型 Y
            public string er_resc_rec { get; set; }//急诊抢救记录  字符型	2000		Y
            public string resc_psn_list { get; set; }//   参加抢救人员名单 字符型	500		Y 人员使用全角“，”分隔
            public string vali_flag { get; set; }//   有效标志 字符型	3	Y Y

        }
    }
}
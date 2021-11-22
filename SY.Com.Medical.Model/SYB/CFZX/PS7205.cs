using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB.CFZX
{
    public class PS7205
    {
        public class In7205 
        {
            public string hi_rxno { get; set; }// 医保处方编号 字符型	30		Y
            public string delv_no { get; set; }// 配送业务编号 字符型	30			
            public string delv_addr { get; set; }// 配送地址    字符型	200			
            public decimal delv_dist { get; set; }// 配送距离    数值型	10,2			单位：km
            public string delv_entp_no { get; set; }//    配送企业编码 字符型	30			
            public string delv_entp_name { get; set; }// 配送企业名称  字符型	50		Y
            public string delver_cert_type { get; set; }//    配送员证件类型 字符型	6	Y 参照人员证件类型
            public string delver_certno { get; set; }//   配送员证件编号 字符型	50			
            public string delver_name { get; set; }// 配送员姓名   字符型	10			
            public string delver_tel { get; set; }// 配送员电话   字符型	20			
            public string delv_stas_codg { get; set; }// 状态编码 字符型	6	Y Y 参考配送状态编码(delv_stas_codg)
            public string delv_stas_name { get; set; }// 状态名称    字符型	20		Y
            public string delv_stas_dscr { get; set; }//  状态描述 字符型	20			
            public DateTime delv_stas_time { get; set; }// 状态描述变更时间    日期时间型
            public string delver_lng { get; set; }//  配送员当前经度 字符型	30			
            public string delver_lat { get; set; }// 配送员当前维度 字符型	30			
            public string delver_geo_type { get; set; }// 配送员经纬度编码类型 字符型	3			参考配送位置经纬度类型(delver_geo_type)

        }
    }
}
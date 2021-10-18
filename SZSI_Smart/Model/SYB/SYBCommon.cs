using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Client.Model
{
    public class SYBCommon
    {
        public class InCommon 
        {
            public string infno { get; set; }// 交易编号    字符型	4		Y 交易编号详见接口列表
            public string msgid { get; set; }// 发送方报文ID 30 Y 定点医药机构编号(12)+时间(14)+顺序号(4)时间格式：yyyyMMddHHmmss
            public string mdtrtarea_admvs { get; set; }// 就医地医保区划 字符型	6 Y 深圳：440300
            public string insuplc_admdvs { get; set; }// 参保地医保区划,结算含有人员编号，此项必填，可通过【1101】人员信息获取交易取得
            public string recer_sys_code { get; set; } //接收方系统代码 字符型	10		Y 用于多套系统接入，区分不同系统使用
            public string dev_no { get; set; } // 设备编号 字符型	100		
            public string dev_safe_info { get; set; }// 设备安全信息  字符型	2000	
            public string cainfo { get; set; }// 数字签名信息  字符型	1024	
            public string signtype { get; set; } //签名类型    字符型	10			建议使用SM2、SM3
            public string infver { get; set; }//  接口版本号 “V1.0”，版本号由医保下发通知。
            public string opter_type { get; set; }// 经办人类别		3	Y Y	1-经办人；2-自助终端；3-移动终端
            public string opter { get; set; }//   经办人 字符型	30		Y 按地方要求传入经办人/终端编号
            public string opter_name { get; set; }//  经办人姓名 字符型	50		Y 按地方要求传入经办人姓名/终端名称
            public string inf_time { get; set; }//    交易时间 日期时间型	19		Y
            public string fixmedins_code { get; set; }// 定点医药机构编号 字符型	12		Y
            public string fixmedins_name { get; set; }// 定点医药机构名称 字符型	20		Y
            public string sign_no { get; set; }// 交易签到流水号 字符型	30			通过签到【9001】交易获取
            public object input { get; set; } //  交易输入 字符型	40000		

        }
        public  class OutCommon
        {
            public int infcode { get; set; }// 交易状态码   数值型	4		Y 详见下节
            public string inf_refmsgid { get; set; }// 接收方报文ID Y 接收方返回，接收方医保区划代码(6)+时间(14)+流水号(10) 时间格式：yyyyMMddHHmmss
            public string refmsg_time { get; set; }// 接收报文时间 字符型	17			格式：yyyyMMddHHmmssSSS
            public string respond_time { get; set; }//   响应报文时间 字符型	17			格式：yyyyMMddHHmmssSSS
            public string err_msg { get; set; }//错误信息 字符型	200			交易失败状态下，业务返回的错误信息
            public object output { get; set; }//  交易输出 字符型	40000			

        }

        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SY.Com.Medical.Model.SYBCommon;

namespace SY.Com.Medical.BLL.Clinic
{
    public class SYBbll
    {
        /// <summary>
        /// 获取公共的入参结构
        /// </summary>
        /// <param name="fixmedins_code">机构编码</param>
        /// <param name="fixmedins_name">机构名称</param>
        /// <param name="opter"></param>
        /// <param name="opter_name"></param>
        /// <param name="sign_no"></param>
        /// <returns></returns>
        public InCommon getComm(string fixmedins_code, string fixmedins_name, string opter, string opter_name, string sign_no)
        {
            InCommon comm = new InCommon();
            comm.mdtrtarea_admvs = "440300"; //就医地医保区划 医保绑定，存储在库中。
            comm.insuplc_admdvs = "440300";  //参保地医保区划 字符型 6，读卡读到的
            comm.recer_sys_code = "MK";// 接收方系统代码 字符型 10      Y  mkzsy
            comm.dev_no = "";// 设备编号 字符型 100
            comm.dev_safe_info = ""; //设备安全信息  字符型 2000
            comm.cainfo = "";// 数字签名信息  字符型 1024
            comm.signtype = "";// 签名类型    字符型 10  
            comm.infver = "V1.0";// 接口版本号   字符型 6       Y      暂时V1.0，配置文件
            comm.msgid = fixmedins_code + DateTime.Now.ToString("yyyyMMddHHmmssfff") + "1";
            comm.opter_type = "1";//  经办人类别       3   Y Y
            comm.opter = opter;//经办人 字符型 30      Y
            comm.opter_name = opter_name;//  经办人姓名 字符型 50      Y
            comm.inf_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");//    交易时间 日期时间型   19      Y
            comm.fixmedins_code = fixmedins_code;//  定点医药机构编号 字符型 12      Y
            comm.fixmedins_name = fixmedins_name;//  定点医药机构名称 字符型 20      Y
            comm.sign_no = sign_no;
            return comm;
        }


    }
}

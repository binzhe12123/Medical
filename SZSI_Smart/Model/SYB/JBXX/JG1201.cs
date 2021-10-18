using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB.JBXX
{
    /// <summary>
    /// 1.1.1.1 医药机构信息获取
    /// </summary>
    public class JG1201
    {
        public class In1201
        {
            public string fixmedins_type { get; set; }// 定点医疗服务机构类型  字符型	6	Y Y
            public string fixmedins_name { get; set; }// 定点医药机构名称    字符型	200			输入关键字模糊查询
            public string fixmedins_code { get; set; }// 定点医药机构编号 字符型	12	　		查询定点零售药店时填写定点零售药店代码；查询定点医疗机构时填写定点医疗机构代码。

        }
        public class Out1201
        {
            public string fixmedins_code { get; set; }//   定点医药机构编号 字符型	12		Y
            public string fixmedins_name { get; set; }// 定点医药机构名称 字符型	200	　	Y
            public string uscc { get; set; }//   统一社会信用代码 字符型	50		Y
            public string fixmedins_type { get; set; }//  定点医疗服务机构类型 字符型	6	Y Y
            public string hosp_lv { get; set; }// 医院等级    字符型	6	Y

        }
    }
}
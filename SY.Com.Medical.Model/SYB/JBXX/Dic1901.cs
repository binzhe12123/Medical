using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB.JBXX
{
    /// <summary>
    /// 字典表查询
    /// </summary>
    public class Dic1901
    {
        /// <summary>
        /// 
        /// </summary>
        public class In1901
        {
            /// <summary>
            /// 
            /// </summary>
            public string type { get; set; }// 字典类型 字符型	30		Y
            /// <summary>
            /// 
            /// </summary>
            public string parentValue { get; set; }// 父字典键值 字符型	10		Y
            /// <summary>
            /// 
            /// </summary>
            public string admdvs { get; set; }//  行政区划 字符型	6	Y Y
            /// <summary>
            /// 
            /// </summary>
            public DateTime date { get; set; }// 查询日期    日期型 Y
            /// <summary>
            /// 
            /// </summary>
            public string valiFlag { get; set; }//            有效标志    字符型	3	Y Y

        }
        /// <summary>
        /// 
        /// </summary>
        public class Out1901
        {
            /// <summary>
            /// 
            /// </summary>
            public string type { get; set; }//  字典类型 字符型	30		Y
            /// <summary>
            /// 
            /// </summary>
            public string label { get; set; }//   字典标签 字符型	50		Y
            /// <summary>
            /// 
            /// </summary>
            public string value { get; set; }//   字典键值 字符型	20		Y
            /// <summary>
            /// 
            /// </summary>
            public string parentValue { get; set; }// 父字典键值 字符型	10		Y
            /// <summary>
            /// 
            /// </summary>
            public int sort { get; set; }  //  序号 整型	30	　	Y
            /// <summary>
            /// 
            /// </summary>
            public string valiFlag { get; set; }//    权限标识 字符型	3	　Y Y
            /// <summary>
            /// 
            /// </summary>
            public string createUser { get; set; }// 创建账户    字符型	30		Y
            /// <summary>
            /// 
            /// </summary>
            public DateTime createDate { get; set; }//  创建时间 日期型         Y
            /// <summary>
            /// 
            /// </summary>
            public string version { get; set; }// 版本号 整型	20	　	Y


        }
    }
}
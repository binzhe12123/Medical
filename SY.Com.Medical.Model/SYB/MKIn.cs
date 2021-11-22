using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Model.SYB
{
    /// <summary>
    /// 
    /// </summary>
    public class MKIn
    {
        /// <summary>
        /// 
        /// </summary>
        public class MKIn1101
        {
            /// <summary>
            /// 
            /// </summary>
            public long? ZHID { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long? YHBH { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string mdtrt_cert_type { get; set; } //就诊凭证类型
            /// <summary>
            /// 
            /// </summary>
            public string mdtrt_cert_no { get; set; }//就诊凭证编号
            /// <summary>
            /// 
            /// </summary>
            public string card_sn { get; set; }//卡识别码, 当mdtrt_cert_no是实体医保卡的时候需传入


        }
        /// <summary>
        /// 
        /// </summary>
        public class UserBd
        {
            /// <summary>
            /// 
            /// </summary>
            public long? zhid { get; set; }//
            /// <summary>
            /// 
            /// </summary>
            public long? YHBH { get; set; }// 字符串 是 用户编号
            /// <summary>
            /// 
            /// </summary>
            public string psn_no { get; set; }// 字符串 是 人员编号
            /// <summary>
            /// 
            /// </summary>
            public string psn_cert_type { get; set; }//字符串 是 证件类型
            /// <summary>
            /// 
            /// </summary>
            public string certno { get; set; }// 字符串 是 证件号码
            /// <summary>
            /// 
            /// </summary>
            public string psn_name { get; set; }// 字符串 是 人员姓名
            /// <summary>
            /// 
            /// </summary>
            public string gend { get; set; }//字符串 是 性别
            /// <summary>
            /// 
            /// </summary>
            public decimal age { get; set; }// 数值 是 年龄
            /// <summary>
            /// 
            /// </summary>
            public insuinfo insuinfo { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        public class insuinfo
        {
            /// <summary>
            /// 
            /// </summary>
            public string insutype { get; set; }// 字符串 是 险种类型
            /// <summary>
            /// 
            /// </summary>
            public string insuplc_admdvs { get; set; }// 字符串 是 参保地医保区划
            /// <summary>
            /// 
            /// </summary>
            public string psn_type { get; set; }// 字符串 是 人员类别
        }
        /// <summary>
        /// 
        /// </summary>
        public class OutRY
        {
            /// <summary>
            /// 
            /// </summary>
            public long? ZHID { get; set; }// 字符串 是
            /// <summary>
            /// 
            /// </summary>
            public long? HZBH { get; set; }//   字符串 是   患者编号
            /// <summary>
            /// 
            /// </summary>
            public long? HZID { get; set; }//    字符串 是   患者ID

        }

    }
}

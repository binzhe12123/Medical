using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB.CFZX
{
    /// <summary>
    /// 
    /// </summary>
    public class CFSH7204
    {
        /// <summary>
        /// 
        /// </summary>
        public class In7204
        {
            /// <summary>
            /// 
            /// </summary>
            public string hi_rxno { get; set; }//   医保处方编号 字符型	30		Y
            /// <summary>
            /// 
            /// </summary>
            public string phar_cert_type { get; set; }//  药师证件类型 字符型	6	Y Y   参照人员证件类型
            /// <summary>
            /// 
            /// </summary>
            public string phar_certno { get; set; }// 药师证件号码 字符型	50		Y
            /// <summary>
            /// 
            /// </summary>
            public string phar_name { get; set; }//   药师姓名 字符型	50		Y
            /// <summary>
            /// 
            /// </summary>
            public string phar_prac_cert_no { get; set; }//   药师执业资格证号 字符型	50			
            /// <summary>
            /// 
            /// </summary>
            public string phar_sign_info { get; set; }// 执业药师签名  字符型	2000			
            /// <summary>
            /// 
            /// </summary>
            public string rchk_phar_cert_type { get; set; }// 复核药师证件类型    字符型	6	Y 参照人员证件类型
            /// <summary>
            /// 
            /// </summary>
            public string rchk_phar_certno { get; set; }// 复核药师证件编号    字符型	50		Y
            /// <summary>
            /// 
            /// </summary>
            public string rchk_phar_name { get; set; }//  复核药师姓名 字符型	40		Y
            /// <summary>
            /// 
            /// </summary>
            public string rx_chk_opnn { get; set; }// 处方审核意见 字符型	2000		Y
            /// <summary>
            /// 
            /// </summary>
            public string rx_chk_stas_codg { get; set; }//    处方审核状态代码 字符型	10	Y Y
            /// <summary>
            /// 
            /// </summary>
            public DateTime rx_chk_time { get; set; }// 处方审核时间  日期时间型 Y   yyyy-MM-dd HH:mm:ss
            /// <summary>
            /// 
            /// </summary>
            public string rx_chk_file { get; set; }// 审方附件 大文本

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB
{
    /// <summary>
    ///电子处方撤销
    /// </summary>
    public class YG7104
    {
        /// <summary>
        /// 
        /// </summary>
        public class In7104data
        {
            /// <summary>
            /// 
            /// </summary>
            public In7104 data { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        public class In7104
        {
            /// <summary>
            /// 
            /// </summary>
            public string hi_rxno { get; set; }//   医保处方编号 字符型	30		Y
            /// <summary>
            /// 
            /// </summary>
            public string prsc_dr_name { get; set; }//    撤销医师姓名 字符型	50		Y
            /// <summary>
            /// 
            /// </summary>
            public string undo_dr_cert_type { get; set; }//   撤销医师证件类型 字符型	6	Y 参照人员证件类型
            /// <summary>
            /// 
            /// </summary>
            public string undo_dr_certno { get; set; }// 撤销医师证件号码    字符型	50		Y
            /// <summary>
            /// 
            /// </summary>
            public string undo_rea { get; set; }//    撤销原因描述 字符型	200		Y
            /// <summary>
            /// 
            /// </summary>
            public string undo_time { get; set; }//   撤销时间 日期时间型           Y
        }
        /// <summary>
        /// 
        /// </summary>
        public class In7105data
        {
            /// <summary>
            /// 
            /// </summary>
            public In7105 data { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        public class In7105
        {
            /// <summary>
            /// 
            /// </summary>
            public string hi_rxno { get; set; }//hi_rxno	医保处方编号	字符型	30		Y	
            /// <summary>
            /// 
            /// </summary>
            public string prsc_dr_name { get; set; }//prsc_dr_name	撤销医师姓名	字符型	50		Y	
            /// <summary>
            /// 
            /// </summary>
            public string undo_dr_cert_type { get; set; }//undo_dr_cert_type	撤销医师证件类型	字符型	6	Y		参照人员证件类型
            /// <summary>
            /// 
            /// </summary>
            public string undo_dr_certno { get; set; }//undo_dr_certno	撤销医师证件号码	字符型	50		Y	
            /// <summary>
            /// 
            /// </summary>
            public string undo_rea { get; set; }//undo_rea	撤销原因描述	字符型	200		Y	
            /// <summary>
            /// 
            /// </summary>
            public string undo_time { get; set; }//undo_time	撤销时间	日期时间型			Y	
        }

    }
}
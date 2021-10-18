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
        public class In7104
        {
            public string hi_rxno { get; set; }//   医保处方编号 字符型	30		Y
            public string prsc_dr_name { get; set; }//    撤销医师姓名 字符型	50		Y
            public string undo_dr_cert_type { get; set; }//   撤销医师证件类型 字符型	6	Y 参照人员证件类型
            public string undo_dr_certno { get; set; }// 撤销医师证件号码    字符型	50		Y
            public string undo_rea { get; set; }//    撤销原因描述 字符型	200		Y
            public DateTime undo_time { get; set; }//   撤销时间 日期时间型           Y
        }
    }
}
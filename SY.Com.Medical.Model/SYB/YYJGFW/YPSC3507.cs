using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SY.Com.Medical.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class YPSC3507
    {
        /// <summary>
        /// 
        /// </summary>
        public class In3507
        {
            /// <summary>
            /// 
            /// </summary>
            public string fixmedins_bchno { get; set; }//   定点医药机构批次流水号 字符型	30	　	Y
            /// <summary>
            /// 
            /// </summary>
            public string inv_data_type { get; set; }//   进销存数据类型 字符型	30	Y Y	1-盘存信息；2-库存变更信息；3-采购信息；4-销售信息

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MK.Clinic.Model
{ 
    public class YPSC3507
    {
        public class In3507
        {
            public string fixmedins_bchno { get; set; }//   定点医药机构批次流水号 字符型	30	　	Y
            public string inv_data_type { get; set; }//   进销存数据类型 字符型	30	Y Y	1-盘存信息；2-库存变更信息；3-采购信息；4-销售信息

        }
    }
}
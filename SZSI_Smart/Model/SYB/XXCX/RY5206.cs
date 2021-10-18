using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SZSI_Smart.Model.SYB.XXCX
{
    public class RY5206
    {
        public class In5206
        {
            public string psn_no { get; set; }//   人员编号 字符型	30		Y
            public string cum_ym { get; set; }//  累计年月 字符型	6			

        }
        public class Out5206 
        {
            public string insutype { get; set; }//  险种类型 字符型	6	Y Y
            public string year { get; set; }// 年度  字符型	4	　	Y
            public string cum_ym { get; set; }//  累计年月 字符型	6	　	Y
            public string cum_type_code { get; set; }//  累计类别代码 字符型	10	　	Y
            public decimal cum { get; set; }// 累计值 数值型	16,2	　	Y

        }

    }
}
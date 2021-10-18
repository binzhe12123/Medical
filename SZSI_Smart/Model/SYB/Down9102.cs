using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MK.Clinic.Model
{
    public class Down9102
    {
        public class In9102
        {
            public string file_qury_no { get; set; }//  文件查询号 字符型	30		Y
            public string filename { get; set; }//    文件名 字符型	200		Y 下载【1301-1319】生成的文件，固定传入“plc”
            public string fixmedins_code { get; set; } //医药机构编号  字符型	30	　	Y

        }
    }
}
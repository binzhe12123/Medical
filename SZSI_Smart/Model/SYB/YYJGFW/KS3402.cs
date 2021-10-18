using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MK.Clinic.Model
{ 
    public class KS3402
    {
        public class In3402
        {
            public string hosp_dept_codg { get; set; }// 医院科室编码  字符型	20		Y
            public string hosp_dept_name { get; set; }// 医院科室名称 字符型	100		Y                    
            public DateTime begntime { get; set; }//    开始时间 日期时间型           Y
            public DateTime endtime { get; set; }// 结束时间 日期时间型
            public string itro { get; set; }// 简介  字符型	500		Y
            public string dept_resper_name { get; set; }//    科室负责人姓名 字符型	50		Y
            public string dept_resper_tel { get; set; }// 科室负责人电话 字符型	50		Y
            public string dept_med_serv_scp { get; set; }//   科室医疗服务范围 字符型	500		
            public string caty { get; set; }// 科别  字符型	6	Y Y   参照科室代码（dept）
            public DateTime dept_estbdat { get; set; }// 科室成立日期  日期时间型 Y
            public int aprv_bed_cnt { get; set; }// 批准床位数量  数值型	11		Y
            public int hi_crtf_bed_cnt { get; set; }// 医保认可床位数 数值型	11			
            public string poolarea_no { get; set; }// 统筹区编号   字符型	6		Y
            public int dr_psncnt { get; set; }//   医师人数 数值型	5		Y
            public int phar_psncnt { get; set; }// 药师人数 数值型	5		Y
            public int nurs_psncnt { get; set; }// 护士人数 数值型	5		Y
            public int tecn_psncnt { get; set; }// 技师人数 数值型	5		Y
            public string memo { get; set; }//    备注 字符型	500			　

        }
    }
}
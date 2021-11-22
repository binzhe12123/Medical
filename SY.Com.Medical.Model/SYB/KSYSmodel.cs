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
    public class KSYSmodel
    {
        /// <summary>
        /// 
        /// </summary>
        public long? ZHID { get; set; }//租户id
        /// <summary>
        /// 
        /// </summary>
        public long? doctorBH { get; set; }//表示医生编号(诊所云)
        /// <summary>
        /// 
        /// </summary>
        public long? KSBH { get; set; }////表示科室编号(诊所云)
    }
    /// <summary>
    /// 
    /// </summary>
    public class OutYsks
    {
        /// <summary>
        /// 
        /// </summary>
        public string doctorNo { get; set; }//医生医保编号
        /// <summary>
        /// 
        /// </summary>
        public string doctorName { get; set; }//医生姓名
        /// <summary>
        /// 
        /// </summary>
        public string doctorSFZ { get; set; }//身份证
        /// <summary>
        /// 
        /// </summary>
        public string KSNo { get; set; }//科室医保编号
        /// <summary>
        /// 
        /// </summary>
        public string KSName { get; set; }////科室名称
        /// <summary>
        /// 
        /// </summary>
        public string KScaty { get; set; }//科室医保科别
    }
    /// <summary>
    /// 
    /// </summary>
    public class MkGH
    {
        /// <summary>
        /// 
        /// </summary>
        public long? ZHID { get; set; }//租户ID
        /// <summary>
        /// 
        /// </summary>
        public long? GHBH { get; set; }//挂号编号
        /// <summary>
        /// 
        /// </summary>
        public string mdtrt_id { get; set; }//医保就诊id
        /// <summary>
        /// 
        /// </summary>
        public string psn_no { get; set; }//医保人员编号
        /// <summary>
        /// 
        /// </summary>
        public string ipt_otp_no { get; set; }//医保住院/门诊号
    }

}

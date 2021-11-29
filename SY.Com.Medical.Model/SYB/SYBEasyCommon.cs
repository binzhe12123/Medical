using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static SY.Com.Medical.Model.SYBCommon;

namespace SY.Com.Medical.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class SYBEasyCommon<T> : BaseModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public long? zhid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int EmployeeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string opter { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string opter_name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fixmedins_code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fixmedins_name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sign_no { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public T input { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>    
    public class SYBCommonModel : BaseModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int EmployeeId { get; set; }
    }



    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SYBCommonModel<T> : BaseModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int EmployeeId { get; set; }        
        /// <summary>
        /// 
        /// </summary>
        public T input { get; set; }
    }

    /// <summary>
    /// 解析报文-医保返回报文
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SYBCommonParseModel<T> : BaseModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int EmployeeId { get; set; }
        /// <summary>
        /// 具体报文
        /// </summary>
        public OutCommon<T> Message { get; set; }
    }

    /// <summary>
    /// 解析报文-医保返回报文-无报文体的时候使用
    /// </summary>    
    public class SYBCommonParseModel : BaseModel
    {
        /// <summary>
        /// 操作人员ID
        /// </summary>
        public int EmployeeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public OutCommon Message { get; set; }
    }


    /// <summary>
    /// 门诊就诊信息上传
    /// </summary>
    public class SYBMZUploadModel : BaseModel
    {
        /// <summary>
        /// 操作者Id
        /// </summary>
        public int EmployeeId { get; set; }
        /// <summary>
        /// 医生ID
        /// </summary>
        public int DoctorId { get; set; }
        /// <summary>
        /// 挂号ID
        /// </summary>
        public int RegisterId { get; set; }
        /// <summary>
        /// 诊断信息
        /// </summary>
        public string Diagnosis { get; set; }

    }

    /// <summary>
    /// 门诊费用明细上传
    /// </summary>
    public class SYBMZ2204Model : BaseModel
    {
        /// <summary>
        /// 操作者Id
        /// </summary>
        public int EmployeeId { get; set; }
        /// <summary>
        /// 门诊Id
        /// </summary>
        public int OutpatientId { get; set; }
    }


    /// <summary>
    /// 解析报文-医保返回报文
    /// </summary>    
    public class SYB2205ParseModel : BaseModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int OutpatientId { get; set; }
        /// <summary>
        /// 具体报文
        /// </summary>
        public OutCommon Message { get; set; }
    }
}

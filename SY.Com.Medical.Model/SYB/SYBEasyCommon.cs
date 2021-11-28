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
    /// <typeparam name="T"></typeparam>
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
    /// <typeparam name="T"></typeparam>
    public class SYBCommonParseModel : BaseModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int EmployeeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public OutCommon Message { get; set; }
    }

}

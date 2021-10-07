using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SY.Com.Medical.Model
{
    /// <summary>
    /// 患者dto模型
    /// </summary>
    public class PatientModel : BaseModel
    {
        /// <summary>
        /// 患者ID
        /// </summary>
        public int PatientId { get; set; }


        /// <summary>
        /// 患者姓名    
        /// </summary>    
        public string PatientName { get; set; }

        /// <summary>
        /// 姓名拼音    
        /// </summary> 
        public string PatientPinYin { get; set; }

        /// <summary>
        /// 电话（手机号）    
        /// </summary>       
        public string Phone { get; set; }

        /// <summary>
        /// 性别    
        /// </summary>
        public Enum.Sex Sex { get; set; }

        /// <summary>
        /// 出生日期    
        /// </summary>
        public DateTime CSRQ { get; set; }

        /// <summary>
        /// 身份证号    
        /// </summary>     
        public string SFZ { get; set; }

        /// <summary>
        /// 医保电脑号    
        /// </summary>  
        public string YBDNH { get; set; }

        /// <summary>
        /// 医保卡号    
        /// </summary>      
        public string YBKH { get; set; }

        /// <summary>
        /// 地址    
        /// </summary>      
        public string Addr { get; set; }
        /// <summary>
        /// 搜索
        /// </summary>
        public string SearchKey { get; set; }
    }

    /// <summary>
    /// 患者分页查询模型
    /// </summary>
    public class PatientPage : PageModel
    {
        /// <summary>
        /// 搜索   
        /// </summary>    
        public string SearchKey { get; set; }

        /// <summary>
        /// 电话（手机号）    
        /// </summary>       
        public string Phone { get; set; }
    }

    /// <summary>
    /// 添加
    /// </summary>
    public class PatientAdddto : BaseModel
    {
        /// <summary>
        /// 患者姓名    
        /// </summary>    
        public string PatientName { get; set; }

        /// <summary>
        /// 姓名拼音    
        /// </summary> 
        [JsonIgnore]
        public string PatientPinYin { get; set; }

        /// <summary>
        /// 电话（手机号）    
        /// </summary>       
        public string Phone { get; set; }

        /// <summary>
        /// 性别    
        /// </summary>
        public Enum.Sex Sex { get; set; }

        /// <summary>
        /// 出生日期    
        /// </summary>
        public DateTime? CSRQ { get; set; }

        /// <summary>
        /// 身份证号    
        /// </summary>     
        public string SFZ { get; set; }

        /// <summary>
        /// 医保电脑号    
        /// </summary>  
        [JsonIgnore]
        public string YBDNH { get; set; }

        /// <summary>
        /// 医保卡号    
        /// </summary>      
        [JsonIgnore]
        public string YBKH { get; set; }

        /// <summary>
        /// 地址    
        /// </summary>              
        public string Addr { get; set; }
        /// <summary>
        /// 搜索
        /// </summary>
        [JsonIgnore]
        public string SearchKey { get; set; }

    }

    /// <summary>
    /// 修改
    /// </summary>
    public class PatientUpdatedto : BaseModel
    {
        /// <summary>
        /// 患者ID
        /// </summary>
        public int PatientId { get; set; }

        /// <summary>
        /// 患者姓名    
        /// </summary>    
        public string PatientName { get; set; }

        /// <summary>
        /// 姓名拼音    
        /// </summary> 
        [JsonIgnore]
        public string PatientPinYin { get; set; }

        /// <summary>
        /// 电话（手机号）    
        /// </summary>       
        public string Phone { get; set; }

        /// <summary>
        /// 性别    
        /// </summary>
        public Enum.Sex Sex { get; set; }

        /// <summary>
        /// 出生日期    
        /// </summary>
        public DateTime? CSRQ { get; set; }

        /// <summary>
        /// 身份证号    
        /// </summary>     
        public string SFZ { get; set; }

        /// <summary>
        /// 医保电脑号    
        /// </summary>  
        [JsonIgnore]
        public string YBDNH { get; set; }

        /// <summary>
        /// 医保卡号    
        /// </summary>      
        [JsonIgnore]
        public string YBKH { get; set; }

        /// <summary>
        /// 地址    
        /// </summary>              
        public string Addr { get; set; }
        /// <summary>
        /// 搜索
        /// </summary>
        [JsonIgnore]
        public string SearchKey { get; set; }

    }

    /// <summary>
    /// 删除患者dto
    /// </summary>
    public class PatientDel:BaseModel
    {
        /// <summary>
        /// 患者ID
        /// </summary>
        public int PatientId { get; set; }
    }

}

using SY.Com.Medical.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Model
{
    /// <summary>
    /// 租户
    /// </summary>
    public class TenantModel : BaseModel
    {
    }


    /// <summary>
    /// 获取用户租户列表入参
    /// </summary>
    public class UserTenantRequest
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { get; set; }
    }

    /// <summary>
    /// 获取租户列表出参
    /// </summary>
    public class UserTenantResponse : BaseModel
    {
        /// <summary>
        /// 租户ID    
        /// </summary>
        public int TenantId { get; set; }

        /// <summary>
        /// 租户名称    
        /// </summary>
        public string TenantName { get; set; }

        /// <summary>
        /// 租户类型,枚举    
        /// </summary>
        public int? TenantType { get; set; }

        /// <summary>
        /// 服务开始时间    
        /// </summary>
        public DateTime? TenantServiceStart { get; set; }

        /// <summary>
        /// 服务结束时间    
        /// </summary>
        public DateTime? TenantServiceEnd { get; set; }

        /// <summary>
        /// 医保编码    
        /// </summary>
        public string YBCode { get; set; }

        /// <summary>
        /// 医保名称    
        /// </summary>
        public string YBName { get; set; }

        /// <summary>
        /// 医保程序路径    
        /// </summary>
        public string YBUrl { get; set; }

        public IsBoss IsBoss {get;set;}
    }

    /// <summary>
    /// 创建租户入参
    /// </summary>
    public class TenentCreateRequest : BaseModel
    {
        /// <summary>
        /// 租户名称    
        /// </summary>
        public string TenantName { get; set; }

        /// <summary>
        /// 租户类型,枚举    
        /// </summary>
        public TenantType TenantType { get; set; }


    }

    /// <summary>
    /// 租户模型入参
    /// </summary>
    public class TenantRequest : BaseModel
    {
        /// <summary>
        /// 租户ID    
        /// </summary>
        public int TenantId { get; set; }

        /// <summary>
        /// 租户名称    
        /// </summary>
        public string TenantName { get; set; }

        /// <summary>
        /// 租户类型,枚举    
        /// </summary>
        public int? TenantType { get; set; }

        /// <summary>
        /// 服务开始时间    
        /// </summary>
        public DateTime TenantServiceStart { get; set; }

        /// <summary>
        /// 服务结束时间    
        /// </summary>
        public DateTime TenantServiceEnd { get; set; }

        /// <summary>
        /// 医保编码    
        /// </summary>
        public string YBCode { get; set; }

        /// <summary>
        /// 医保名称    
        /// </summary>
        public string YBName { get; set; }

        /// <summary>
        /// 医保程序路径    
        /// </summary>
        public string YBUrl { get; set; }

        /// <summary>
        /// 是否可用:枚举    
        /// </summary>        
        public Enable IsEnable { get; set; }

        /// <summary>
        /// 启用禁用
        /// </summary>        
        public Delete IsDelete { get; set; }
        /// <summary>
        /// 记录创建时间
        /// </summary>        
        public DateTime CreateTime { get; set; }
        
    }
    
    /// <summary>
    /// 租户模型出参
    /// </summary>
    public class TenantResponse : BaseModel
    {

    }

}

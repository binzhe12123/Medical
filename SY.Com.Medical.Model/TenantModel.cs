using Newtonsoft.Json.Converters;
using SY.Com.Medical.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
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
        public new int TenantId { get; set; }

        /// <summary>
        /// 租户名称    
        /// </summary>
        public string TenantName { get; set; }

        /// <summary>
        /// 租户类型,枚举    
        /// </summary>        
        //public TenantType TenantType { get; set; }
        public int TenantType { get; set; }

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

        /// <summary>
        /// 是否老板
        /// </summary>
        
        public int IsBoss {get;set;}
        /// <summary>
        /// 租户图片
        /// </summary>
        public string LogoImg { get; set; }
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
        public int TenantType { get; set; }

        /// <summary>
        /// 图片路径(相对),通过图片上传接口返回的路径
        /// </summary>
        public string LogoImg { get; set; }


    }

    /// <summary>
    /// 租户模型入参
    /// </summary>
    public class TenantRequest : BaseModel
    {

        /// <summary>
        /// 租户名称    
        /// </summary>
        public string TenantName { get; set; }

        /// <summary>
        /// 租户类型,枚举    
        /// </summary>
        public int TenantType { get; set; }

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

    /// <summary>
    /// 邀请员工模型入参
    /// </summary>
    public class TenantInviteRequest : BaseModel
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 角色字符串
        /// </summary>
        public string Roles { get; set; }
    }

    /// <summary>
    /// 邀请员工出参
    /// </summary>
    public class TenantInivteResponse : BaseModel
    {

    }

}

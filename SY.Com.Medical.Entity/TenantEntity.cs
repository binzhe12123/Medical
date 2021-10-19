using SY.Com.Medical.Attribute;
using SY.Com.Medical.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Entity
{

    /// <summary>
    ///  租户    
    /// </summary>
    [DB_Table("Tenants")]
    [DB_Key("TenantId")]
    public class TenantEntity :BaseEntity
    {
        /// <summary>
        /// 租户ID    
        /// </summary>
        [DB_Key("TenantId")]
        public int TenantId { get; set; }

        /// <summary>
        /// 租户名称    
        /// </summary>
        public string TenantName { get; set; }

        /// <summary>
        /// 租户类型,枚举    
        /// </summary>
        [DB_Default(typeof(TenantType))]
        public TenantType TenantType { get; set; }

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
        /// logo图片路径
        /// </summary>
        public string LogoImg { get; set; }

    }

}

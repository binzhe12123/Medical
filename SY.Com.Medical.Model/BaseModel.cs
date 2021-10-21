using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SY.Com.Medical.Model
{
    /// <summary>
    /// 基模型
    /// </summary>
    public class BaseModel
    {
        /// <summary>
        /// 租户ID
        /// </summary>        
        [JsonIgnore]
        [Range(0,10000000)]
        public int TenantId { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        [JsonIgnore]
        public int UserId { get; set; }
        
    }
}

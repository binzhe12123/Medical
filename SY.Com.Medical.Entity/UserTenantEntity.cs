using SY.Com.Medical.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Entity
{
    /// <summary>
    ///  用户关联租户    
    /// </summary>
    [DB_Table("UserTenants")]
    [DB_Key("Id")]
    public class UserTenantEntity : BaseEntity
    {
        /// <summary>
        /// 无    
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public int? UsersId { get; set; }

        /// <summary>
        /// 租户ID    
        /// </summary>
        public int? TenantId { get; set; }

        /// <summary>
        /// 是否老板    
        /// </summary>
        public int? IsBoss { get; set; }


    }


}

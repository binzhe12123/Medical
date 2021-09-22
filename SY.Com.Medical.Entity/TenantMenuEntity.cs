using SY.Com.Medical.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Entity
{
    /// <summary>
    ///  租户菜单    
    /// </summary>
    [DB_Table("TenantMenus")]
    [DB_Key("Id")]
    public class TenantMenuEntity : BaseEntity
    {
        /// <summary>
        /// 自增id    
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 菜单id    
        /// </summary>
        public int? MenuId { get; set; }

        /// <summary>
        /// 租户id    
        /// </summary>
        public int? TenantId { get; set; }
 
    }

}

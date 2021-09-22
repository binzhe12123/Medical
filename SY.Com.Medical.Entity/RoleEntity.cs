using SY.Com.Medical.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Entity
{
    /// <summary>
    ///  员工角色    
    /// </summary>
    [DB_Table("Roles")]
    [DB_Key("RoleId")]
    public class RoleEntity : BaseEntity
    {
        /// <summary>
        /// 员工角色Id    
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 员工角色名称    
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 员工角色菜单集合    
        /// </summary>
        public string MenuIds { get; set; }



    }

}

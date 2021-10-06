using SY.Com.Medical.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Entity
{
    /// <summary>
    /// 角色菜单关系表
    /// </summary>
    [DB_Table("RoleMenus")]
    [DB_Key("Id")]
    public class RoleMenuEntity : BaseEntity
    {
        /// <summary>
        /// 自增主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 菜单id
        /// </summary>
        public int MenuId { get; set; }
        /// <summary>
        /// 角色id
        /// </summary>
        public int RoleId { get; set; }
    }
}

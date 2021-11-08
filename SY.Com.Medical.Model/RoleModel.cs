using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Model
{
    /// <summary>
    /// 角色信息
    /// </summary>
    public class RoleModel : BaseModel
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }
    }

    /// <summary>
    /// 更新角色菜单信息
    /// </summary>
    public class RoleUpdateMenuModel : BaseModel
    {
        /// <summary>
        /// 角色id
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 菜单id数组
        /// </summary>
        public List<int> MenuIds { get; set; }
    }

    /// <summary>
    /// 新增角色模型
    /// </summary>
    public class RoleInsertModel : BaseModel
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }
    }

    /// <summary>
    /// 获取角色菜单入参
    /// </summary>
    public class RoleOnlyIdModel:BaseModel
    {
        /// <summary>
        /// 角色id
        /// </summary>
        public int RoleId { get; set; }
    }


}

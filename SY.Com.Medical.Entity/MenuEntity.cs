using SY.Com.Medical.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Entity
{

    /// <summary>
    ///  菜单    
    /// </summary>
    [DB_Table("Menus")]
    [DB_Key("MenuId")]
    public class MenuEntity : BaseEntity
    {
        /// <summary>
        /// 菜单Id    
        /// </summary>
        public int MenuId { get; set; }

        /// <summary>
        /// 菜单名称    
        /// </summary>
        public string MenuName { get; set; }

        /// <summary>
        /// 菜单路由    
        /// </summary>
        public string MenuRoute { get; set; }

        /// <summary>
        /// 父路由,一级菜单为0    
        /// </summary>
        public int? MenuParent { get; set; }

    }
}

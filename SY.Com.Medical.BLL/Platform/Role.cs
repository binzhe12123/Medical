using SY.Com.Medical.Entity;
using SY.Com.Medical.Extension;
using SY.Com.Medical.Model;
using SY.Com.Medical.Repository.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.BLL.Platform
{
    public class Role 
    {

        private RoleRepository db;
        public Role()
        {
            db = new RoleRepository();
        }

        /// <summary>
        /// 获取租户的角色信息
        /// </summary>
        /// <param name="TenantId"></param>
        /// <returns></returns>
        public List<RoleModel> getRoles(int TenantId)
        {
            List<RoleModel> reulst = new List<RoleModel>();
            var tenantrole = db.getRoles(TenantId);
            if (tenantrole.Any())
            {
                tenantrole.ToList().ForEach(x=> reulst.Add(x.EntityToDto<RoleModel>()));
                return reulst;
            }
            tenantrole = db.getRoles();
            if (tenantrole.Any())
            {
                tenantrole.ToList().ForEach(x => reulst.Add(x.EntityToDto<RoleModel>()));
                return reulst;
            }
            return null;
        }

        /// <summary>
        /// 获取角色的菜单
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public List<MenuKeyValueDto> getMenu(RoleModel roleid)
        {
            var roleentity = roleid.DtoToEntity<RoleEntity>();
            var menus = db.getMenus(new List<RoleEntity>() { roleentity });
            return menus.EntityToDto<MenuKeyValueDto>();            
        }

        /// <summary>
        /// 更新角色的菜单列表
        /// </summary>
        /// <param name="role"></param>
        /// <param name="menuids"></param>
        /// <returns></returns>
        public bool nice(RoleModel role,List<int> menuids)
        {
            return db.UpdateMenus(role.DtoToEntity<RoleEntity>(), menuids);
        }
        


    }
}

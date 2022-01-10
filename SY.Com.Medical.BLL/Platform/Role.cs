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
        public List<RoleModel> getTenantRoles(int TenantId)
        {
            List<RoleModel> reulst = new List<RoleModel>();
            var tenantrole = db.getRoles(TenantId);
            if (tenantrole.Any())
            {
                tenantrole.ToList().ForEach(x=> reulst.Add(x.EntityToDto<RoleModel>()));
                return reulst;
            }
            //租户首次加载不存在角色,则创建租户角色
            if (db.FirstCopy(TenantId))
            {
                tenantrole = db.getRoles(TenantId);
                tenantrole.ToList().ForEach(x => reulst.Add(x.EntityToDto<RoleModel>()));
                return reulst;
            }
            return null;
        }

        /// <summary>
        /// 租户新增角色
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        //public bool InsertRole(RoleInsertModel mod)
        //{
        //    return db.insertRoles(mod.DtoToEntity<RoleEntity>()) >0;
        //}

        public bool InsertRole(RoleUpdateMenuModel mod)
        {
            var roleid = db.getID("Roles");
            mod.RoleId = roleid;
            db.insertRoles(mod.DtoToEntity<RoleEntity>());
            RoleModel rm = new RoleModel();
            rm.RoleId = mod.RoleId;
            rm.TenantId = mod.TenantId;
            rm.RoleName = mod.RoleName;
            rm.UserId = mod.UserId;
            updateMenu(rm, mod.MenuIds);
            return true;
        }


        /// <summary>
        /// 租户修改角色信息
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        public bool update(RoleModel mod)
        {
             return db.updateRole(mod.DtoToEntity<RoleEntity>()) > 0;
        }

        /// <summary>
        /// 租户删除角色信息
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        public bool delete(RoleOnlyIdModel mod)
        {
            if(getTenantRoles(mod.TenantId).Count == 1)
            {
                throw new MyException("只剩下一个角色了,不能删除");
            }
            return db.deleteRole(mod.DtoToEntity<RoleEntity>()) > 0;
        }

        /// <summary>
        /// 租户获取某一个或多个角色的菜单
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public List<MenuTreeResponse> getMenu(List<RoleModel> roleid)
        {          
            //获取角色菜单
            var menus = db.getMenus(roleid.DtoToEntity<RoleEntity>());
            Menu menubll = new Menu();
            return menubll.GetSystemTree(menus);
        }

        /// <summary>
        /// 租户更新角色的名称和菜单列表
        /// </summary>
        /// <param name="role"></param>
        /// <param name="menuids"></param>
        /// <returns></returns>
        public bool updateMenu(RoleModel role,List<int> menuids)
        {
            var entity = db.Get(role.RoleId);
            if(entity.RoleName != role.RoleName)
            {
                if (!update(role))
                {
                    throw new MyException("修改角色基本信息失败");
                }
            }
            return db.UpdateMenus(role.DtoToEntity<RoleEntity>(), menuids);
        }
        


    }
}

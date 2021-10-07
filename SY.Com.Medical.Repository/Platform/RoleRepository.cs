using Dapper;
using SY.Com.Medical.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Repository.Platform
{
    /// <summary>
    /// 角色
    /// </summary>
    public class RoleRepository : BaseRepository<RoleEntity>
    {
        /// <summary>
        /// 获取租户角色
        /// </summary>
        /// <param name="TenantId"></param>
        /// <returns></returns>
        public IEnumerable<RoleEntity> getRoles(int TenantId)
        {
            string sql = @" Select * From Roles Where TenantId = @TenantId And IsDelete = 0  ";
            return _db.Query<RoleEntity>(sql, new { TenantId = TenantId });
        }

        /// <summary>
        /// 获取系统角色
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleEntity> getRoles()
        {
            string sql = @" Select * From Roles Where TenantId = 0 ";
            return _db.Query<RoleEntity>(sql);
        }

        /// <summary>
        /// 复制系统数据进入租户数据
        /// 如果租户中存在角色,就不进行复制,否则进行复制
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public bool FirstCopy(int TenantId)
        {
            if (getRoles(TenantId).Any())
            {
                return true;
            }
            var sysroles = getRoles();
            int maxId = getID("Roles", sysroles.Count() + 1);
            sysroles.ToList().ForEach(x => {
                x.RoleId = maxId--;
                x.TenantId = TenantId;
            });
            Insert(sysroles);
            return true;
        }

        /// <summary>
        /// 根据角色获取菜单信息
        /// 可以是1个或多个角色
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public IEnumerable<MenuEntity> getMenus(List<RoleEntity> roles)
        {
            string sql = @" Select * From Menus Where MenuId in(
                                Select MenuId From RoleMenus Where RoleId in @RoleId
                            ) ";
            List<int> RoleIds = roles.Select(x => x.RoleId).ToList();            
            return _db.Query<MenuEntity>(sql, new { RoleId = RoleIds.ToArray() });
        }

        /// <summary>
        /// 更新角色的菜单
        /// </summary>
        /// <param name="role"></param>
        /// <param name="menuids"></param>
        /// <returns></returns>
        public bool UpdateMenus(RoleEntity role,List<int> menuids)
        {
            string sql = @" Delete From RoleMenus Where RoleId = @RoleId ";
            _db.Query(sql, role.RoleId);            
            string sql1 = @" Insert Into RoleMenus(MenuId,RoleId) Values(@MenuId,RoleId) ";
            List<RoleMenuEntity> rms = new List<RoleMenuEntity>();
            foreach(var item in menuids)
            {
                RoleMenuEntity rm = new RoleMenuEntity();
                rm.MenuId = item;
                rm.RoleId = role.RoleId;
                rms.Add(rm);
            }
            _db.Execute(sql1, rms);
            return true;
        }

        /// <summary>
        /// 获取一组role的信息
        /// </summary>
        /// <param name="RoleIds"></param>
        /// <returns></returns>
        public IEnumerable<RoleEntity> getRoles(List<int> RoleIds)
        {
            string sql = @" Select * From Roles Where RoleId in @RoleId  ";
            return _db.Query<RoleEntity>(sql, new { RoleId = new[] { RoleIds }  });
        }



    }
}

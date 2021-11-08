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
            string sql = @" Select * From Roles Where TenantId = @TenantId And IsDelete = 1  ";
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

        public int insertRoles(RoleEntity entity)
        {
            string sql = @" Insert Into Roles(RoleId,TenantId,RoleName,CreateTime,IsEnable,IsDelete)
                                       Values(@RoleId,@TenantId,@RoleName,getdate(),1,1)";
            return _db.Execute(sql, new { RoleId = (entity.RoleId == 0 ? getID("Roles") : entity.RoleId), TenantId=entity.TenantId, RoleName=entity.RoleName });
        }

        /// <summary>
        /// 修改角色信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int updateRole(RoleEntity entity)
        {
            string sql = " Update Roles Set RoleName = @rolename Where RoleId = @roleid ";
            return _db.Execute(sql, new { RoleName = entity.RoleName, RoleId = entity.RoleId });
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int deleteRole(RoleEntity entity)
        {
            string sql = " Update Roles Set IsDelete = 2 Where RoleId = @roleid ";
            return _db.Execute(sql, new {  RoleId = entity.RoleId });
        }

        /// <summary>
        /// 复制系统数据进入租户数据
        /// 如果租户中存在角色,就不进行复制,否则进行复制
        /// 不进需要复制角色信息还需要复制菜单信息
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
            var currentid = maxId - sysroles.Count() + 1;
            sysroles.ToList().ForEach(x => {
                copyRoleMenuToOther(0, x.RoleId, currentid);
                x.RoleId = currentid++;
                x.TenantId = TenantId;
                insertRoles(x);
            });
            return true;
        }

        /// <summary>
        /// 从一个角色复制他的权限到另外一个角色
        /// </summary>
        /// <param name="TenantId"></param>
        /// <param name="sourceRoleId"></param>
        /// <param name="targetRoleId"></param>
        /// <returns></returns>
        public int copyRoleMenuToOther(int TenantId,int sourceRoleId,int targetRoleId)
        {
            string sql = @" Insert Into RoleMenus(MenuId,RoleId,CreateTime,IsEnable,IsDelete)
                            Select rm.MenuId,@target,GETDATE(),1,1
                            From Roles  as r
                            Inner Join RoleMenus as rm on r.roleid = rm.roleid
                            Where r.TenantId = @tenantid And r.RoleId = @source ";
            return _db.Execute(sql, new { tenantid = TenantId, source = sourceRoleId, target = targetRoleId });
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
            _db.Query(sql, new { RoleId = role.RoleId });            
            string sql1 = @" Insert Into RoleMenus(MenuId,RoleId,CreateTime,IsEnable,IsDelete) Values(@MenuId,@RoleId,getdate(),1,1) ";
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

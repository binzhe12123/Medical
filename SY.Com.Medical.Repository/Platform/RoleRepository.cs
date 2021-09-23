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
            string sql = @" Select * From Roles Where TenantId = @TenantId  ";
            return _db.Query<RoleEntity>(sql, new { TenantId = TenantId });
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

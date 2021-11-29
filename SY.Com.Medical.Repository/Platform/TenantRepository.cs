using Dapper;
using SY.Com.Medical.Entity;
using SY.Com.Medical.Enum;
using SY.Com.Medical.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Repository.Platform
{
    /// <summary>
    /// 租户数据访问层
    /// </summary>
    public class TenantRepository : BaseRepository<TenantEntity>
    {

        public TenantRepository() : base() { }
        public TenantRepository(string connection) : base(connection) { }

        /// <summary>
        /// 获取用户关联的租户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IEnumerable<TenantEntity> getTenants(int UserId)
        {
            return getTenants(UserId, IsBoss.不是);
        }

        /// <summary>
        /// 获取用户拥有的租户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IEnumerable<TenantEntity> getTenants(int UserId, IsBoss isboss = IsBoss.不是)
        {
            string sql = @" select A.*,B.* From Tenants as A
                            Inner Join UserTenants as B On A.TenantId = B.TenantId
                            Where B.UserId=@Userid And B.IsEnable = @IsEnable And B.IsDelete = @IsDelete And B.IsBoss = @IsBoss";
            return _db.Query<TenantEntity>(sql, new { UserId = UserId, IsEnable = (int)Enable.启用, IsDelete = (int)Enum.Delete.正常,IsBoss = (int)isboss });
        }

        /// <summary>
        /// 创建用户和租户关联
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="TenantId"></param>
        public int CreateUserTenant(int UserId, int TenantId, IsBoss isboss = IsBoss.不是)
        {
            string sql = @" Insert Into UserTenants(UserId,TenantId,IsBoss,CreateTime,IsEnable,IsDelete)
                            Values(@UserId,@TenantId,@IsBoss,getdate(),@IsEnable,@IsDelete) ";
            return _db.Execute(sql, new { UserId = UserId, TenantId = TenantId, IsBoss = (int)isboss, IsEnable = (int)Enable.启用, IsDelete = (int)Enum.Delete.正常 });
        }

        /// <summary>
        /// 删除租户及其关系
        /// </summary>
        /// <param name="TenantId"></param>
        /// <param name="UserId"></param>
        public void DeleteTenant(int TenantId,int UserId)
        {
            string sql = @" Update Tenants Set IsDelete = @IsDelete Where TenantId=@TenantId;
                            Update UserTenants Set IsDelete =@IsDelete Where TenantId=@TenantId And UserId=@UserId ";
            _db.Execute(sql, new { UserId = UserId, TenantId = TenantId, IsDelete = (int)Enum.Delete.删除 });
        }

        public TenantEntity getById(int tenantId)
        {
            string sql = " Select * From Tenants where TenantId = @TenantId ";
            return _db.Query<TenantEntity>(sql, new { TenantId = tenantId })?.FirstOrDefault();
        }

    }
}

﻿using Dapper;
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

        public void DisableTenant(int TenantId,Enum.Enable enable)
        {
            string sql = " Update Tenants Set IsEnable = @enable Where TenantId=@TenantId ";
            _db.Execute(sql, new { TenantId = TenantId, enable = enable });
        }

        public TenantEntity getById(int tenantId)
        {
            string sql = " Select * From Tenants where TenantId = @TenantId ";
            return _db.Query<TenantEntity>(sql, new { TenantId = tenantId })?.FirstOrDefault();
        }

        /// <summary>
        /// 全平台搜索租户列表
        /// </summary>
        /// <param name="tenantName"></param>
        /// <param name="tenantIds"></param>
        /// <param name="BossName"></param>
        /// <param name="StopStart"></param>
        /// <param name="StopEnd"></param>
        /// <param name="CreateStart"></param>
        /// <param name="CreateEnd"></param>
        /// <returns></returns>
        public List<TenantAllSearchResponse> getAllPaltform(string tenantName,string tenantIds,string BossName,DateTime? StopStart,DateTime? StopEnd,DateTime? CreateStart,DateTime? CreateEnd)
        {
            StringBuilder where = new StringBuilder();
            //处理名称
            if(!string.IsNullOrEmpty(tenantName))
            {
                where.Append(" And a.TenantName Like '%" + tenantName + "%' ");
            }
            //处理Id
            if(!string.IsNullOrEmpty(tenantIds))
            {
                int id = 0;
                if(int.TryParse(tenantIds,out id))
                {
                    where.Append(" And a.TenantId = " + id + " ");
                }
                else
                {
                    string[] ids = tenantIds.Split(" ");
                    string inids = "";
                    for(int i = 0;i<ids.Length;i++)
                    {
                        int tempid = 0;
                        if(int.TryParse(ids[i],out tempid))
                        {
                            inids +=tempid + ",";
                        }
                    }
                    if(!string.IsNullOrEmpty(inids))
                    {
                        inids = inids.Substring(0, inids.Length - 1);
                        where.Append(" And a.TenantId in(" + inids + ") ");
                    }
                }
            }
            if(!string.IsNullOrEmpty(BossName))
            {
                where.Append(" And c.EmployeeName like '%" + BossName + "%' ");
            }
            if(StopStart != null)
            {
                where.Append(" And a.TenantServiceEnd >= '" + StopStart + "' ");
            }
            if (StopEnd != null)
            {
                where.Append(" And a.TenantServiceEnd <= '" + StopEnd + "' ");
            }
            if (CreateStart != null)
            {
                where.Append(" And a.CreateTime >= '" + CreateStart + "' ");
            }
            if (CreateEnd != null)
            {
                where.Append(" And a.CreateTime <= '" + CreateEnd + "' ");
            }
            string sql = @" Select a.TenantId,a.TenantName,a.TenantServiceStart,a.TenantServiceEnd
                            , a.IsEnable,a.CreateTime,c.EmployeeName
                             From Tenants as a
                            Inner Join UserTenants as b on a.TenantId = b.TenantId And b.IsBoss = 1
                            Inner Join Employees as c on b.UserId = c.EmployeeId
                            Where a.IsDelete = 1  " + where;
            return _db.Query<TenantAllSearchResponse>(sql)?.ToList();
        }

        /// <summary>
        /// 购买服务时间
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public int BuyServiceTime(TenantBuyRequest request)
        {
            int day = 0;
            switch(request.TimeUnit)
            {
                case "年":day = request.BuyTime * 365;break;
                case "月":day = request.BuyTime * 30;break;
                case "日":day = request.BuyTime * 1;break;
                default:day = request.BuyTime;break;
            }
            string sql = @" Update Tenants Set TenantServiceEnd = DATEADD(dd,@days,TenantServiceEnd) Where TenantId = @TenantId
                            Insert Into BuyRecords(BuyRecordId, TenantId, BuyUser, BuyStaff, Price, Way, Code, BuyTime)
                            Values(@BuyRecordId, @TenantId, @BuyUser, @BuyStaff, @Price, @Way, @Code, @BuyTime)";
            int recordid = getID("BuyRecords");
            return _db.Execute(sql, new { days = day, TenantId = request.TenantId, BuyRecordId = recordid
                , BuyUser = request.BuyUser, BuyStaff = request.BuyStaff,Price=request.Price,Way=request.Way,
                Code=request.Code,
                BuyTime=request.BuyTime + request.TimeUnit
            });
        }

    }
}

using SY.Com.Medical.Entity;
using SY.Com.Medical.Infrastructure;
using SY.Com.Medical.Model;
using SY.Com.Medical.Repository.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.BLL.Platform
{
    /// <summary>
    /// 租户
    /// </summary>
    public class Tenant 
    {
        private CURDObject<TenantEntity> curdObj;
        private TenantRepository db;
        public Tenant()
        {
            curdObj = new CURDObject<TenantEntity>();
            curdObj.Entity = new TenantEntity();
            curdObj.db = new TenantRepository();
            db = new TenantRepository();
        }

        /// <summary>
        /// 返回用户关联的租户信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IEnumerable<UserTenantResponse> GetTenants(BaseRequest<BaseModel> request)
        {
            var join = db.getTenants(request.UserID, Enum.IsBoss.不是);
            var boss = db.getTenants(request.UserID, Enum.IsBoss.是);
            List<UserTenantResponse> responsesjoin = new List<UserTenantResponse>();
            List<UserTenantResponse> responsesboss = new List<UserTenantResponse>();
            if (join.Any()) join.ToList().ForEach(entity => responsesjoin.Add(entity.EntityToModel<UserTenantResponse>()));            
            if (boss.Any()) boss.ToList().ForEach(entity => responsesboss.Add(entity.EntityToModel<UserTenantResponse>()));
            if (responsesjoin.Any()) responsesjoin.ForEach(response => response.IsBoss = Enum.IsBoss.是);
            if (responsesboss.Any()) responsesboss.ForEach(response => response.IsBoss = Enum.IsBoss.不是);
            return responsesjoin.Concat(responsesboss);
        }

        /// <summary>
        /// 返回用户关联的特定租户信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UserTenantResponse GetTenant(BaseRequest<BaseModel> request)
        {
            var join = db.getTenants(request.UserID, Enum.IsBoss.不是);
            var boss = db.getTenants(request.UserID, Enum.IsBoss.是);
            List<UserTenantResponse> responsesjoin = new List<UserTenantResponse>();
            List<UserTenantResponse> responsesboss = new List<UserTenantResponse>();
            if (join.Any()) join.ToList().ForEach(entity => responsesjoin.Add(entity.EntityToModel<UserTenantResponse>()));
            if (boss.Any()) boss.ToList().ForEach(entity => responsesboss.Add(entity.EntityToModel<UserTenantResponse>()));
            if (responsesjoin.Any()) responsesjoin.ForEach(response => response.IsBoss = Enum.IsBoss.是);
            if (responsesboss.Any()) responsesboss.ForEach(response => response.IsBoss = Enum.IsBoss.不是);
            return responsesjoin.Concat(responsesboss).ToList().Find(x=>x.TenantId == request.TenantID);
        }

        /// <summary>
        /// 创建租户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UserTenantResponse CreateTenant(BaseRequest<TenentCreateRequest> request)
        {
            var entity = curdObj.ModelToBLL<TenantEntity, TenentCreateRequest>(request.Data);
            entity.TenantServiceStart = DateTime.Now;
            entity.TenantServiceEnd = DateTime.Now.AddDays(double.Parse(ReadConfig.GetConfigSection("TenantTryDay")));
            int TenantID = curdObj.db.Create(entity);
            if(TenantID > 0)
            {
                db.CreateUserTenant(request.UserID, TenantID, Enum.IsBoss.是);
            }
            UserTenantResponse response = new UserTenantResponse();
            response.TenantId = TenantID;
            response.TenantName = request.Data.TenantName;
            return response;
        }

    }
}

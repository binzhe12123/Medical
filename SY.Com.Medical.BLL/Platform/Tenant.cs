using SY.Com.Medical.Entity;
using SY.Com.Medical.Infrastructure;
using SY.Com.Medical.Model;
using SY.Com.Medical.Repository.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using SY.Com.Medical.Extension;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.BLL.Platform
{
    /// <summary>
    /// 租户
    /// </summary>
    public class Tenant
    {
        private TenantRepository db;
        public Tenant()
        {
            db = new TenantRepository();
        }

        /// <summary>
        /// 返回用户关联的租户信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IEnumerable<UserTenantResponse> GetTenants(BaseModel request)
        {
            var join = db.getTenants(request.UserId, Enum.IsBoss.不是);
            var boss = db.getTenants(request.UserId, Enum.IsBoss.是);
            List<UserTenantResponse> responsesjoin = new List<UserTenantResponse>();
            List<UserTenantResponse> responsesboss = new List<UserTenantResponse>();
            if (join.Any()) join.ToList().ForEach(entity => responsesjoin.Add(entity.EntityToDto<UserTenantResponse>()));
            if (boss.Any()) boss.ToList().ForEach(entity => responsesboss.Add(entity.EntityToDto<UserTenantResponse>()));
            if (responsesjoin.Any()) responsesjoin.ForEach(response => response.IsBoss = Enum.IsBoss.不是);
            if (responsesboss.Any()) responsesboss.ForEach(response => response.IsBoss = Enum.IsBoss.是);
            return responsesjoin.Concat(responsesboss);
        }

        /// <summary>
        /// 返回用户关联的特定租户信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UserTenantResponse GetTenant(BaseModel request)
        {
            var join = db.getTenants(request.UserId, Enum.IsBoss.不是);
            var boss = db.getTenants(request.UserId, Enum.IsBoss.是);
            List<UserTenantResponse> responsesjoin = new List<UserTenantResponse>();
            List<UserTenantResponse> responsesboss = new List<UserTenantResponse>();
            if (join.Any()) join.ToList().ForEach(entity => responsesjoin.Add(entity.EntityToDto<UserTenantResponse>()));
            if (boss.Any()) boss.ToList().ForEach(entity => responsesboss.Add(entity.EntityToDto<UserTenantResponse>()));
            if (responsesjoin.Any()) responsesjoin.ForEach(response => response.IsBoss = Enum.IsBoss.不是);
            if (responsesboss.Any()) responsesboss.ForEach(response => response.IsBoss = Enum.IsBoss.是);
            return responsesjoin.Concat(responsesboss).ToList().Find(x => x.TenantId == request.TenantId);
        }

        /// <summary>
        /// 创建租户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UserTenantResponse CreateTenant(TenentCreateRequest request)
        {

            var entity = request.DtoToEntity<TenantEntity>();
            entity.TenantServiceStart = DateTime.Now;
            entity.TenantServiceEnd = DateTime.Now.AddDays(double.Parse(ReadConfig.GetConfigSection("TenantTryDay")));
            int TenantID = db.Create(entity);
            if (TenantID > 0)
            {
                db.CreateUserTenant(request.UserId, TenantID, Enum.IsBoss.是);
                //创建员工
                User ubll = new User();
                Employee embll = new Employee();
                EmployeeModel emmod = new EmployeeModel();
                UserModel ummod = ubll.getUser(request.UserId);
                var mod = CloneClass.Clone<UserModel, EmployeeModel>(ummod, emmod);
                mod.TenantId = TenantID;
                mod.Roles = "1,2";
                embll.createEmployee(mod);
            }
            UserTenantResponse response = new UserTenantResponse();
            response.TenantId = TenantID;
            response.TenantName = request.TenantName;
            response.TenantType = request.TenantType;
            response.TenantServiceStart = entity.TenantServiceStart;
            response.TenantServiceEnd = entity.TenantServiceEnd;
            //
            DepartmentRepository dbdepart = new DepartmentRepository();
            dbdepart.CopyToTenant(TenantID);
            return response;
        }

        /// <summary>
        /// 修改租户信息
        /// </summary>
        /// <param name="request"></param>
        public void UpdateTenant(TenantRequest request)
        {
            var entity = request.DtoToEntity<TenantEntity>();
            db.Update(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="TenantId"></param>
        public void DeleteTenant(int TenantId,int UserId)
        {
            db.DeleteTenant(TenantId, UserId);            
        }

        /// <summary>
        /// 点击进入租户
        /// 根据用户信息获取员工信息
        /// 根据员工角色信息获取菜单信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public List<MenuResponse> GetMenu(EmployeeGetModel request)
        {
            Employee em = new Employee();
            var emmodel = em.getEmployee(request);            
            List<RoleEntity> listrole = new List<RoleEntity>();
            foreach(var item in emmodel.Roles.Split(',').ToList())
            {
                listrole.Add(new RoleEntity() { RoleId = int.Parse(item) });
            }
            RoleRepository dbrole = new RoleRepository();
            return dbrole.getMenus(listrole).EntityToDto<MenuResponse>();
        }



    }
}

using Dapper;
using SY.Com.Medical.Entity;
using SY.Com.Medical.Enum;
using SY.Com.Medical.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Repository.Platform
{
    /// <summary>
    /// 科室
    /// </summary>
    public class DepartmentRepository : BaseRepository<DepartmentEntity>
    {
        /// <summary>
        /// 读取科室
        /// </summary>
        /// <param name="TenantId"></param>
        /// <returns></returns>
        public IEnumerable<DepartmentEntity> getTenantDepartment(int TenantId)
        {
            string sql = @" 
                            select B.* From TenantDepartments As A
                            Inner Join Departments As B On A.DepartmentId = B.Departmentid
                            Where a.TenantId = @TenantId ; ";
            var result = _db.Query<DepartmentEntity>(sql, new { TenantId = TenantId });
            return result;
        }


        /// <summary>
        /// 把科室信息拷贝到租户
        /// </summary>
        /// <param name="TenantId"></param>
        public void CopyToTenant(int TenantId)
        {
            string sql = @" Select * From Departments Where IsSystem = 1 ";
            var entitys = _db.Query<DepartmentEntity>(sql);
            string sql2 = @" Insert Into TenantDepartments(TenantDepartmentId,TenantId,DepartmentId,CreateTime,IsEnable,IsDelete)
                             Values(@TenantDepartmentId,@TenantId,@DepartmentId,@CreateTime,@IsEnable,@IsDelete)";
            List<TenantDepartmentEntity> entity2 = new List<TenantDepartmentEntity>();
            foreach(var item in entitys)
            {
                var tdentity = CloneClass.Clone<DepartmentEntity, TenantDepartmentEntity>(item, new TenantDepartmentEntity());
                entity2.Add(tdentity);
            }
            _db.Execute(sql2, entity2);
        }

        //插入
        public void InsertDepartment(int TenantId,DepartmentEntity entity)
        {
            int DepartmentId = Create(entity);
            string sql2 = @" Insert Into TenantDepartments(TenantDepartmentId,TenantId,DepartmentId,CreateTime,IsEnable,IsDelete)
                             Values(@TenantDepartmentId,@TenantId,@DepartmentId,@CreateTime,@IsEnable,@IsDelete)";
            _db.Execute(sql2, new
            {
                TenantDepartmentId = getID("TenantDepartments"),
                TenantId = TenantId,
                DepartmentId = DepartmentId
                ,
                CreateTime = DateTime.Now,
                IsEnable = Enable.启用,
                IsDelete = Enum.Delete.正常
            });
        }  


    }
}

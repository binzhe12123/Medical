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
                            select * From Departments                            
                            Where TenantId = @TenantId ; ";
            var result = _db.Query<DepartmentEntity>(sql, new { TenantId = TenantId });
            return result;
        }


        /// <summary>
        /// 把科室信息拷贝到租户
        /// </summary>
        /// <param name="TenantId"></param>
        public void CopyToTenant(int TenantId)
        {
            string sql3 = @" Select * From Departments Where TenantId =@TenantId  ";
            var temp =_db.Query(sql3, TenantId);
            if(temp.Any())
            {
                return;
            }
            string sql = @" Select * From Departments Where TenantId = 0 ";
            var entitys = _db.Query<DepartmentEntity>(sql);
            string sql2 = @" Insert Into Departments(DepartmentsId,TenantId,DepartmentName,DepartmentCode,CreateTime,IsEnable,IsDelete)
                             Values(@DepartmentsId,@TenantId,@DepartmentName,@DepartmentCode,@CreateTime,@IsEnable,@IsDelete)";
            _db.Execute(sql2, entitys);
        }



        //插入
        public void InsertDepartment(DepartmentEntity entity)
        {
            CopyToTenant(entity.TenantId);
            int DepartmentId = Create(entity);
            string sql2 = @" Insert Into Departments(DepartmentsId,TenantId,DepartmentName,DepartmentCode,CreateTime,IsEnable,IsDelete)
                             Values(@DepartmentsId,@TenantId,@DepartmentName,@DepartmentCode,@CreateTime,@IsEnable,@IsDelete)";
            _db.Execute(sql2, new
            {
                TenantDepartmentId = getID("Departments"),
                TenantId = entity.TenantId,
                DepartmentId = DepartmentId
                ,
                CreateTime = DateTime.Now,
                IsEnable = Enable.启用,
                IsDelete = Enum.Delete.正常
            });
        }

        //编辑
        public void EditDepartment(DepartmentEntity entity)
        {
            CopyToTenant(entity.TenantId);
            Update(entity);
        }



    }
}

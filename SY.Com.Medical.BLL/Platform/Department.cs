using SY.Com.Medical.Entity;
using SY.Com.Medical.Infrastructure;
using SY.Com.Medical.Model;
using SY.Com.Medical.Repository.Platform;
using SY.Com.Medical.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.BLL.Platform
{
    /// <summary>
    /// 科室
    /// </summary>
    public class Department
    {
        private DepartmentRepository db;
        public Department()
        {
            db = new DepartmentRepository();
        }

        /// <summary>
        /// 获取科室
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public List<DepartmentResponse> getDepartment(DepartmentEntity entity)
        {
            List<DepartmentResponse> result = new List<DepartmentResponse>();
            var entitys = db.getTenantDepartment(entity.DepartmentId);
            foreach(var item in entitys)
            {
                DepartmentResponse dr = new DepartmentResponse();
                result.Add(CloneClass.Clone<DepartmentEntity, DepartmentResponse>(item, dr));
            }
            return result;
        }

        /// <summary>
        /// 插入科室
        /// </summary>
        /// <param name="request"></param>
        /// <param name="TenantId"></param>
        public void createDepartment(DepartmentCreateRequest request,int TenantId)
        {
            var entity = request.DtoToEntity<DepartmentEntity>();
            db.InsertDepartment(TenantId, entity);
        }

        

    }
}

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
    /// 员工
    /// </summary>
    public class Employee
    {
        private CURDObject<EmployeeEntity> curdObj;
        private EmployeesRepository db;
        public Employee()
        {
            curdObj = new CURDObject<EmployeeEntity>();
            curdObj.Entity = new EmployeeEntity();
            curdObj.db = new EmployeesRepository();
            db = new EmployeesRepository();
        }

        /// <summary>
        /// 获取诊所的员工信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public List<EmployeeModel> getEmployees(int tenantId)
        {
            List<EmployeeModel> result = new List<EmployeeModel>();
            var entitys = db.getTenant(tenantId);
            foreach(var item in entitys)
            {
                EmployeeModel mod = new EmployeeModel();
                result.Add(CloneClass.Clone<EmployeeEntity, EmployeeModel>(item, mod));
            }
            return result;
        }

        /// <summary>
        /// 获取单个员工信息
        /// </summary>
        /// <param name="employeeid"></param>
        /// <returns></returns>
        public EmployeeModel getEmployee(int employeeid)
        {
            EmployeeModel result = new EmployeeModel();
            var entity = db.Get(employeeid, "Employees", "EmployeeId");
            CloneClass.Clone<EmployeeEntity, EmployeeModel>(entity, result) ;
            return result;
        }

        /// <summary>
        /// 邀请员工最后一步创建员工信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public int createEmployee(EmployeeModel request)
        {
            var entity = curdObj.ModelToBLL<EmployeeEntity, EmployeeModel>(request);
            return db.Create(entity);
        }
    }
}

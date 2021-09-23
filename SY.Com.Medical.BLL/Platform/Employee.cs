using SY.Com.Medical.Entity;
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



    }
}

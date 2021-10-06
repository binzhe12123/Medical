using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Model
{
    /// <summary>
    /// 员工模型
    /// </summary>
    public class EmployeeModel : BaseModel
    {
        /// <summary>
        /// 员工Id    
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// 租户id    
        /// </summary>
        public int? TenantId { get; set; }

        /// <summary>
        /// 用户id    
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// 员工姓名    
        /// </summary>
        public string EmployeeName { get; set; }

        /// <summary>
        /// 员工电话    
        /// </summary>
        public string EmployeePhone { get; set; }

        /// <summary>
        /// 员工医保编码    
        /// </summary>
        public string YBCode { get; set; }

        /// <summary>
        /// 员工角色    
        /// </summary>
        public string Roles { get; set; }
    }

    /// <summary>
    /// 获取员工信息
    /// </summary>
    public class EmployeeGetModel : BaseModel
    {

    }


}

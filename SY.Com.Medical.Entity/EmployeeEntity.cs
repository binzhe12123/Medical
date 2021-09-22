using SY.Com.Medical.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Entity
{
    /// <summary>
    ///  员工实体    
    /// </summary>
    [DB_Table("Employees")]
    [DB_Key("EmployeeId")]
    public class EmployeeEntity : BaseEntity
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
}

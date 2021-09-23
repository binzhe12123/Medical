using SY.Com.Medical.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Entity
{

    /// <summary>
    ///  租户科室    
    /// </summary>
    [DB_Table("TenantDepartments")]
    [DB_Key("TenantDepartmentId")]
    public class TenantDepartmentEntity : BaseEntity
    {
        /// <summary>
        /// 主键    
        /// </summary>
        [DB_Key("TenantDepartmentId")]
        public int TenantDepartmentId { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public int TenantId { get; set; }

        /// <summary>
        /// 科室id    
        /// </summary>
        public int DepartmentId { get; set; }
        

    }

}

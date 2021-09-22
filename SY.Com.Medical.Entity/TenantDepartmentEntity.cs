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
    [DB_Key("Id")]
    public class TenantDepartmentEntity : BaseEntity
    {
        /// <summary>
        /// 自增id    
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public int? TenantId { get; set; }

        /// <summary>
        /// 科室id    
        /// </summary>
        public int? DepartmentId { get; set; }
        

    }

}

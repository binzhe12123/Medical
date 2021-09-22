using SY.Com.Medical.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Entity
{
    /// <summary>
    ///  科室实体    
    /// </summary>
    [DB_Table("Departments")]
    [DB_Key("DepartmentId")]
    public class DepartmentEntity : BaseEntity
    {
        /// <summary>
        /// 科室ID    
        /// </summary>
        [DB_Key("DepartmentId")]
        public int DepartmentId { get; set; }

        /// <summary>
        /// 科室名称    
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// 科室编码    
        /// </summary>
        public string DepartmentCode { get; set; }

        /// <summary>
        /// 是否初始化给租户，枚举    
        /// </summary>
        public int IsInit { get; set; }


    }

}

using SY.Com.Medical.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class DepartmentModel : BaseModel
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public class DepartmentResponse : BaseModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int DepartmentId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DepartmentCode { get; set; }        
    }

    /// <summary>
    /// 
    /// </summary>
    public class DepartmentCreateRequest : BaseModel
    {        
        /// <summary>
        /// 
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DepartmentCode { get; set; }
    }

}

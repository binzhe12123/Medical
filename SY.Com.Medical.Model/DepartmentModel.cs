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
        /// 科室id
        /// </summary>
        public int DepartmentId { get; set; }
        /// <summary>
        /// 科室名称
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// 科室编码
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

    /// <summary>
    /// 
    /// </summary>
    public class DepartmentDelete : BaseModel
    {
        /// <summary>
        /// 科室id 
        /// </summary>
        public int DepartmentId { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class DepartmentDisalbe : BaseModel
    {
        /// <summary>
        /// 科室id 
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// 禁用/启用
        /// </summary>
        public Enable enalbe { get; set; }
    }

}

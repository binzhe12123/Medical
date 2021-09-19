using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Clinic.Model
{
    /// <summary>
    ///  Employee    
    /// </summary>
    public class EmployeeModel
    {
        /// <summary>
        /// 员工ID    
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 员工编号    
        /// </summary>
        public long? BH { get; set; }

        /// <summary>
        /// 机构ID    
        /// </summary>
        public int? ClinicID { get; set; }

        /// <summary>
        /// 用户ID    
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string RoleKeys { get; set; }

        /// <summary>
        /// 姓名    
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public int? Sex { get; set; }

        /// <summary>
        /// 电话    
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public DateTime? BirthDay { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string SFZH { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string YBCode { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string Imagepath { get; set; }

        /// <summary>
        /// 是否删除:0:正常,-1:禁用    
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// 是否删除:0:正常,-1:删除    
        /// </summary>
        public int IsDelete { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public DateTime CreateTime { get; set; }

    }

}

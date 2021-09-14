using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Clinic.Model
{

    /// <summary>
    ///  科室信息    
    /// </summary>
    public class DepartmentModel
    {
        /// <summary>
        /// 主键ID    
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 系统id
        /// </summary>
        public int SysId { get; set; }
        /// <summary>
        /// 诊所ID
        /// </summary>
        public int ClinicId { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public long BH { get; set; }

        /// <summary>
        /// 科室名称    
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 医保编码    
        /// </summary>
        public string BureauCode { get; set; }

        /// <summary>
        /// 自定义编码    
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 分类    
        /// </summary>
        public int? Kind { get; set; }

        /// <summary>
        /// 是否常规:0:否,1:是    
        /// </summary>
        public int? Star { get; set; }

        /// <summary>
        /// 描述    
        /// </summary>
        public string Descrition { get; set; }

        /// <summary>
        /// 是否删除:0:正常,-1:删除    
        /// </summary>
        public int IsDelete { get; set; }

    }
}

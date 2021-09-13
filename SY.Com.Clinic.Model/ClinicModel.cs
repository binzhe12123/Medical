using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Clinic.Model
{
    public class ClinicModel
    {

        /// <summary>
        ///  Clinic    
        /// </summary>
        public class Clinic
        {
            /// <summary>
            /// 主键id    
            /// </summary>
            public int Id { get; set; }

            /// <summary>
            /// 编号    
            /// </summary>
            public string Code { get; set; }

            /// <summary>
            /// 名称    
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// 种类    
            /// </summary>
            public string Category { get; set; }

            /// <summary>
            /// 图片路径    
            /// </summary>
            public string Imagepath { get; set; }

            /// <summary>
            /// 服务开始时间    
            /// </summary>
            public DateTime? ServiceStart { get; set; }

            /// <summary>
            /// 服务结束时间    
            /// </summary>
            public DateTime? ServiceEnd { get; set; }

            /// <summary>
            /// 是否删除:0:正常,-1:禁用    
            /// </summary>
            public int? State { get; set; }

            /// <summary>
            /// 创建时间    
            /// </summary>
            public DateTime CreateTime { get; set; }

            /// <summary>
            /// 是否删除:0:正常,-1:删除    
            /// </summary>
            public int IsDelete { get; set; }

        }

    }
}

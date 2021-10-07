using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Model
{
    /// <summary>
    /// 分页模型
    /// </summary>
    public class PageModel : BaseModel
    {
        /// <summary>
        /// 每页数量
        /// </summary>
        [Required]
        [Range(1, 200)]
        public int PageSize { get; set; }
        /// <summary>
        /// 第几页
        /// </summary>
        [Required]
        [Range(1, 100000)]
        public int PageIndex { get; set; }
    }
}

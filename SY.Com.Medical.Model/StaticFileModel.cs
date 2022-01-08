using SY.Com.Medical.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SY.Com.Medical.Model
{
    /// <summary>
    /// 静态资源上传模型
    /// </summary>
    public class StaticFileModel
    {
        /// <summary>
        /// 资源类型
        /// </summary>
        public StaticFileType StaticFileType { get; set; }
        /// <summary>
        /// 业务类型
        /// </summary>
        public StaticFileBusiness StaticFileBusiness { get; set; }
        /// <summary>
        /// 文件后缀名
        /// </summary>
        [JsonIgnore]
        public string fileExtension { get; set; }

        /// <summary>
        /// 文件路径扩展
        /// </summary>
        [JsonIgnore]
        public string filepathExtension { get; set; }

    }
}

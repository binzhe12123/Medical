using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Enum
{
    /// <summary>
    /// 静态文件类型
    /// </summary>
    public enum StaticFileType
    {
        /// <summary>
        /// 默认值,无意义
        /// </summary>
        无=0,
        /// <summary>
        /// 图片
        /// </summary>
        图片=1,
        /// <summary>
        /// Excel格式
        /// </summary>
        Excel=2,
        /// <summary>
        /// Word文件
        /// </summary>
        Word=3,
        /// <summary>
        /// 压缩文件
        /// </summary>
        压缩文件=4,
        /// <summary>
        /// Json文件
        /// </summary>
        Json文件=5,
        /// <summary>
        /// XML文件
        /// </summary>
        XML文件=6,
        /// <summary>
        /// Html文件
        /// </summary>
        Html=7,
        /// <summary>
        /// 其他类型文件
        /// </summary>
        其他=8
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.BLL.Platform
{
    /// <summary>
    /// 文件上传接口
    /// </summary>
    public interface IFileUpload
    {
        /// <summary>
        /// 保存stream到文件并返回相对路径
        /// </summary>
        /// <param name="mstream"></param>
        /// <returns></returns>
        public string SaveFile(MemoryStream mstream);
    }
}

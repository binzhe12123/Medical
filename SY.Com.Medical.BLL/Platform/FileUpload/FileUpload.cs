using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.BLL.Platform
{
    /// <summary>
    /// 文件上传抽象基类
    /// </summary>
    public abstract class FileUpload : IFileUpload
    {
        /// <summary>
        /// 上传的文件类型
        /// </summary>
        protected FileBus fb { get; set; }
        protected string _extension { get; set; }
        public FileUpload(FileBus filebus)
        {
            fb = filebus;
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="mstream"></param>
        /// <returns></returns>
        public abstract string SaveFile(MemoryStream mstream);
    }
    


}

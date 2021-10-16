using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SY.Com.Medical.Attribute;
using SY.Com.Medical.BLL;
using SY.Com.Medical.BLL.Platform;
using SY.Com.Medical.Enum;
using SY.Com.Medical.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SY.Com.Medical.WebApi.Controllers.Platform
{
    /// <summary>
    /// 静态资源
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class StaticFileController : ControllerBase
    {
        /// <summary>
        /// 上传静态资源
        /// </summary>
        /// <param name="files">Form表单提交图片</param>
        /// <param name="type">文件类型枚举</param>
        /// <param name="bus">上传业务枚举</param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<List<string>> UpLoadStaticFile([FromForm]List<IFormFile> files, [FromForm] StaticFileType staticFileType, [FromForm] StaticFileBusiness staticFileBusiness)
        {
            BaseResponse<List<string>> result = new BaseResponse<List< string>>();
            result.Data = new List<string>();
            try
            {                
                StaticFileModel request = new StaticFileModel() { StaticFileType = staticFileType, StaticFileBusiness = staticFileBusiness };
                if (files.Count < 1)
                {
                    throw new MyException("为上传任何文件");
                }
                foreach (var item in files)
                {
                    if (item != null)
                    {
                        //文件后缀
                        request.fileExtension = Path.GetExtension(item.FileName);
                        //获取文件操作类
                        var fileupload = FileUploadFactory.getInstance(request);
                        MemoryStream ms = new MemoryStream();
                        item.CopyTo(ms);
                        ms.Flush();
                        //执行文件保存
                        string filepath = fileupload.SaveFile(ms);
                        ms.Close();
                        result.Data.Add(Request.Host.Value + filepath);
                    }
                }
                //返回文件路径
                return result;
            }
            catch (Exception ex)
            {
                if (ex is MyException)
                {
                    return result.busExceptino(Enum.ErrorCode.业务逻辑错误, ex.Message);
                }
                else
                {
                    return result.sysException(ex.Message);
                }
            }

        }
    }
}

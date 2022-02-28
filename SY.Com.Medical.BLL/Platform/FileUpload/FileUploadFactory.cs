using SY.Com.Medical.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.BLL.Platform
{
    /// <summary>
    /// 静态文件上传工厂类,构造合适的对象
    /// </summary>
    public static class FileUploadFactory
    {
        /// <summary>
        /// 构造一个具体的图片上传类
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        public static IFileUpload getInstance(StaticFileModel mod)
        {
            IFileUpload ifu;
            FileBus fb;
            switch(mod.StaticFileBusiness)
            {
                case Enum.StaticFileBusiness.无: fb = new FileBus(); break;
                case Enum.StaticFileBusiness.用户头像上传: fb = new UserImgFileBus(); break;
                case Enum.StaticFileBusiness.租户图片上传: fb = new TenantImgFileBus(); break;
                case Enum.StaticFileBusiness.租户打印视图: fb = new TenantPrintView();break;
                case Enum.StaticFileBusiness.物料导入Excel:fb = new TenantGoodExcel();break;
                default: throw new MyException("请选择正确的上传业务");
            }
            switch(mod.StaticFileType)
            {
                case Enum.StaticFileType.无: throw new MyException("请选择正确的文件类型");
                case Enum.StaticFileType.图片: ifu = new ImgFileUpload(fb,mod.fileExtension); break;
                case Enum.StaticFileType.Print: ifu = new PrintViewFileUpload(fb, mod.fileExtension,mod.filepathExtension); break;
                case Enum.StaticFileType.Excel:ifu = new GoodExcelFileUpload(fb, mod.fileExtension,mod.fileExtension);break;
                default: throw new MyException("该文件类型暂不支持上传");
            }
            return ifu;
        }

    }
}

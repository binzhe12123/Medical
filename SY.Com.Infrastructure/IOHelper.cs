using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Drawing;
using System.Configuration;
using System.Text.RegularExpressions;

namespace SY.Com.Infrastructure
{
    /// <summary>
    /// 系统日志操作类
    /// </summary>
    public class IOHelper
    {
        public IOHelper()
        {

        }

        /// <summary>
        /// 判断文件是否存在
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool Exists(string fileName)
        {
            if (fileName == null || fileName.Trim() == "")
            {
                return false;
            }

            if (File.Exists(fileName))
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="dirName"></param>
        /// <returns></returns>
        public static bool CreateDir(string dirName)
        {
            if (!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }
            return true;
        }


        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool CreateFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                FileStream fs = File.Create(fileName);
                fs.Close();
                fs.Dispose();
            }
            return true;

        }


        /// <summary>
        /// 读文件内容
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string Read(string fileName)
        {
            if (!Exists(fileName))
            {
                return null;
            }
            //将文件信息读入流中
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                return new StreamReader(fs).ReadToEnd();
            }
        }


        public static string ReadLine(string fileName)
        {
            if (!Exists(fileName))
            {
                return null;
            }
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                return new StreamReader(fs).ReadLine();
            }
        }


        /// <summary>
        /// 记录操作日志
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="content">内容</param>
        /// <returns></returns>
        public static bool WriteLine(string ZHID, string content, string OperatePeople)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("记录时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            sb.AppendLine(content);
            sb.AppendLine("操作人：" + OperatePeople);

            //Log.Info(ZHID + "操作日志：", sb.ToString());
            return true;
        }



        public static bool CopyDir(DirectoryInfo fromDir, string toDir)
        {
            return CopyDir(fromDir, toDir, fromDir.FullName);
        }


        /// <summary>
        /// 复制目录
        /// </summary>
        /// <param name="fromDir">被复制的目录</param>
        /// <param name="toDir">复制到的目录</param>
        /// <returns></returns>
        public static bool CopyDir(string fromDir, string toDir)
        {
            if (fromDir == null || toDir == null)
            {
                throw new NullReferenceException("参数为空");
            }

            if (fromDir == toDir)
            {
                throw new Exception("两个目录都是" + fromDir);
            }

            if (!Directory.Exists(fromDir))
            {
                throw new IOException("目录fromDir=" + fromDir + "不存在");
            }

            DirectoryInfo dir = new DirectoryInfo(fromDir);
            return CopyDir(dir, toDir, dir.FullName);
        }


        /// <summary>
        /// 复制目录
        /// </summary>
        /// <param name="fromDir">被复制的目录</param>
        /// <param name="toDir">复制到的目录</param>
        /// <param name="rootDir">被复制的根目录</param>
        /// <returns></returns>
        private static bool CopyDir(DirectoryInfo fromDir, string toDir, string rootDir)
        {
            string filePath = string.Empty;
            foreach (FileInfo f in fromDir.GetFiles())
            {
                filePath = toDir + f.FullName.Substring(rootDir.Length);
                string newDir = filePath.Substring(0, filePath.LastIndexOf("//"));
                CreateDir(newDir);
                File.Copy(f.FullName, filePath, true);
            }

            foreach (DirectoryInfo dir in fromDir.GetDirectories())
            {
                CopyDir(dir, toDir, rootDir);
            }

            return true;
        }


        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="fileName">文件的完整路径</param>
        /// <returns></returns>
        public static bool DeleteFile(string fileName)
        {
            if (Exists(fileName))
            {
                File.Delete(fileName);
                return true;
            }
            return false;
        }


        public static void DeleteDir(DirectoryInfo dir)
        {
            if (dir == null)
            {
                throw new NullReferenceException("目录不存在");
            }

            foreach (DirectoryInfo d in dir.GetDirectories())
            {
                DeleteDir(d);
            }

            foreach (FileInfo f in dir.GetFiles())
            {
                DeleteFile(f.FullName);
            }

            dir.Delete();

        }

        /// <summary>
        /// 初始化租户的操作日志目录
        /// </summary>
        /// <param name="ZHID">租户编号</param>
        public static string InitDirectory(string ZHID)
        {
            string rootDirectory = HttpContext.Current.Server.MapPath("~/OperateLog");
            string myDirectory = rootDirectory + "\\" + ZHID;

            CreateDir(myDirectory);

            return myDirectory;
        }

        /// <summary>
        /// 删除目录
        /// </summary>
        /// <param name="dir">制定目录</param>
        /// <param name="onlyDir">是否只删除目录</param>
        /// <returns></returns>
        public static bool DeleteDir(string dir, bool onlyDir)
        {
            if (dir == null || dir.Trim() == "")
            {
                throw new NullReferenceException("目录dir=" + dir + "不存在");
            }

            if (!Directory.Exists(dir))
            {
                return false;
            }

            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            if (dirInfo.GetFiles().Length == 0 && dirInfo.GetDirectories().Length == 0)
            {
                Directory.Delete(dir);
                return true;
            }


            if (!onlyDir)
            {
                return false;
            }
            else
            {
                DeleteDir(dirInfo);
                return true;
            }

        }


        /// <summary>
        /// 在指定的目录中查找文件
        /// </summary>
        /// <param name="dir">目录</param>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        public static bool FindFile(string dir, string fileName)
        {
            if (dir == null || dir.Trim() == "" || fileName == null || fileName.Trim() == "" || !Directory.Exists(dir))
            {
                return false;
            }

            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            return FindFile(dirInfo, fileName);

        }


        public static bool FindFile(DirectoryInfo dir, string fileName)
        {
            foreach (DirectoryInfo d in dir.GetDirectories())
            {
                if (File.Exists(d.FullName + "//" + fileName))
                {
                    return true;
                }
                FindFile(d, fileName);
            }

            return false;
        }

        /// <summary>
        /// 将图片路径转换成二进制byte[]数据存储
        /// </summary>
        /// <param name="ImgPath"></param>
        /// <returns></returns>
        public static byte[] GetImgData(string ImgPath)
        {
            using (FileStream fs = new FileStream(ImgPath, FileMode.Open))
            {
                byte[] bydata = new byte[fs.Length];
                fs.Read(bydata, 0, bydata.Length);
                fs.Close();
                return bydata;
            }
        }

        /// <summary>
        /// 将Image转换成流数据，并保存为byte[]
        /// </summary>
        /// <param name="imgPhoto"></param>
        /// <returns></returns>
        public static byte[] PhotoImageInsert(Image imgPhoto)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imgPhoto.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                byte[] bydata = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(bydata, 0, bydata.Length);
                ms.Close();
                return bydata;
            }
        }

        /// <summary>
        /// 参数是Byte[]类型，返回值是Image对象
        /// </summary>
        /// <param name="streamByte"></param>
        /// <returns></returns>
        public static System.Drawing.Image ReturnPhoto(byte[] streamByte)
        {

            System.IO.MemoryStream ms = new System.IO.MemoryStream(streamByte);

            System.Drawing.Image img = System.Drawing.Image.FromStream(ms);

            return img;
        }

        /// <summary>
        /// 将二进制流输出显示为图片
        /// </summary>
        /// <param name="page"></param>
        /// <param name="streamByte"></param>
        public static void WritePhoto(Page page, byte[] streamByte)
        {
            // Response.ContentType 的默认值为默认值为“text/html”
            //图片输出的类型有: image/GIF image/JPEG
            page.Response.ContentType = "image/GIF";
            page.Response.BinaryWrite(streamByte);
        }

        /// <summary>
        /// 二进制流上传图片到指定位置
        /// </summary>
        /// <param name="fileSize">图片大小</param>
        /// <param name="picFile">图片文件夹名</param>
        public static string UploadPictureToFile(int fileSize, string picFile)
        {
            string imgPath = string.Empty;
            string imgName = string.Empty;
            string newName = string.Empty;
            HttpFileCollection FileCollect = System.Web.HttpContext.Current.Request.Files;
            if (FileCollect.Count > 0)
            {
                //Regex reg = new Regex(@"\.(jpg|jpeg|png|bmp)$");
                foreach (string str in FileCollect)
                {
                    HttpPostedFile fileSave = FileCollect[str];

                    byte[] bt = new byte[fileSave.ContentLength];
                    Stream s = fileSave.InputStream;
                    s.Read(bt, 0, bt.Length);
                    
                    if (string.IsNullOrEmpty(fileSave.FileName))
                    {
                        return "0"; //图片不存在
                    }
                    if (fileSave.ContentLength >= fileSize)
                    {
                        return "1"; //图片过大
                    }
                    string ext = null;
                    if (fileSave.ContentType.Contains("image/bmp"))
                    {
                        ext = ".bmp";
                    }
                    else if (fileSave.ContentType.Contains("image/png"))
                    {
                        ext = ".png";
                    }
                    else if (fileSave.ContentType.Contains("image/jpg"))
                    {
                        ext = ".jpg";
                    }
                    else if (fileSave.ContentType.Contains("image/jpeg"))
                    {
                        ext = ".jpeg";
                    }
                    else
                    {
                        return "2"; //格式错误
                    }

                    newName = Guid.NewGuid().ToString().Replace("-", "") + ext;
                    string url = ConfigurationManager.AppSettings["FilePath"];
                    //string dirPath = string.Format("zsy.zsglrj.cn/{0}/", picFile);
                    //UploadHelper.Upload(bt, url + "UploadHandler.ashx", newName, dirPath);
                    //imgName = url + dirPath + newName;
                    imgName = newName;

                    if (picFile == "userPic")
                    {
                        UploadHelper.Upload(bt, url + "UploadHandler.ashx", newName, "zsy.zsglrj.cn/Picture/");
                        imgName = "zsy.zsglrj.cn/Picture/" + newName;
                    }
                    else
                    {
                        UploadHelper.Upload(bt, url + "UploadHandler.ashx", newName, "zsy.zsglrj.cn/" + picFile + "/");
                        imgName = "zsy.zsglrj.cn/" + picFile + "/" + newName;
                    }
                }
            }
            return imgName;//返回图片名称
        }

        /// <summary>
        /// 二进制流上传图片到指定位置
        /// </summary>
        /// <param name="fileSize">图片大小</param>
        /// <param name="picFile">图片文件夹名</param>
        public static string UploadPictureToFile(int fileSize, string picFile,string Site)
        {
            string imgPath = string.Empty;
            string imgName = string.Empty;
            string newName = string.Empty;
            HttpFileCollection FileCollect = System.Web.HttpContext.Current.Request.Files;
            if (FileCollect.Count > 0)
            {
                //Regex reg = new Regex(@"\.(jpg|jpeg|png|bmp)$");
                foreach (string str in FileCollect)
                {
                    HttpPostedFile fileSave = FileCollect[str];

                    byte[] bt = new byte[fileSave.ContentLength];
                    Stream s = fileSave.InputStream;
                    s.Read(bt, 0, bt.Length);

                    if (string.IsNullOrEmpty(fileSave.FileName))
                    {
                        return "0"; //图片不存在
                    }
                    if (fileSave.ContentLength >= fileSize)
                    {
                        return "1"; //图片过大
                    }
                    string ext = null;
                    if (fileSave.ContentType.Contains("image/bmp"))
                    {
                        ext = ".bmp";
                    }
                    else if (fileSave.ContentType.Contains("image/png"))
                    {
                        ext = ".png";
                    }
                    else if (fileSave.ContentType.Contains("image/jpg"))
                    {
                        ext = ".jpg";
                    }
                    else if (fileSave.ContentType.Contains("image/jpeg"))
                    {
                        ext = ".jpeg";
                    }
                    else if (fileSave.ContentType.Contains("application/octet-stream"))
                    {
                        ext = ".png";
                    }
                    else
                    {
                        return "2"; //格式错误
                    }

                    newName = Guid.NewGuid().ToString().Replace("-", "") + ext;
                    string url = ConfigurationManager.AppSettings["FilePath"];
                    //string dirPath = string.Format("zsy.zsglrj.cn/{0}/", picFile);
                    //UploadHelper.Upload(bt, url + "UploadHandler.ashx", newName, dirPath);
                    //imgName = url + dirPath + newName;
                    imgName = newName;

                    if (picFile == "userPic")
                    {
                        UploadHelper.Upload(bt, url + "UploadHandler.ashx", newName, Site + "/" + "Picture/");
                        imgName = Site + "/" + picFile + "/" + newName;
                    }
                    else
                    {
                        UploadHelper.Upload(bt, url + "UploadHandler.ashx", newName, Site + "/" + picFile + "/");
                        imgName = Site + "/" + picFile + "/" + newName;
                    }
                }
            }
            return imgName;//返回图片名称
        }

        /// <summary>
        /// 二进制流上传图片到指定位置
        /// </summary>
        /// <param name="fileSize">图片大小</param>
        /// <param name="picFile">图片文件夹名</param>
        public static string UploadExcelToFile(HttpRequest request, int fileSize, string hz, string picFile)
        {
            string imgPath = string.Empty;
            string imgName = string.Empty;
            request = System.Web.HttpContext.Current.Request;
            HttpFileCollection FileCollect = request.Files;
            if (FileCollect.Count > 0)
            {
                foreach (string str in FileCollect)
                {
                    HttpPostedFile fileSave = FileCollect[str];

                    byte[] bt = new byte[fileSave.ContentLength];
                    Stream s = fileSave.InputStream;
                    s.Read(bt, 0, bt.Length);

                    imgName = fileSave.FileName + hz;
                    if (string.IsNullOrEmpty(imgName))
                    {
                        return "0"; //图片不存在
                    }
                    //string imgType = "png;gif;jpg;bmp;jpeg;";
                    //string type = imgName.Substring(imgName.LastIndexOf(".") + 1);

                    //if (!imgType.Contains(type))
                    //{
                    //    return "1"; //图片格式不正确
                    //}
                    if (fileSave.ContentLength >= fileSize)
                    {
                        return "1";//图片过大
                    }
                    string imgData = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString()
                  + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString()
                  + DateTime.Now.Second.ToString();
                    imgName = imgData + imgName;
                    if (picFile == "userPic")
                    {
                        imgPath = AppDomain.CurrentDomain.BaseDirectory + "Picture/" + imgName;
                        fileSave.SaveAs(imgPath);
                    }
                    else
                    {
                        UploadHelper.Upload(bt, ConfigurationManager.AppSettings["FilePath"] + "UploadHandler.ashx", imgName, "zsy.zsglrj.cn/" + picFile + "/");
                        imgName = "zsy.zsglrj.cn/" + picFile + "/" + imgName;
                    }
                }
            }
            return imgName;//返回图片名称
        }

        public static List<string> UploadExcelToFileReturnArray(HttpRequest request, int fileSize, string hz, string picFile)
        {
            try {
                string imgPath = string.Empty;
                string imgName = string.Empty;
                List<string> imgNameArray = new List<string>();
                request = System.Web.HttpContext.Current.Request;
                HttpFileCollection FileCollect = request.Files;
                if (FileCollect.Count > 0)
                {
                    for (int index = 0; index < FileCollect.Count; index++)
                    {
                        HttpPostedFile fileSave = FileCollect[index];

                        byte[] bt = new byte[fileSave.ContentLength];
                        Stream s = fileSave.InputStream;
                        s.Read(bt, 0, bt.Length);

                        imgName = fileSave.FileName + hz;
                        if (string.IsNullOrEmpty(imgName))
                        {
                            return null; //图片不存在
                        }
                        if (fileSave.ContentLength >= fileSize)
                        {
                            return null;//图片过大
                        }
                        string imgData = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString()
                      + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString()
                      + DateTime.Now.Second.ToString();
                        //图片宽高信息
                        string heigh = "";
                        string width = "";
                        if (imgName.IndexOf(".png") > 0 || imgName.IndexOf(".jpg") > 0 || imgName.IndexOf(".JPEG") > 0)
                        {
                            Image img = Image.FromStream(fileSave.InputStream);
                            heigh = img.Height.ToString();
                            width = img.Width.ToString();
                            imgName = imgName.Substring(0, imgName.IndexOf(".")) + "_" + width + "x" + heigh + imgName.Substring(imgName.IndexOf("."));
                        }
                        imgName = imgData + imgName;
                        if (picFile == "userPic")
                        {
                            imgPath = AppDomain.CurrentDomain.BaseDirectory + "Picture/" + imgName;                            
                            fileSave.SaveAs(imgPath);
                        }
                        else
                        {
                            UploadHelper.Upload(bt, ConfigurationManager.AppSettings["FilePath"] + "UploadHandler.ashx", imgName, "zsy.zsglrj.cn/" + picFile + "/");
                            imgName = "zsy.zsglrj.cn/" + picFile + "/" + imgName;
                        }                                                                        
                        imgNameArray.Add(imgName);
                    }
                }
                return imgNameArray;//返回图片名称
            } catch (Exception ex)
            {
                throw ex;
            }
        
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace SY.Com.Infrastructure
{
    /// <summary>
    /// ZIP文件解压处理类
    /// </summary>
    public class UnZipStream
    {
        public UnZipStream()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 解压
        /// <summary>
        /// 解压压缩文件
        /// </summary>
        /// <returns></returns>
        public bool UnZipFileToPath(string PackageFile, string extractFolder)
        {
            string[] FileProperty = new string[2];
            FileProperty[0] = PackageFile;
            FileProperty[1] = extractFolder;

            return UnZip(FileProperty);
        }

        /// <summary>
        /// 解压压缩文件,解压指定扩展名的文件
        /// </summary>
        /// <returns></returns>
        public bool UnZipFileToPath(string PackageFile, string extractFolder, string ExtName)
        {
            string[] FileProperty = new string[2];
            FileProperty[0] = PackageFile;
            FileProperty[1] = extractFolder;

            return UnZip(FileProperty, ExtName);
        }
        /// <summary>
        /// 解压压缩文件,解压指定扩展名的文件
        /// </summary>
        /// <returns></returns>
        public bool UnZipFileToPath(string PackageFile, string extractFolder, string ExtName, string FileName)
        {
            string[] FileProperty = new string[2];
            FileProperty[0] = PackageFile;
            FileProperty[1] = extractFolder;
            return UnZip(FileProperty, ExtName, FileName);
        }

        /// <summary>
        /// 解压文件
        /// </summary>
        /// <returns></returns>
        private bool UnZip(string[] args)
        {
            ZipInputStream s = new ZipInputStream(File.OpenRead(args[0]));
            try
            {

                ZipEntry theEntry;
                while ((theEntry = s.GetNextEntry()) != null)
                {
                    string directoryName = Path.GetDirectoryName(args[1]);
                    string fileName = Path.GetFileName(theEntry.Name);

                    //生成解压目录
                    if (Directory.Exists(directoryName) == false)
                        Directory.CreateDirectory(directoryName);

                    if (fileName != String.Empty)
                    {
                        //解压文件到指定的目录
                        FileStream streamWriter = File.Create(directoryName + "\\" + theEntry.Name);
                        byte[] data = new byte[2048];
                        while (true)
                        {
                            int size = s.Read(data, 0, data.Length);
                            if (size > 0)
                            {
                                streamWriter.Write(data, 0, size);
                            }
                            else
                            {
                                break;
                            }
                        }
                        streamWriter.Close();
                    }
                }
                s.Close();
                return true;
            }
            catch (Exception ex)
            {
                s.Close();
                //Response.Write(ex.Message );
                return false;
            }
        }

        /// <summary>
        /// 解压文件
        /// </summary>
        /// <param name="args"></param>
        /// <param name="ExtName"></param>
        /// <returns></returns>
        private bool UnZip(string[] args, string ExtName)
        {
            ZipInputStream s = new ZipInputStream(File.OpenRead(args[0]));
            try
            {
                string FileExt = ExtName.ToUpper();
                ZipEntry theEntry;
                while ((theEntry = s.GetNextEntry()) != null)
                {
                    string directoryName = Path.GetDirectoryName(args[1]);
                    string fileName = Path.GetFileName(theEntry.Name);
                    //判断压缩文件中的文件是否为指定的扩展名
                    int P = fileName.LastIndexOf(".");//
                    if (P < 1) //不是进行下一个
                        continue;
                    else
                    {
                        if (fileName.Substring(P + 1).ToUpper() != FileExt)
                            continue;
                    }

                    //生成解压目录
                    if (Directory.Exists(directoryName) == false)
                        Directory.CreateDirectory(directoryName);

                    if (fileName != String.Empty)
                    {
                        //解压文件到指定的目录
                        FileStream streamWriter = File.Create(directoryName + "\\" + theEntry.Name);
                        byte[] data = new byte[2048];
                        while (true)
                        {
                            int size = s.Read(data, 0, data.Length);
                            if (size > 0)
                            {
                                streamWriter.Write(data, 0, size);
                            }
                            else
                            {
                                break;
                            }
                        }
                        streamWriter.Close();
                    }
                }
                s.Close();
                return true;
            }
            catch (Exception ex)
            {
                s.Close();
                //Response.Write(ex.Message );
                return false;
            }
        }

        /// <summary>
        /// 解压文件
        /// </summary>
        /// <param name="args"></param>
        /// <param name="ExtName"></param>
        /// <returns></returns>
        private bool UnZip(string[] args, string ExtName, string FileName)
        {
            ZipInputStream s = new ZipInputStream(File.OpenRead(args[0]));
            try
            {
                string FileExt = ExtName.ToUpper();
                ZipEntry theEntry;
                while ((theEntry = s.GetNextEntry()) != null)
                {
                    string directoryName = Path.GetDirectoryName(args[1]);
                    string fileName = Path.GetFileName(theEntry.Name);
                    //判断压缩文件中的文件是否为指定的扩展名
                    int P = fileName.LastIndexOf(".");//
                    if (P < 1) //不是进行下一个
                        continue;
                    else
                    {
                        if (fileName.Substring(P + 1).ToUpper() != FileExt)
                            continue;
                    }

                    //生成解压目录
                    if (Directory.Exists(directoryName) == false)
                        Directory.CreateDirectory(directoryName);

                    if (fileName != String.Empty)
                    {
                        //解压文件到指定的目录
                        FileStream streamWriter = File.Create(directoryName + "\\" + FileName);
                        byte[] data = new byte[2048];
                        while (true)
                        {
                            int size = s.Read(data, 0, data.Length);
                            if (size > 0)
                            {
                                streamWriter.Write(data, 0, size);
                            }
                            else
                            {
                                break;
                            }
                        }
                        streamWriter.Close();
                    }
                }
                s.Close();
                return true;
            }
            catch (Exception ex)
            {
                s.Close();
                //Response.Write(ex.Message );
                return false;
            }
        }
        #endregion
    }
}

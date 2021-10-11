using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class FileGen
    {
        /// <summary>
        /// 生成文件的根路径
        /// </summary>
        public string Root { get; private set; }
        /// <summary>
        /// 文件夹目录路径
        /// </summary>
        private string DirPath { get; set; }
        /// <summary>
        /// 路径
        /// </summary>
        private string FilePath { get; set; }
        public FileGen()
        {
            //默认是CodeGenerator项目下
            string rootpath = System.Environment.CurrentDirectory;
            rootpath = rootpath.Substring(0, rootpath.IndexOf("CodeGenerator") + "CodeGenerator".Length);           
            Root = rootpath;
        }
        public FileGen(string root) :base()
        {            
            Root = Root;
        }

        public bool Gen(string dirpath, string filepath,string txt)
        {
            try {
                DirPath = Root + "\\" + dirpath;
                FilePath = DirPath + "\\" + filepath;
                if (!Directory.Exists(DirPath))
                {
                    Directory.CreateDirectory(DirPath);
                }
                if (File.Exists(FilePath))
                {
                    File.Delete(FilePath);
                }
                byte[] buffer = System.Text.Encoding.Default.GetBytes(txt);
                FileStream fs = File.Create(FilePath, buffer.Length);
                fs.Write(buffer, 0, buffer.Length);
                fs.Flush();
                fs.Close();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message + "生成代码错误");
            }
            return true;
        }

    }
}

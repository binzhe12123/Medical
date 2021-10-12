using SY.Com.Medical.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class RepositoryGen
    {
        public string EntityName { get; private set; }
        public string TableName { get; private set; }
        public string ClassName { get; private set; }
        public string TableKey { get; private set; }
        private string TextUsing { get; set; }
        private string TextNamespace { get; set; }
        private string TextClass { get; set; }
        private FileGen fg { get; set; }
        private string dbname { get; set; }
        private string Navigate { get; set; }
        private string OnSplit { get; set; }


        public RepositoryGen(GenParam param)
        {
            TableName = param.TableName;
            TableKey = param.TableKey;
            ClassName = TableName.Substring(TableName.Length - 1, 1) == "s"
    ? TableName.Substring(0, TableName.Length - 1) : TableName;//Table是复数命名,class单数形式    
            fg = new FileGen();
            dbname = param.dbname.ToString();
            Navigate = param.Navigate;
            if(!string.IsNullOrEmpty(param.Navigate) && string.IsNullOrEmpty(param.Navikey))
            {
                throw new Exception("有导航属性,必须也要有OnSplit");
            }
            OnSplit = param.Navikey;
            Navigate += "Entity";
        }



        public string Gen()
        {
            string result = "";

            return result;
        }

        /// <summary>
        /// Using
        /// </summary>
        private void GenUsing()
        {
            TextUsing = @"using Dapper;
using SY.Com.Medical.Attribute;
using SY.Com.Medical.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
";
        }

        /// <summary>
        /// NameSpace
        /// </summary>
        private void GenNameSpace()
        {
            TextNamespace = @"namespace SY.Com.Medical.Repository." + dbname + @"
{
    /// <summary>
    /// 数据访问层
    /// </summary>
    #Class#
} ";
        }

        private void GenClass()
        {          
            StringBuilder txt = new StringBuilder();
            txt.Append($"public class {ClassName}Repository : BaseRepository<{ClassName}Entity> ");
            txt.Append("\r\n\t{ ");
            txt.Append(txtGetNavigate());
            txt.Append(txtGenNavigateMany());
            txt.Append(txtGenNavigatePages());
            txt.Append("\r\n\t}");
            TextClass = txt.ToString();
        }

        /// <summary>
        /// 生成导航的get(int id)
        /// </summary>
        /// <returns></returns>
        private string txtGetNavigate()
        {
            if (string.IsNullOrEmpty(Navigate)) return "";
            StringBuilder txt = new StringBuilder();
            txt.Append("\r\n\t\t///<summary> ");
            txt.Append($"\r\n\t\t///获取有导航属性的单条记录");
            txt.Append("\r\n\t\t///<summary> ");
            txt.Append("\r\n\t\t///<param name=\"id\"></param>");
            txt.Append("\r\n\t\t/// <returns></returns>");
            txt.Append($"\r\n\t\tpublic {ClassName}Entity getOne(int id)");
            txt.Append("\r\n\t\t{");
            txt.Append($"\r\n\t\t\treturn Get<{Navigate}>(id,(main,sub)=>");            
            txt.Append("\r\n\t\t\t{");
            txt.Append($"\r\n\t\t\t\tmain.{Navigate.Replace("Entity","")} = sub;");
            txt.Append($"\r\n\t\t\t\treturn main;");
            txt.Append("\r\n\t\t\t},\"" + OnSplit + "\");");
            txt.Append("\r\n\t\t}");
            return txt.ToString();
        }

        /// <summary>
        /// 生成导航的getMany
        /// </summary>
        /// <returns></returns>
        private string txtGenNavigateMany()
        {
            if (string.IsNullOrEmpty(Navigate)) return "";
            StringBuilder txt = new StringBuilder();
            txt.Append("\r\n\t\t///<summary> ");
            txt.Append($"\r\n\t\t///获取有导航属性的多条记录");
            txt.Append("\r\n\t\t///<summary> ");
            txt.Append("\r\n\t\t///<param name=\"entity\"></param>");
            txt.Append("\r\n\t\t/// <returns></returns>");
            txt.Append($"\r\n\t\tpublic IEnumerable<{ClassName}Entity> getMany({ClassName}Entity entity)");
            txt.Append("\r\n\t\t{");
            txt.Append($"\r\n\t\t\treturn Gets<{Navigate}>(entity,(main,sub)=>");
            txt.Append("\r\n\t\t\t{");
            txt.Append($"\r\n\t\t\t\tmain.{Navigate.Replace("Entity", "")} = sub;");
            txt.Append($"\r\n\t\t\t\treturn main;");
            txt.Append("\r\n\t\t\t},\"" + OnSplit + "\");");
            txt.Append("\r\n\t\t}");
            return txt.ToString();
        }

        /// <summary>
        /// 生成导航的getPages
        /// </summary>
        /// <returns></returns>
        private string txtGenNavigatePages()
        {
            if (string.IsNullOrEmpty(Navigate)) return "";
            StringBuilder txt = new StringBuilder();
            txt.Append("\r\n\t\t///<summary> ");
            txt.Append($"\r\n\t\t///获取有导航属性的多条记录 - 分页");
            txt.Append("\r\n\t\t///<summary> ");
            txt.Append("\r\n\t\t///<param name=\"entity\"></param>");
            txt.Append("\r\n\t\t///<param name=\"pageSize\"></param>");
            txt.Append("\r\n\t\t///<param name=\"pageIndex\"></param>");
            txt.Append("\r\n\t\t/// <returns></returns>");
            txt.Append($"\r\n\t\tpublic Tuple<IEnumerable<{ClassName}Entity>,int> getPages({ClassName}Entity entity,int pageSize,int pageIndex)");
            txt.Append("\r\n\t\t{");
            txt.Append($"\r\n\t\t\tvar datas = GetsPage<{Navigate}>(entity,(main,sub)=>");
            txt.Append("\r\n\t\t\t{");
            txt.Append($"\r\n\t\t\t\tmain.{Navigate.Replace("Entity", "")} = sub;");
            txt.Append($"\r\n\t\t\t\treturn main;");
            txt.Append("\r\n\t\t\t},pageSize, pageIndex, \"" + OnSplit + "\");");
            txt.Append($"\r\n\t\t\tTuple<IEnumerable<{ClassName}Entity>, int> result = new Tuple<IEnumerable<{ClassName}Entity>, int>(datas.Item1, datas.Item2);");
            txt.Append("\r\n\t\t\treturn result;");
            txt.Append("\r\n\t\t}");
            return txt.ToString();
        }

        /// <summary>
        /// 获取文本
        /// </summary>
        /// <returns></returns>
        public string getCode()
        {
            GenUsing();
            GenNameSpace();
            GenClass();
            return TextUsing + TextNamespace.Replace("#Class#", TextClass);
        }

        public void GenFile()
        {
            fg.Gen("GenRepository", $"{ClassName}Repository.cs", getCode());
        }
    }
}

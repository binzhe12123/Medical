﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class BllGen
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


        public BllGen(GenParam param)
        {
            TableName = param.TableName;
            TableKey = param.TableKey;
            ClassName = TableName.Substring(TableName.Length - 1, 1) == "s"
    ? TableName.Substring(0, TableName.Length - 1) : TableName;//Table是复数命名,class单数形式    
            fg = new FileGen();
            dbname = param.dbname.ToString();
            Navigate = param.Navigate;
            if (!string.IsNullOrEmpty(param.Navigate) && string.IsNullOrEmpty(param.Navikey))
            {
                throw new Exception("有导航属性,必须也要有OnSplit");
            }
            OnSplit = param.Navikey;
            if(!string.IsNullOrEmpty(param.Navigate))
            {
                Navigate += "Model";
            }            
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
            TextUsing = @"using SY.Com.Medical.BLL."+ dbname + @";
using SY.Com.Medical.Entity;
using SY.Com.Medical.Extension;
using SY.Com.Medical.Model;
using SY.Com.Medical.Repository."+ dbname +@";
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
            TextNamespace = @"namespace SY.Com.Medical.BLL." + dbname + @"
{
    /// <summary>
    /// 业务逻辑层
    /// </summary>
    #Class#
} ";
        }

        private void GenClass()
        {
            StringBuilder txt = new StringBuilder();
            txt.Append($"public class {ClassName} ");
            txt.Append("\r\n\t{");
            txt.Append($"\r\n\t\tprivate {ClassName}Repository db;");
            txt.Append($"\r\n\t\tpublic {ClassName}()");
            txt.Append("\r\n\t\t{");
            txt.Append($"\r\n\t\t\tdb = new {ClassName}Repository();");
            txt.Append("\r\n\t\t}");

            txt.Append(txtGet());
            txt.Append(txtGets());
            txt.Append(txtGetNavigate());
            txt.Append(txtGenNavigateMany());
            txt.Append(txtGenAdd());
            txt.Append(txtGenUpdate());
            txt.Append(txtGenDelete());
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
            txt.Append("\r\n\t\t///</summary> ");
            txt.Append("\r\n\t\t///<param name=\"id\"></param>");
            txt.Append("\r\n\t\t/// <returns></returns>");
            txt.Append($"\r\n\t\tpublic {ClassName}Model getOne(int id)");
            txt.Append("\r\n\t\t{");
            txt.Append($"\r\n\t\t\treturn db.getOne(id).EntityToDto<{ClassName}Model>();");
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
            txt.Append($"\r\n\t\t///获取有导航属性的多条记录-分页");
            txt.Append("\r\n\t\t///</summary> ");
            txt.Append("\r\n\t\t///<param name=\"request\"></param>");
            txt.Append("\r\n\t\t/// <returns></returns>");
            txt.Append($"\r\n\t\tpublic Tuple<IEnumerable<{ClassName}Model>,int> getMany({ClassName}Request request)");
            txt.Append("\r\n\t\t{");
            txt.Append($"\r\n\t\t\tvar datas  = db.getPages(request.DtoToEntity<{ClassName}Entity>(), request.pageSize, request.pageIndex);");            
            txt.Append($"\r\n\t\t\tTuple<IEnumerable<{ClassName}Model>, int> result = new(datas.Item1.EntityToDto<{ClassName}Model>(), datas.Item2);");
            txt.Append($"\r\n\t\t\treturn result;");
            txt.Append("\r\n\t\t}");
            return txt.ToString();
        }

        /// <summary>
        /// 非导航详情查询
        /// </summary>
        /// <returns></returns>
        private string txtGet()
        {
            if (!string.IsNullOrEmpty(Navigate)) return "";
            StringBuilder txt = new StringBuilder();
            txt.Append("\r\n\t\t///<summary> ");
            txt.Append($"\r\n\t\t///获取详情记录");
            txt.Append("\r\n\t\t///</summary> ");
            txt.Append("\r\n\t\t///<param name=\"id\"></param>");
            txt.Append("\r\n\t\t/// <returns></returns>");
            txt.Append($"\r\n\t\tpublic {ClassName}Model get(int id)");
            txt.Append("\r\n\t\t{");
            txt.Append($"\r\n\t\t\treturn db.Get(id).EntityToDto<{ClassName}Model>();");
            txt.Append("\r\n\t\t}");
            return txt.ToString();
        }

        private string txtGets()
        {
            if (!string.IsNullOrEmpty(Navigate)) return "";
            StringBuilder txt = new StringBuilder();
            txt.Append("\r\n\t\t///<summary> ");
            txt.Append($"\r\n\t\t///获取列表-分页");
            txt.Append("\r\n\t\t///</summary> ");
            txt.Append("\r\n\t\t///<param name=\"request\"></param>");
            txt.Append("\r\n\t\t/// <returns></returns>");
            txt.Append($"\r\n\t\tpublic Tuple<IEnumerable<{ClassName}Model>,int> gets({ClassName}Request request)");
            txt.Append("\r\n\t\t{");
            txt.Append($"\r\n\t\t\tvar datas  = db.GetsPage(request.DtoToEntity<{ClassName}Entity>(), request.PageSize, request.PageIndex);");
            txt.Append($"\r\n\t\t\tTuple<IEnumerable<{ClassName}Model>, int> result = new(datas.Item1.EntityToDto<{ClassName}Model>(), datas.Item2);");
            txt.Append($"\r\n\t\t\treturn result;");
            txt.Append("\r\n\t\t}");
            return txt.ToString();
        }

        /// <summary>
        /// 生成add
        /// </summary>
        /// <returns></returns>
        private string txtGenAdd()
        {            
            StringBuilder txt = new StringBuilder();
            txt.Append("\r\n\t\t///<summary> ");
            txt.Append($"\r\n\t\t///新增");
            txt.Append("\r\n\t\t///</summary> ");
            txt.Append("\r\n\t\t///<param name=\"request\"></param>");
            txt.Append("\r\n\t\t/// <returns></returns>");
            txt.Append($"\r\n\t\tpublic int add({ClassName}Add request)");
            txt.Append("\r\n\t\t{");
            txt.Append($"\r\n\t\t\treturn db.Create(request.DtoToEntity<{ClassName}Entity>());");
            txt.Append("\r\n\t\t}");
            return txt.ToString();
        }

        /// <summary>
        /// 生成update
        /// </summary>
        /// <returns></returns>
        private string txtGenUpdate()
        {
            StringBuilder txt = new StringBuilder();
            txt.Append("\r\n\t\t///<summary> ");
            txt.Append($"\r\n\t\t///修改");
            txt.Append("\r\n\t\t///</summary> ");
            txt.Append("\r\n\t\t///<param name=\"request\"></param>");
            txt.Append("\r\n\t\t/// <returns></returns>");
            txt.Append($"\r\n\t\tpublic void update({ClassName}Update request)");
            txt.Append("\r\n\t\t{");
            txt.Append($"\r\n\t\t\tdb.Update(request.DtoToEntity<{ClassName}Entity>());");
            txt.Append("\r\n\t\t}");
            return txt.ToString();
        }

        /// <summary>
        /// 生成add/update/delete
        /// </summary>
        /// <returns></returns>
        private string txtGenDelete()
        {            
            StringBuilder txt = new StringBuilder();
            txt.Append("\r\n\t\t///<summary> ");
            txt.Append($"\r\n\t\t///删除");
            txt.Append("\r\n\t\t///</summary> ");
            txt.Append("\r\n\t\t///<param name=\"request\"></param>");
            txt.Append("\r\n\t\t/// <returns></returns>");
            txt.Append($"\r\n\t\tpublic void delete({ClassName}Delete request)");
            txt.Append("\r\n\t\t{");
            txt.Append($"\r\n\t\t\tdb.Delete(request.DtoToEntity<{ClassName}Entity>());");
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
            fg.Gen("GenBll", $"{ClassName}.cs", getCode());
        }
    }

}

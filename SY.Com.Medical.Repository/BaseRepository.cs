using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using SY.Com.Medical.Attribute;
using SY.Com.Medical.Entity;
using SY.Com.Medical.Infrastructure;

namespace SY.Com.Medical.Repository
{
    /// <summary>
    /// 数据层基类
    /// </summary>
    public class BaseRepository<T> where T : BaseEntity
    {
        public static object obj = new object();
        protected IDbConnection _db;
        private string strconnection;
        protected IConfiguration Configuration;

        /// <summary>
        /// 根据业务层反射类获取数据库连接
        /// 反射不到就直接抛出异常
        /// </summary>
        protected BaseRepository()
        {
             Configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true })
            .Build();            
            Type t = this.GetType();
            if(t.Namespace == "SY.Com.Medical.BLL.Clinic")
            {
                strconnection = Configuration.GetSection("Medical_Clinic").Value;
                _db = new SqlConnection(strconnection);
            }else if(t.Namespace == "SY.Com.Medical.BLL.Platform")
            {
                strconnection = Configuration.GetSection("Medical_Platform").Value;
                _db = new SqlConnection(strconnection);
            }
            else
            {
                throw new DllNotFoundException("无法找到数据库");
            }
        }

        /// <summary>
        /// 单表单记录查询
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        protected T Get(int Id)
        {
            Type t = typeof(T);
            string tableName = ReadAttribute<DB_TableAttribute>.getString(t);
            string tablekey = ReadAttribute<DB_KeyAttribute>.getString(t);
            if (tableName == "")
            {
                tableName = t.Name.Replace("Entity", "");
            }
            string sql = $" Select * From {tableName} Where {tablekey} = @Id ";
            return _db.QueryFirst<T>(sql, new object[] { Id });
        }

        /// <summary>
        /// 新增单条记录,并返回新增记录唯一id
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        protected int Create(T t)
        {
            int ireturn = 0;
            string tableName = ReadAttribute<DB_TableAttribute>.getString(t);//获取表名
            string tablekey = ReadAttribute<DB_KeyAttribute>.getString(t);
            List<string> columns = new List<string>();
            List<string> param = new List<string>();
            string entityPrimkey = "";
            string entityPrimvalue = "";
            if (tableName == "")
            {
                tableName = t.GetType().Name.Replace("Entity", "");//如果反射没获取到用实体名称去掉Entity试试
            }
            ireturn = getID(tableName);
            PropertyInfo[] properties = t.GetType().GetProperties();
            foreach(PropertyInfo prop in properties)
            {
                //主键可能字段属性名称和Attribute不一致
                if (prop.IsDefined(typeof(DB_KeyAttribute), false))
                {
                    columns.Add(tablekey);
                    param.Add($"@{tablekey}");
                    prop.SetValue(t, ireturn);
                }
                else {
                    columns.Add(prop.Name);
                    param.Add($"@{prop.Name}");
                }
            }
            string strcolum = string.Join(',', columns);
            string strparam = string.Join(',', param);
            string sql = $" Insert Into {tableName}({strcolum}) Values({strparam}) ";
            _db.Execute(sql, t);
            return ireturn;
        }

        /// <summary>
        /// 修改单条记录
        /// 主键为条件
        /// 值类型默认值,则不更新.引用类型空不更新
        /// </summary>
        /// <param name="t"></param>
        protected void Update(T t)
        {            
            string tableName = ReadAttribute<DB_TableAttribute>.getString(t);//获取表名
            string tablekey = ReadAttribute<DB_KeyAttribute>.getString(t);
            string entityPrimkey = "";
            string entityPrimvalue = "";
            List<string> updateColumns = new List<string>();
            if (tableName == "")
            {
                tableName = t.GetType().Name.Replace("Entity", "");//如果反射没获取到用实体名称去掉Entity试试
            }
            PropertyInfo[] properties = t.GetType().GetProperties();
            foreach (PropertyInfo prop in properties)
            {
                if (prop.IsDefined(typeof(DB_KeyAttribute), false))
                {
                    entityPrimkey = prop.Name;
                    entityPrimvalue = prop.GetValue(t).ToString();
                }
                else if(!DefaultValue.IsDefaultValue(prop.PropertyType, prop.GetValue(t)))
                {
                    updateColumns.Add($"{prop.Name}=@{prop.Name}");
                }
            }
            string strcolum = string.Join(',', updateColumns);
            string sql = $" Update {tableName} Set {strcolum} Where {tablekey}=@{entityPrimkey} ";
            _db.Execute(sql, t);
        }


        /// <summary>
        /// 获取全局
        /// </summary>
        /// <param name="name"></param>
        /// <param name="step"></param>
        /// <returns></returns>
        protected int getID(string name,int step = 1)
        {
            string sql = @" 
                            Update IDGlobal Set ID = ID + @step Where Name = @Name ;
                            Select ID From IDGlobal Where Name = @Name; ";
            lock (obj)
            {
                return _db.QueryFirst<int>(sql, new { Name = name, step = step });
            }
        }

        /// <summary>
        /// 获取全局租户编号
        /// </summary>
        /// <param name="TenantId"></param>
        /// <param name="name"></param>
        /// <param name="step"></param>
        /// <returns></returns>
        protected long getBH(int TenantId,string name, int step = 1)
        {
            string sql = @" 
                            Update BHGlobal Set BH = BH + @step Where TenantId=@TenantId And Name = @Name ;
                            Select BH From BHGlobal Where ClinicId=@ClinicId And Name = @Name;  ";
            lock (obj)
            {
                return _db.QueryFirst<long>(sql, new { TenantId= TenantId, Name = name, step = step });
            }
        }

    }
}

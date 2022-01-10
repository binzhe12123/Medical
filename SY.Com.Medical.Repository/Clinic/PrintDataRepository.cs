using SY.Com.Medical.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Repository.Clinic
{
    /// <summary>
    /// 打印数据仓库类
    /// </summary>
    public class PrintDataRepository
    {
        public static object obj = new object();
        protected IDbConnection _db;
        protected IDbConnection _dbid;
        private string strconnection;

        /// <summary>
        /// 根据业务层反射类获取数据库连接
        /// 反射不到就直接抛出异常
        /// </summary>
        protected PrintDataRepository()
        {
            Type t = this.GetType();
            if (t.Namespace == "SY.Com.Medical.Repository.Clinic")
            {
                strconnection = ReadConfig.GetConfigSection("Medical_Clinic");
            }
            else if (t.Namespace == "SY.Com.Medical.Repository.Platform")
            {
                strconnection = ReadConfig.GetConfigSection("Medical_Platform");
            }
            else
            {
                throw new DllNotFoundException("无法找到数据库");
            }
            _db = new SqlConnection(strconnection);
            _dbid = new SqlConnection(ReadConfig.GetConfigSection("Medical_Platform"));
        }


        //制定数据库
        public PrintDataRepository(string strconnection)
        {
            _db = new SqlConnection(strconnection);
            _dbid = new SqlConnection(ReadConfig.GetConfigSection("Medical_Platform"));
        }



    }
}

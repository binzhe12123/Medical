using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Clinic.Repository
{
    /// <summary>
    /// 用来返回需要的sqlconnection,dapper的时候使用
    /// </summary>
    public class IDbConnection
    {
        //private static IDbConnection _idbconnection;
        private DbConnection _dbconnection;
        //private static object obj = new object();
        public IDbConnection(string connection)
        {
            _dbconnection = new SqlConnection(connection);
        }

        public DbConnection getConnection()
        {
            return _dbconnection;
        }

        //public IDbConnection getInstance()
        //{
        //    if(_idbconnection == null)
        //    {
        //        lock (obj)
        //        {
        //            if (_idbconnection == null)
        //            {
        //                _idbconnection = new IDbConnection();
        //            }
        //        }
        //    }
        //    return _idbconnection;
        //}

    }
}

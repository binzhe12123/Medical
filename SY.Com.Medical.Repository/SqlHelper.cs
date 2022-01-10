using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Repository
{
    public static class SqlHelper
    {
        /// <summary>
        /// 返回受影响的行数 用于执行Sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static int ExecNonQuery(string connStr, string sql, SqlParameter[] parameter)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = sql;
                    if (parameter != null)
                    {
                        cmd.Parameters.AddRange(parameter);
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// 返回结果集DataSet
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static DataSet ExecDataSet(string connStr, string sql, SqlParameter[] parameter)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    if (parameter != null)
                    {
                        cmd.Parameters.AddRange(parameter);
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    return ds;
                }
            }
        }
        /// <summary>
        /// 返回表
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static DataTable ExecDataTable(string connStr, string sql, SqlParameter[] parameter)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    if (parameter != null)
                    {
                        cmd.Parameters.AddRange(parameter);
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    return ds.Tables[0];
                }
            }
        }
        /// <summary>
        /// 执行存储过程，返回影响的行数             
        /// </summary>
        /// <param name="storedProcName"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static int RunProcedure(string connStr, string storedProcName, SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    //设置命令类型为存储过程
                    cmd.CommandType = CommandType.StoredProcedure;
                    //设置存储过程名称
                    cmd.CommandText = storedProcName;
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    //执行存储过程
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// 返回首行首列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string connStr, string sql, SqlParameter[] parameter)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    if (parameter != null)
                    {
                        cmd.Parameters.AddRange(parameter);
                    }
                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}

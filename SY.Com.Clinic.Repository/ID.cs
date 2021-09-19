using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Clinic.Repository
{
    public class IDBH
    {
        private static object obj = new object();
        /// <summary>
        /// 获取全局的最大id
        /// </summary>
        /// <param name="name"></param>
        /// <param name="step"></param>
        public static int getID(string name,int step = 1)
        {            
            DataSet ds;
            string sql = @" 
                            Update IDGlobal Set ID = ID + @step Where Name = @Name ;
                            Select ID From IDGlobal Where Name = @Name; ";            
            SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@Name",SqlDbType.NVarChar){ Value = name},
                    new SqlParameter("@step",SqlDbType.Int){ Value = step}
                };
            lock (obj)
            {
                ds = DbHelperSQL.Query(0,sql, param);
            }
            if(ds != null && ds.Tables != null &&ds.Tables[0].Rows.Count >0)
            {
                return int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
            }
            else
            {
                throw new Exception("无法获取全局ID");
            }
        }

        /// <summary>
        /// 获取全局的最大BH
        /// </summary>
        /// <param name="name"></param>
        /// <param name="step"></param>
        public static long getBH(string name,int ClinicID, int step = 1)
        {
            DataSet ds;
            string sql = @" 
                            Update BHGlobal Set Bh = Bh + @step Where ClinicId=@ClinicId And Name = @Name ;
                            Select BH From BHGlobal Where ClinicId=@ClinicId And Name = @Name; ";
            SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@Name",SqlDbType.NVarChar){ Value = name},
                    new SqlParameter("@ClinicId",SqlDbType.Int){ Value = ClinicID},
                    new SqlParameter("@step",SqlDbType.Int){ Value = step}
                };
            lock (obj)
            {
                ds = DbHelperSQL.Query(0, sql, param);
            }
            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
            {
                return long.Parse(ds.Tables[0].Rows[0]["BH"].ToString());
            }
            else
            {
                throw new Exception("无法获取机构编号");
            }

        }

    }
    
    enum IDName
    {
        User,
        Clinic,
        Employee,
        Department,
    }
}

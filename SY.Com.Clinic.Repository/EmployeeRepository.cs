using Dapper;
using SY.Com.Clinic.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Clinic.Repository
{
    public class EmployeeRepository : RepositoryBase2
    {
        //获取诊所里面的员工
        public List<EmployeeModel> getEmplyees(int clinicid)
        {
            string sql = " Select * From Employee Where ClinicID=@ClinicID And IsDelete=0 ";
            SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@ClinicID",SqlDbType.Int){ Value = clinicid}
                };
            return DbHelperSQL.QueryList<EmployeeModel>(clinicid, sql, param);
        }

        //修改员工信息
        public bool updateEmplyee(EmployeeModel mod)
        {
            string sql = @" Update Employee
                            Set RoleKeys = @RoleKeys,Name=@Name,Sex=@Sex,Phone=@Phone,
                            BirthDay=@BirthDay,SFZH=@SFZH,YBCode=@YBCode,Imagepath=@Imagepath
                            Where ClinicID=@ClinicID And UserId=@UserId";
            _dbClinic.getConnection().Execute(sql, mod);
            return true;
        }

        /// <summary>
        /// 获取单个员工信息
        /// </summary>
        /// <param name="ClinicID"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public EmployeeModel getEmplyee(int ClinicID,int UserId)
        {
            string sql = " Select * From Employee Where ClinicID=@ClinicID And UserId=@UserId And IsDelete=0 ";
            SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@ClinicID",SqlDbType.Int){ Value = ClinicID},
                    new SqlParameter("@UserId",SqlDbType.Int){ Value = UserId}
                };
            return DbHelperSQL.Query<EmployeeModel>(ClinicID, sql, param);
        }


    }
}

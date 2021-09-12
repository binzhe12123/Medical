using SY.Com.Clinic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;


namespace SY.Com.Clinic.Repository
{
    public class UserRepository :RepositoryBase2
    {
        //登录
        public UserModel Login(UserModel mod )
        {
            //通过账号密码获取实体,如果不存在实体为空
            using (var con = _dbMedical.getConnection())
            {
                string sql = " Select * From User Where UserName = @UserName ";
            }

            return mod;
        }

        //

        //
        
    }
}

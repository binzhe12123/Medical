using SY.Com.Clinic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using SY.Com.Infrastructure;

namespace SY.Com.Clinic.Repository
{
    public class UserRepository :RepositoryBase2
    {
        //登录
        public UserModel Login(UserModel mod)
        {
            //通过账号密码获取实体,如果不存在实体为空
            using (var con = _dbMedical.getConnection())
            {
                string sql = " Select * From User Where UserName = @UserName And IsDelete = 0 ";
                SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@UserName",SqlDbType.NVarChar){ Value = mod.UserName}                    
                };
                return DbHelperSQL.Query<UserModel>(0, sql, param);
            }
        }

        //注册
        public int Register(UserModel mod)
        {
            string sql = " Insert Into User(ID,Name,Phone,UserName,[Password],Sex,VirifyCode) Values(@ID,@Name,@Phone,@UserName,@Password,@Sex,@VirifyCode) ";
            int id = IDBH.getID(IDName.User.ToString());
            SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.Int){ Value = id},
                    new SqlParameter("@Name",SqlDbType.NVarChar){ Value = mod.Name},
                    new SqlParameter("@UserName",SqlDbType.NVarChar){ Value = mod.UserName},
                    new SqlParameter("@Password",SqlDbType.NVarChar){ Value = mod.Password},
                    new SqlParameter("@Phone",SqlDbType.NVarChar){ Value = mod.Phone},
                    new SqlParameter("@VirifyCode",SqlDbType.NVarChar){ Value = mod.VirifyCode},
                    new SqlParameter("@Sex",SqlDbType.Int){ Value = mod.Sex}
                };
            DbHelperSQL.ExecuteSql(0, sql, param);
            return id;            
        }

        #region 重置密码
        public bool Reset(UserModel mod)
        {
            string sql = " Update User Set [PassWord] = @Password Where ID = @ID ";
            SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.Int){ Value = mod.Id},
                    new SqlParameter("@Password",SqlDbType.NVarChar){ Value = mod.Password}                    
                };
            int result = DbHelperSQL.ExecuteSql(0, sql, param);
            return true;
        }

        public UserModel QueryReset(UserModel mod)
        {
            string sql = " Select * From User Where UserName = @UserName And VirifyCode = @VirifyCode And IsDelete = 0 ";
            SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.Int){ Value = mod.Id},
                    new SqlParameter("@UserName",SqlDbType.NVarChar){ Value = mod.UserName},
                    new SqlParameter("@VirifyCode",SqlDbType.NVarChar){ Value = mod.VirifyCode}
                };
            return DbHelperSQL.Query<UserModel>(0, sql, param);
        }

        #endregion

        //修改信息
        public bool Update(UserModel mod)
        {
            string sql = @" Update User 
                            Set Name=@Name,Phone=@Phone,Sex=@Sex,BirthDay=@BirthDay,SFZH=@SFZH
                            Where ID = @ID ";
            SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.Int){ Value = mod.Id},
                    new SqlParameter("@Name",SqlDbType.NVarChar){ Value = mod.Name},
                    new SqlParameter("@Phone",SqlDbType.NVarChar){ Value = mod.Phone},
                    new SqlParameter("@BirthDay",SqlDbType.NVarChar){ Value = mod.BirthDay},
                    new SqlParameter("@BirtSFZHhDay",SqlDbType.NVarChar){ Value = mod.SFZH},
                    new SqlParameter("@Sex",SqlDbType.Int){ Value = mod.Sex}
                };
            int result = DbHelperSQL.ExecuteSql(0, sql, param);
            return true;
        }

        //禁用启用
        public bool Disable(UserModel mod)
        {
            string sql = @" Update User 
                            Set [State]=@State
                            Where ID = @ID ";
            SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.Int){ Value = mod.Id},
                    new SqlParameter("@State",SqlDbType.Int){ Value = mod.State}
                };
            int result = DbHelperSQL.ExecuteSql(0, sql, param);
            return true;
        }

        //删除恢复
        public bool Delete(UserModel mod)
        {
            string sql = @" Update User 
                            Set [IsDelete]=@IsDelete
                            Where ID = @ID ";
            SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.Int){ Value = mod.Id},
                    new SqlParameter("@IsDelete",SqlDbType.Int){ Value = mod.IsDelete}
                };
            int result = DbHelperSQL.ExecuteSql(0, sql, param);
            return true;
        }

        //获取单个用户信息
        public UserModel Get(int id)
        {
            string sql = " Select * From User Where ID = @ID And IsDelete = 0 ";
            SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.Int){ Value = id}                    
                };
            DataSet ds = DbHelperSQL.Query(0, sql, param);
            if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count < 1)
            {
                return null;
            }
            else
            {
                return ListHelper.DataTableToSingleFiled<UserModel>(ds.Tables[0]);
            }
        }

        //获取诊所用户信息
        public UserModel GetByClinic(int ClinicId)
        {
            string sql = @" Select a.* From User as a
                            Inner Join UserClinic as b on a.ID = b.UserID
                            Where b.ClinicID = @ClinicID And a.IsDelete = 0 And b.IsDelete = 0 ";
            SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@ClinicID",SqlDbType.Int){ Value = ClinicId}
                };
            DataSet ds = DbHelperSQL.Query(0, sql, param);
            if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count < 1)
            {
                return null;
            }
            else
            {
                return ListHelper.DataTableToSingleFiled<UserModel>(ds.Tables[0]);
            }
        }




    }
}

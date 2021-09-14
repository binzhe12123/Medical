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
    public class ClinicRepository: RepositoryBase2
    {
        /// <summary>
        /// 创建诊所
        /// 创建诊所员工列表
        /// 添加诊所信息
        /// 加入员工
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
         public ClinicModel Create(ClinicModel mod)
        {
            ClinicModel result;
            string sql = @" Insert Into Clinic(Id,Name,Category,Imagepath,ServiceStart,ServiceEnd,Boss,Phone)
                            Values(@Id,@Name,@Category,@Imagepath,@ServiceStart,@ServiceEnd,@Boss,@Phone) ";
            int id = IDBH.getID(IDName.Clinic.ToString());
            SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.Int){ Value = id},
                    new SqlParameter("@Name",SqlDbType.NVarChar){ Value = mod.Name},
                    new SqlParameter("@Category",SqlDbType.NVarChar){ Value = mod.Category},
                    new SqlParameter("@Imagepath",SqlDbType.NVarChar){ Value = mod.Imagepath},
                    new SqlParameter("@ServiceStart",SqlDbType.DateTime){ Value = mod.ServiceStart},
                    new SqlParameter("@ServiceEnd",SqlDbType.DateTime){ Value = mod.ServiceEnd},
                    new SqlParameter("@Boss",SqlDbType.Int){ Value = mod.Boss},
                    new SqlParameter("@Phone",SqlDbType.NVarChar){ Value = mod.Phone}
            };
            string sql2 = " Insert Into UserClinic(ClinicID,UserID,Boss) Values(@ID,@Boss,1) ";
            DbHelperSQL.ExecuteSql(0, sql +sql2, param);
            result = Get(id);
            if(result != null)
            {
                string sql3 = @" Insert Into CliniInfo(ClinicID,YBCode,YBLocalApi) 
                                 Values(@ClinicID,'','')";
                string sql4 = @" Insert Into Employee(ID,BH,ClinicID,UserId,RoleKeys,Name,Sex,Phone)
                                 Values(@ID,@BH,@ClinicID,@UserId,@RoleKeys,@Name,@Sex,@Phone)";
                SqlParameter[] param2 = new SqlParameter[]{
                    new SqlParameter("@ClinicID",SqlDbType.Int){ Value = id},
                    new SqlParameter("@ID",SqlDbType.Int){ Value = IDBH.getID(IDName.Employee.ToString())},
                    new SqlParameter("@BH",SqlDbType.BigInt){ Value = IDBH.getBH(IDName.Employee.ToString(),id) },
                    new SqlParameter("@UserId",SqlDbType.Int){ Value = mod.Boss},
                    new SqlParameter("@RoleKeys",SqlDbType.NVarChar){ Value = "管理员,医生"},
                    new SqlParameter("@Name",SqlDbType.NVarChar){ Value = mod.Name},
                    new SqlParameter("@Sex",SqlDbType.Int){ Value = 1},
                    new SqlParameter("@Phone",SqlDbType.NVarChar){Value = mod.Phone}
                };
                DbHelperSQL.ExecuteSql(id, sql3 + sql4, param2);

            }
            return result;
        }

        //查询单个诊所通过id
        public ClinicModel Get(int id)
        {
            string sql = " Select * From Clinic Where Id = @ID ";
            SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.Int){ Value = id}
            };
            return DbHelperSQL.Query<ClinicModel>(0, sql, param);
        }

        /// <summary>
        /// 邀请用户加入诊所
        /// 还不是用户的帮他自动注册成为用户
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Invite(UserModel user,string roles,int ClinicID)
        {            
            string sql = " Select * From [User] Where UserName = @UserName  ";
            SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@UserName",SqlDbType.Int){ Value = user.UserName}
            };
            var nowuser = DbHelperSQL.Query<UserModel>(0, sql, param);
            if(nowuser == null)
            {
                //没注册自动帮他注册
                UserRepository userrepository = new UserRepository();
                int userid = userrepository.Register(user);
                user.Id = userid;
            }
            string sql1 = "  Insert Into UserClinic(ClinicID,UserID,Boss) Values(@ClinicID,@UserID,0)  ";
            SqlParameter[] param1 = new SqlParameter[] {
                new SqlParameter("@ClinicID",SqlDbType.Int){ Value = ClinicID},
                new SqlParameter("@UserID",SqlDbType.Int){ Value = user.Id}
            };
            DbHelperSQL.ExecuteSql(0, sql1, param1);            
            string sql2 = @" Insert Into Employee(ID,BH,ClinicID,UserId,RoleKeys,Name,Sex,Phone)
                                 Values(@ID,@BH,@ClinicID,@UserId,@RoleKeys)";
            SqlParameter[] param2 = new SqlParameter[]{
                    new SqlParameter("@ID",SqlDbType.Int){ Value = IDBH.getID(IDName.Employee.ToString()) },
                    new SqlParameter("@BH",SqlDbType.BigInt){ Value = IDBH.getBH(IDName.Employee.ToString(),ClinicID) },
                    new SqlParameter("@ClinicID",SqlDbType.Int){ Value = ClinicID},
                    new SqlParameter("@UserId",SqlDbType.Int){ Value = user.Id},                    
                    new SqlParameter("@RoleKeys",SqlDbType.NVarChar){ Value = roles}
                };
            DbHelperSQL.ExecuteSql(user.Id, sql2, param2);
            return true;
        }

        //修改诊所信息

        //删除诊所

        //获取诊所下用户

        //或者诊所类型



    }
}

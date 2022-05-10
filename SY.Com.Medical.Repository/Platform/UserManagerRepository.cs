using Dapper;
using SY.Com.Medical.Attribute;
using SY.Com.Medical.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SY.Com.Medical.Repository.Platform
{
    /// <summary>
    /// 数据访问层
    /// </summary>
    public class UserManagerRepository : BaseRepository<UserManagerEntity> 
	{
        /// <summary>
        /// 获取用户-通过账号密码
        /// </summary>
        /// <param name="Account"></param>
        /// <param name="Pwd"></param>
        /// <returns></returns>
        public UserManagerEntity Get(string Account, string Pwd)
        {
            string sql = " Select * From UserManager Where Account =@Account And Pwd=@Pwd ";
            return _db.QueryFirstOrDefault<UserManagerEntity>(sql, new { Account = Account, Pwd = Pwd });
        }

        /// <summary>
        /// 获取用户-通过账号
        /// </summary>
        /// <param name="Account"></param>
        /// <returns></returns>
        public UserManagerEntity Get(string Account)
        {
            string sql = " Select * From UserManager Where Account = @Account ";
            return _db.QueryFirstOrDefault<UserManagerEntity>(sql, new { Account = Account });
        }
    }
} 
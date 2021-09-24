﻿using Dapper;
using SY.Com.Medical.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Repository.Platform
{
    /// <summary>
    /// 用户数据库访问层
    /// </summary>
    public class UserRepository : BaseRepository<UserEntity>
    {
        /// <summary>
        /// 通过ID获取
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public UserEntity Get(int UserId)
        {
            return Get(UserId);
        }

        /// <summary>
        /// 获取用户-通过账号密码
        /// </summary>
        /// <param name="Account"></param>
        /// <param name="Pwd"></param>
        /// <returns></returns>
        public UserEntity Get(string Account,string Pwd)
        {
            string sql = " Select * From Users Where Account =@Account And Pwd=@Pwd ";
            return _db.QueryFirstOrDefault<UserEntity>(sql, new { Account = Account, Pwd = Pwd });
        }

        /// <summary>
        /// 获取用户-通过账号
        /// </summary>
        /// <param name="Account"></param>
        /// <returns></returns>
        public UserEntity Get(string Account)
        {
            string sql = " Select * From Users Where Account = @Account ";
            return _db.QueryFirstOrDefault<UserEntity>(sql, new { Account = Account });
        }
        
        /// <summary>
        /// 获取用户-通过账号验证码
        /// </summary>
        /// <param name="Account"></param>
        /// <param name="YZM"></param>
        /// <returns></returns>
        public UserEntity GetReSet(string Account,string YZM)
        {
            string sql = " Select * From Users Where Account = @Account And YZM = @YZM ";
            return _db.QueryFirstOrDefault<UserEntity>(sql, new { Account = Account, YZM= YZM });
        }

    }
}

using SY.Com.Clinic.Api.Model;
using SY.Com.Clinic.Model;
using SY.Com.Clinic.Repository;
using SY.Com.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SY.Com.Clinic.Api.Controllers
{
    /// <summary>
    /// 用户接口
    /// </summary>
    public class UserController : ApiController
    {
        UserRepository userdb = new UserRepository();

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="inmod">UserName和Password必填</param>
        /// <returns>成功返回用户信息</returns>
        [HttpPost]
        public OutPutMessage<UserModel> Login(InputMessage<UserLoginModel> inmod)
        {
            OutPutMessage<UserModel> outmod = new OutPutMessage<UserModel>();
            try
            {
                UserLoginModel mod = inmod.Data;
                if (string.IsNullOrEmpty(mod.UserName) || string.IsNullOrEmpty(mod.Password))
                {
                    return outmod.busExceptino(ErrorCode.入参数错误, "账号和密码不能为空");
                }
                UserModel dbmod = ReflectionExtention.Clone<UserLoginModel, UserModel>(mod);
                var modlogin = userdb.Login(dbmod);
                if(modlogin == null)
                {
                    return outmod.busExceptino(ErrorCode.用户不存在, "用户不存在");
                }
                if(modlogin.State == -1)
                {
                    return outmod.busExceptino(ErrorCode.用户被禁用, "账号已被禁用");
                }
                if(modlogin.Password != mod.Password)
                {
                    return outmod.busExceptino(ErrorCode.密码错误, "密码错误");
                }
                outmod.Data = modlogin;
                return outmod;
            }
            catch (Exception ex)
            {
                return outmod.sysException(ex.Message);
            }            
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="inmod">Phone,Password必填</param>
        /// <returns></returns>
        [HttpPost]
        public OutPutMessage<bool> Register(InputMessage<UserModel> inmod)
        {
            OutPutMessage<bool> outmod = new OutPutMessage<bool>();
            try
            {
                UserModel mod = inmod.Data;
                    ;
                if (string.IsNullOrEmpty(mod.Phone))
                {
                    return outmod.busExceptino(ErrorCode.入参数错误, "手机号不能为空");
                }
                if (string.IsNullOrEmpty(mod.Password))
                {
                    return outmod.busExceptino(ErrorCode.入参数错误, "密码必填");
                }
                if (string.IsNullOrEmpty(mod.VirifyCode))
                {
                    return outmod.busExceptino(ErrorCode.入参数错误, "安全码必填");
                }
                mod.UserName = mod.Phone;
                if (string.IsNullOrEmpty(mod.Name)) { 
                    mod.Name = mod.UserName;
                }
                outmod.Data = userdb.Register(mod);
                return outmod;
            }
            catch (Exception ex)
            {
                return outmod.sysException(ex.Message);
            }
        }


        /// <summary>
        /// 用户重置密码
        /// </summary>
        /// <param name="inmod">UserName,Password,VirifyCode必填</param>
        /// <returns></returns>
        [HttpPost]
        public OutPutMessage<bool> Reset(InputMessage<UserResetModel> inmod)
        {
            OutPutMessage<bool> outmod = new OutPutMessage<bool>();
            try
            {
                if(string.IsNullOrEmpty(inmod.Data.UserName) || string.IsNullOrEmpty(inmod.Data.Password) || string.IsNullOrEmpty(inmod.Data.VirifyCode))
                {
                    return outmod.busExceptino(ErrorCode.入参数错误, "账号/密码/保护码不能为空");
                }
                var dbinmod = ReflectionExtention.Clone<UserResetModel, UserModel>(inmod.Data);
                var dboutmod =  userdb.QueryReset(dbinmod);
                if(dboutmod == null)
                {
                    return outmod.busExceptino(ErrorCode.保护码错误, "账号+保护码错误");
                }
                if(dboutmod.State == -1)
                {
                    return outmod.busExceptino(ErrorCode.用户被禁用, "用户被禁用");
                }
                dboutmod.Password = dbinmod.Password;
                outmod.Data = userdb.Reset(dboutmod);
                return outmod;
            }
            catch (Exception ex)
            {
                return outmod.sysException(ex.Message);
            }

        }


    }
}

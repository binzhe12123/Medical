using SY.Com.Clinic.Api.Model;
using SY.Com.Clinic.Model;
using SY.Com.Clinic.Repository;
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
        /// <param name="mod">账号和密码</param>
        /// <returns>成功返回用户信息</returns>
        [HttpPost]
        public OutPutMessage<UserModel> Login(UserModel mod)
        {
            OutPutMessage<UserModel> result = new OutPutMessage<UserModel>();
            try
            {
                if (string.IsNullOrEmpty(mod.UserName) || string.IsNullOrEmpty(mod.Password))
                {
                    return result.busExceptino(ErrorCode.入参数错误, "账号和密码不能为空");
                }
                var modlogin = userdb.Login(mod);
                if(modlogin == null)
                {
                    return result.busExceptino(ErrorCode.用户不存在, "用户不存在");
                }
                if(modlogin.State == -1)
                {
                    return result.busExceptino(ErrorCode.用户被禁用, "账号已被禁用");
                }
                if(modlogin.Password != mod.Password)
                {
                    return result.busExceptino(ErrorCode.密码错误, "密码错误");
                }
                result.Data = modlogin;
                return result;
            }
            catch (Exception ex)
            {
                return result.sysException(ex.Message);
            }            
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="mod">Phone,Password必填</param>
        /// <returns></returns>
        [HttpPost]
        public OutPutMessage<bool> Register(UserModel mod)
        {
            OutPutMessage<bool> result = new OutPutMessage<bool>();
            try
            {
                if (string.IsNullOrEmpty(mod.Phone))
                {
                    return result.busExceptino(ErrorCode.入参数错误, "手机号不能为空");
                }
                if (string.IsNullOrEmpty(mod.Password))
                {
                    return result.busExceptino(ErrorCode.入参数错误, "密码必填");
                }
                if (string.IsNullOrEmpty(mod.VirifyCOde))
                {
                    return result.busExceptino(ErrorCode.入参数错误, "安全码必填");
                }
                mod.UserName = mod.Phone;
                if (string.IsNullOrEmpty(mod.Name)) { 
                    mod.Name = mod.UserName;
                }
                result.Data = userdb.Register(mod);
                return result;
            }
            catch (Exception ex)
            {
                return result.sysException(ex.Message);
            }
        }




    }
}

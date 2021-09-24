using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SY.Com.Medical.BLL;
using SY.Com.Medical.BLL.Platform;
using SY.Com.Medical.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SY.Com.Medical.WebApi.Controllers.Platform
{
    /// <summary>
    /// 登录相关
    /// </summary>
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        User userbll = new User();

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<LoginResponse> login(BaseRequest<LoginRequest> request)
        {
            BaseResponse<LoginResponse> result = new BaseResponse<LoginResponse>();
            try
            {                
                result.Data = userbll.Login(request.Data);
                return result;
            }
            catch (Exception ex)
            {
                if (ex is MyException)
                {
                    return result.busExceptino(Enum.ErrorCode.业务逻辑错误, ex.Message);
                }
                else
                {
                    return result.sysException(ex.Message);
                }
            }
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<RegisterResponse> register(BaseRequest<RegisterRequest> request)
        {
            BaseResponse<RegisterResponse> result = new BaseResponse<RegisterResponse>();
            try
            {
                if(userbll.ExistsAccount(request.Data.Account))
                {
                    return result.busExceptino(Enum.ErrorCode.用户不存在,"用户已存在,请重新登录");
                }                
                result.Data = userbll.Register(request.Data);
                return result;
            }
            catch (Exception ex)
            {
                if (ex is MyException)
                {
                    return result.busExceptino(Enum.ErrorCode.业务逻辑错误, ex.Message);
                }
                else
                {
                    return result.sysException(ex.Message);
                }
            }
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<ResetResponse> reset(BaseRequest<ResetRequest> request)
        {
            BaseResponse<ResetResponse> result = new BaseResponse<ResetResponse>();
            try
            {
                result.Data = userbll.Reset(request.Data);
                return result;
            }
            catch (Exception ex)
            {
                if (ex is MyException)
                {
                    return result.busExceptino(Enum.ErrorCode.业务逻辑错误, ex.Message);
                }
                else
                {
                    return result.sysException(ex.Message);
                }
            }
        }


    }
}

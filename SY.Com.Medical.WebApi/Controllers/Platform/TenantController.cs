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
    /// 租户控制器
    /// </summary>
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        Tenant tenantbll = new Tenant();

        /// <summary>
        /// 获取租户详情
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<UserTenantResponse> getTenant(BaseRequest<BaseModel> request)
        {
            BaseResponse<UserTenantResponse> response = new BaseResponse<UserTenantResponse>();
            try
            {
                response.Data = tenantbll.GetTenant(request);
                return response;
            }
            catch (Exception ex)
            {
                if (ex is MyException)
                {
                    return response.busExceptino(Enum.ErrorCode.业务逻辑错误, ex.Message);
                }
                else
                {
                    return response.sysException(ex.Message);
                }
            }
        }

        /// <summary>
        /// 获取用户租户列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<List<UserTenantResponse>> getTenants(BaseRequest<BaseModel> request)
        {
            BaseResponse<List<UserTenantResponse>> response = new BaseResponse<List<UserTenantResponse>>();
            try {
                response.Data = tenantbll.GetTenants(request).ToList();                
                return response;
            }catch(Exception ex)
            {
                if (ex is MyException)
                {
                    return response.busExceptino(Enum.ErrorCode.业务逻辑错误, ex.Message);
                }
                else
                {
                    return response.sysException(ex.Message);
                }
            }
        }

        /// <summary>
        /// 创建租户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<UserTenantResponse> createTenant(BaseRequest<TenentCreateRequest> request)
        {
            BaseResponse<UserTenantResponse> response = new BaseResponse<UserTenantResponse>();
            try
            {
                response.Data = tenantbll.CreateTenant(request);
                return response;
            }
            catch (Exception ex)
            {
                if (ex is MyException)
                {
                    return response.busExceptino(Enum.ErrorCode.业务逻辑错误, ex.Message);
                }
                else
                {
                    return response.sysException(ex.Message);
                }
            }            
        }

        /// <summary>
        /// 修改租户信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<TenantModel> updateTenant(BaseRequest<TenantRequest> request )
        {
            BaseResponse<TenantModel> response = new BaseResponse<TenantModel>();
            try
            {
                tenantbll.UpdateTenant(request);
                response.Data = null;
                return response;
            }
            catch (Exception ex)
            {
                if (ex is MyException)
                {
                    return response.busExceptino(Enum.ErrorCode.业务逻辑错误, ex.Message);
                }
                else
                {
                    return response.sysException(ex.Message);
                }
            }
        }



    }
}

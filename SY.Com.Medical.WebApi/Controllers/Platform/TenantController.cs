using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SY.Com.Medical.Attribute;
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
    [Authorize]
    [ApiController]    
    public class TenantController : ControllerBase
    {
        Tenant tenantbll = new Tenant();

        /// <summary>
        /// 获取用户租户列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<List<UserTenantResponse>> getTenants(BaseModel request)
        {
            BaseResponse<List<UserTenantResponse>> response = new BaseResponse<List<UserTenantResponse>>();
            try
            {
                response.Data = tenantbll.GetTenants(request).ToList();
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
        /// 获取租户详情
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Api_Tenant]
        public BaseResponse<UserTenantResponse> getTenant(BaseModel request)
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
        /// 创建租户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]        
        public BaseResponse<UserTenantResponse> createTenant(TenentCreateRequest request)
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
        [Api_Tenant]
        public BaseResponse<TenantModel> updateTenant(TenantRequest request )
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

        /// <summary>
        /// 删除租户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Api_Tenant]
        public BaseResponse<bool> deleteTenant(BaseModel request)
        {
            BaseResponse<bool> response = new BaseResponse<bool>();
            try
            {
                tenantbll.DeleteTenant(request.TenantId,request.UserId);
                response.Data = true;
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
        /// 获取用户的菜单
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Api_Tenant]
        public BaseResponse<List<MenuResponse>> getMenu(EmployeeGetModel request)
        {
            BaseResponse<List<MenuResponse>> response = new BaseResponse<List<MenuResponse>>();
            try
            {                
                response.Data = tenantbll.GetMenu(request);
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

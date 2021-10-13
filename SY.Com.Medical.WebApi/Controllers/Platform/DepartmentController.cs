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
    /// 科室控制器abc
    /// </summary>
    [Route("api/[controller]/[Action]")]
    [Authorize]    
    [ApiController]
    [Api_Tenant]
    public class DepartmentController : ControllerBase
    {
        Department bll = new Department();
        /// <summary>
        /// 获取科室列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Api_Tenant]
        public BaseResponse<List<DepartmentResponse>> getList(DepartmentModel request)
        {
            BaseResponse<List<DepartmentResponse>> result = new BaseResponse<List<DepartmentResponse>>();
            try {
                result.Data = bll.getDepartment(request);
                return result;
            }catch(Exception ex)
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
        /// 科室详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public BaseResponse<DepartmentResponse> getDetail(int id)
        {
            BaseResponse<DepartmentResponse> result = new BaseResponse<DepartmentResponse>();
            try
            {
                result.Data = bll.getDetail(id);
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
        /// 编辑科室
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<bool> update(DepartmentResponse request)
        {
            BaseResponse<bool> result = new BaseResponse<bool>();
            try
            {
                bll.updateDepartment(request);
                result.Data = true;
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
        /// 添加科室
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<bool> add(DepartmentCreateRequest request)
        {
            BaseResponse<bool> result = new BaseResponse<bool>();
            try
            {
                bll.createDepartment(request);
                result.Data = true;
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
        /// 删除科室
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<bool> delete(DepartmentDelete request)
        {
            BaseResponse<bool> result = new BaseResponse<bool>();
            try
            {
                bll.deleteDepartment(request);
                result.Data = true;
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

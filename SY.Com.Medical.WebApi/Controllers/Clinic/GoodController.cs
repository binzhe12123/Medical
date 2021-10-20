using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SY.Com.Medical.Attribute;
using SY.Com.Medical.BLL;
using SY.Com.Medical.BLL.Clinic;
using SY.Com.Medical.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SY.Com.Medical.WebApi.Controllers.Clinic
{
    /// <summary>
    /// 物料控制器(药品、项目、材料)
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    [Api_Tenant]
    public class GoodController : ControllerBase
    {
        Good bll = new Good();

        /// <summary>
        /// 获取药品分页
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<List<GoodModel>> gets(GoodRequest request )
        {
            BaseResponse<List<GoodModel>> result = new BaseResponse<List<GoodModel>>();
            try {
                var tuple = bll.gets(request);
                result.Data = tuple.Item1.ToList();
                result.CalcPage(tuple.Item2, request.PageIndex, request.PageSize);
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
        /// 获取药品详情
        /// </summary>
        /// <param name="goodid"></param>
        /// <returns></returns>
        [HttpGet]
        public BaseResponse<GoodModel> get(int goodid)
        {
            BaseResponse<GoodModel> result = new BaseResponse<GoodModel>();
            try
            {
                result.Data = bll.get(goodid);
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
        /// 添加药品商品
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<int> add(GoodAdd request)
        {
            BaseResponse<int> result = new BaseResponse<int>();
            try
            {
                result.Data = bll.add(request);
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
        /// 修改药品
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<bool> update(GoodUpdate request)
        {
            BaseResponse<bool> result = new BaseResponse<bool>();
            try
            {
                bll.update(request);
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
        /// 删除药品
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<bool> delete(GoodDelete request)
        {
            BaseResponse<bool> result = new BaseResponse<bool>();
            try
            {
                bll.delete(request);
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
        /// 获取租户的药品分类
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<List<Dictionary<string,string>>> getGoodSort()
        {
            BaseResponse<List<Dictionary<string, string>>> result = new BaseResponse<List<Dictionary<string, string>>>();
            result.Data = bll.getGoodSort();
            return result;
        }

    }
}

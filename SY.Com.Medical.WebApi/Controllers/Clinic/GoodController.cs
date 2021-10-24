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
using SY.Com.Medical.Extension;

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
                if(request.GoodType == 0)
                {
                    request.GoodType = 6;
                }
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
        /// 添加药品
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
        /// 获取租户的药品/项目/材料分类
        /// 其中DicType值为枚举,需要通过getKeyValue接口查询        
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<List<Dictionary<int,string>>> getGoodSort(GoodSortReuqest request)
        {
            BaseResponse<List<Dictionary<int, string>>> result = new BaseResponse<List<Dictionary<int, string>>>();
            result.Data = bll.getGoodSort(request);
            return result;
        }


        /// <summary>
        /// 获取项目列表分页
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<List<GoodItemModel>> getItems(GoodItemsRequest request)
        {
            BaseResponse<List<GoodItemModel>> result = new BaseResponse<List<GoodItemModel>>();
            try
            {                
                var mod = request.Mapping<GoodRequest>();
                mod.GoodType = 4;
                request.GoodType = 4;
                var tuple = bll.gets(mod);
                result.Data = tuple.Item1.ToList().Mapping<GoodItemModel>();
                result.CalcPage(tuple.Item2, mod.PageIndex, mod.PageSize);
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
        /// 获取项目详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public BaseResponse<GoodItemModel> getItem(int id)
        {
            BaseResponse<GoodItemModel> result = new BaseResponse<GoodItemModel>();
            try
            {
                result.Data = bll.get(id).Mapping<GoodItemModel>();
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
        /// 添加项目
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<int> addItem(GoodItemAdd request)
        {
            BaseResponse<int> result = new BaseResponse<int>();
            try
            {
                request.GoodType = 4;
                result.Data = bll.add(request.Mapping<GoodAdd>());
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
        /// 修改项目
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<bool> updateItem(GoodItemUpdate request)
        {
            BaseResponse<bool> result = new BaseResponse<bool>();
            try
            {
                request.GoodType = 4;
                bll.update(request.Mapping<GoodUpdate>());
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
        /// 删除项目
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<bool> deleteItem(GoodDelete request)
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
        /// 获取材料分页
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<List<GoodModel>> getsMaterial(GoodRequest request)
        {
            BaseResponse<List<GoodModel>> result = new BaseResponse<List<GoodModel>>();
            try
            {
                request.GoodType = 5;
                var tuple = bll.gets(request);
                result.Data = tuple.Item1.ToList();
                result.CalcPage(tuple.Item2, request.PageIndex, request.PageSize);
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
        /// 获取材料详情
        /// </summary>
        /// <param name="goodid"></param>
        /// <returns></returns>
        [HttpGet]
        public BaseResponse<GoodModel> getMaterial(int goodid)
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
        /// 添加材料
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<int> addMaterial(GoodAdd request)
        {
            BaseResponse<int> result = new BaseResponse<int>();
            try
            {
                request.GoodType = 5;
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
        /// 修改材料
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<bool> updateMaterial(GoodUpdate request)
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
        /// 删除材料
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<bool> deleteMaterial(GoodDelete request)
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
    }
}

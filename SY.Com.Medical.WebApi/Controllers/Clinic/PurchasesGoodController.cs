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
    /// 控制器
    /// </summary>
    [Route("api /[controller] /[action]")]
    [ApiController]
    [Authorize]
    [Api_Tenant]
    public class PurchasesGoodController : ControllerBase 
	{
		 PurchasesGood bll = new PurchasesGood();

		/// <summary>
		/// 采购页面搜索药品
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		[HttpPost]
		public BaseResponse<List<PurchasesGoodSearchResponse>> searchDrugs(PurchasesGoodSearchRequest request)
        {
			BaseResponse<List<PurchasesGoodSearchResponse>> result = new BaseResponse<List<PurchasesGoodSearchResponse>>();
			request.GoodType = 6;
			var tuple = bll.searchGoods(request);
			result.Data = tuple.Item1.ToList();
			result.CalcPage(tuple.Item2, request.PageIndex, request.PageSize);
			return result;
		}

		/// <summary>
		/// 采购页面搜索材料
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		[HttpPost]
		public BaseResponse<List<PurchasesGoodSearchResponse>> searchMaterials(PurchasesGoodSearchRequest request)
		{
			BaseResponse<List<PurchasesGoodSearchResponse>> result = new BaseResponse<List<PurchasesGoodSearchResponse>>();
			request.GoodType = 5;
			var tuple = bll.searchGoods(request);
			result.Data = tuple.Item1.ToList();
			result.CalcPage(tuple.Item2, request.PageIndex, request.PageSize);
			return result;
		}




		///<summary> 
		///获取详情记录
		///</summary> 
		///<param name="id"></param>
		/// <returns></returns>
		[HttpGet]
		public BaseResponse<PurchasesGoodModel> get(int id)
		{
			BaseResponse<PurchasesGoodModel> result = new BaseResponse<PurchasesGoodModel>();
				try{
					result.Data = bll.get(id);
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
		///<summary> 
		///获取列表-分页
		///</summary> 
		///<param name="request"></param>
		/// <returns></returns>
		[HttpPost]
		public BaseResponse<List<PurchasesGoodModel>> gets(PurchasesGoodRequest request)
		{
				BaseResponse<List<PurchasesGoodModel>> result = new BaseResponse<List<PurchasesGoodModel>>();
				try{
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
		///<summary> 
		///新增
		///</summary> 
		///<param name="request"></param>
		/// <returns></returns>
		[HttpPost]
		public BaseResponse<int> add(PurchasesGoodAdd request)
		{
				BaseResponse<int> result = new BaseResponse<int>();
				try{
					result.Data = bll.add(request);
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
		///<summary> 
		///修改
		///</summary> 
		///<param name="request"></param>
		/// <returns></returns>
		[HttpPost]
		public BaseResponse<bool> update(PurchasesGoodUpdate request)
		{
			BaseResponse<bool> result = new BaseResponse<bool>();
				try{
					bll.update(request);
					result.Data = true;
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
		///<summary> 
		///删除
		///</summary> 
		///<param name="request"></param>
		/// <returns></returns>
		[HttpPost]
		public BaseResponse<bool> delete(PurchasesGoodDelete request)
		{
			BaseResponse<bool> result = new BaseResponse<bool>();
				try{
					bll.delete(request);
					result.Data = true;
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
	}
} 
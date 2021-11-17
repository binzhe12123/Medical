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
    public class InventoryGoodController : ControllerBase 
	{
		 InventoryGood bll = new InventoryGood();

		/// <summary>
		/// 盘点页面搜索药品/材料
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		[HttpPost]
		public BaseResponse<List<InventoryGoodSearchResponse>> searchGoods(InventoryGoodSearchRequest request)
		{
			BaseResponse<List<InventoryGoodSearchResponse>> result = new BaseResponse<List<InventoryGoodSearchResponse>>();
			if (request.Type == 0)
			{
				request.GoodType = 0;
			}
			else if (request.Type == 1)
			{
				request.GoodType = 6;
			}
			else
			{
				request.GoodType = 5;
			}
			var tuple = bll.searchGoods(request);
			result.Data = tuple.Item1.ToList();
			result.CalcPage(tuple.Item2, request.PageIndex, request.PageSize);
			return result;
		}

		/// <summary>
		/// 盘点
		/// </summary>
		/// <param name="requst"></param>
		/// <returns></returns>
		[HttpPost]
		public BaseResponse<bool> Inventory(List<InventoryGoodRequest> requst)
        {
			BaseResponse<bool> result = new BaseResponse<bool>();
			result.Data = bll.Inventory(requst);
			return result;
		}

		/// <summary>
		/// 计算物品的盘点售后价
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		[HttpPost]
		public BaseResponse<double> getAfterPrice(InventoryPriceRequest request)
        {
			BaseResponse<double> result = new BaseResponse<double>();
			if (request.Stock <= request.StockAfter)
            {
				result.Data = request.Price;
				return result;
            }
			result.Data = bll.CalcAfterPrice(request.TenantId, request.GoodId, request.Stock, request.StockAfter);
			return result;
		}

		Inventory mainbll = new Inventory();
		
		///<summary> 
		///获取列表-分页
		///</summary> 
		///<param name="request"></param>
		/// <returns></returns>
		[HttpPost]
		public BaseResponse<List<InventoryModel>> gets(InventoryRequest request)
		{
			BaseResponse<List<InventoryModel>> result = new BaseResponse<List<InventoryModel>>();
			try
			{
				var tuple = mainbll.gets(request);
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
		/// 获取某盘点单明细
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		[HttpPost]
		public BaseResponse<List<InventoryGoodModel>> getInventory(InventoryListRequest request)
		{
			BaseResponse<List<InventoryGoodModel>> result = new BaseResponse<List<InventoryGoodModel>>();
			result.Data = bll.getInventory(request.TenantId, request.InventoryId);
			return result;
		}


	}
} 
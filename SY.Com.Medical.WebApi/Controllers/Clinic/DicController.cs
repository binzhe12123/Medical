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
    /// 字典控制器
    /// </summary>
    [Route("api /[controller] /[action]")]
    [ApiController]
    [Authorize]
    [Api_Tenant]
    public class DicController : ControllerBase 
	{
		 Dic bll = new Dic();
		///<summary> 
		///获取字典详情记录
		///</summary> 
		///<param name="id"></param>
		/// <returns></returns>
		[HttpGet]
		public BaseResponse<DicModel> get(int id)
		{
			BaseResponse<DicModel> result = new BaseResponse<DicModel>();
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
		///获取字典列表-分页
		///</summary> 
		///<param name="request"></param>
		/// <returns></returns>
		[HttpPost]
		public BaseResponse<List<DicModel>> gets(DicRequest request)
		{
				BaseResponse<List<DicModel>> result = new BaseResponse<List<DicModel>>();
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
		///新增字典条目
		///</summary> 
		///<param name="request"></param>
		/// <returns></returns>
		[HttpPost]
		public BaseResponse<int> add(DicAdd request)
		{
			BaseResponse<int> result = new BaseResponse<int>();
			try
			{
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
		///修改字典条目
		///</summary> 
		///<param name="request"></param>
		/// <returns></returns>
		[HttpPost]
		public BaseResponse<bool> update(DicUpdate request)
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

	}
} 
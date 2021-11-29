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
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    [Api_Tenant]
    public class OutpatientController : ControllerBase 
	{
	    Outpatient bll = new Outpatient();

        /// <summary>
        /// 保存门诊
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<int> Save(OutpatientAddStructure request)
        {
            BaseResponse<int> result = new BaseResponse<int>();
            if(request.OutpatientId == 0)
            {
               result.Data =  bll.AddStructure(request);
            }
            else
            {
                bll.UpdateStructure(request);
                result.Data = request.OutpatientId;
            }
            return result;
        }

        /// <summary>
        /// 查询挂单处方-列表-分页
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<List<OutpatientListModel>> getNoPaid(OutpatientSearchModel request)
        {
            BaseResponse<List<OutpatientListModel>> result = new BaseResponse<List<OutpatientListModel>>();
            var tuple =  bll.getNoPaid(request.TenantId, request.PageSize, request.PageIndex, request.searchKey, request.start, request.end);
            result.Data = tuple.Item1.ToList();
            result.CalcPage(tuple.Item2, request.PageIndex, request.PageSize);
            return result;
        }

        /// <summary>
        /// 查询历史处方-列表-分页
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<List<OutpatientListModel>> getHistory(OutpatientSearchModel request)
        {
            BaseResponse<List<OutpatientListModel>> result = new BaseResponse<List<OutpatientListModel>>();
            var tuple = bll.getHistory(request.TenantId, request.PageSize, request.PageIndex, request.searchKey, request.start, request.end);
            result.Data = tuple.Item1.ToList();
            result.CalcPage(tuple.Item2, request.PageIndex, request.PageSize);
            return result;
        }

        /// <summary>
        /// 门诊收费
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<int> OutpatientCharge(OutpatientChargeModel request)
        {
            BaseResponse<int> result = new BaseResponse<int>();
            result.Data = bll.Charge(request);
            return result;
        }



    }
} 
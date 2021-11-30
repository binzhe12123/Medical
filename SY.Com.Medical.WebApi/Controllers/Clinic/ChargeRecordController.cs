using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SY.Com.Medical.Attribute;
using SY.Com.Medical.BLL;
using SY.Com.Medical.BLL.Clinic;
using SY.Com.Medical.Extension;
using SY.Com.Medical.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SY.Com.Medical.WebApi.Controllers.Clinic
{
	/// <summary>
	/// 收费管理
	/// </summary>
	[Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    [Api_Tenant]
    public class ChargeRecordController : ControllerBase
	{
		Outpatient outpatient_bll = new Outpatient();
		Good goodsbll = new Good();
		Register regbll = new Register();
		ChargeRecord bll = new ChargeRecord();
        /// <summary>
        /// 查询代收费门诊处方列表-列表-分页
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<List<OutpatientListModel>> getNoPaid(OutpatientSearch2Model request)
        {
            BaseResponse<List<OutpatientListModel>> result = new BaseResponse<List<OutpatientListModel>>();
            var tuple = outpatient_bll.getNoPaid(request.TenantId, request.PageSize, request.PageIndex, request.searchKey, request.start, request.end, request.DoctorId);
            result.Data = tuple.Item1.ToList();
            result.CalcPage(tuple.Item2, request.PageIndex, request.PageSize);
            return result;
        }

        /// <summary>
        /// 查询已收费门诊处方-列表-分页
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<List<OutpatientListModel>> getHistory(OutpatientSearch2Model request)
        {
            BaseResponse<List<OutpatientListModel>> result = new BaseResponse<List<OutpatientListModel>>();
            var tuple = outpatient_bll.getHistory(request.TenantId, request.PageSize, request.PageIndex, request.searchKey, request.start, request.end, request.DoctorId);
            result.Data = tuple.Item1.ToList();
            result.CalcPage(tuple.Item2, request.PageIndex, request.PageSize);
            return result;
        }

        /// <summary>
        /// 查询退费门诊处方-列表-分页
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<List<OutpatientListModel>> getBackList(OutpatientSearch2Model request)
        {
            BaseResponse<List<OutpatientListModel>> result = new BaseResponse<List<OutpatientListModel>>();
            var tuple = outpatient_bll.getBackList(request.TenantId, request.PageSize, request.PageIndex, request.searchKey, request.start, request.end, request.DoctorId);
            result.Data = tuple.Item1.ToList();
            result.CalcPage(tuple.Item2, request.PageIndex, request.PageSize);
            return result;
        }
        

        /// <summary>
        /// 收费管理时时获取医生下拉框
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<List<RegisterDoctor>> getDoctors(BaseModel request)
        {
            BaseResponse<List<RegisterDoctor>> result = new BaseResponse<List<RegisterDoctor>>();
            result.Data = regbll.getDoctors(request.TenantId);
            return result;
        }

        /// <summary>
        /// 获取具体一个门诊+处方详细信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<OutpatientStructure> getDetail(OutpatientStructureRequest request)
        {
            BaseResponse<OutpatientStructure> result = new BaseResponse<OutpatientStructure>();
            result.Data = outpatient_bll.getStructure(request.TenantId, request.OutpatientId);
            return result;
        }

        /// <summary>
        /// 退费
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<bool> BackCharge(OutpatientStructureRequest request)
        {
            BaseResponse<bool> result = new BaseResponse<bool>();
            outpatient_bll.BackCharge(request.TenantId, request.OutpatientId);
            result.Data = true;
            return result;
        }

        /// <summary>
        /// 获取门诊收费详情
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<ChargeRecordModel> getChargeByOutpatient(OutpatientStructureRequest request)
        {
            BaseResponse<ChargeRecordModel> result = new BaseResponse<ChargeRecordModel>();
            //保存退费记录
            var entity = bll.getByOutpatientId(request.TenantId, request.OutpatientId);
            result.Data = entity.EntityToDto<ChargeRecordModel>();
            return result;
        }
        

    }
} 
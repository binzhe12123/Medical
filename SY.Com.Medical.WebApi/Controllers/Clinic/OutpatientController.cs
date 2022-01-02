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
    /// 门诊+处方控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    [Api_Tenant]
    public class OutpatientController : ControllerBase 
	{
	    Outpatient bll = new Outpatient();
        Good goodsbll = new Good();
        Register regbll = new Register();
        Patient patbll = new Patient();

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
        /// 获取具体一个门诊+处方详细信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<OutpatientStructure> getDetail(OutpatientStructureRequest request)
        {
            BaseResponse<OutpatientStructure> result = new BaseResponse<OutpatientStructure>();
            result.Data = bll.getStructure(request.TenantId, request.OutpatientId);
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

        /// <summary>
        /// 获取药品和材料列表-分页
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<List<GoodModels>> getsGoods(GoodsRequest request)
        {
            BaseResponse<List<GoodModels>> result = new BaseResponse<List<GoodModels>>();
            try
            {
                //（枚举1:西药,2:中成药,3:中药,4:诊疗项目,5:材料）
                if (request.GoodType == 1)
                {
                    request.GoodType = 7;
                }
                var tuple = goodsbll.getGoods(request.TenantId, request.PageSize, request.PageIndex, request.GoodType,0, request.SearchKey);
                if (tuple.Item2 == 0)
                {
                    return new BaseResponse<List<GoodModels>>();
                }
                result.Data = tuple.Item1.ToList().Mapping<GoodModels>();
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
        /// 模糊搜索租户患者信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<List<PatientModel>> searchPatient(PatientSearchPage request)
        {
            BaseResponse<List<PatientModel>> result = new BaseResponse<List<PatientModel>>();
            try
            {
                PatientPage page = new PatientPage();
                page.PageSize = request.PageSize;
                page.PageIndex = request.PageIndex;
                page.SearchKey = request.SearchKey;
                var tuple =  patbll.gets(page);
                result.Data = tuple.Item1;
                result.CalcPage(tuple.Item2,1, 1);
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
        /// 查找未被使用的挂号
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<List<RegisterModel>> findRegister(Register1Request request)
        {
            BaseResponse<List<RegisterModel>> result = new BaseResponse<List<RegisterModel>>();
            try
            {
                var tuple = regbll.gets(request.TenantId, request.PageSize, request.PageIndex, request.SearchKey, request.start, request.end,-1);
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

    }
} 
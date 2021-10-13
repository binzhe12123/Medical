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
    /// 患者信息
    /// </summary>
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [Authorize]
    [Api_Tenant]
    public class PatientController : ControllerBase
    {
        Patient bll = new Patient();
        CaseBook cbbll = new CaseBook();

        /// <summary>
        /// 获取租户患者信息列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<List<PatientModel>> gets(PatientPage request)
        {
            BaseResponse<List<PatientModel>> result = new BaseResponse<List<PatientModel>>();
            try
            {
                var tuple = bll.gets(request);
                result.Data = tuple.Item1;
                result.CalcPage(tuple.Item2,request.PageIndex,request.PageSize);
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
        /// 获取单个患者信息
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        [HttpGet]
        public BaseResponse<PatientModel> get(int patientId)
        {
            BaseResponse<PatientModel> result = new BaseResponse<PatientModel>();
            try
            {
                result.Data = bll.get(patientId);
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
        /// 添加患者
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<int> add(PatientAdddto request)
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
        /// 修改患者
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<bool> update(PatientUpdatedto request)
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
        /// 删除患者
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<bool> delete(PatientDel request)
        {
            BaseResponse<bool> result = new BaseResponse<bool>();
            try
            {
                bll.delete(request.PatientId);
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
        /// 获取患者的病历列表-分页
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<List<CaseBookModel>> getCaseBooks(CaseBookPage request)
        {
            BaseResponse<List<CaseBookModel>> result = new BaseResponse<List<CaseBookModel>>();
            try
            {                 
                var tuple = cbbll.gets(request.PatientId, request.PageSize, request.PageIndex);
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
        /// 获取单份病历
        /// </summary>
        /// <param name="caseBookId">病历ID</param>
        /// <returns></returns>
        [HttpGet]
        public BaseResponse<CaseBookModel> getCaseBook(int caseBookId)
        {
            BaseResponse<CaseBookModel> result = new BaseResponse<CaseBookModel>();
            try
            {
                result.Data = cbbll.get(caseBookId);
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
        /// 新增病历
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<int> addCaseBook(CaseBookAdd request)
        {
            BaseResponse<int> result = new BaseResponse<int>();
            try
            {
                result.Data = cbbll.add(request);
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
        /// 修改病历
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<bool> updateCaseBook(CaseBookUpdate request)
        {
            BaseResponse<bool> result = new BaseResponse<bool>();
            try
            {
                cbbll.update(request);
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
        /// 删除病历
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<bool> deleteCaseBook(CaseBookDelete request)
        {
            BaseResponse<bool> result = new BaseResponse<bool>();
            try
            {
                cbbll.delete(request);
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

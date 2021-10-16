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
    /// 配置控制器
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        Setting bll = new Setting();
        /// <summary>
        /// 获取枚举键值对
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        [HttpGet]
        public BaseResponse<List<KeyValueModel>> getKeyValue(string Name)
        {
            BaseResponse<List<KeyValueModel>> result = new BaseResponse<List<KeyValueModel>>();
            try
            {
                switch(Name.ToLower())
                {
                    case "casebooktype": Name = "CaseBookType";break;
                    case "delete": Name = "Delete"; break;
                    case "enable": Name = "Enable"; break;
                    case "isboss": Name = "IsBoss"; break;
                    case "sex": Name = "Sex"; break;
                    case "tenanttype": Name = "TenantType";break;
                    case "errorcode":Name = "ErrorCode"; break;
                    default:break;
                }
                result.Data = bll.getEnum(Name);
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

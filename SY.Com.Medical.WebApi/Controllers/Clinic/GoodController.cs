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
    /// 商品控制器
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [Api_Tenant]
    public class GoodController : ControllerBase
    {
        Good bll = new Good();

        [HttpPost]
        public BaseResponse<List<GoodModel>> gets(GoodModel request )
        {
            BaseResponse<List<GoodModel>> result = new BaseResponse<List<GoodModel>>();
            try {
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

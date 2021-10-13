using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SY.Com.Medical.Attribute;
using SY.Com.Medical.BLL.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SY.Com.Medical.WebApi.Controllers.Platform
{
    /// <summary>
    /// 菜单控制器
    /// </summary>
    [Route("api/[controller]/[Action]")]
    [Authorize]
    [ApiController]
    [Api_Tenant]
    public class MenuController : ControllerBase
    {
        Menu menu = new Menu();

        

    }
}

using SY.Com.Clinic.Api.Model;
using SY.Com.Clinic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SY.Com.Clinic.Api.Controllers
{
    /// <summary>
    /// 用户接口
    /// </summary>
    public class UserController : ApiController
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        [HttpPost]
        public OutPutMessage<UserModel> Login(UserModel mod)
        {
            return new OutPutMessage<UserModel>();
        }
    }
}

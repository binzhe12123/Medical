using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SY.Com.Medical.BLL;

namespace SY.Com.Clinic.Api.Controllers
{
    /// <summary>
    /// 默认-接口测试
    /// </summary>
    public class DefaultController : ApiController
    {
        /// <summary>
        /// 测试接口
        /// </summary>
        /// <returns></returns>
        public object get()
        {
            Class1 clas = new Class1();
            
            return new  { ID = 1, Name = "tianlei" };
        }
    }
}

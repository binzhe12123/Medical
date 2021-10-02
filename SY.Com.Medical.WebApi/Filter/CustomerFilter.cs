using Microsoft.AspNetCore.Mvc.Filters;
using SY.Com.Medical.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SY.Com.Medical.WebApi.Filter
{
    /// <summary>
    /// 获取JWT中的user信息和head中传入的TenantId
    /// </summary>
    public class CustomerFilter : IActionFilter,IResourceFilter
    {
        /// <summary>
        /// 空实现
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        /// <summary>
        /// 查询所有的参数,如果有继承自BaseModel的就获取一下信息
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            try {
                foreach (var item in context.ActionArguments)
                {
                    //继承自BaseModel
                    if (typeof(BaseModel).IsInstanceOfType(item.Value))
                    {
                        var request = item.Value;
                        var type = request.GetType();
                        var userid = context.HttpContext.User.Claims.ToList().Find(x => x.Type == "UserId")?.Value;
                        if (userid != null)
                        {
                            type.GetProperty("UserId").SetValue(request, int.Parse(userid));
                        }
                        var tenantid = context.HttpContext.Request.Headers["TenantId"].ToString();
                        if (!string.IsNullOrEmpty(tenantid))
                        {
                            type.GetProperty("TenantId").SetValue(request, int.Parse(tenantid));
                        }
                    }
                }
            }catch(Exception)
            {
                
            }

        }

        /// <summary>
        /// 空实现
        /// </summary>
        /// <param name="context"></param>
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            
        }

        /// <summary>
        /// 获取参数自定义绑定
        /// </summary>
        /// <param name="context"></param>
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            //var userid = context.HttpContext.User.Claims.ToList().Find(x => x.Type == "UserId").Value;
            //var tenantid = context.HttpContext.Request.Headers["TenantId"].ToString();
        }
    }
}

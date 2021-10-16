using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using SY.Com.Medical.Attribute;
using SY.Com.Medical.BLL;
using SY.Com.Medical.Model;
using System;
using System.Collections;
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
            //var response = ((Microsoft.AspNetCore.Mvc.ObjectResult)context.Result).Value;
            //var datavalue = response.GetType().GetProperty("Data").GetValue(response);
            ////如果返回值是数组,就循环数组
            //if (datavalue.GetType().IsGenericType && datavalue.GetType().GetGenericTypeDefinition() == typeof(List<>))
            //{
            //    for (int i = 0; i < ((IList)datavalue).Count; i++)
            //    {
            //        var datavalueitem = ((IList)datavalue)[i];
            //        foreach (var e in datavalueitem.GetType().GetProperties())
            //        {
            //            if (e.GetValue(datavalueitem) != null && e.GetValue(datavalueitem).GetType().IsEnum)
            //            {
            //                e.SetValue(datavalueitem, e.GetValue(datavalueitem).GetHashCode());
            //            }
            //        }
            //    }
            //}
            //else {
            //    foreach (var e in datavalue.GetType().GetProperties())
            //    {
            //        if (e.GetValue(datavalue) != null && e.GetValue(datavalue).GetType().IsEnum)
            //        {
            //            e.SetValue(datavalue, (int)e.GetValue(datavalue));
            //        }
            //    }
            //}

        }

        /// <summary>
        /// 查询所有的参数,如果有继承自BaseModel的就获取一下信息
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                var tenantid = context.HttpContext.Request.Headers["TenantId"].ToString();
                if (string.IsNullOrEmpty(tenantid) || tenantid == "0")
                {
                    foreach (var prop in context.Controller.GetType().GetCustomAttributesData())
                    {
                        if (prop.AttributeType.Name == nameof(Api_TenantAttribute))
                        {
                            throw new MyException("TenantId非法");
                        }
                    }
                    var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
                    foreach (var prop in controllerActionDescriptor.MethodInfo.GetCustomAttributesData())
                    {
                        if (prop.AttributeType.Name == nameof(Api_TenantAttribute))
                        {                            
                            throw new MyException("TenantId非法");
                        }
                    }
                }
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
                        if(!string.IsNullOrEmpty(tenantid))
                        {
                            type.GetProperty("TenantId").SetValue(request, int.Parse(tenantid));
                        }                        
                    }
                }
            }
            catch(Exception ex)
            {
                if (ex is MyException)
                {
                    context.Result = new JsonResult(new BaseResponse<string>().busExceptino(Enum.ErrorCode.业务逻辑错误, ex.Message));
                }
                else
                {
                    context.Result = new JsonResult(new BaseResponse<string>().sysException(ex.Message));
                }
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

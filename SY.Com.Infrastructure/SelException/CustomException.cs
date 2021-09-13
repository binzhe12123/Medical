using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;


namespace SY.Com.Infrastructure.SelException
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class NotImplExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            Log4Net.LogHelper.Error("系统异常: " + context.Exception);
            if (context.Exception is NotImplementedException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.NotImplemented);
            }
        }
    }

    public class CustomException : Exception
    {
        public virtual string ErrorCode { get; set; }
        public virtual string ErrorDescription { get; set; }
    }

    public class BusinessLayerException : CustomException
    {

        public BusinessLayerException(string errorCode, string errorDescription)
            : base()
        {
            base.ErrorCode = errorCode;
            base.ErrorDescription = errorDescription;
        }
    }

    public class DataLayerException : CustomException
    {
        public DataLayerException(string errorCode, string errorDescription)
            : base()
        {
            base.ErrorCode = errorCode;
            base.ErrorDescription = errorDescription;
        }
    }

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class MethodAttributeExceptionHandling : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            //这里可以加入Log部分，记录异常日志,记录异常堆栈信息
           Log4Net.LogHelper.Error(actionExecutedContext.Request.RequestUri.AbsoluteUri + "错误信息" + actionExecutedContext.Response.Content + actionExecutedContext.Exception.Message , actionExecutedContext.Exception);
            


            if (actionExecutedContext.Exception is BusinessLayerException)
            {
                var businessException = actionExecutedContext.Exception as BusinessLayerException;
                var errorMessagError = new System.Web.Http.HttpError(businessException.ErrorDescription) { { "ErrorCode", businessException.ErrorCode } };
                actionExecutedContext.Response =
                    actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, errorMessagError);

            }
            else if (actionExecutedContext.Exception is DataLayerException)
            {
                var dataException = actionExecutedContext.Exception as DataLayerException;
                var errorMessagError = new System.Web.Http.HttpError(dataException.ErrorDescription) { { "ErrorCode", dataException.ErrorCode } };
                actionExecutedContext.Response =
                    actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, errorMessagError);

            }
            else
            {
                var errorMessagError = new System.Web.Http.HttpError("Oops some internal Exception. Please contact your administrator") { { "ErrorCode", 500 } };
                actionExecutedContext.Response =
                    actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, errorMessagError);
            }
        }
    }

    public class CustomApiControllerActionInvoker : ApiControllerActionInvoker
    {
        public override Task<HttpResponseMessage> InvokeActionAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            var result = base.InvokeActionAsync(actionContext, cancellationToken);

            if (result.Exception != null && result.Exception.GetBaseException() != null)
            {
                var baseException = result.Exception.InnerExceptions[0];//result.Exception.GetBaseException();

                //这里可以加入Log部分，记录异常日志
                Log4Net.LogHelper.Error(baseException);

                if (baseException is BusinessLayerException)
                {
                    var baseExcept = baseException as BusinessLayerException;
                    var errorMessagError = new System.Web.Http.HttpError(baseExcept.ErrorDescription) { { "ErrorCode", baseExcept.ErrorCode } };
                    return Task.Run<HttpResponseMessage>(() => actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, errorMessagError));
                }
                else if (baseException is DataLayerException)
                {
                    var baseExcept = baseException as DataLayerException;
                    var errorMessagError = new System.Web.Http.HttpError(baseExcept.ErrorDescription) { { "ErrorCode", baseExcept.ErrorCode } };
                    return Task.Run<HttpResponseMessage>(() => actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, errorMessagError));
                }
                else
                {
                    var errorMessagError = new System.Web.Http.HttpError("Oops some internal Exception. Please contact your administrator") { { "ErrorCode", 500 } };
                    return Task.Run<HttpResponseMessage>(() => actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, errorMessagError));
                }
            }

            return base.InvokeActionAsync(actionContext, cancellationToken);
        }
    }
}

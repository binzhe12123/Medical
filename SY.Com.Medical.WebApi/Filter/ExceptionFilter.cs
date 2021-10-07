﻿using Microsoft.AspNetCore.Mvc.Filters;
using SY.Com.Medical.BLL;
using SY.Com.Medical.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SY.Com.Medical.WebApi.Filter
{
    /// <summary>
    /// 统一处理异常
    /// </summary>
    public class ExceptionFilter : IExceptionFilter
    {
        /// <summary>
        /// 全局异常处理
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            //BaseResponse<string> result = new BaseResponse<string>();            
            //if (context.Exception is MyException)
            //{
            //    result.busExceptino(Enum.ErrorCode.业务逻辑错误, context.Exception.Message);
            //}
            //else
            //{
            //    context.Result = result.sysException(context.Exception.Message);
            //}
            throw new NotImplementedException();
        }
    }
}

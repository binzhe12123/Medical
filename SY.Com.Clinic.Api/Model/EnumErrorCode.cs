using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SY.Com.Clinic.Api.Model
{

    /// <summary>
    /// 错误代码
    /// </summary>
    public enum ErrorCode
    { 
        /// <summary>
        /// 程序异常
        /// </summary>
        程序异常,
        /// <summary>
        /// 入参错误
        /// </summary>
        入参数错误,
        /// <summary>
        /// 用户不存在
        /// </summary>
        用户不存在,
        /// <summary>
        /// 账号被禁用
        /// </summary>
        用户被禁用,
        /// <summary>
        /// 密码错误
        /// </summary>
        密码错误
    }


}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Enum
{
    /// <summary>
    /// 错误代码
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        /// 程序异常
        /// </summary>
        程序异常 = 1,
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
        密码错误,
        /// <summary>
        /// 保护码错误
        /// </summary>
        保护码错误,
        /// <summary>
        /// 业务逻辑错误
        /// </summary>
        业务逻辑错误,
        /// <summary>
        /// 用户已存在
        /// </summary>
        用户已存在,
        /// <summary>
        /// 数据为空
        /// </summary>
        数据为空,

    }
}

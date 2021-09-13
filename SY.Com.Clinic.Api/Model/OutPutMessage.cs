using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SY.Com.Clinic.Api.Model
{
    /// <summary>
    /// 统一输出参数
    /// </summary>
    public class OutPutMessage<T>
    {
        /// <summary>
        /// 结果,-1:系统异常,-2:逻辑异常,0:正常
        /// </summary>
        public int Result { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrMes { get; set; }
        /// <summary>
        /// 报文体
        /// </summary>
        public T Data { get; set; }

    }
}
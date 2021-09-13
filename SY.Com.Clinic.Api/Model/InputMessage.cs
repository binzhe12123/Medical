using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SY.Com.Clinic.Api.Model
{
    /// <summary>
    /// 输入公共报文
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class InputMessage<T>
    {
        /// <summary>
        /// 机构ID
        /// </summary>
        public int ClinicID { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 登录token 
        /// </summary>
        public string token { get; set; }
        /// <summary>
        /// 报文体
        /// </summary>
        public T Data { get; set; }

    }
}
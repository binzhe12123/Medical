using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Model
{
    /// <summary>
    /// 输入参数
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseRequest<T> where T : BaseModel
    {
        /// <summary>
        /// 租户ID
        /// </summary>
        public int TenantID { get; set; }
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

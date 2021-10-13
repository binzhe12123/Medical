using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Model
{
    /// <summary>
    /// 用户模型
    /// </summary>
    public class UserModel : BaseModel
    {


        /// <summary>
        /// 账号    
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 密码md5小写    
        /// </summary>
        public string Pwd { get; set; }

        /// <summary>
        /// 验证码    
        /// </summary>
        public string YZM { get; set; }
    }

    /// <summary>
    /// 登录入参
    /// </summary>
    public class LoginRequest
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 密码(md5小写)
        /// </summary>
        public string Pwd { get; set; }
    }

    /// <summary>
    /// 登录出参
    /// </summary>
    public class LoginResponse
    { 
        /// <summary>
        /// Jwt验证token,后续请求中放入Header的Authorization中
        /// </summary>
        public string access_token { get; set; }
    }

    /// <summary>
    /// 注册入参
    /// </summary>
    public class RegisterRequest : BaseModel
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        public string YZM { get; set; }
    }


    /// <summary>
    /// 注册出参
    /// </summary>
    public class RegisterResponse
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }
    }

    /// <summary>
    /// 重置密码入参
    /// </summary>
    public class ResetRequest : BaseModel
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd { get; set; }
        /// <summary>
        /// 确认密码
        /// </summary>
        public string Pwd2 { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        public string YZM { get; set; }
    }


    /// <summary>
    /// 重置密码出参
    /// </summary>
    public class ResetResponse
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }
    }

}

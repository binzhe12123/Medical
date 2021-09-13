using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Clinic.Model
{
    /// <summary>
    /// 用户模型
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// 主键ID    
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 用户姓名    
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 性别(国标)1:男2:女    
        /// </summary>
        public int? Sex { get; set; }

        /// <summary>
        /// 出生年月    
        /// </summary>
        public DateTime? BirthDay { get; set; }

        /// <summary>
        /// 身份证    
        /// </summary>
        public string SFZH { get; set; }

        /// <summary>
        /// 电话    
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 用户名    
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码md5    
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 头像    
        /// </summary>
        public string Imagepath { get; set; }
        /// <summary>
        /// 重置密码用
        /// </summary>
        public string VirifyCode { get; set; }

        /// <summary>
        /// 状态：0:正常，-1:禁用    
        /// </summary>
        public int? State { get; set; }

        /// <summary>
        /// 创建日期    
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 是否删除:0:正常,-1:删除    
        /// </summary>
        public int IsDelete { get; set; }
    }

    /// <summary>
    /// 用户登录模型
    /// </summary>
    public class UserLoginModel
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
    }

    /// <summary>
    /// 用户重置密码
    /// </summary>
    public class UserResetModel
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 保护码
        /// </summary>
        public string VirifyCode { get; set; }
    }
}

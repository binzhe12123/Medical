using SY.Com.Medical.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Entity
{

    /// <summary>
    ///  用户    
    /// </summary>
    [Serializable]
    [DB_Table("Users")]
    [DB_Key("UserId")]
    public class UserEntity : BaseEntity
    {
        /// <summary>
        /// 用户id    
        /// </summary>
        [DB_Key("UserId")]
        public int UserId { get; set; }

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
        /// <summary>
        /// 头像图片
        /// </summary>
        public string LogoImg { get; set; }


    }

}

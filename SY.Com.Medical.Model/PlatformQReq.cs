using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Model
{
    public class PlatformQReq : BaseModel
    {
        /// <summary>
        /// 主键id    
        /// </summary>        
        public int PlatformId { get; set; }

        /// <summary>
        /// 平台名称    
        /// </summary>
        public string PlatformName { get; set; }

        /// <summary>
        /// logo    
        /// </summary>
        public string LogoImage { get; set; }

        /// <summary>
        /// ico    
        /// </summary>
        public string LogoIco { get; set; }

        /// <summary>
        /// url    
        /// </summary>
        public string UrlAdd { get; set; }

        /// <summary>
        /// 服务电话    
        /// </summary>
        public string ServicePhone { get; set; }

        /// <summary>
        /// 标题    
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 标语口号    
        /// </summary>
        public string Slogan { get; set; }

        /// <summary>
        /// 备案信息    
        /// </summary>
        public string Record { get; set; }


        /// <summary>
        /// 版本id    
        /// </summary>
        public int? VersionId { get; set; }
    }
}

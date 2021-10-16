using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.BLL.Platform
{
    /// <summary>
    /// 静态文件上传所属的业务
    /// </summary>
    public class FileBus
    {
        public virtual string getPath()
        {
            return "/default/";
        }
    }

    /// <summary>
    /// 用户头像上传
    /// </summary>
    public class UserImgFileBus : FileBus
    {        
        public override string getPath()
        {            
            return "/user/logo/";
        }
    }

    /// <summary>
    /// 租户头像上传
    /// </summary>
    public class TenantImgFileBus : FileBus
    {        
        public override string getPath()
        {
            return "/tenant/logo/";
        }
    }


}

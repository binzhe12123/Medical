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
        public virtual string getPath(params string[] parms)
        {
            return "/default/";
        }
    }

    /// <summary>
    /// 用户头像上传
    /// </summary>
    public class UserImgFileBus : FileBus
    {        
        public override string getPath(params string[] parms)
        {            
            return "/user/logo/";
        }
    }

    /// <summary>
    /// 租户头像上传
    /// </summary>
    public class TenantImgFileBus : FileBus
    {        
        public override string getPath(params string[] parms)
        {
            return "/tenant/logo/";
        }
    }

    public class TenantPrintView : FileBus
    {
        public override string getPath(params string[] parms)
        {
            string str = "/PrintView/";
            if(parms != null)
            {
                for (int i = 0; i < parms.Length; i++)
                {
                    str += $"{parms[i]}/";
                }
            }
            return str;
        }
    }


}

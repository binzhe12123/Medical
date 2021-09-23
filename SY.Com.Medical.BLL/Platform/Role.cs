using SY.Com.Medical.Entity;
using SY.Com.Medical.Repository.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.BLL.Platform
{
    public class Role 
    {

        private CURDObject<RoleEntity> curdObj;
        private RoleRepository db;
        public Role()
        {
            curdObj = new CURDObject<RoleEntity>();
            curdObj.Entity = new RoleEntity();
            curdObj.db = new RoleRepository();
            db = new RoleRepository();
        }



    }
}

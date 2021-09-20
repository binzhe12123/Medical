using SY.Com.Medical.Entity;
using SY.Com.Medical.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.BLL
{
    /// <summary>
    /// 把model转换成BLL类,把model映射到bll中的entity中
    /// </summary>
    public static class ModelToBLLExtession
    {
        public static T ModelToBLL<T,U>(this CURDObject<T> bll, U model) where T : BaseEntity where U : BaseModel
        {
            Type modtype = model.GetType();
            Type entitytype = typeof(T);
            foreach(var prop in modtype.GetProperties())
            {
                var bllpro = entitytype.GetProperty(prop.Name);
                if (bllpro != null)
                {
                    bllpro.SetValue(bll.Entity, prop.GetValue(model));
                }
            }
            return bll.Entity;
        }


    }
}

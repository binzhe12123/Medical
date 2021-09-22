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


        /// <summary>
        /// Entity转Model
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static U EntityToModel<U>(this BaseEntity entity)  where U : BaseModel
        {

            Type modtype = typeof(U);
            Type entitytype = entity.GetType();
            var model = (U)Activator.CreateInstance(modtype);
            foreach (var prop in modtype.GetProperties())
            {
                var bllpro = entitytype.GetProperty(prop.Name);
                if (bllpro != null)
                {
                    bllpro.SetValue(model, prop.GetValue(entity));
                }
            }
            return model;
        }
    }
}

using SY.Com.Clinic.Model;
using SY.Com.Clinic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Domain
{
    //Domain基类
    /// <summary>
    /// Domain和Repository通过Model和基本类型进行数据传递
    /// 这里做一个Domain层面的基本操作
    /// 按照约定Model就是
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DomainBase<T,M> where T : class where M : ModelBase
    {
        //包含一个repository用来调用数据层
        RepositoryBase<M> repository;
        ModelBase model;
        public DomainBase()
        {
            repository = new RepositoryBase<M>();            
        }        

        //通过反射获取一个Model对象
        protected ModelBase GetModelInstan()
        {
            Type type = this.GetType();
            string typename = $"{type.Name}Model";
            string modelfullname = $"SY.Com.Clinic.Model.{type.Name}Model";
            var assembly = Assembly.Load(modelfullname);
            var instan = assembly.CreateInstance(typename);
            model = GetModelInstan() as M;
            return model;
        }

        //通过反射给Model赋值
        protected virtual ModelBase GetModelData()
        {
            var domaintype = this.GetType();
            var modeltype = model.GetType();
            //属性赋值
            foreach (var prop in domaintype.GetProperties())
            {
                var modelprop = modeltype.GetProperty(prop.Name);
                if (modelprop != null && modelprop.CanWrite && modelprop.PropertyType == prop.PropertyType)
                {
                    modelprop.SetValue(model, prop.GetValue(this));
                }
            }
            //字段赋值
            foreach(var filed in domaintype.GetFields())
            {
                var modelfiled = modeltype.GetField(filed.Name);
                if(modelfiled != null &&modelfiled.FieldType == filed.FieldType)
                {
                    modelfiled.SetValue(model, filed.GetValue(this));
                }
            }
            return model;
        }

        //根据id获取Domain模型

    }
}

using SY.Com.Medical.Entity;
using SY.Com.Medical.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Extension
{
    public static class TypeConvert
    {
        /// <summary>
        /// Dto转Entity
        /// </summary>
        /// <typeparam name="D">一个BaseModel</typeparam>
        /// <typeparam name="E">一个BaseEntity</typeparam>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static E DtoToEntity<E>(this BaseModel dto)  where E : BaseEntity
        {
            Type modtype = dto.GetType();
            Type entitytype = typeof(E);
            E entity = (E)Activator.CreateInstance(typeof(E));
            foreach (var prop in modtype.GetProperties())
            {
                var pro = entitytype.GetProperty(prop.Name);
                if (pro != null)
                {
                    pro.SetValue(entity, prop.GetValue(dto));
                }
            }
            return entity;
        }

        /// <summary>
        /// Dto转Entity
        /// List-->List
        /// </summary>
        /// <typeparam name="E"></typeparam>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static List<E> DtoToEntity<E>(this List<BaseModel> dto) where E : BaseEntity
        {
            List<E> result = new List<E>();
            foreach (var item in dto)
            {
                result.Add(item.DtoToEntity<E>());
            }
            return result;
        }

        /// <summary>
        /// Dto转Entity
        /// IEnumerable-->List
        /// </summary>
        /// <typeparam name="E"></typeparam>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static List<E> DtoToEntity<E>(this IEnumerable<BaseModel> dto) where E : BaseEntity
        {
            List<E> result = new List<E>();
            foreach (var item in dto)
            {
                result.Add(item.DtoToEntity<E>());
            }
            return result;
        }

        /// <summary>
        /// Entity转Dto
        /// </summary>
        /// <typeparam name="E">一个BaseEntity</typeparam>
        /// <typeparam name="D">一个BaseModel</typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static D EntityToDto<D>(this BaseEntity entity) where D : BaseModel
        {
            Type modtype = typeof(D);
            Type entitytype = entity.GetType();
            D dto = (D)Activator.CreateInstance(typeof(D));
            foreach (var prop in entitytype.GetProperties())
            {
                var pro = modtype.GetProperty(prop.Name);
                if (pro != null)
                {
                    pro.SetValue(dto, prop.GetValue(entity));
                }
            }
            return dto;
        }

        /// <summary>
        /// Entity转Dto
        /// List-->List
        /// </summary>
        /// <typeparam name="D"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static List<D> EntityToDto<D>(this List<BaseEntity> entity) where D : BaseModel
        {
            List<D> result = new List<D>();
            foreach(var item in entity)
            {
                result.Add(item.EntityToDto<D>());
            }
            return result;
        }

        /// <summary>
        /// Entity转Dto
        /// IEnumerable-->List
        /// </summary>
        /// <typeparam name="D"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static List<D> EntityToDto<D>(this IEnumerable<BaseEntity> entity) where D : BaseModel
        {
            List<D> result = new List<D>();
            foreach (var item in entity)
            {
                result.Add(item.EntityToDto<D>());
            }
            return result;
        }

    }
}

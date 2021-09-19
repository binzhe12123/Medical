using SY.Com.Medical.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.BLL
{
    /// <summary>
    /// 业务CURD基类,需要执行增删改查和数据库有映射的继承此类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CURDObject<T> where T : BaseEntity
    {
        #region 单条记录操作
        /// <summary>
        /// 单表单记录查询
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        protected T Get(int Id)
        {
            return default(T);
        }


        /// <summary>
        /// 新增单条记录,并返回新增记录唯一id
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        protected int Create(T t)
        {
            return 0;
        }

        /// <summary>
        /// 修改单条记录
        /// </summary>
        /// <param name="t"></param>
        protected void Update(T t)
        {

        }

        /// <summary>
        /// 删除单条记录
        /// </summary>
        /// <param name="t"></param>
        protected void Delete(T t)
        {

        }

        #endregion

        #region 多条记录操作
        /// <summary>
        /// 单表多记录查询
        /// </summary>
        /// <returns></returns>
        protected IEnumerable<T> Gets()
        {
            IEnumerable<T> result = new List<T>();
            return result;
        }

        /// <summary>
        /// 多条记录更新
        /// </summary>
        /// <param name="tcol"></param>
        protected void Update(IEnumerable<T> collection)
        {

        }

        /// <summary>
        /// 多条记录插入
        /// </summary>
        /// <param name="collection"></param>
        protected void Insert(IEnumerable<T> collection)
        {

        }

        #endregion

    }
}

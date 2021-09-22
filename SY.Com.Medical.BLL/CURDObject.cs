using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using SY.Com.Medical.Attribute;
using SY.Com.Medical.Entity;
using SY.Com.Medical.Repository;
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
        public BaseRepository<T> db;
        public T Entity { get; set; }



        #region 单条记录操作
        /// <summary>
        /// 单表单记录查询
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public T Get(int Id)
        {
            string tableName = ReadAttribute<DB_TableAttribute>.getKey(Entity).ToString();
            string tablekey = ReadAttribute<DB_KeyAttribute>.getKey(Entity).ToString();
            return db.Get(Id, tableName, tablekey);
        }


        /// <summary>
        /// 新增单条记录,并返回新增记录唯一id
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Create(T t)
        {
            return db.Create(t);
        }

        /// <summary>
        /// 修改单条记录
        /// </summary>
        /// <param name="t"></param>
        public void Update(T t)
        {
            db.Update(t);
        }

        /// <summary>
        /// 删除单条记录
        /// </summary>
        /// <param name="t"></param>
        public void Delete(T t)
        {
            db.Delete(t);
        }

        #endregion

        #region 多条记录操作
        /// <summary>
        /// 单表多记录查询
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> Gets(T t)
        {
            return db.Gets(t);
        }

        public Tuple<IEnumerable<T>, int> GetsPage(T t, int pageSize, int pageIndex)
        {
            return db.GetsPage(t, pageSize, pageIndex);
        }

        /// <summary>
        /// 多条记录更新
        /// </summary>
        /// <param name="tcol"></param>
        public void Update(IEnumerable<T> collection)
        {
            db.Update(collection);
        }

        /// <summary>
        /// 多条记录插入
        /// </summary>
        /// <param name="collection"></param>
        public void Insert(IEnumerable<T> collection)
        {
            db.Insert(collection);
        }

        #endregion

    }
}

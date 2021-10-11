using Dapper;
using SY.Com.Medical.Attribute;
using SY.Com.Medical.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Repository.Clinic
{
    /// <summary>
    /// 病历数据层
    /// </summary>
    public class CaseBookRepository : BaseRepository<CaseBookEntity>
    {

        /// <summary>
        /// 获取有导航属性的单条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CaseBookEntity getOne(int id)
        {
            return Get<PatientEntity>(id, (casebook, patien) =>
            {
                casebook.Patient = patien;
                return casebook;
            }, "PatientId");
        }

        /// <summary>
        /// 获取有导航属性的多条记录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public IEnumerable<CaseBookEntity> getMany(CaseBookEntity entity)
        {
            return Gets<PatientEntity>(entity, (casebook, patien) =>
            {
                casebook.Patient = patien;
                return casebook;
            }, "PatientId");
        }

        /// <summary>
        /// 获取有导航属性的多条记录 - 分页
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public Tuple<IEnumerable<CaseBookEntity>,int> getPages(CaseBookEntity entity,int pageSize,int pageIndex)
        {
            
            var datas = GetsPage<PatientEntity>(entity, (casebook, patien) =>
            {
                casebook.Patient = patien;
                return casebook;
            }, pageSize, pageIndex, "PatientId");
            Tuple<IEnumerable<CaseBookEntity>, int> result = new Tuple<IEnumerable<CaseBookEntity>, int>(datas.Item1,datas.Item2);
            return result;
        }
    }
}

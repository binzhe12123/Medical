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
                casebook.PatientInfo = patien;
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
                casebook.PatientInfo = patien;
                return casebook;
            }, "PatientId");
        }
    }
}

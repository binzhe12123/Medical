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
    /// 数据访问层
    /// </summary>
    public class ChargeRecordRepository : BaseRepository<ChargeRecordEntity> 
	{ 
        public ChargeRecordEntity getByOutpatientId(int tenantId,int outpatientId,string chargetype)
        {
            string sql = @" Select * From ChargeRecords 
                            Where TenantId=@TenantId And PatientId=@PatientId And ChargeType= '"+ chargetype + "' ";
            var mods =_db.Query<ChargeRecordEntity>(sql, new { TenantId = tenantId, PatientId = outpatientId });
            if(mods!=null && mods.Any())
            {
                return mods.FirstOrDefault();
            }
            return null;
        }
	}
} 
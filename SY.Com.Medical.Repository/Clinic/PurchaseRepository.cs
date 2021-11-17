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
    public class PurchaseRepository : BaseRepository<PurchaseEntity> 
	{ 
        public Tuple<IEnumerable<PurchaseEntity>, int> page(long tenantId,int pageSize,int pageIndex,DateTime? start,DateTime? end,string goodName)
        {
            string sql = " Select * From Purchases Where TenantId="+ tenantId +" ";
            string sqlwhere = "  ";
            if (start != null)
            {
                sqlwhere += " And CreateTime >= '"+ start + "' ";
            }
            if(end != null)
            {
                sqlwhere += " And CreateTime <= '"+ end +"' ";
            }
            if(string.IsNullOrEmpty(goodName))
            {
                sqlwhere += " And PurchaseId In( Select PurchaseId From PurchasesGoods Where TenantId="+ tenantId + " And GoodName like '%"+ goodName +"%' ) ";
            }
            string sqlcommon = @" select count(1) as nums from ( " + sql + sqlwhere + @" )t;
                                ; Select ROW_NUMBER() over(order by purchaseid) row_id,* From ( " + sql + sqlwhere + " )t where row_id between "+ ((pageIndex-1)*pageSize) +" and "+ (pageIndex * pageSize) +" ";
            var grid = _db.QueryMultiple(sql);
            var total = grid.Read<int>().FirstOrDefault();
            var entitys = grid.Read<PurchaseEntity>();
            Tuple<IEnumerable<PurchaseEntity>, int> result = new Tuple<IEnumerable<PurchaseEntity>, int>(entitys, total);
            return result;
        }

    }
} 
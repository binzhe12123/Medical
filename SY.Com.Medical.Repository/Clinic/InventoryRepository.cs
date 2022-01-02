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
    public class InventoryRepository : BaseRepository<InventoryEntity> 
	{
        public Tuple<IEnumerable<InventoryEntity>, int> page(long tenantId, int pageSize, int pageIndex, DateTime? start, DateTime? end, string goodName)
        {
            string sql1 = " Select * From Inventorys Where TenantId=" + tenantId + " ";
            string sql2 = " Select ROW_NUMBER() over(order by InventoryId) row_id,* From Inventorys Where TenantId=" + tenantId + " ";            
            string sqlwhere = "  ";
            if (start != null)
            {
                sqlwhere += " And CreateTime >= '" + start + "' ";
            }
            if (end != null)
            {
                sqlwhere += " And CreateTime <= '" + end + "' ";
            }
            if (string.IsNullOrEmpty(goodName))
            {
                sqlwhere += " And InventoryId In( Select InventoryId From InventoryGoods Where TenantId=" + tenantId + " And GoodName like '%" + goodName + "%' ) ";
            }
            string sqlcommon = @" select count(1) as nums from ( " + sql1 + sqlwhere + @" )t;
                                ; Select * From ( " + sql2 + sqlwhere + " )t where row_id between " + ((pageIndex - 1) * pageSize) + " and " + (pageIndex * pageSize) + " ";
            var grid = _db.QueryMultiple(sqlcommon);
            var total = grid.Read<int>().FirstOrDefault();
            var entitys = grid.Read<InventoryEntity>();
            Tuple<IEnumerable<InventoryEntity>, int> result = new Tuple<IEnumerable<InventoryEntity>, int>(entitys, total);
            return result;
        }
    }
} 
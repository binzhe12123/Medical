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
    public class GoodRepository : BaseRepository<GoodEntity> 
	{ 
        /// <summary>
        /// 获取药品或者项目源数据,分页
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="goodType"></param>
        /// <param name="goodSort"></param>
        /// <param name="searchKey"></param>
        /// <returns></returns>
        public Tuple<int,List<GoodEntity>> getPagesByWhere(int tenantId,int pageSize,int pageIndex,int goodType = 0,int goodSort = 0 ,string searchKey = "")
        {
            Tuple<int, List<GoodEntity>> result;
            string sql = " Select ROW_NUMBER() over(order by goodid desc) row_id,* From Goods Where tenantId = @TenantId ";
            string sqlwhere = "";
            if(goodType > 0)
            {
                sqlwhere += " And GoodType = "+ goodType +" ";
            }
            if(goodSort > 0)
            {
                sqlwhere += " And GoodSort = "+ goodSort +" ";
            }
            if(!string.IsNullOrEmpty(searchKey) && searchKey.Trim() != "")
            {
                sqlwhere += " And SearchKey like '%"+ searchKey + "%' ";
            }
            sql = sql + sqlwhere;
            sql = " Select Count(*) as total From ( " + sql + " )as t ;Select * From ( " + sql + " )as t where row_id between @start and @end ";
            var grid = _db.QueryMultiple(sql, new { TenantId = tenantId, start = (pageIndex - 1) * pageSize + 1, end = pageIndex * pageSize });
            int total =grid.Read<int>().First();
            IEnumerable<GoodEntity> collection = grid.Read<GoodEntity>();
            if (collection == null || !collection.Any())
            {
                return null;
            }
            result = new Tuple<int, List<GoodEntity>>(total, collection.ToList());
            return result;
        }

                

	}
} 
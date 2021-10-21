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
        /// 获取药品分类
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Dictionary<int, string>> getGoodSort(string dictype)
        {
            string sql = " Select DicId,DicValue From Dics Where DicType=@Dictype And IsDelete=1 ";
            return _db.Query<Dictionary<int, string>>(sql,new { Dictype = dictype });
        }
	}
} 
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
    public class RegisterProjectRepository : BaseRepository<RegisterProjectEntity> 
	{ 
        public  List<RegisterProjectEntity> getByTenant(int tenantId)
        {
            string sql = " Select * From dbo.RegisterProjects Where TenantId = @TenantId And IsDelete = 1 ";
            var mods= _db.Query<RegisterProjectEntity>(sql, new { TenantId = tenantId });
            if(mods == null || !mods.Any())
            {
                return null;
            }
            return mods.ToList();
        }
	}
} 
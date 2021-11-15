using Dapper;
using SY.Com.Medical.Attribute;
using SY.Com.Medical.Entity;
using SY.Com.Medical.Extension;
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
    public class DicRepository : BaseRepository<DicEntity> 
	{ 
        public List<DicEntity> getDic(int tenantId,string keyFirst)
        {
            return getDic(tenantId, keyFirst, null, null);
        }

        public List<DicEntity> getDic(int tenantId, string keyFirst,string keySecond)
        {
           return getDic(tenantId, keyFirst, keySecond, null);
        }

        public List<DicEntity> getDic(int tenantId, string keyFirst,string keySecond,string searchKey)
        {
            string sql = " Select * From Dics Where IsEnable=1 And IsDelete = 1 And (TenantId = 0 Or TenantId = @TenantId ) ";
            string sqlwhere = "";
            if(!string.IsNullOrEmpty(keyFirst))
            {
                sqlwhere += " And KeyFirst= '"+ keyFirst +"' ";
            }
            if (!string.IsNullOrEmpty(keySecond))
            {
                sqlwhere += " And KeySecond= '"+ keySecond +"' ";
            }
            if (!string.IsNullOrEmpty(searchKey))
            {
                sqlwhere += " And SearchKey like '%"+ searchKey +"%' ";
            }
            sql = sql + sqlwhere;
            var mod = _db.Query<DicEntity>(sql, new { TenantId = tenantId });
            if (mod != null && mod.Any())
            {
                return mod.ToList();
            }
            return null;
        }

        public string getIdByValue(int tenantId,string keyFirst,string keySecond,int id)
        {
            string sql = " Select DicValue From Dics Where IsEnable=1 And IsDelete = 1 And (TenantId = 0 Or TenantId = @TenantId ) ";
            string sqlwhere = "";
            if (!string.IsNullOrEmpty(keyFirst))
            {
                sqlwhere += " And KeyFirst= '" + keyFirst + "' ";
            }
            if (!string.IsNullOrEmpty(keySecond))
            {
                sqlwhere += " And KeySecond= '" + keySecond + "' ";
            }
            if (id > 0)
            {
                sqlwhere += " And DicId = " + id + " ";
            }
            sql = sql + sqlwhere;
            var result = _db.Query<string>(sql, new { TenantId = tenantId });
            if(result != null && result.Any())
            {
                return result.FirstOrDefault();
            }
            return "";
        }

        public int Add(int tenantId, string dicValue, string keyFirst)
        {
            return Add(tenantId, dicValue, keyFirst, "");
        }

        public int Add(int tenantId, string dicValue,string keyFirst,string keySecond)
        {
            DicEntity mod = new DicEntity();
            mod.TenantId = tenantId;
            mod.KeyFirst = keyFirst;
            mod.KeySecond = keySecond;
            mod.DicValue = dicValue;
            mod.SearchKey = dicValue.GetPinYinHead();
            mod.IsEnable = Enum.Enable.启用;
            mod.IsDelete = Enum.Delete.正常;
            mod.CreateTime = DateTime.Now;
            return Create(mod);
        }



    }
} 
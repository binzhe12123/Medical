using SY.Com.Medical.BLL.Clinic;
using SY.Com.Medical.Entity;
using SY.Com.Medical.Extension;
using SY.Com.Medical.Model;
using SY.Com.Medical.Repository.Clinic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SY.Com.Medical.BLL.Clinic
{
    /// <summary>
    /// 业务逻辑层
    /// </summary>
    public class Dic 
	{
		private DicRepository db;
		public Dic()
		{
			db = new DicRepository();
		}

		public List<DicKeyValueModel> getValueByKey(DicSearchModel mod)
        {			
			List<DicKeyValueModel> result = new List<DicKeyValueModel>();
			var entitys = db.getDic(mod.tenantid, mod.keyFirst, mod.keySecond, mod.searchKey);
			if(entitys == null || entitys.Any())
            {
				return null;
            }
			entitys.ForEach(x =>
			{
				DicKeyValueModel mod = new DicKeyValueModel();
				mod.Id = x.DicId;
				mod.Value = x.DicValue;
			});
			return result;
		}

		public string getValueByKey(int tenantId, string keyFirst, string keySecond, int id)
        {
			return db.getIdByValue(tenantId, keyFirst, keySecond, id);
        }

		public int Insert(int tenantId,string value,string keyFirst,string keySecond)
        {
			return db.Add(tenantId, value, keyFirst, keySecond);
        }

	}
} 
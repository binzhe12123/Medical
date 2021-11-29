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
    public class Outpatient 
	{
		private OutpatientRepository db;
		public Outpatient()
		{
			db = new OutpatientRepository();
		}

		/// <summary>
		/// 挂单处方列表
		/// </summary>
		/// <param name="tenantId"></param>
		/// <param name="pageSize"></param>
		/// <param name="pageIndex"></param>
		/// <param name="searchKey"></param>
		/// <param name="start"></param>
		/// <param name="end"></param>
		/// <returns></returns>
		public Tuple<List<OutpatientListModel>, int> getNoPaid(int tenantId, int pageSize, int pageIndex, string searchKey, DateTime? start, DateTime? end)
        {
			List<OutpatientListModel> modellist = new List<OutpatientListModel>();
			Patient pat = new Patient();			
			var tuple = db.getNoPaid(tenantId, pageSize, pageIndex, searchKey, start, end);
			tuple.Item1.ForEach(x =>
			{
				OutpatientListModel mod = new OutpatientListModel();
				var pamod = pat.get(x.PatientId);
				mod.OutpatientId = x.OutpatientId;
				mod.TenantId = x.TenantId;				
				mod.PatientName = pamod.PatientName;
				mod.Sex = pamod.Sex == 1 ? "男" : "女";
				mod.Age = pamod.Age;
				mod.Phone = pamod.Phone;
				mod.DoctorName = x.DoctorName;
				mod.Cost = x.Cost;
				mod.CreateTime = x.CreateTime;
				mod.PrescriptionCount = x.PrescriptionCount;
				modellist.Add(mod);
			});
			Tuple<List<OutpatientListModel>, int> result = new Tuple<List<OutpatientListModel>, int>(modellist, tuple.Item2);
			return result;
        }

		/// <summary>
		/// 历史处方列表
		/// </summary>
		/// <param name="tenantId"></param>
		/// <param name="pageSize"></param>
		/// <param name="pageIndex"></param>
		/// <param name="searchKey"></param>
		/// <param name="start"></param>
		/// <param name="end"></param>
		/// <returns></returns>
		public Tuple<List<OutpatientListModel>, int> getHistory(int tenantId, int pageSize, int pageIndex, string searchKey, DateTime? start, DateTime? end)
        {
			List<OutpatientListModel> modellist = new List<OutpatientListModel>();
			Patient pat = new Patient();
			var tuple = db.getHistoryPaid(tenantId, pageSize, pageIndex, searchKey, start, end);
			tuple.Item1.ForEach(x =>
			{
				OutpatientListModel mod = new OutpatientListModel();
				var pamod = pat.get(x.PatientId);
				mod.OutpatientId = x.OutpatientId;
				mod.TenantId = x.TenantId;
				mod.PatientName = pamod.PatientName;
				mod.Sex = pamod.Sex == 1 ? "男" : "女";
				mod.Age = pamod.Age;
				mod.Phone = pamod.Phone;
				mod.Cost = x.Cost;
				mod.DoctorName = x.DoctorName;
				mod.CreateTime = x.CreateTime;
				mod.PrescriptionCount = x.PrescriptionCount;
				modellist.Add(mod);
			});
			Tuple<List<OutpatientListModel>, int> result = new Tuple<List<OutpatientListModel>, int>(modellist, tuple.Item2);
			return result;
		}

		/// <summary>
		/// 获取单个处方
		/// </summary>
		/// <param name="tenantId"></param>
		/// <param name="outpatientId"></param>
		/// <returns></returns>
		public OutpatientStructure getStructure(int tenantId, int outpatientId)
        {
			return db.getStructure(tenantId, outpatientId);
        }

		/// <summary>
		/// 新增门诊
		/// </summary>
		/// <param name="structure"></param>
		/// <returns></returns>
		public int AddStructure(OutpatientAddStructure structure)
        {
			return db.AddStructure(structure);
        }

		/// <summary>
		/// 修改门诊
		/// </summary>
		/// <param name="structure"></param>
		/// <returns></returns>
		public int UpdateStructure(OutpatientAddStructure structure)
        {
			return db.UpdateStructure(structure);
        }



	}
} 
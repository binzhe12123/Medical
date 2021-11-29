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

		/// <summary>
		/// 门诊收费
		/// </summary>
		/// <param name="mod"></param>
		/// <returns></returns>
		public int Charge(OutpatientChargeModel mod)
        {
			var entity = db.Get(mod.OutpatientId);
			if(entity.IsPay == 1 || entity.IsBack == 1)
            {
				throw new MyException("该门诊已经收费");
            }
			//修改支付状态和医保结算时,医保结算号,医保余额
			db.UpdateIsPay(mod.TenantId, mod.OutpatientId,mod.setl_id,Convert.ToInt64(mod.Balc * 1000));

			//保存退费记录
			ChargeRecord chargebll = new ChargeRecord();
			ChargeRecordEntity chargeentity = new ChargeRecordEntity();
			chargeentity.TenantId = mod.TenantId;
			chargeentity.PatientId = entity.PatientId;
			chargeentity.RegisterId = 0;
			chargeentity.SeeDoctorId = mod.OutpatientId;
			chargeentity.Price = Convert.ToInt64(mod.Cost * 1000);
			chargeentity.ChargeType = "门诊收费";
			if (!string.IsNullOrEmpty(entity.mdtrt_id))
			{
				chargeentity.PayYB = Convert.ToInt64(mod.YBCost * 1000);
				chargeentity.PayCash = Convert.ToInt64(mod.CashCost * 1000);
			}
			else if(mod.PayWay == 0)
			{
				chargeentity.PayCash = chargeentity.Price;
			}else if(mod.PayWay == 1)
            {
				chargeentity.PayWx = chargeentity.Price;
			}else if(mod.PayWay == 2)
            {
				chargeentity.PayAli = chargeentity.Price;
			}else if(mod.PayWay == 3)
            {
				chargeentity.PayBank = chargeentity.Price;
			}
			int chargeid = chargebll.add(chargeentity);
			return chargeid;
        }

		/// <summary>
		/// 医保费用明细撤销时修改chrg_bchno
		/// </summary>
		/// <param name="tenantId"></param>
		/// <param name="outpatientId"></param>
		public void Updatechrgbchno(int tenantId, int outpatientId)
        {
			db.Updatechrgbchno(tenantId, outpatientId);
        }

	}
} 
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
    public class Prescription 
	{
		private PrescriptionRepository db;
		public Prescription()
		{
			db = new PrescriptionRepository();
		}
		///<summary> 
		///获取详情记录
		///</summary> 
		///<param name="id"></param>
		/// <returns></returns>
		public PrescriptionModel get(int id)
		{
			return db.Get(id).EntityToDto<PrescriptionModel>();
		}
		///<summary> 
		///获取列表-分页
		///</summary> 
		///<param name="request"></param>
		/// <returns></returns>
		public Tuple<IEnumerable<PrescriptionModel>,int> gets(PrescriptionRequest request)
		{
			var datas  = db.GetsPage(request.DtoToEntity<PrescriptionEntity>(), request.PageSize, request.PageIndex);
			Tuple<IEnumerable<PrescriptionModel>, int> result = new(datas.Item1.EntityToDto<PrescriptionModel>(), datas.Item2);
			return result;
		}
		///<summary> 
		///新增
		///</summary> 
		///<param name="request"></param>
		/// <returns></returns>
		public int add(PrescriptionAdd request)
		{
			return db.Create(request.DtoToEntity<PrescriptionEntity>());
		}
		///<summary> 
		///修改
		///</summary> 
		///<param name="request"></param>
		/// <returns></returns>
		public void update(PrescriptionUpdate request)
		{
			db.Update(request.DtoToEntity<PrescriptionEntity>());
		}
		///<summary> 
		///删除
		///</summary> 
		///<param name="request"></param>
		/// <returns></returns>
		public void delete(PrescriptionDelete request)
		{
			db.Delete(request.DtoToEntity<PrescriptionEntity>());
		}
	}
} 
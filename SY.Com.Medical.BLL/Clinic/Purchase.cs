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
    public class Purchase 
	{
		private PurchaseRepository db;
		public Purchase()
		{
			db = new PurchaseRepository();
		}
		///<summary> 
		///获取详情记录
		///</summary> 
		///<param name="id"></param>
		/// <returns></returns>
		public PurchaseModel get(int id)
		{
			return db.Get(id).EntityToDto<PurchaseModel>();
		}
		///<summary> 
		///获取列表-分页
		///</summary> 
		///<param name="request"></param>
		/// <returns></returns>
		public Tuple<IEnumerable<PurchaseModel>,int> gets(PurchaseRequest request)
		{
			var datas  = db.GetsPage(request.DtoToEntity<PurchaseEntity>(), request.PageSize, request.PageIndex);
			Tuple<IEnumerable<PurchaseModel>, int> result = new(datas.Item1.EntityToDto<PurchaseModel>(), datas.Item2);
			return result;
		}
		///<summary> 
		///新增
		///</summary> 
		///<param name="request"></param>
		/// <returns></returns>
		public int add(PurchaseAdd request)
		{
			return db.Create(request.DtoToEntity<PurchaseEntity>());
		}
		///<summary> 
		///修改
		///</summary> 
		///<param name="request"></param>
		/// <returns></returns>
		public void update(PurchaseUpdate request)
		{
			db.Update(request.DtoToEntity<PurchaseEntity>());
		}
		///<summary> 
		///删除
		///</summary> 
		///<param name="request"></param>
		/// <returns></returns>
		public void delete(PurchaseDelete request)
		{
			db.Delete(request.DtoToEntity<PurchaseEntity>());
		}
	}
} 
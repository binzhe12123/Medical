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
    public class PurchasesGood 
	{
		private PurchasesGoodRepository db;
		private GoodRepository goodrepository = new GoodRepository();
		public PurchasesGood()
		{
			db = new PurchasesGoodRepository();
		}


		/// <summary>
		/// 采购页面搜索药品/材料
		/// </summary>
		/// <returns></returns>
		public Tuple<List<PurchasesGoodSearchResponse>,int>  searchGoods(PurchasesGoodSearchRequest mod)
        {
			List<PurchasesGoodSearchResponse> resp = new List<PurchasesGoodSearchResponse>();
			var goodentity = goodrepository.getPagesByWhere(mod.TenantId, mod.PageSize, mod.PageIndex, mod.GoodType, 0, mod.SearchKey);
			var total = goodentity.Item1;
			if(goodentity.Item2 != null && goodentity.Item2.Any())
            {
				goodentity.Item2.ForEach(x =>
				{
					PurchasesGoodSearchResponse mod = new PurchasesGoodSearchResponse();
					mod.GoodId = x.GoodId;
					mod.GoodName = x.GoodName;
					mod.Norm = x.Norm;
					mod.Factory = x.Factory;
					mod.SalesUnit = x.SalesUnit;
					mod.Units = new UnitModel() { SalesUnit = x.SalesUnit, StockUnit = x.SalesUnit };
					mod.Ratio = x.Ratio;
					mod.Stock = x.Stock;
					resp.Add(mod);
				});
            }
			Tuple<List<PurchasesGoodSearchResponse>, int> result = new Tuple<List<PurchasesGoodSearchResponse>, int>(resp, total);
			return result;
		}

		/// <summary>
		/// 采购
		/// </summary>
		/// <param name="mod"></param>
		/// <returns></returns>
		public bool Purchases(List<PurchasesGoodModel> mod)
        {
			bool result = false;
			//
			return result;
        }


		///<summary> 
		///获取详情记录
		///</summary> 
		///<param name="id"></param>
		/// <returns></returns>
		public PurchasesGoodModel get(int id)
		{
			return db.Get(id).EntityToDto<PurchasesGoodModel>();
		}
		///<summary> 
		///获取列表-分页
		///</summary> 
		///<param name="request"></param>
		/// <returns></returns>
		public Tuple<IEnumerable<PurchasesGoodModel>,int> gets(PurchasesGoodRequest request)
		{
			var datas  = db.GetsPage(request.DtoToEntity<PurchasesGoodEntity>(), request.PageSize, request.PageIndex);
			Tuple<IEnumerable<PurchasesGoodModel>, int> result = new(datas.Item1.EntityToDto<PurchasesGoodModel>(), datas.Item2);
			return result;
		}
		///<summary> 
		///新增
		///</summary> 
		///<param name="request"></param>
		/// <returns></returns>
		public int add(PurchasesGoodAdd request)
		{
			return db.Create(request.DtoToEntity<PurchasesGoodEntity>());
		}
		///<summary> 
		///修改
		///</summary> 
		///<param name="request"></param>
		/// <returns></returns>
		public void update(PurchasesGoodUpdate request)
		{
			db.Update(request.DtoToEntity<PurchasesGoodEntity>());
		}
		///<summary> 
		///删除
		///</summary> 
		///<param name="request"></param>
		/// <returns></returns>
		public void delete(PurchasesGoodDelete request)
		{
			db.Delete(request.DtoToEntity<PurchasesGoodEntity>());
		}
	}
} 
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
		private PurchaseRepository purchaseDb = new PurchaseRepository();
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
			long totalmoney = 0;
			List<PurchasesGoodEntity> targetEntity = new List<PurchasesGoodEntity>();
			mod.ForEach(x =>
			{
				PurchasesGoodEntity entity = new PurchasesGoodEntity();
				entity.TenantId = x.TenantId;
				entity.GoodId = x.GoodId;
				entity.GoodName = x.GoodName;
				entity.Norm = x.Norm;
				entity.Factory = x.Factory;
				entity.SalesUnit = x.SalesUnit;
				entity.StockUnit = x.StockUnit;
				entity.Ratio = x.Ratio;
				entity.Stock = x.Stock;
				entity.ProductTime = x.ProductTime;
				entity.ValidTime = x.ValidTime;
				entity.BatchNum = x.BatchNum;
				entity.PurchasePrice = Convert.ToInt64(x.PurchasePrice * 1000);
				entity.SellPrice = Convert.ToInt64(x.SellPrice * 1000);
				totalmoney += x.SalesUnit == x.StockUnit ? (Convert.ToInt64(x.PurchasePrice * 1000) * x.Stock) : (x.Ratio * Convert.ToInt64(x.PurchasePrice * 1000) * x.Stock);
				targetEntity.Add(entity);
			});
			PurchaseEntity purchaseEntity = new PurchaseEntity();
			purchaseEntity.TenantId = mod.First().TenantId;
			purchaseEntity.GoodsCount = mod.Count;
			purchaseEntity.GoodsMoney = totalmoney;
			purchaseEntity.Supplier = "";
			purchaseEntity.CreateTime = DateTime.Now;
			purchaseEntity.Createtor = mod.First().UserId;
			purchaseEntity.IsEnable = Enum.Enable.启用 ;
			purchaseEntity.IsDelete = Enum.Delete.正常;
			var id = purchaseDb.Create(purchaseEntity);
			targetEntity.ForEach(x => x.PurchaseId = id);
			db.Inserts(targetEntity);
			db.UpdateStockAndPrice(targetEntity);						
			return true;
        }

		public List<PurchasesGoodResponse> getPurchases(long tenantId,long purchaseId)
        {
			List<PurchasesGoodResponse> result = new List<PurchasesGoodResponse>();
			var entity = db.getPurchasesById(tenantId, purchaseId);
			if(entity == null || !entity.Any())
            {
				return new List<PurchasesGoodResponse>();
				//throw new MyException("无数据");
            }
			entity.ForEach(x =>
			{
				PurchasesGoodResponse mod = new PurchasesGoodResponse();
				mod.GoodId = x.GoodId;
				mod.GoodName = x.GoodName;
				mod.Norm = x.Norm;
				mod.Factory = x.Factory;
				mod.SalesUnit = x.SalesUnit;
				mod.StockUnit = x.StockUnit;
				mod.Stock = x.Stock;
				mod.ProductTime = x.ProductTime;
				mod.ValidTime = x.ValidTime;
				mod.BatchNum = x.BatchNum;
				mod.PurchasePrice = Math.Round(x.PurchasePrice / 1000.00,3);
				mod.SellPrice = Math.Round(x.SellPrice / 1000.00, 3);
				result.Add(mod);
			});
			return result;
		}

	}
} 
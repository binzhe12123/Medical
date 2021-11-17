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
    public class InventoryGood 
	{
		private InventoryGoodRepository db;
		private GoodRepository goodrepository = new GoodRepository();
		private InventoryRepository inventoryDB = new InventoryRepository();
		public InventoryGood()
		{
			db = new InventoryGoodRepository();
		}		
		/// <summary>
		/// 盘点页面搜索药品/材料
		/// </summary>
		/// <returns></returns>
		public Tuple<List<InventoryGoodSearchResponse>, int> searchGoods(InventoryGoodSearchRequest mod)
		{
			List<InventoryGoodSearchResponse> resp = new List<InventoryGoodSearchResponse>();
			var goodentity = goodrepository.getPagesByWhere(mod.TenantId, mod.PageSize, mod.PageIndex, mod.GoodType, 0, mod.SearchKey,true);
			var total = goodentity.Item1;
			if (goodentity.Item2 != null && goodentity.Item2.Any())
			{
				goodentity.Item2.ForEach(x =>
				{
					InventoryGoodSearchResponse mod = new InventoryGoodSearchResponse();
					mod.GoodId = x.GoodId;
					mod.GoodName = x.GoodName;
					mod.Norm = x.Norm;
					mod.Factory = x.Factory;
					mod.SalesUnit = x.SalesUnit;
					mod.Stock = x.Stock;
					resp.Add(mod);
				});
			}
			Tuple<List<InventoryGoodSearchResponse>, int> result = new Tuple<List<InventoryGoodSearchResponse>, int>(resp, total);
			return result;
		}

		public bool Inventory(List<InventoryGoodRequest> mod)
        {
			if(mod == null || !mod.Any())
            {
				return false;
            }
			List<InventoryGoodEntity> entitys = new List<InventoryGoodEntity>();
			mod.ForEach(model =>
			{
				InventoryGoodEntity entity = new InventoryGoodEntity();
				entity.GoodId = model.GoodId;
				entity.GoodName = model.GoodName;
				entity.Norm = model.Norm;
				entity.Factory = model.Factory;
				entity.SalesUnit = model.SalesUnit;
				if(model.StockAfter < 0)
                {
					throw new MyException("盘点库存不能小于0");
                }
				entity.Stock = model.Stock;
				entity.StockAfter = model.StockAfter;
				entity.Price = Convert.ToInt64(model.Price * 1000);
				entity.PriceAfter = Convert.ToInt64(model.PriceAfter * 1000);
				entitys.Add(entity);
			});
			InventoryEntity inventoryentity = new InventoryEntity();
			inventoryentity.TenantId = mod.First().TenantId;
			inventoryentity.GoodsCount = mod.Count;
			inventoryentity.CreateTime = DateTime.Now;
			inventoryentity.Createtor = 0;
			inventoryentity.IsEnable = Enum.Enable.启用;
			inventoryentity.IsDelete = Enum.Delete.正常;
			var inventoryId = inventoryDB.Create(inventoryentity);
			entitys.ForEach(entity =>
			{
				entity.InventoryId = inventoryId;
			});
			db.Inventory(entitys);
			db.UpdateGoodStockAndPrice(entitys);
			return true;
		}

		public double CalcAfterPrice(long tenantId, long goodId, int stock, int stockAfter)
        {
			var price = db.CalcAfterPrice(tenantId, goodId, stock, stockAfter);
			return Math.Round(price / 1000.00,3);
        }

		public List<InventoryGoodModel> getInventory(long tenantId,long inventoryId)
        {
			List<InventoryGoodModel> result = new List<InventoryGoodModel>();
			var entitys = db.getInventoryById(tenantId, inventoryId);
			entitys.ToList().ForEach(entity =>
			{
				InventoryGoodModel mod = new InventoryGoodModel();
				mod.InventoryId = entity.InventoryId;
				mod.GoodId = entity.GoodId;
				mod.GoodName = entity.GoodName;
				mod.Norm = entity.Norm;
				mod.Factory = entity.Factory;
				mod.SalesUnit = entity.SalesUnit;
				mod.Stock = entity.Stock;
				mod.StockAfter = entity.StockAfter;
				mod.Price = Math.Round(entity.Price / 1000.00, 3);
				mod.PriceAfter = Math.Round(entity.PriceAfter / 1000.00, 3);
				result.Add(mod);
			});
			return result;
		}

	}
} 
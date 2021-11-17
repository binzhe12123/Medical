using Dapper;
using SY.Com.Medical.Attribute;
using SY.Com.Medical.Entity;
using SY.Com.Medical.Model;
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
    public class InventoryGoodRepository : BaseRepository<InventoryGoodEntity> 
	{ 
        public int Inventory(List<InventoryGoodEntity> entitys)
        {
            string sql = @" Insert Into InventoryGoods(TenantId,InventoryId,GoodId,GoodName,Norm,Factory,SalesUnit,Stock,StockAfter
                                                        ,Price,PriceAfter,CreateTime,IsEnalbe,IsDelete) 
                            Values(@TenantId,@InventoryId,@GoodId,@GoodName,@Norm,@Factory,@SalesUnit,@Stock,@StockAfter
                                                        ,@Price,@PriceAfter,getdate(),1,1)";
            return _db.Execute(sql, entitys);
        }

        /// <summary>
        /// 扣减库存,调整价格
        /// 如果库存增加,则增加到最后一次采购商
        /// 如果库存减少,则从先采购的量开始减少
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        public bool UpdateGoodStockAndPrice(List<InventoryGoodEntity> entitys)
        {
            var strGooids = string.Join(',', entitys.Select(x => x.GoodId).ToList());
            var tenantid = entitys.First().TenantId;
            string sqlpurchase = @" Select GoodId,Consume,id,TenantId,PurchaseId From PurchasesGoods Where TenantId=@TenantId And Consume > 0 And IsDelete = 1 And GoodId in@GoodId Order By PurchaseId Asc ";
            var purchase = _db.Query<PurchasesGoodEntity>(sqlpurchase, new { TenantId = tenantid, GoodId = strGooids });
            if(purchase != null && purchase.Any())
            {
                entitys.ForEach(inventory =>
                {
                    var somepurcha = purchase.ToList().FindAll(purcha => purcha.GoodId == inventory.GoodId).ToList();
                    var stockdiff = inventory.StockAfter - inventory.Stock;
                    if (stockdiff >= 0)
                    {
                        somepurcha[somepurcha.Count - 1].Consume += stockdiff;
                    }
                    else {
                        foreach (var item in somepurcha)
                        {
                            if (stockdiff < 0)
                            {
                                if (item.Consume >= Math.Abs(stockdiff))
                                {
                                    item.Consume = item.Consume - Math.Abs(stockdiff);
                                    stockdiff = 0;
                                }
                                else
                                {
                                    item.Consume = 0;
                                    stockdiff = stockdiff + item.Consume;
                                }
                            }
                        }
                    }
                });

                string sqlupdatepurchase = @" Update PurchasesGoods Set Consume = @Consume Where TenantId=@TenantId And PurchaseId=@PurchaseId And id=@id And GoodId=@GoodId ";
                _db.Execute(sqlupdatepurchase, purchase);
            }
            string sqlupdateprice = @" Update Goods Set Stock = @StockAfter,Price = @PriceAfter Where TenantId=@TenantId And GoodId=@GoodId   ";
            _db.Execute(sqlupdateprice, entitys);
            return true;

        }

        public long CalcAfterPrice(long tenantId,long goodId,int stock,int stockAfter)
        {
            string sql = @" Select GoodId,Consume,id,TenantId,PurchaseId From PurchasesGoods Where TenantId=@TenantId And Consume > 0 And IsDelete = 1 And GoodId  = @GoodId Order By PurchaseId Asc ";
            var purchase = _db.Query<PurchasesGoodEntity>(sql, new { TenantId = tenantId, GoodId = goodId });
            if(purchase != null && purchase.Any())
            {
                var stockdiff = stockAfter - stock;                
                foreach (var item in purchase)
                {
                    if(item.Consume >= Math.Abs(stockdiff))
                    {
                        return item.SellPrice;
                    }
                    else
                    {
                        stockdiff = stockdiff + item.Consume;
                    }
                }
            }
            return 0;

        }

        public List<InventoryGoodEntity> getInventoryById(long tenantId, long inventoryId)
        {
            string sql = @" Select * From InventoryGoods Where TenantId = @TenantId And InventoryId=@InventoryId ";
            var collection = _db.Query<InventoryGoodEntity>(sql, new { TenantId = tenantId, InventoryId = inventoryId });
            if (collection != null && collection.Any())
            {
                return collection.ToList();
            }
            return null;
        }

    }
} 
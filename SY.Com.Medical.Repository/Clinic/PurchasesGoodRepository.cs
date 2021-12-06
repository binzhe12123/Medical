using Dapper;
using SY.Com.Medical.Attribute;
using SY.Com.Medical.Entity;
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
    public class PurchasesGoodRepository : BaseRepository<PurchasesGoodEntity> 
	{ 

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        public int Inserts(List<PurchasesGoodEntity> entitys)
        {
            string sql = @" Insert Into PurchasesGoods(TenantId,PurchaseId,GoodId,GoodName,Norm,Factory,SalesUnit,StockUnit,Ratio,Stock
                                                       ,Consume,ProductTime,ValidTime,BatchNum,PurchasePrice,SellPrice,CreateTime,IsEnalbe,IsDelete)
                                                       Values(@TenantId,@PurchaseId,@GoodId,@GoodName,@Norm,@Factory,@SalesUnit,@StockUnit,@Ratio,@Stock
                                                       ,@Stock,@ProductTime,@ValidTime,@BatchNum,@PurchasePrice,@SellPrice,getdate(),1,1)  ";
            return _db.Execute(sql, entitys);
        }

        /// <summary>
        /// 先找到最老的采购批次的药品价格
        /// 修改库存量和价格
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        public int UpdateStockAndPrice(List<PurchasesGoodEntity> entitys)
        {            
            string sqlprice = @" Select GoodId,SellPrice From PurchasesGoods Where TenantId=@TenantId And Consume > 0 And IsDelete = 1 And GoodId in@GoodId Order By PurchaseId Asc  ";
            var purchaseprice = _db.Query<PurchasesGoodEntity>(sqlprice, new { TenantId = entitys.First().TenantId, GoodId = entitys.Select(x => x.GoodId).ToList() });
            string sql = "";
            if (purchaseprice == null || !purchaseprice.Any())
            {
                sql = @" Update Goods Set Stock = Stock + @Stock Where TenantId=@TenantId And GoodId=@GoodId ";
            }
            else {
                entitys.ForEach(x =>
                {
                    x.SellPrice = purchaseprice.ToList().Find(y=>y.GoodId == x.GoodId).SellPrice;
                });
                sql = @" Update Goods Set Stock = Stock + @Stock,Price = @SellPrice  Where TenantId=@TenantId  And GoodId=@GoodId ";

            }            
            return _db.Execute(sql, entitys);
        }

        public List<PurchasesGoodEntity> getPurchasesById(long tenantId, long purchaseId)
        {
            string sql = @" Select * From PurchasesGoods Where TenantId = @TenantId And PurchaseId=@PurchaseId ";
            var collection = _db.Query<PurchasesGoodEntity>(sql, new { TenantId = tenantId, PurchaseId = purchaseId });
            if(collection != null && collection.Any())
            {
                return collection.ToList();
            }
            return null;
        }

    }
} 
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

        public int UpdateStock(List<PurchasesGoodEntity> entitys)
        {
            string sql = @" Update Goods Set Stock = Stock + @Stock Where TenantId=@TenantId And GoodId=@GoodId ";
            return _db.Execute(sql, entitys);
        }

        public int UpdatePrice(List<PurchasesGoodEntity> entitys)
        {
            string sql = @" Select top 1 SellPrice From  PurchasesGoods Where TenantId=@TenantId And  ";
        }



    }
} 
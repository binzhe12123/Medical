using SY.Com.Medical.Attribute;
using SY.Com.Medical.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SY.Com.Medical.Entity
{
    /// <summary>
    /// 实体
    /// </summary>
    [DB_Table("InventoryGoods")]
    [DB_Key("id")]
    public class InventoryGoodEntity : BaseEntity 
	{ 
		///<summary> 
		///自增主键
		///</summary> 
		[DB_Key("id")]
		public int id {get;set;} 
		///<summary> 
		///租户id
		///</summary> 
		public long TenantId {get;set;} 
		///<summary> 
		///盘点单id
		///</summary> 
		public long InventoryId {get;set;} 
		///<summary> 
		///商品id
		///</summary> 
		public long GoodId {get;set;} 
		///<summary> 
		///商品名称
		///</summary> 
		public string GoodName {get;set;} 
		///<summary> 
		///规格
		///</summary> 
		public string Norm {get;set;} 
		///<summary> 
		///厂家
		///</summary> 
		public string Factory {get;set;} 
		///<summary> 
		///计价单位
		///</summary> 
		public string SalesUnit {get;set;} 
		///<summary> 
		///盘点前库存
		///</summary> 
		public int Stock {get;set;} 
		///<summary> 
		///盘点后库存
		///</summary> 
		public int StockAfter {get;set;} 
		///<summary> 
		///盘点前售价
		///</summary> 
		public long Price {get;set;} 
		///<summary> 
		///盘点后售价
		///</summary> 
		public long PriceAfter {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int IsEnalbe {get;set;} 
	}
} 
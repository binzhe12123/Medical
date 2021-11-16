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
    [DB_Table("PurchasesGoods")]
    [DB_Key("id")]
    public class PurchasesGoodEntity : BaseEntity 
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
		///采购id
		///</summary> 
		public long PurchaseId {get;set;}
		/// <summary>
		/// 物品id 
		/// </summary>
		public long GoodId { get; set; }
		///<summary> 
		///药品名称
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
		///库存单位
		///</summary> 
		public string StockUnit {get;set;} 
		///<summary> 
		///库存量
		///</summary> 
		public int Stock {get;set;} 
		///<summary> 
		///剩余库存量
		///</summary> 
		public int Consume {get;set;} 
		///<summary> 
		///生产日期
		///</summary> 
		public DateTime? ProductTime {get;set;} 
		///<summary> 
		///有效期
		///</summary> 
		public DateTime? ValidTime {get;set;} 
		///<summary> 
		///批号
		///</summary> 
		public string BatchNum {get;set;} 
		///<summary> 
		///采购价
		///</summary> 
		public long PurchasePrice {get;set;} 
		///<summary> 
		///销售价
		///</summary> 
		public long SellPrice {get;set;} 
		/// <summary>
		/// 比率
		/// </summary>
		public int Ratio { get; set; }
	}
} 
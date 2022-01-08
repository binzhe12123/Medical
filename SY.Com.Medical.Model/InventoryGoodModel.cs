using SY.Com.Medical.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace SY.Com.Medical.Model
{

	/// <summary>
	/// 查询入参
	/// </summary>
	public class InventoryListRequest : BaseModel
	{
		/// <summary>
		/// 采购单id 
		/// </summary>
		public long InventoryId { get; set; }
	}

	/// <summary>
	/// 采购搜索药品/材料输入
	/// </summary>
	public class InventoryGoodSearchRequest : PageModel
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonIgnore]
		public int GoodType { get; set; }
		/// <summary>
		/// 搜索关键词
		/// </summary>
		public string SearchKey { get; set; }
		/// <summary>
		/// 类型0:全部,1:药品,2:材料
		/// </summary>
		public int Type { get; set; }
	}

	/// <summary>
	/// 采购搜索药品/材料列表
	/// </summary>
	public class InventoryGoodSearchResponse : BaseModel
	{
		/// <summary>
		/// 药品/材料id
		/// </summary>
		public int GoodId { get; set; }
		/// <summary>
		/// 名称
		/// </summary>
		public string GoodName { get; set; }
		/// <summary>
		/// 规格
		/// </summary>
		public string Norm { get; set; }
		/// <summary>
		/// 厂家
		/// </summary>		
		public string Factory { get; set; }
		/// <summary>
		/// 计价单位
		/// </summary>
		public string SalesUnit { get; set; }
		/// <summary>
		/// 库存剩余
		/// </summary>
		public int Stock { get; set; }
		/// <summary>
		/// 当前单价价格
		/// </summary>
		public double Price { get; set; }
	}

	///<summary>
	/// 盘点
	/// </summary>
	public class InventoryGoodRequest  : BaseModel
	{
		///<summary> 
		///盘点单id
		///</summary> 
		[JsonIgnore]
		public long InventoryId { get; set; }
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
		public double Price {get;set;} 
		///<summary> 
		///盘点后售价
		///</summary> 
		public double PriceAfter {get;set;} 
	}

	/// <summary>
	/// 计算盘点后价格
	/// </summary>
	public class InventoryPriceRequest : BaseModel
    {
		/// <summary>
		/// 物品id 
		/// </summary>
		public long GoodId { get; set; }
		/// <summary>
		/// 盘点后库存
		/// </summary>
		public int StockAfter { get; set; }
		/// <summary>
		/// 现库存
		/// </summary>
		public int Stock { get; set; }
		/// <summary>
		/// 现售价
		/// </summary>
		public double Price { get; set; }

    }
	
	///<summary>
	/// InventoryGood模型
	/// </summary>
	public class InventoryGoodModel : BaseModel 
	{ 
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
			public double Price {get;set;} 
			///<summary> 
			///盘点后售价
			///</summary> 
			public double PriceAfter {get;set;} 
		}
	
	///<summary>
	/// InventoryGood模型
	/// </summary>
	public class InventoryGoodUpdate : BaseModel 
		{ 
			///<summary> 
			///自增主键
			///</summary> 
			public int id {get;set;} 
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
			public DateTime CreateTime {get;set;} 
			///<summary> 
			///
			///</summary> 
			public int IsEnalbe {get;set;} 
			///<summary> 
			///
			///</summary> 
			public int IsDelete {get;set;} 
		}
	
	///<summary>
	/// InventoryGood模型
	/// </summary>
	public class InventoryGoodDelete : BaseModel 
		{ 
			///<summary> 
			///自增主键
			///</summary> 
			public int id {get;set;} 
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
			public DateTime CreateTime {get;set;} 
			///<summary> 
			///
			///</summary> 
			public int IsEnalbe {get;set;} 
			///<summary> 
			///
			///</summary> 
			public int IsDelete {get;set;} 
		}
	
} 
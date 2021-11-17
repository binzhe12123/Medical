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
    
	///<summary>
	/// PurchasesGood模型
	/// </summary>
	public class PurchasesGoodModel : BaseModel 
	{ 
		/// <summary>
		/// 药品/材料ID
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
		/// <summary>
		/// 采购单位
		/// </summary>
		public string StockUnit { get; set; }
		/// <summary>
		/// bilv
		/// </summary>
		public int Ratio { get; set; }
		///<summary> 
		///采购量
		///</summary> 
		public int Stock {get;set;} 	
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
		public double PurchasePrice {get;set;} 
		///<summary> 
		///销售价
		///</summary> 
		public double SellPrice {get;set;} 
	}

	/// <summary>
	/// 查询入参
	/// </summary>
	public class PurchasesGoodRequest : BaseModel
    {
		/// <summary>
		/// 采购单id 
		/// </summary>
		public long PurchaseId { get; set; }
    }
	/// <summary>
	/// 查询返回
	/// </summary>
	public class PurchasesGoodResponse : BaseModel
	{
		/// <summary>
		/// 药品/材料ID
		/// </summary>
		public long GoodId { get; set; }
		///<summary> 
		///药品名称
		///</summary> 
		public string GoodName { get; set; }
		///<summary> 
		///规格
		///</summary> 
		public string Norm { get; set; }
		///<summary> 
		///厂家
		///</summary> 
		public string Factory { get; set; }
		///<summary> 
		///计价单位
		///</summary> 
		public string SalesUnit { get; set; }
		/// <summary>
		/// 采购单位
		/// </summary>
		public string StockUnit { get; set; }
		///<summary> 
		///采购量
		///</summary> 
		public int Stock { get; set; }
		/// <summary>
		/// 剩余量
		/// </summary>
		public int Consume { get; set; }
		///<summary> 
		///生产日期
		///</summary> 
		public DateTime? ProductTime { get; set; }
		///<summary> 
		///有效期
		///</summary> 
		public DateTime? ValidTime { get; set; }
		///<summary> 
		///批号
		///</summary> 
		public string BatchNum { get; set; }
		///<summary> 
		///采购价
		///</summary> 
		public double PurchasePrice { get; set; }
		///<summary> 
		///销售价
		///</summary> 
		public double SellPrice { get; set; }
	}

	/// <summary>
	/// 采购搜索药品/材料列表
	/// </summary>
	public class PurchasesGoodSearchResponse : BaseModel
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
		/// 两个单位模型
		/// </summary>
		public UnitModel Units { get; set; }
		/// <summary>
		/// 比率
		/// </summary>
		public int Ratio { get; set; }
		/// <summary>
		/// 库存剩余
		/// </summary>
		public int Stock { get; set; }
	}

	/// <summary>
	/// 单位模型
	/// </summary>
	public class UnitModel
    {
		/// <summary>
		/// 计价单位
		/// </summary>
		public string SalesUnit { get; set; }
		/// <summary>
		/// 采购单位
		/// </summary>
		public string StockUnit { get; set; }

	}

	/// <summary>
	/// 采购搜索药品/材料输入
	/// </summary>
	public class PurchasesGoodSearchRequest : PageModel
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


	///<summary>
	/// PurchasesGood模型
	/// </summary>
	public class PurchasesGoodAdd : BaseModel 
		{ 
			///<summary> 
			///自增主键
			///</summary> 
			public int id {get;set;} 
			///<summary> 
			///采购id
			///</summary> 
			public long PurchaseId {get;set;} 
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
			///采购单位
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
	/// PurchasesGood模型
	/// </summary>
	public class PurchasesGoodUpdate : BaseModel 
		{ 
			///<summary> 
			///自增主键
			///</summary> 
			public int id {get;set;} 
			///<summary> 
			///采购id
			///</summary> 
			public long PurchaseId {get;set;} 
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
			///采购单位
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
	/// PurchasesGood模型
	/// </summary>
	public class PurchasesGoodDelete : BaseModel 
		{ 
			///<summary> 
			///自增主键
			///</summary> 
			public int id {get;set;} 
			///<summary> 
			///采购id
			///</summary> 
			public long PurchaseId {get;set;} 
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
			///采购单位
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
using SY.Com.Medical.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SY.Com.Medical.Model
{
    
///<summary>
/// Inventory模型
/// </summary>
public class InventoryModel : BaseModel 
	{ 
		///<summary> 
		///盘点单ID
		///</summary> 
		public long InventoryId {get;set;} 
		///<summary> 
		///药品种类
		///</summary> 
		public int GoodsCount {get;set;} 
		///<summary> 
		///创建时间
		///</summary> 
		public DateTime CreateTime {get;set;} 
	}

	///<summary>
	/// Inventory模型
	/// </summary>
	public class InventoryRequest : PageModel
	{
		/// <summary>
		/// 开始时间
		/// </summary>
		public DateTime? start { get; set; }
		/// <summary>
		/// 结算时间
		/// </summary>
		public DateTime? end { get; set; }
		/// <summary>
		/// 药品名称
		/// </summary>
		public string GoodName { get; set; }
	}

	
///<summary>
/// Inventory模型
/// </summary>
public class InventoryAdd : BaseModel 
	{ 
		///<summary> 
		///盘点单ID
		///</summary> 
		public long InventoryId {get;set;} 
		///<summary> 
		///药品种类
		///</summary> 
		public int GoodsCount {get;set;} 
		///<summary> 
		///创建时间
		///</summary> 
		public DateTime CreateTime {get;set;} 
		///<summary> 
		///创建人员
		///</summary> 
		public int Createtor {get;set;} 
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
/// Inventory模型
/// </summary>
public class InventoryUpdate : BaseModel 
	{ 
		///<summary> 
		///盘点单ID
		///</summary> 
		public long InventoryId {get;set;} 
		///<summary> 
		///药品种类
		///</summary> 
		public int GoodsCount {get;set;} 
		///<summary> 
		///创建时间
		///</summary> 
		public DateTime CreateTime {get;set;} 
		///<summary> 
		///创建人员
		///</summary> 
		public int Createtor {get;set;} 
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
/// Inventory模型
/// </summary>
public class InventoryDelete : BaseModel 
	{ 
		///<summary> 
		///盘点单ID
		///</summary> 
		public long InventoryId {get;set;} 
		///<summary> 
		///药品种类
		///</summary> 
		public int GoodsCount {get;set;} 
		///<summary> 
		///创建时间
		///</summary> 
		public DateTime CreateTime {get;set;} 
		///<summary> 
		///创建人员
		///</summary> 
		public int Createtor {get;set;} 
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
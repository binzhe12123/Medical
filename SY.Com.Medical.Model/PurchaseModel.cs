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
/// Purchase模型
/// </summary>
public class PurchaseModel : BaseModel 
	{ 
		///<summary> 
		///采购id
		///</summary> 
		public long PurchaseId {get;set;} 
		///<summary> 
		///药品种类
		///</summary> 
		public int GoodsCount {get;set;} 
		///<summary> 
		///采购金额
		///</summary> 
		public double GoodsMoney {get;set;} 
		///<summary> 
		///采购时间
		///</summary> 
		public DateTime CreateTime {get;set;}  
	}
	
///<summary>
/// Purchase模型
/// </summary>
public class PurchaseRequest : PageModel 
	{ 
		///<summary> 
		///采购id
		///</summary> 
		public long PurchaseId {get;set;} 
		///<summary> 
		///药品种类
		///</summary> 
		public int GoodsCount {get;set;} 
		///<summary> 
		///采购金额
		///</summary> 
		public long GoodsMoney {get;set;} 
		///<summary> 
		///供应商
		///</summary> 
		public string Supplier {get;set;} 
		///<summary> 
		///采购时间
		///</summary> 
		public DateTime CreateTime {get;set;} 
		///<summary> 
		///创建者
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
/// Purchase模型
/// </summary>
public class PurchaseAdd : BaseModel 
	{ 
		///<summary> 
		///采购id
		///</summary> 
		public long PurchaseId {get;set;} 
		///<summary> 
		///药品种类
		///</summary> 
		public int GoodsCount {get;set;} 
		///<summary> 
		///采购金额
		///</summary> 
		public long GoodsMoney {get;set;} 
		///<summary> 
		///供应商
		///</summary> 
		public string Supplier {get;set;} 
		///<summary> 
		///采购时间
		///</summary> 
		public DateTime CreateTime {get;set;} 
		///<summary> 
		///创建者
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
/// Purchase模型
/// </summary>
public class PurchaseUpdate : BaseModel 
	{ 
		///<summary> 
		///采购id
		///</summary> 
		public long PurchaseId {get;set;} 
		///<summary> 
		///药品种类
		///</summary> 
		public int GoodsCount {get;set;} 
		///<summary> 
		///采购金额
		///</summary> 
		public long GoodsMoney {get;set;} 
		///<summary> 
		///供应商
		///</summary> 
		public string Supplier {get;set;} 
		///<summary> 
		///采购时间
		///</summary> 
		public DateTime CreateTime {get;set;} 
		///<summary> 
		///创建者
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
/// Purchase模型
/// </summary>
public class PurchaseDelete : BaseModel 
	{ 
		///<summary> 
		///采购id
		///</summary> 
		public long PurchaseId {get;set;} 
		///<summary> 
		///药品种类
		///</summary> 
		public int GoodsCount {get;set;} 
		///<summary> 
		///采购金额
		///</summary> 
		public long GoodsMoney {get;set;} 
		///<summary> 
		///供应商
		///</summary> 
		public string Supplier {get;set;} 
		///<summary> 
		///采购时间
		///</summary> 
		public DateTime CreateTime {get;set;} 
		///<summary> 
		///创建者
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
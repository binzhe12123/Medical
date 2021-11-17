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
    [DB_Table("Purchases")]
    [DB_Key("PurchaseId")]
    public class PurchaseEntity : BaseEntity 
	{ 
		///<summary> 
		///采购id
		///</summary> 
		[DB_Key("PurchaseId")]
		public long PurchaseId {get;set;} 
		///<summary> 
		///租户id
		///</summary> 
		public long TenantId {get;set;} 
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
		///创建者
		///</summary> 
		public int Createtor {get;set;}
	}
} 
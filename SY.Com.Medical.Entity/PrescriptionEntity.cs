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
    [DB_Table("Prescriptions")]
    [DB_Key("PrescriptionId")]
    public class PrescriptionEntity : BaseEntity 
	{ 
		///<summary> 
		///
		///</summary> 
		[DB_Key("PrescriptionId")]
		public int PrescriptionId {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int TenantId {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int OutpatientId {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int PreNo {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string PreName {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int GoodsId {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string GoodsName {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string GOodsNorm {get;set;} 
		///<summary> 
		///
		///</summary> 
		public long GoodsPirce {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int GoodsNum {get;set;} 
		///<summary> 
		///
		///</summary> 
		public long GoodsCost {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string GoodsUsage {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string GoodsEveryDay {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int GoodsDays {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string GoodsSalesUnit {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int Pair {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string Place {get;set;} 
	}
} 
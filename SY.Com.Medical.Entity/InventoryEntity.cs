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
    [DB_Table("Inventorys")]
    [DB_Key("InventoryId")]
    public class InventoryEntity : BaseEntity 
	{ 
		///<summary> 
		///盘点单ID
		///</summary> 
		[DB_Key("InventoryId")]
		public long InventoryId {get;set;} 
		///<summary> 
		///租户ID
		///</summary> 
		public long TenantId {get;set;} 
		///<summary> 
		///药品种类
		///</summary> 
		public int GoodsCount {get;set;} 
		///<summary> 
		///创建人员
		///</summary> 
		public int Createtor {get;set;} 		
	}
} 
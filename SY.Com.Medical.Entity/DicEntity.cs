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
    [DB_Table("Dics")]
    [DB_Key("DicId")]
    public class DicEntity : BaseEntity 
	{ 
		///<summary> 
		///主键ID
		///</summary> 
		[DB_Key("DicId")]
		public int DicId {get;set;} 
		///<summary> 
		///租户ID
		///</summary> 
		public int TenantId {get;set;} 
		///<summary> 
		///键
		///</summary> 
		public string DicKey {get;set;} 
		///<summary> 
		///值
		///</summary> 
		public string DicValue {get;set;} 
		///<summary> 
		///分类
		///</summary> 
		[DB_Default(typeof(DicType))]
		public DicType DicType {get;set;} 
		/// <summary>
		/// 
		/// </summary>
		public string SearchKey { get; set; }
	}
} 
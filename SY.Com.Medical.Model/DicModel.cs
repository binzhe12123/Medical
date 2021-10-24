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
	/// Dic模型
	/// </summary>
	public class DicModel : BaseModel 
		{ 
			///<summary> 
			///主键ID
			///</summary> 
			public int DicId {get;set;} 
			///<summary> 
			///键
			///</summary> 
			public string DicKey {get;set;} 
			///<summary> 
			///值
			///</summary> 
			public string DicValue {get;set;}
		///<summary> 
		///分类-枚举-Setting.getKeyValue接口查看
		///</summary> 
		public int DicType {get;set;} 
			///<summary> 
			///
			///</summary> 
			public DateTime? CreateTime {get;set;} 
			///<summary> 
			///
			///</summary> 
			public int IsEnable {get;set;} 
			///<summary> 
			///
			///</summary> 
			public int IsDelete {get;set;} 
		
		}
	
	/// <summary>
	/// 返回模型
	/// </summary>
	public class DicResponse : BaseModel
    {
		///<summary> 
		///主键ID
		///</summary> 
		public int DicId { get; set; }
		///<summary> 
		///值
		///</summary> 
		public string DicValue { get; set; }
		///<summary> 
		///分类-枚举-Setting.getKeyValue接口查看
		///</summary> 
		public int DicType { get; set; }
	}

	///<summary>
	/// Dic模型
	/// </summary>
	public class DicRequest : PageModel 
		{
			///<summary> 
			///值
			///</summary> 
			public string DicValue {get;set;}
			///<summary> 
			///分类-枚举-Setting.getKeyValue接口查看
			///</summary> 
			public int DicType {get;set;}
			/// <summary>
			/// 搜索关键字
			/// </summary>
			public string SearchKey { get; set; }
	}
	
	///<summary>
	/// Dic模型
	/// </summary>
	public class DicAdd : BaseModel 
	{ 
		///<summary> 
		///值
		///</summary> 
		public string DicValue {get;set;}
		///<summary> 
		///分类-枚举-Setting.getKeyValue接口查看
		///</summary> 
		[Required]
		public int DicType {get;set;} 		
		/// <summary>
		/// 搜索关键字
		/// </summary>
		[JsonIgnore]
		public string SearchKey { get; set; }
	}
	
	///<summary>
	/// Dic模型
	/// </summary>
	public class DicUpdate : BaseModel 
	{ 
		///<summary> 
		///主键ID
		///</summary> 
		public int DicId {get;set;} 
		///<summary> 
		///值
		///</summary> 
		public string DicValue {get;set;}
		/// <summary>
		/// 
		/// </summary>
		[JsonIgnore]	
		public string SearchKey { get; set; }
	}
	
	///<summary>
	/// Dic模型
	/// </summary>
	public class DicDelete : BaseModel 
		{ 
			///<summary> 
			///主键ID
			///</summary> 
			public int DicId {get;set;} 
			///<summary> 
			///键
			///</summary> 
			public string DicKey {get;set;} 
			///<summary> 
			///值
			///</summary> 
			public string DicValue {get;set;}
		///<summary> 
		///分类-枚举-Setting.getKeyValue接口查看
		///</summary> 
		public int DicType {get;set;} 
			///<summary> 
			///
			///</summary> 
			public DateTime? CreateTime {get;set;} 
			///<summary> 
			///
			///</summary> 
			public int IsEnable {get;set;} 
			///<summary> 
			///
			///</summary> 
			public int IsDelete {get;set;} 			
		}
	
} 
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
/// RegisterProject模型
/// </summary>
public class RegisterProjectModel : BaseModel 
	{ 
		///<summary> 
		///ID
		///</summary> 
		public int ProjectId {get;set;} 
		///<summary> 
		///名称
		///</summary> 
		public string ProjectName {get;set;} 
		///<summary> 
		///医保编码
		///</summary> 
		public string ProjectAgencyCode {get;set;} 
		/// <summary>
		/// 机构编码
		/// </summary>
		public string ProjectSelfCode { get; set; }
		///<summary> 
		///价格
		///</summary> 
		public long ProjectPrice {get;set;} 
	}
	
	///<summary>
	/// RegisterProject模型
	/// </summary>
	public class RegisterProjectRequest : PageModel 
	{ 
		///<summary> 
		///名称
		///</summary> 
		public string ProjectName {get;set;} 
		///<summary> 
		///医保编码
		///</summary> 
		public string ProjectAgencyCode {get;set;} 
		///<summary> 
		///机构编码
		///</summary> 
		public string ProjectSelfCode {get;set;} 
		///<summary> 
		///价格
		///</summary> 
		public long ProjectPrice {get;set;} 
	}
	
	///<summary>
	/// RegisterProject模型
	/// </summary>
	public class RegisterProjectAdd : BaseModel 
	{ 
		///<summary> 
		///名称
		///</summary> 
		public string ProjectName {get;set;} 
		///<summary> 
		///医保编码
		///</summary> 
		public string ProjectAgencyCode {get;set;} 
		///<summary> 
		///机构编码
		///</summary> 
		public string ProjectSelfCode {get;set;} 
		///<summary> 
		///价格
		///</summary> 
		public long ProjectPrice {get;set;} 
	}
	
	///<summary>
	/// RegisterProject模型
	/// </summary>
	public class RegisterProjectUpdate : BaseModel 
	{ 
		///<summary> 
		///ID
		///</summary> 
		public int ProjectId {get;set;} 
		///<summary> 
		///名称
		///</summary> 
		public string ProjectName {get;set;} 
		///<summary> 
		///医保编码
		///</summary> 
		public string ProjectAgencyCode {get;set;} 
		///<summary> 
		///机构编码
		///</summary> 
		public string ProjectSelfCode {get;set;} 
		///<summary> 
		///价格
		///</summary> 
		public long ProjectPrice {get;set;} 
	}
	
	///<summary>
	/// RegisterProject模型
	/// </summary>
	public class RegisterProjectDelete : BaseModel 
	{ 
		///<summary> 
		///ID
		///</summary> 
		public int ProjectId {get;set;}  
	}
	
} 
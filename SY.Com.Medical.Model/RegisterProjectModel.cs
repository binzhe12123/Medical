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
		///
		///</summary> 
		public int ProjectId {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string ProjectName {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string ProjectAgencyCode {get;set;} 
		///<summary> 
		///
		///</summary> 
		public long ProjectPrice {get;set;} 
	}
	
///<summary>
/// RegisterProject模型
/// </summary>
public class RegisterProjectRequest : PageModel 
	{ 
		///<summary> 
		///
		///</summary> 
		public int ProjectId {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string ProjectName {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string ProjectAgencyCode {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string ProjectSelfCode {get;set;} 
		///<summary> 
		///
		///</summary> 
		public long ProjectPrice {get;set;} 
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
	
///<summary>
/// RegisterProject模型
/// </summary>
public class RegisterProjectAdd : BaseModel 
	{ 
		///<summary> 
		///
		///</summary> 
		public int ProjectId {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string ProjectName {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string ProjectAgencyCode {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string ProjectSelfCode {get;set;} 
		///<summary> 
		///
		///</summary> 
		public long ProjectPrice {get;set;} 
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
	
///<summary>
/// RegisterProject模型
/// </summary>
public class RegisterProjectUpdate : BaseModel 
	{ 
		///<summary> 
		///
		///</summary> 
		public int ProjectId {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string ProjectName {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string ProjectAgencyCode {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string ProjectSelfCode {get;set;} 
		///<summary> 
		///
		///</summary> 
		public long ProjectPrice {get;set;} 
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
	
///<summary>
/// RegisterProject模型
/// </summary>
public class RegisterProjectDelete : BaseModel 
	{ 
		///<summary> 
		///
		///</summary> 
		public int ProjectId {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string ProjectName {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string ProjectAgencyCode {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string ProjectSelfCode {get;set;} 
		///<summary> 
		///
		///</summary> 
		public long ProjectPrice {get;set;} 
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
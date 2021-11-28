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
    [DB_Table("RegisterProjects")]
    [DB_Key("ProjectId")]
    public class RegisterProjectEntity : BaseEntity 
	{ 
		///<summary> 
		///
		///</summary> 
		[DB_Key("ProjectId")]
		public int ProjectId {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int TenantId {get;set;} 
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
	}
} 
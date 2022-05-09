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
/// UserManager模型
/// </summary>
	public class UserManagerModel : BaseModel 
	{ 
		///<summary> 
		///主键Id
		///</summary> 
		public int Id {get;set;} 
		///<summary> 
		///账号
		///</summary> 
		public string Account {get;set;} 
		///<summary> 
		///密码
		///</summary> 
		public string Pwd {get;set;} 
		///<summary> 
		///创建日期
		///</summary> 
		public DateTime CreateTime {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int IsEnablef {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int IsDelete {get;set;} 
	}
	
///<summary>
/// UserManager模型
/// </summary>
	public class UserManagerRequest : PageModel 
	{ 
		///<summary> 
		///主键Id
		///</summary> 
		public int Id {get;set;} 
		///<summary> 
		///账号
		///</summary> 
		public string Acount {get;set;} 
		///<summary> 
		///密码
		///</summary> 
		public string Pwd {get;set;} 
		///<summary> 
		///创建日期
		///</summary> 
		public DateTime CreateTime {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int IsEnablef {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int IsDelete {get;set;} 
	}
	
///<summary>
/// UserManager模型
/// </summary>
	public class UserManagerAdd : BaseModel 
	{ 
		///<summary> 
		///主键Id
		///</summary> 
		public int Id {get;set;} 
		///<summary> 
		///账号
		///</summary> 
		public string Acount {get;set;} 
		///<summary> 
		///密码
		///</summary> 
		public string Pwd {get;set;} 
		///<summary> 
		///创建日期
		///</summary> 
		public DateTime CreateTime {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int IsEnablef {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int IsDelete {get;set;} 
	}
	
///<summary>
/// UserManager模型
/// </summary>
	public class UserManagerUpdate : BaseModel 
	{ 
		///<summary> 
		///主键Id
		///</summary> 
		public int Id {get;set;} 
		///<summary> 
		///账号
		///</summary> 
		public string Acount {get;set;} 
		///<summary> 
		///密码
		///</summary> 
		public string Pwd {get;set;} 
		///<summary> 
		///创建日期
		///</summary> 
		public DateTime CreateTime {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int IsEnablef {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int IsDelete {get;set;} 
	}
	
///<summary>
/// UserManager模型
/// </summary>
	public class UserManagerDelete : BaseModel 
	{ 
		///<summary> 
		///主键Id
		///</summary> 
		public int Id {get;set;} 
		///<summary> 
		///账号
		///</summary> 
		public string Acount {get;set;} 
		///<summary> 
		///密码
		///</summary> 
		public string Pwd {get;set;} 
		///<summary> 
		///创建日期
		///</summary> 
		public DateTime CreateTime {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int IsEnablef {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int IsDelete {get;set;} 
	}
	
} 
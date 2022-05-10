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
    [DB_Table("UserManager")]
    [DB_Key("Id")]
    public class UserManagerEntity : BaseEntity 
	{ 
		///<summary> 
		///主键Id
		///</summary> 
		[DB_Key("Id")]
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
		///
		///</summary> 
		public int IsEnablef {get;set;} 
	}
} 
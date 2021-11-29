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
    [DB_Table("Registers")]
    [DB_Key("RegisterId")]
    public class RegisterEntity : BaseEntity 
	{ 
		///<summary> 
		///挂号id
		///</summary> 
		[DB_Key("RegisterId")]
		public int RegisterId {get;set;} 
		///<summary> 
		///租户id
		///</summary> 
		public int TenantId {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int PatientId {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string psn_no {get;set;} 
		///<summary> 
		///患者姓名
		///</summary> 
		public string Name {get;set;} 
		///<summary> 
		///患者性别
		///</summary> 
		public int Sex {get;set;} 
		///<summary> 
		///
		///</summary> 
		public DateTime? CSRQ {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string SFZH {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string Phone {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string Addr {get;set;} 
	
		///<summary> 
		///
		///</summary> 
		public string DoctorName {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string DepartmentName {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string GoodsName {get;set;} 
		///<summary> 
		///
		///</summary> 
		public long GoodsPrice {get;set;} 
		/// <summary>
		/// 
		/// </summary>
		public string ipt_otp_no { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string mdtrt_id { get; set; }
		/// <summary>
		/// 是否使用1:已使用,-1未使用
		/// </summary>
		public int IsUsed { get; set; }
	}
} 
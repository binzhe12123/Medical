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
		///人员系统Id
		///</summary> 
		public int PatientId {get;set;} 
		///<summary> 
		///医保人员编号
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
		///出生日期
		///</summary> 
		public DateTime? CSRQ {get;set;} 
		///<summary> 
		///省份证号
		///</summary> 
		public string SFZH {get;set;} 
		///<summary> 
		///电话号码
		///</summary> 
		public string Phone {get;set;} 
		///<summary> 
		///地址
		///</summary> 
		public string Addr {get;set;} 
	
		///<summary> 
		///医生姓名
		///</summary> 
		public string DoctorName {get;set;} 
		///<summary> 
		///科室名称
		///</summary> 
		public string DepartmentName {get;set;} 
		///<summary> 
		///项目名称
		///</summary> 
		public string GoodsName {get;set;} 
		///<summary> 
		///金额
		///</summary> 
		public long GoodsPrice {get;set;} 
		/// <summary>
		/// 医保ipt_otp_no
		/// </summary>
		public string ipt_otp_no { get; set; }
		/// <summary>
		/// 医保mdtrt_id
		/// </summary>
		public string mdtrt_id { get; set; }
		/// <summary>
		/// 是否使用1:已使用,-1未使用
		/// </summary>
		public int IsUsed { get; set; }
		/// <summary>
		/// 搜索字段
		/// </summary>
		public string SearchKey { get; set; }
	}
} 
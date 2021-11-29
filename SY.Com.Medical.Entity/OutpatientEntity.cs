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
    [DB_Table("Outpatients")]
    [DB_Key("OutpatientId")]
    public class OutpatientEntity : BaseEntity 
	{ 
		///<summary> 
		///
		///</summary> 
		[DB_Key("OutpatientId")]
		public int OutpatientId {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int TenantId {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int PatientId {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int RegisterId {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int CaseBookId {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int DoctorId {get;set;} 
		/// <summary>
		/// 
		/// </summary>
		public string DoctorName { get; set; }
		///<summary> 
		///
		///</summary> 
		public string mdtrt_id {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string chrg_bchno {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int PrescriptionCount {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int IsPay {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int IsBack {get;set;} 
		///<summary> 
		///
		///</summary> 
		public long PayYB {get;set;} 
		///<summary> 
		///
		///</summary> 
		public long PayCash {get;set;} 
		///<summary> 
		///
		///</summary> 
		public long PayYBBefor {get;set;} 
		///<summary> 
		///
		///</summary> 
		public long PayYBAfter {get;set;} 
		/// <summary>
		/// 
		/// </summary>
		public string SearchKey { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public long Cost { get; set; }
	}


} 
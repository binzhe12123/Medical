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
/// Outpatient模型
/// </summary>
public class OutpatientModel : BaseModel 
	{ 
		///<summary> 
		///
		///</summary> 
		public int OutpatientId {get;set;} 
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
/// Outpatient模型
/// </summary>
public class OutpatientRequest : PageModel 
	{ 
		///<summary> 
		///
		///</summary> 
		public int OutpatientId {get;set;} 
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
/// Outpatient模型
/// </summary>
public class OutpatientAdd : BaseModel 
	{ 
		///<summary> 
		///
		///</summary> 
		public int OutpatientId {get;set;} 
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
/// Outpatient模型
/// </summary>
public class OutpatientUpdate : BaseModel 
	{ 
		///<summary> 
		///
		///</summary> 
		public int OutpatientId {get;set;} 
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
/// Outpatient模型
/// </summary>
public class OutpatientDelete : BaseModel 
	{ 
		///<summary> 
		///
		///</summary> 
		public int OutpatientId {get;set;} 
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
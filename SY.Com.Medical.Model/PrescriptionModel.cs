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
/// Prescription模型
/// </summary>
public class PrescriptionModel : BaseModel 
	{ 
		///<summary> 
		///
		///</summary> 
		public int PrescriptionId {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int OutpatientId {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int PreNo {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string PreName {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int GoodsId {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string GoodsName {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string GOodsNorm {get;set;} 
		///<summary> 
		///
		///</summary> 
		public long GoodsPirce {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int GoodsNum {get;set;} 
		///<summary> 
		///
		///</summary> 
		public long GoodsCost {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string GoodsUsage {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string GoodsEveryDay {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int GoodsDays {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string GoodsSalesUnit {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int Pair {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string Place {get;set;} 
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
/// Prescription模型
/// </summary>
public class PrescriptionRequest : PageModel 
	{ 
		///<summary> 
		///
		///</summary> 
		public int PrescriptionId {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int OutpatientId {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int PreNo {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string PreName {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int GoodsId {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string GoodsName {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string GOodsNorm {get;set;} 
		///<summary> 
		///
		///</summary> 
		public long GoodsPirce {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int GoodsNum {get;set;} 
		///<summary> 
		///
		///</summary> 
		public long GoodsCost {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string GoodsUsage {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string GoodsEveryDay {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int GoodsDays {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string GoodsSalesUnit {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int Pair {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string Place {get;set;} 
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
/// Prescription模型
/// </summary>
public class PrescriptionAdd : BaseModel 
	{ 
		///<summary> 
		///
		///</summary> 
		public int PrescriptionId {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int OutpatientId {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int PreNo {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string PreName {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int GoodsId {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string GoodsName {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string GOodsNorm {get;set;} 
		///<summary> 
		///
		///</summary> 
		public long GoodsPirce {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int GoodsNum {get;set;} 
		///<summary> 
		///
		///</summary> 
		public long GoodsCost {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string GoodsUsage {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string GoodsEveryDay {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int GoodsDays {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string GoodsSalesUnit {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int Pair {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string Place {get;set;} 
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
/// Prescription模型
/// </summary>
public class PrescriptionUpdate : BaseModel 
	{ 
		///<summary> 
		///
		///</summary> 
		public int PrescriptionId {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int OutpatientId {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int PreNo {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string PreName {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int GoodsId {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string GoodsName {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string GOodsNorm {get;set;} 
		///<summary> 
		///
		///</summary> 
		public long GoodsPirce {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int GoodsNum {get;set;} 
		///<summary> 
		///
		///</summary> 
		public long GoodsCost {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string GoodsUsage {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string GoodsEveryDay {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int GoodsDays {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string GoodsSalesUnit {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int Pair {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string Place {get;set;} 
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
/// Prescription模型
/// </summary>
public class PrescriptionDelete : BaseModel 
	{ 
		///<summary> 
		///
		///</summary> 
		public int PrescriptionId {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int OutpatientId {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int PreNo {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string PreName {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int GoodsId {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string GoodsName {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string GOodsNorm {get;set;} 
		///<summary> 
		///
		///</summary> 
		public long GoodsPirce {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int GoodsNum {get;set;} 
		///<summary> 
		///
		///</summary> 
		public long GoodsCost {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string GoodsUsage {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string GoodsEveryDay {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int GoodsDays {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string GoodsSalesUnit {get;set;} 
		///<summary> 
		///
		///</summary> 
		public int Pair {get;set;} 
		///<summary> 
		///
		///</summary> 
		public string Place {get;set;} 
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
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
/// Dic模型
/// </summary>
public class DicModel : BaseModel 
	{ 
		///<summary> 
		///主键ID
		///</summary> 
		public int DicId {get;set;} 
		///<summary> 
		///键
		///</summary> 
		public string DicKey {get;set;} 
		///<summary> 
		///值
		///</summary> 
		public string DicValue {get;set;} 
		///<summary> 
		///分类
		///</summary> 
		public string DicType {get;set;} 
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
		///<summary> 
		///
		///</summary> 
		public int dictypeid {get;set;} 
	}
	
///<summary>
/// Dic模型
/// </summary>
public class DicRequest : PageModel 
	{ 
		///<summary> 
		///主键ID
		///</summary> 
		public int DicId {get;set;} 
		///<summary> 
		///键
		///</summary> 
		public string DicKey {get;set;} 
		///<summary> 
		///值
		///</summary> 
		public string DicValue {get;set;} 
		///<summary> 
		///分类
		///</summary> 
		public string DicType {get;set;} 
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
		///<summary> 
		///
		///</summary> 
		public int dictypeid {get;set;} 
	}
	
///<summary>
/// Dic模型
/// </summary>
public class DicAdd : BaseModel 
	{ 
		///<summary> 
		///主键ID
		///</summary> 
		public int DicId {get;set;} 
		///<summary> 
		///键
		///</summary> 
		public string DicKey {get;set;} 
		///<summary> 
		///值
		///</summary> 
		public string DicValue {get;set;} 
		///<summary> 
		///分类
		///</summary> 
		public string DicType {get;set;} 
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
		///<summary> 
		///
		///</summary> 
		public int dictypeid {get;set;} 
	}
	
///<summary>
/// Dic模型
/// </summary>
public class DicUpdate : BaseModel 
	{ 
		///<summary> 
		///主键ID
		///</summary> 
		public int DicId {get;set;} 
		///<summary> 
		///键
		///</summary> 
		public string DicKey {get;set;} 
		///<summary> 
		///值
		///</summary> 
		public string DicValue {get;set;} 
		///<summary> 
		///分类
		///</summary> 
		public string DicType {get;set;} 
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
		///<summary> 
		///
		///</summary> 
		public int dictypeid {get;set;} 
	}
	
///<summary>
/// Dic模型
/// </summary>
public class DicDelete : BaseModel 
	{ 
		///<summary> 
		///主键ID
		///</summary> 
		public int DicId {get;set;} 
		///<summary> 
		///键
		///</summary> 
		public string DicKey {get;set;} 
		///<summary> 
		///值
		///</summary> 
		public string DicValue {get;set;} 
		///<summary> 
		///分类
		///</summary> 
		public string DicType {get;set;} 
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
		///<summary> 
		///
		///</summary> 
		public int dictypeid {get;set;} 
	}
	
} 
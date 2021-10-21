using SY.Com.Medical.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace SY.Com.Medical.Model
{
    /// <summary>
    /// 全模型
    /// </summary>
    public class GoodModel : BaseModel 
	{ 
		///<summary> 
		///商品ID
		///</summary> 
		public int GoodId {get;set;} 
		///<summary> 
		///商品名称
		///</summary> 
		public string GoodName {get;set;} 
		///<summary> 
		///规格
		///</summary> 
		public string Norm {get;set;} 
		///<summary> 
		///厂家
		///</summary> 
		public string Factory {get;set;} 
		///<summary> 
		///类型（枚举1:西药,2:中成药,3:中药,4:诊疗项目,5:材料）
		///</summary> 
		public int GoodType {get;set;} 
		///<summary> 
		///分类:自定义,和字典表进行关联
		///</summary> 
		public int GoodSort {get;set;} 
		///<summary> 
		///国药准字
		///</summary> 
		public string GoodStandard {get;set;} 
		///<summary> 
		///医保编码
		///</summary> 
		public string InsuranceCode {get;set;} 
		///<summary> 
		///机构编码-自定义码
		///</summary> 
		public string CustomerCode {get;set;} 
		///<summary> 
		///条码
		///</summary> 
		public string BarCode {get;set;} 
		///<summary> 
		///搜索词根
		///</summary> 
		public string SearchKey {get;set;} 
		///<summary> 
		///计价单位
		///</summary> 
		public string SalesUnit {get;set;} 
		///<summary> 
		///库存单位
		///</summary> 
		public string StockUnit {get;set;} 
		///<summary> 
		///库存单位--》计价单位比率，正整数
		///</summary> 
		public int Ratio {get;set;} 
		///<summary> 
		///
		///</summary> 
		public DateTime? CreateTime {get;set;} 
		/// <summary>
		/// 价格
		/// </summary>
		[JsonIgnore]
		public decimal Price { get; set; }
	}
	/// <summary>
	/// 添加模型
	/// </summary>
	public class GoodAdd : BaseModel 
	{
		///<summary> 
		///商品ID
		///</summary> 
		[JsonIgnore]
		public int GoodId {get;set;} 
		///<summary> 
		///商品名称
		///</summary> 
		[Required]
		public string GoodName {get;set;}
		///<summary> 
		///规格
		///</summary> 
		[Required]
		public string Norm {get;set;}
		///<summary> 
		///厂家
		///</summary> 
		[Required]
		public string Factory {get;set;}
		///<summary> 
		///类型（枚举1:西药,2:中成药,3:中药,4:诊疗项目,5:材料）
		///</summary> 
		[Required]
		public int GoodType {get;set;}
		///<summary> 
		///分类:自定义,和字典表进行关联
		///</summary> 
		[Required]
		public int GoodSort {get;set;} 
		///<summary> 
		///国药准字
		///</summary> 
		public string GoodStandard {get;set;} 
		///<summary> 
		///医保编码
		///</summary> 
		public string InsuranceCode {get;set;} 
		///<summary> 
		///机构编码-自定义码
		///</summary> 
		public string CustomerCode {get;set;} 
		///<summary> 
		///条码
		///</summary> 
		public string BarCode {get;set;}
		///<summary> 
		///搜索词根
		///</summary> 
		[JsonIgnore]
		public string SearchKey {get;set;}
		///<summary> 
		///计价单位
		///</summary> 
		[Required]
		public string SalesUnit {get;set;} 
		///<summary> 
		///库存单位
		///</summary> 
		public string StockUnit {get;set;} 
		///<summary> 
		///库存单位--》计价单位比率，正整数
		///</summary> 
		public int Ratio {get;set;}
		/// <summary>
		/// 价格
		/// </summary>
		[JsonIgnore]
		public decimal? Price { get; set; }
	}

	/// <summary>
	/// 修改模型
	/// </summary>
	public class GoodUpdate : BaseModel 
	{
		///<summary> 
		///商品ID
		///</summary> 
		[Required]
		public int GoodId {get;set;}
		///<summary> 
		///商品名称
		///</summary> 
		[Required]
		public string GoodName {get;set;}
		///<summary> 
		///规格
		///</summary> 
		[Required]
		public string Norm {get;set;}
		///<summary> 
		///厂家
		///</summary> 
		[Required]
		public string Factory {get;set;}
		///<summary> 
		///类型（枚举1:西药,2:中成药,3:中药,4:诊疗项目,5:材料）
		///</summary> 
		[Required]
		public int GoodType {get;set;}
		///<summary> 
		///分类:自定义,和字典表进行关联
		///</summary> 
		[Required]
		public int GoodSort {get;set;} 
		///<summary> 
		///国药准字
		///</summary> 
		public string GoodStandard {get;set;} 
		///<summary> 
		///医保编码
		///</summary> 
		public string InsuranceCode {get;set;} 
		///<summary> 
		///机构编码-自定义码
		///</summary> 
		public string CustomerCode {get;set;} 
		///<summary> 
		///条码
		///</summary> 
		public string BarCode {get;set;}
		///<summary> 
		///搜索词根
		///</summary> 
		[JsonIgnore]
		public string SearchKey {get;set;}
		///<summary> 
		///计价单位
		///</summary> 
		[Required]
		public string SalesUnit {get;set;} 
		///<summary> 
		///库存单位
		///</summary> 
		public string StockUnit {get;set;} 
		///<summary> 
		///库存单位--》计价单位比率，正整数
		///</summary> 
		public int Ratio {get;set;}
		/// <summary>
		/// 价格
		/// </summary>
		[JsonIgnore]
		public decimal? Price { get; set; }
	}

	/// <summary>
	/// 删除模型
	/// </summary>
	public class GoodDelete : BaseModel 
	{
		///<summary> 
		///商品ID
		///</summary> 
		[Required]
		public int GoodId {get;set;} 	
	}

	/// <summary>
	/// 
	/// </summary>
	public class GoodRequest : PageModel
    {
		///<summary> 
		///商品名称
		///</summary> 
		public string GoodName { get; set; }
		///<summary> 
		///医保编码
		///</summary> 
		public string InsuranceCode { get; set; }
		///<summary> 
		///机构编码-自定义码
		///</summary> 
		public string CustomerCode { get; set; }

		///<summary> 
		///类型（枚举1:西药,2:中成药,3:中药,4:诊疗项目,5:材料）
		///</summary> 
		public int GoodType { get; set; }
		///<summary> 
		///分类:自定义,和字典表进行关联
		///</summary> 
		public int GoodSort { get; set; }				
	}

	/// <summary>
	/// 项目模型
	/// </summary>
	public class GoodItemsRequest : PageModel
	{
		///<summary> 
		///商品名称
		///</summary> 
		public string GoodName { get; set; }
		///<summary> 
		///医保编码
		///</summary> 
		public string InsuranceCode { get; set; }
		///<summary> 
		///机构编码-自定义码
		///</summary> 
		public string CustomerCode { get; set; }

		///<summary> 
		///类型（枚举1:西药,2:中成药,3:中药,4:诊疗项目,5:材料）
		///</summary> 
		[JsonIgnore]
		public int GoodType { get; set; }
		///<summary> 
		///分类:自定义,和字典表进行关联
		///</summary> 
		public int GoodSort { get; set; }

	}

	/// <summary>
	/// 项目信息
	/// </summary>
	public class GoodItemModel : BaseModel
    {
		///<summary> 
		///商品ID
		///</summary> 
		public int GoodId { get; set; }
		///<summary> 
		///商品名称
		///</summary> 
		public string GoodName { get; set; }
		/// <summary>
		/// 价格
		/// </summary>
		public decimal Price { get; set; }
		///<summary> 
		///分类:自定义,和字典表进行关联
		///</summary> 
		public int GoodSort { get; set; }
		///<summary> 
		///医保编码
		///</summary> 
		public string InsuranceCode { get; set; }
		///<summary> 
		///机构编码-自定义码
		///</summary> 
		public string CustomerCode { get; set; }
		///<summary> 
		///计价单位
		///</summary> 
		public string SalesUnit { get; set; }
		///<summary> 
		///
		///</summary> 
		public DateTime? CreateTime { get; set; }
	}

	/// <summary>
	/// 项目添加模型
	/// </summary>
	public class GoodItemAdd : BaseModel
	{
		///<summary> 
		///商品ID
		///</summary> 
		[JsonIgnore]
		public int GoodId { get; set; }
		///<summary> 
		///商品名称
		///</summary> 
		[Required]
		public string GoodName { get; set; }
		///<summary> 
		///类型（枚举1:西药,2:中成药,3:中药,4:诊疗项目,5:材料）
		///</summary> 
		[JsonIgnore]
		public int GoodType { get; set; }
		///<summary> 
		///分类:自定义,和字典表进行关联
		///</summary> 
		[Required]
		public int GoodSort { get; set; }
		///<summary> 
		///医保编码
		///</summary> 
		public string InsuranceCode { get; set; }
		///<summary> 
		///机构编码-自定义码
		///</summary> 
		public string CustomerCode { get; set; }
		///<summary> 
		///搜索词根
		///</summary> 
		[JsonIgnore]
		public string SearchKey { get; set; }
		///<summary> 
		///计价单位
		///</summary> 
		[Required]
		public string SalesUnit { get; set; }
		/// <summary>
		/// 价格
		/// </summary>
		public decimal? Price { get; set; }
	}

	/// <summary>
	/// 修改模型
	/// </summary>
	public class GoodItemUpdate : BaseModel
	{
		///<summary> 
		///商品ID
		///</summary> 
		[Required]
		public int GoodId { get; set; }
		///<summary> 
		///商品名称
		///</summary> 
		[Required]
		public string GoodName { get; set; }
		///<summary> 
		///类型（枚举1:西药,2:中成药,3:中药,4:诊疗项目,5:材料）
		///</summary> 
		[JsonIgnore]
		public int GoodType { get; set; }
		///<summary> 
		///分类:自定义,和字典表进行关联
		///</summary> 
		[Required]
		public int GoodSort { get; set; }
		///<summary> 
		///医保编码
		///</summary> 
		public string InsuranceCode { get; set; }
		///<summary> 
		///机构编码-自定义码
		///</summary> 
		public string CustomerCode { get; set; }
		///<summary> 
		///搜索词根
		///</summary> 
		[JsonIgnore]
		public string SearchKey { get; set; }
		///<summary> 
		///计价单位
		///</summary> 
		[Required]
		public string SalesUnit { get; set; }
		/// <summary>
		/// 价格
		/// </summary>		
		public decimal? Price { get; set; }
	}

	/// <summary>
	/// 获取药品分类相关字典
	/// </summary>
	public class GoodSortReuqest
    {
		/// <summary>
		/// 字典类型
		/// </summary>
		public string DicType { get; set; }
    }
} 
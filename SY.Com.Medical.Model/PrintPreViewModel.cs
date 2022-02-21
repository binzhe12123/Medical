using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Model
{
    /// <summary>
    /// 挂号打印模板入参
    /// </summary>
    public class PrintRegisterRequestModel : BaseModel
    {
       /// <summary>
       /// 挂号Id
       /// </summary>
       public int RegisterId { get; set; }
    }

    /// <summary>
    /// 挂号打印模板输出
    /// </summary>
    public class PrintRegisterResponseModel: BaseModel
    {
        /// <summary>
        /// 模板路径-相对
        /// </summary>
        public string ViewPath { get; set; }
		/// <summary>
		/// 挂号Id
		/// </summary>
		public int RegisterId { get; set; }
		///<summary> 
		///人员系统Id
		///</summary> 
		public int PatientId { get; set; }
		///<summary> 
		///医保人员编号
		///</summary> 
		public string psn_no { get; set; }
		///<summary> 
		///患者姓名
		///</summary> 
		public string Name { get; set; }
		///<summary> 
		///患者性别
		///</summary> 
		public int Sex { get; set; }
		///<summary> 
		///出生日期
		///</summary> 
		public DateTime? CSRQ { get; set; }
		///<summary> 
		///省份证号
		///</summary> 
		public string SFZH { get; set; }
		///<summary> 
		///电话号码
		///</summary> 
		public string Phone { get; set; }
		///<summary> 
		///地址
		///</summary> 
		public string Addr { get; set; }

		///<summary> 
		///医生姓名
		///</summary> 
		public string DoctorName { get; set; }
		///<summary> 
		///科室名称
		///</summary> 
		public string DepartmentName { get; set; }
		///<summary> 
		///项目名称
		///</summary> 
		public string GoodsName { get; set; }
		///<summary> 
		///金额
		///</summary> 
		public long GoodsPrice { get; set; }
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

	/// <summary>
	/// 处方打印入参
	/// </summary>
    public class PrintPrescriptionRequestModel:BaseModel
    {
		/// <summary>
		/// 门诊Id
		/// </summary>
		public int OutpatientId { get; set; }
		/// <summary>
		/// 处方PreNo
		/// </summary>
		public int PreNo { get; set; }
		/// <summary>
		/// 中药处方:1,西药处方:2,项目处方:3,治疗单:4
		/// </summary>
		public int Type { get; set; }
	}
	/// <summary>
	/// 处方打印模板输出
	/// </summary>
	public class PrintPrescriptionResponseModel:BaseModel
    {
		/// <summary>
		/// 模板路径-相对
		/// </summary>
		public string ViewPath { get; set; }
		/// <summary>
		/// 具体数据
		/// </summary>
		public OutpatientStructure Data { get; set; }
	}

	/// <summary>
	/// 打印收费退费输入
	/// </summary>
	public class ChargeRecordRequestModel:BaseModel
    {
		/// <summary>
		/// 门诊Id
		/// </summary>
		public int OutPatientId { get; set; }
		/// <summary>
		/// 类型,门诊收费,门诊退费
		/// </summary>
		public string ChargeType { get; set; }

	}

	/// <summary>
	/// 打印收费退费输出
	/// </summary>
	public class ChargeRecordResponseModel:BaseModel
	{
		/// <summary>
		/// 模板路径
		/// </summary>
		public string ViewPath { get; set; }
		///<summary> 
		///收费记录Id
		///</summary> 
		public int ChargeRecordId { get; set; }
		///<summary> 
		/// 患者Id
		///</summary> 
		public int PatientId { get; set; }
		///<summary> 
		/// 挂号Id
		///</summary> 
		public int RegisterId { get; set; }
		///<summary> 
		///门诊Id		
		///</summary> 
		public int SeeDoctorId { get; set; }
		///<summary> 
		///金额
		///</summary> 
		public long Price { get; set; }
		///<summary> 
		///类型
		///</summary> 
		public string ChargeType { get; set; }
		///<summary> 
		///医保支付
		///</summary> 
		public long PayYB { get; set; }
		///<summary> 
		///现金支付
		///</summary> 
		public long PayCash { get; set; }
		///<summary> 
		///微信支付
		///</summary> 
		public long PayWx { get; set; }
		///<summary> 
		///银行卡支付
		///</summary> 
		public long PayBank { get; set; }
		///<summary> 
		///支付宝支付
		///</summary> 
		public long PayAli { get; set; }
	}

	/// <summary>
	/// 打印病历输入
	/// </summary>
	public class CaseBookRequestModel:BaseModel
    {
		/// <summary>
		/// 病历Id
		/// </summary>
		public int CaseBookId { get; set; }
    }

	/// <summary>
	/// 打印病历输出
	/// </summary>
	public class CaseBookResponseModel
    {
		/// <summary>
		/// 打印模板路径
		/// </summary>
		public string ViewPath { get; set; }
		/// <summary>
		/// 打印数据
		/// </summary>
		public CaseBookModel Data { get; set; }
	}

}

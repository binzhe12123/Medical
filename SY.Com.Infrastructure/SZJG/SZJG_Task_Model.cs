using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Infrastructure
{
    //任务类
    public class SZJG_Task_Model
    {
        public int ID { get; set; }
        public long ZHID { get; set; }
        public string TaskName { get; set; }
        public long TaskBH { get; set; }
        public int TaskStatus { get; set; }
        public string TaskResult { get; set; }
        public string CreateTime { get; set; }
        public int IsDelete { get; set; }
        public string ApiPath { get; set; }
        public string ApiMethod { get; set; }
        public string encodeData { get; set; }
    }

    //诊所密钥
    public class SZJG_Key_Model
    {
        public long ZHID { get; set; }
        public string ZHMC { get; set; }
        public string channelId { get; set; }
        public string accessKey { get; set; }
        public string secretKey { get; set; }
        public string publicKey { get; set; }
        public string ZHCode { get; set; }
        public string tel { get; set; }
    }

    public class SZJG_Return_Model
    {
        public string code { get; set; }
        public string msg { get; set; }
        public object data { get; set; }

    }

    public class SZJG_Return_RLSB_Model
    {
        public string code { get; set; }
        public string msg { get; set; }
        public SZJG_Return_RLSB_Event_Model data { get; set; }

    }

    public class SZJG_Return_RLSB_query_Model
    {
        public string code { get; set; }
        public string msg { get; set; }
        public SZJG_Return_RLSB_Query_Model data { get; set; }
    }

    public class SZJG_Return_RLSB_Event_Model
    {
        public string eventId { get; set; }
    }



    //深圳监管平台药品字典数据
    public class SZJG_YPXX_Model
    {
        public string medicalOrgCode { get; set; }// String 是 医疗机构编码
        public string medicalOrgName { get; set; }// String 是 医疗机构名称
        public string drugCode { get; set; }// String 是 药品编码
        public string drugName { get; set; }// String 是 药品名称
        public string commonName { get; set; }// String 是 通用名
        public string drugType { get; set; }// String 是 药品类别
        public string drugSubtype { get; set; }// String 是 药品分类
        public string dosageCode { get; set; }// String 是 剂型
        public string specifications { get; set; }// String 是 规格
        public string drugStoreUnit { get; set; }// String 是 药品库存单位
        public string drugDosageUnit { get; set; }// String 是 药品剂量单位
        public int isMaterial { get; set; }// Boolean 是 是否是材料（0 否，1 是）
        public string antibacterialsFlag { get; set; }// String 是 抗菌药物标志
        public string disabled { get; set; }// String 是 是否停用(0 启用,1 停用)
        public string isDeleted { get; set; }// String 是 记录是否已逻辑删除，0 未删除 1 已删除
        public long createTime { get; set; }// Long 是 数据创建时间
        public long updateTime { get; set; }// Long 是 数据变更时间
    }

    //深圳监管平台药品出入库信息
    public class SZJG_YPCRK_Model
    {
        public string medicalOrgCode { get; set; }// String 是 医疗机构编码
        public string medicalOrgName { get; set; }// Long 是 医疗机构名称
        public string depotId { get; set; }// String 是 单据号 id（出入库数据库关联id）
        public string billNo { get; set; }// String 是 单据号（界面显示给用户看）
        public string depotIdentify { get; set; }// String 是 出入库标识（0 出 1 入）
        public string depotType { get; set; }// String 是 出入库方式，参见字典说明
        public long depotTime { get; set; }// Long 是 出入库时间
        public string isDeleted { get; set; }// String 是 记录是否已逻辑删除，0 未删除1 已删除
        public long createTime { get; set; }// Long 是 数据创建时间
        public long updateTime { get; set; }// Long 是 数据变更时间
    }

    //深圳监管平台药品出入库明细
    public class SZJG_YPCRKMX_Model
    {
        public string medicalOrgCode { get; set; }// String 是 医疗机构编码
        public string medicalOrgName { get; set; }// String 是 医疗机构名称
        public string depotId { get; set; }// String 是 单据号 id（出入库数据库关联 id）
        public string billNo { get; set; }// String 是 单据号（界面显示给用户看）
        public string detailId { get; set; }// String 是 出入库明细 id
        public string drugCode { get; set; }// String 是 药品编码
        public string drugName { get; set; }// String 是 药品名称
        public string variableQuantity { get; set; }// String 是 变动数量
        public string specifications { get; set; }// String 是 规格
        public string storeUnitCode { get; set; }// String 是 库存单位编码
        public string storeUnitName { get; set; }// String 是 库存单位名称
        public string isDeleted { get; set; }// String 是 记录是否已逻辑删除，0 未删除 1 已删除
        public long createTime { get; set; }// Long 是 数据创建时间
        public long updateTime { get; set; }// Long 是 数据变更时间
    }

    //深圳监管平台-药品库存信息
    public class SZJG_YPKCXX_Model
    {
        public string medicalOrgCode { get; set; }// String 是 医疗机构编码
        public string medicalOrgName { get; set; }// String 是 医疗机构名称
        public string storeId { get; set; }// String 是 库存记录 ID
        public string drugCode { get; set; }// String 是 药品编码
        public string drugName { get; set; }// String 是 药品名称
        public string commonName { get; set; }// String 是 通用名
        public string pharmacyCode { get; set; }// String 是 药房编码
        public string pharmacyName { get; set; }// String 是 药房名称
        public string drugType { get; set; }// String 是 药品类别
        public string drugSubtype { get; set; }// String 是 药品分类
        public string storeUnitCode { get; set; }// String 是 库存单位编码
        public string storeUnitName { get; set; }// String 是 库存单位名称
        public string stockQuantity { get; set; }// String 是 药品库存数量
        public string totalOutQuantity { get; set; }// String 是 药品出库数量合计
        public string totalInQuantity { get; set; }// String 是 药品入库数量合计
        public string isDeleted { get; set; }// String 是 记录是否已逻辑删除，0 未删除 1 已删除
        public string createTime { get; set; }// Long 是 数据创建时间
        public string updateTime { get; set; }// Long 是 数据变更时间
    }

    //深圳监管平台-患者基本信息
    public class SZJG_HZXX_Model
    {
        public string medicalOrgCode { get; set; }// String 是 医疗机构代码
        public string medicalOrgName { get; set; }// String 是 医疗机构名称
        public string personIdType { get; set; }// String是个人标识类型（参见字典说明）患者识别码，与患者各种就诊信息记录进行关联
        public string personIdNo { get; set; }// String是个人标识号, 患者识别码，与患者各种就诊信息记录进行关联
        public string idType { get; set; }// String 是 证件类型（参见字典说明）
        public string idNo { get; set; }// String 是 证件号码
        public string patientSex { get; set; }// String 是 性别（参见字典说明）
        public string patientName { get; set; }// String 是 姓名
        public string birthday { get; set; }
        public string nation { get; set; }// String 是 民族（参见字典说明）
        public string countryCode { get; set; }// String 是 国籍（参见字典说明）
        public string isDeleted { get; set; }// String 是 记录是否已逻辑删除，0 未删除 1 已删除
        public string createTime { get; set; }// Long 是 数据生成时间
        public string updateTime { get; set; }// Long 是 数据修改时间
    }

    //深圳监管平台-诊疗项目目录
    public class SZJG_ZLXM_Model
    {
        public string medicalOrgCode { get; set; }// String 是 医疗机构编码
        public string medicalOrgName { get; set; }// String 是 医疗机构名称
        public string treatmentId { get; set; }// String 是 诊所诊疗项目 id
        public string treatmentCode { get; set; }// String 是 诊所诊疗项目编号     
        public string treatmentName { get; set; }// String 是 诊所诊疗项目名称
        public string treatmentTypeId { get; set; }// String 是 诊疗项目类型，不作映射
        public string treatmentUnit { get; set; }// String 是 诊疗项目单位
        public string treatmentPrice { get; set; }// String 是 诊所诊疗项目单价
        public string disabled { get; set; }// String 是 是否停用(0 启用,1 停用)
        public string isDeleted { get; set; }// String 是 记录是否已逻辑删除，0 未删除 1 已删除
        public string createTime { get; set; }// Long 是 数据创建时间
        public string updateTime { get; set; }// Long 是 数据变更时间
    }

    //深圳监管平台-患者门急诊信息
    public class SZJG_HZMZXX_Model
    {
        public string medicalOrgCode { get; set; }// String 是 医疗机构代码
        public string medicalOrgName { get; set; }// String 是 医疗机构名称
        public string personIdType { get; set; }// String是个人标识类型（参见字典说明）患者识别码，与患者各种就诊信息记录进行关联
        public string personIdNo { get; set; }// String是个人标识号, 患者识别码，与患者各种就诊信息记录进行关联
        public string appointment { get; set; }// String否挂号明细，JSONArray 格式的字符串形式。其中单个 JSONObject 的格式定义见下文
        public string acography { get; set; }//String否就诊明细，JSONArray 格式的字符串形式。其中单个 JSONObject 的格式定义见下文
        public string diagnosis { get; set; }// String 否诊断明细，JSONArray 格式的字符串形式。其中单个 JSONObject 的格式定义见下文
        public string mainPrescription { get; set; }// String否处方主表信息，JSONArray 格式的字符串形式。其中单个 JSONObject 的格式定义见下文
        public string drugPrescription { get; set; }// String否药品处方明细，JSONArray 格式的字符串形式。其中单个 JSONObject 的格式定义见下文
        public string otherPrescription { get; set; }// String否其他处方明细，JSONArray 格式的字符串形式。其中单个 JSONObject 的格式定义见下文
        public string cost { get; set; }// String否费用明细，JSONArray 格式的字符串形式。其中单个 JSONObject 的格式定义见下文
        public string settlement { get; set; }// String否结算明细，JSONArray 格式的字符串形式。其中单个 JSONObject 的格式定义见下文
        public string settlementPay { get; set; }// String否结算支付方式明细，JSONArray 格式的字符串形式。其中单个 JSONObject 的格式定义见下文
        public string medicalRecord { get; set; }// String否门诊病历主表信息，JSONArray 格式的字符串形式。其中单个 JSONObject 的格式定义见下文
        public string medicalRecordDiagnosis { get; set; }// String否门诊病历诊断信息，JSONArray 格式的字符串形式。其中单个 JSONObject 的格式定义见下文
        public string medicalRecordAdvice { get; set; }// String否门诊病历医嘱信息，JSONArray 格式的字符串形式。其中单个 JSONObject 的格式定义见下文
        public string tcmRecord { get; set; }// String否中医门诊电子病历明细，JSONArray 格式的字符串形式。其中单个 JSONObject 的格式定义见下文
        public string oralCavityRecord { get; set; }// String否口腔门诊电子病历明细，JSONArray 格式的字符串形式。其中单个 JSONObject 的格式定义见下文
    }

    //挂号明细
    public class SZJG_GHMX_Model
    {
        public string registeredRecordId { get; set; }// String 是 挂号记录 ID
        public string acographyNo { get; set; }// String 是 就诊流水号
        public string patientName { get; set; }// String 是 就诊人姓名
        public string registeredTime { get; set; }// Long 是 挂号时间
        public string reExamine { get; set; }// String 是 是否初复诊（1 初诊，2 复诊）
        public string deptCode { get; set; }// String 是 科室编码
        public string deptName { get; set; }// String 是 科室名称
        public string doctorNo { get; set; }// String 是 挂号医生编号
        public string doctorName { get; set; }// String 是 挂号医生姓名
        public string totalAmount { get; set; }// String 是 挂号总费用
        public string isDeleted { get; set; }// String 是 记录是否已逻辑删除，0 未删除 1 已删除
        public string createTime { get; set; }// Long 是 数据生成时间
        public string updateTime { get; set; }// Long 是 数据修改时间
    }

    //就诊明细
    public class SZJG_JZMX_Model
    {
        public string acographyId { get; set; }// String 是 就诊记录 ID
        public string acographyNo { get; set; }// String 是 就诊流水号
        public string reExamine { get; set; }// String 是 是否复诊（1 初诊，2 复诊）
        public string patientName { get; set; }// String 是 患者姓名
        public string paymentType { get; set; }// String 是 结算方式（1:医保 2:商保 3:自费)）
        public string acographyType { get; set; }// String 是 就诊类别：0-普通，1-急诊，2-儿科
        public string departNo { get; set; }// String 是 就诊科室编码
        public string departName { get; set; }// String 是 就诊科室名称
        public string acographyDate { get; set; }// Long 是 门诊就诊日期
        public string doctorNo { get; set; }// String 是 主诊医生编号
        public string doctorName { get; set; }// String 是 主诊医生姓名
        public string diagnosisCode { get; set; }// String是门诊诊断代码（主要诊断，多个使用 & 隔 开)
        public string diagnosisName { get; set; }// String是门诊诊断名称（主要诊断，多个使用 & 隔开）
        public string isDeleted { get; set; } //String 是 记录是否已逻辑删除，0 未删除 1 已删除
        public string createTime { get; set; }// Long 是 数据生成时间
        public string updateTime { get; set; }// Long 是 数据修改时间
    }

    //诊断明细
    public class SZJG_ZDMX_Model
    {
        public string diagnoseId { get; set; }// String 是 诊断 ID
        public string acographyNo { get; set; }// String 是 就诊流水号
        public string diagnoseTime { get; set; }// Long 是 诊断日期时间
        public string diagnoseMethodCode { get; set; }// String是诊断方法代码，01：西医；02：中医；03:口腔
        public string diagnoseStandardCode { get; set; }// String是诊断标准代码，01：ICD-10；02：国标-95； 03:自定义
        public string diagnoseTypeCode { get; set; }// String 是 诊断类别代码（参见字典说明）
        public string diagnosticCode { get; set; }// String是诊断代码，填写医院业务系统实际的诊断代码
        public string diagnosticName { get; set; }// String 是 诊断名称
        public string isDeleted { get; set; }// String 是 记录是否已逻辑删除，0 未删除 1 已删除
        public string createTime { get; set; }// Long 是 数据创建时间
        public string updateTime { get; set; }// Long 是 数据变更时间(编辑时间)
    }

    //处方主表信息
    public class SZJG_CFZBXX_Model
    {
        public string prescriptionId { get; set; }// String 是 处方 ID
        public string prescriptionNo { get; set; }// String 是 处方编号
        public string acographyNo { get; set; }// String 是 就诊流水号
        public string prescriptionType { get; set; }// String 是 处方类型，参见字典说明
        public string deptCode { get; set; }// String 是 开方科室代码
        public string deptName { get; set; }// String 是 开方科室名称
        public string doctorNo { get; set; }// String 是 开方医生编号
        public string doctorName { get; set; }// String 是 开方医生姓名
        public string prescriptionTime { get; set; }// Long 是 开方时间
        public string patientId { get; set; }// String 是 患者 ID
        public string costType { get; set; }//费别
        public string patientName { get; set; }// String 是 患者姓名
        public string patientSex { get; set; }
        public string patientAge { get; set; }
        public float prescriptionAmount { get; set; }// Float 是 处方金额
        public string isDeleted { get; set; }// String 是 记录是否已逻辑删除，0 未删除 1 已删除
        public string createTime { get; set; }// Long 是 数据创建时间
        public string updateTime { get; set; }// Long 是 数据变更时间
    }

    //药品处方明细
    public class SZJG_YPCFMX_Model
    {
        public string prescriptionDetailId { get; set; }// String 是 处方明细 ID
        public string acographyNo { get; set; }// String 是 就诊流水号
        public string prescriptionMajorId { get; set; }// String 是 处方主 ID
        public string diagnosticCategoryCode { get; set; }// String 是 诊疗项目类别编码
        public string projectCode { get; set; } //String 是 项目代码
        public string projectName { get; set; } //String是项目名称, 药品通用名，中草药部分填写院内使用药物名称
        public string medicinalFormCode { get; set; }// String 是 剂型代码
        public string drugSpecifications { get; set; }// String 是 药品规格
        public string medicationRouteCode { get; set; }// String是用药途径代码（参见字典说明中的药品用法定义）
        public string medicationRouteName { get; set; }// String 是 用药途径名称
        public string useFrequencyCode { get; set; }// String 是 使用频次代码
        public string useDrugFrequency { get; set; }// String 是 用药频次
        public string dosageUnit { get; set; }// Float 是 使用剂量单位
        public float dosageTotal { get; set; }// Float 是 使用总剂量
        public int medicationDays { get; set; }// Integer 是 用药天数
        public string isDeleted { get; set; }// String 是 记录是否已逻辑删除，0 未删除 1 已删除
        public string createTime { get; set; }// Long 是 数据创建时间
        public string updateTime { get; set; }// Long 是 数据变更时间
    }
    //其他处方明细
    public class SZJG_QTCFMX_Model
    {
        public string prescriptionDetailId { get; set; }// String 是 处方明细 ID
        public string acographyNo { get; set; }// String 是 就诊流水号
        public string prescriptionMajorId { get; set; }// String 是 处方主 ID
        public string diagnosticCategoryCode { get; set; }// String 是 诊疗项目类别编码
        public string projectCode { get; set; }// String 是 项目代码
        public string projectName { get; set; }// String 是 项目名称
        public string projectTypeCode { get; set; }// String 是 项目分类代码（参见字典说明）
        public string projectTypeName { get; set; }// String 是 项目分类名称
        public string isDeleted { get; set; }// String 是 记录是否已逻辑删除，0 未删除 1 已删除
        public string createTime { get; set; }// Long 是 数据创建时间
        public string updateTime { get; set; }// Long 是 数据变更时间
    }
    //费用明细
    public class SZJG_FYMX_Model
    {
        public string costId { get; set; }// String 是 收费明细 ID
        public string acographyNo { get; set; }// String 是 就诊流水号
        public string refundFlag { get; set; }// String 是 退费标志（参见字典说明）
        public string chargeScenarioCode { get; set; }// String 是 收费场景代码
        public string prescriptionDetailId { get; set; }// String 是 处方明细 ID
        public string chargeCategoryCode { get; set; }// String 是 收费项目类别代码
        public string costClassifyCode { get; set; }// String 是 费用收入归类代码（参见字典说明）
        public string costClassifyName { get; set; }// String 是 费用收入归类名称
        public string costTime { get; set; }// Long 是 费用发生时间
        public string costPayId { get; set; }// String 是 费用结算 ID
        public string costPayTime { get; set; }// Long是费用结算时间，收费为收费结算时间，退费为退费结算时间
        public string costDeptCode { get; set; }// String 是 开单科室编码
        public string costDeptName { get; set; }// String 是 开单科室名称
        public string costDoctorNo { get; set; }// String 是 开单医生编号
        public string costDoctorName { get; set; }// String 是 开单医生姓名
        public string detailItemCode { get; set; }// String 是 明细项目代码
        public string detailItemName { get; set; }// String 是 明细项目名称
        public string detailItemUnit { get; set; }// String 是 明细项目单位
        public float detailItemUnitPrice { get; set; }// Float 是 明细项目单价
        public string itemTypeCode { get; set; }// String 是 项目分类代码（参见字典说明）
        public string itemNameCode { get; set; }// String 是 项目分类名称
        public float detailItemQuantity { get; set; }// Float 是 明细项目数量
        public float receivableAmount { get; set; }// Float 是 明细项目应收金额
        public float payInAmount { get; set; }// Float 是 明细项目实收金额
        public string isDeleted { get; set; }// String 是 记录是否已逻辑删除，0 未删除 1 已删除
        public string createTime { get; set; }// Long 是 数据创建时间
        public string updateTime { get; set; }// Long 是 数据变更时间
    }
    //结算明细
    public class SZJG_JSMX_Model
    {
        public string settlementRecordId { get; set; }// String 是 结算记录 ID
        public string acographyNo { get; set; }// String 是 就诊流水号
        public string chargeScenarioCode { get; set; }// String是收费场景代码, 1 挂号时产生费用；2 门诊收费产生费用
        public string settlementStatus { get; set; }// String 是 记录收费状态，参见退费标志字典说明
        public string costPayTime { get; set; }// Long 是 费用结算时间
        public string payTypeCode { get; set; }// String 是 医疗付费方式代码（参见字典说明）
        public string payTypeName { get; set; }// String 是 医疗付费方式名称
        public float costTotalAmount { get; set; }// Float 是 费用结算总金额（应收）
        public float personalCostAmount { get; set; }// Float 是 个人承担费用金额（实收）
        public string settlerNo { get; set; }// String 是 结算人员编号
        public string settlerName { get; set; }// String 是 结算人员姓名
        public string isDeleted { get; set; }// String 是 记录是否已逻辑删除，0 未删除 1 已删除
        public string createTime { get; set; }// Long 是 数据创建时间
        public string updateTime { get; set; }// Long 是 数据变更时间
    }
    //结算支付方式明细
    public class SZJG_JSZFFSMX_Model
    {
        public string payTypeRecordId { get; set; }// String 是 支付记录 ID
        public string payOrderId { get; set; }// String 是 支付订单号
        public string payOrderStatus { get; set; }// String 是 支付订单状态（参见字典说明）
        public string acographyNo { get; set; }// String 是 就诊流水号
        public string settlementRecordId { get; set; }// String 是 结算记录 ID
        public string settlementStatus { get; set; }// String 是 记录收费状态 1：收费；2：退费
        public string chargeNo { get; set; }// String 是 收费单据号
        public string payTypeCode { get; set; }// String 是 支付方式代码（参见字典说明）
        public float payAmount { get; set; }// Float 是 支付金额
        public string costPayTime { get; set; }// Long 是 费用结算时间
        public string settlerNo { get; set; }// String 是 结算人员编号
        public string settlerName { get; set; }// String 是 结算人员姓名
        public string isDeleted { get; set; }// String 是 记录是否已逻辑删除，0 未删除 1 已删除
        public string createTime { get; set; }// Long 是 数据创建时间
        public string updateTime { get; set; }// Long 是 数据变更时间
    }
    //病历主表信息
    public class SZJG_BLZBXX_Model
    {
        public string acographyNo { get; set; }// String 是 就诊流水号
        public string recordNo { get; set; }// String 是 病历id
        public string modifyFlag { get; set; }// String 是 修改标志
        public string doorNum { get; set; }// String 是 门（急）诊号     
        public string recordType { get; set; }// String 是 病历类型（参见字典说明）
        public string patientName { get; set; }// String 是 患者姓名
        public string sexCode { get; set; }// String 是 性别代码
        public string patientSex { get; set; }// String 是 性别
        public string birthDate { get; set; }// Long 是 出生日期
        public string AgeYears { get; set; }// Integer 年龄(岁)
        public string AgeMonth { get; set; }// Integer 年龄(月）
        public string patientTypeCode { get; set; }// String 是 患者类型代码
        public string iniDiagnosisCode { get; set; }// String 是 初诊标志代码
        public string mainComplaint { get; set; }// String 是 主诉
        public string visitDate { get; set; }// Long 是 就诊时间
        public string resDoctorName { get; set; }// String 是 责任医师姓名
        public string isDeleted { get; set; }// String 是 记录是否已逻辑删除，0 未删除 1 已删除
        public string createTime { get; set; }// Long 是 数据创建时间
        public string updateTime { get; set; }// Long 是 数据变更时间
    }
    //病历诊断信息
    public class SZJG_BLZDXX_Model
    {
        public string recordNo { get; set; }// String 是 病历 id
        public string acographyNo { get; set; }// String 是 就诊流水号
        public string doorNum { get; set; }// String 是 门（急）诊号
        public string departmentCode { get; set; }// String 是 就诊科室代码
        public string departmentName { get; set; }// String 是 就诊科室名称
        public string visitDate { get; set; }// Long 是 就诊日期时间
        public string iniWMDiagnosisCode { get; set; }// String 是 初步诊断_西医诊断编码
        public string iniWMDiagnosisName { get; set; }// String 是 初步诊断_西医诊断名称
        public string doctorNum { get; set; }// String 是 医师编号
        public string doctorSign { get; set; }// String 是 医师签名
        public string isDeleted { get; set; }// String 是 记录是否已逻辑删除，0 未删除 1 已删除
        public string createTime { get; set; }// Long 是 数据创建时间
        public string updateTime { get; set; }// Long 是 数据变更时间
    }
    //病历医嘱信息
    public class SZJG_BLYZXX_Model
    {
        public string adviceRecordNum { get; set; }// String 是 医嘱记录编号
        public string recordNo { get; set; }// String 是 病历 id
        public string acographyNo { get; set; }// String 是 就诊流水号
        public string doorNum { get; set; }// String 是 门（急）诊号
        public string isDeleted { get; set; }// String 是 记录是否已逻辑删除，0 未删除 1 已删除
        public string createTime { get; set; }// Long 是 数据创建时间
        public string updateTime { get; set; }// Long 是 数据变更时间
    }
    //中医病历明细信息
    public class SZJG_ZYBLMX_Model
    {
        public string recordNo { get; set; }// String 是 病历id
        public string acographyNo { get; set; }// String 是 就诊流水号
        public string departmentCode { get; set; }// String 是 科室编码
        public string departmentName { get; set; }// String 是 科室名称
        public string doctorNum { get; set; }// String 是 医生编号
        public string doctorName { get; set; }// String 是 医生姓名
        public string attackRecord { get; set; }// String 是 发病记录
        public string visitDate { get; set; }// Long 是 就诊时间
        public string diagnosisSuggestion { get; set; }// String 是 诊疗意见
        public string tcmDiagnosisName { get; set; }// String 是 中医诊断病名
        public string diseaseLocation { get; set; }// String 是 病位
        public string natureDisease { get; set; }// String 是 病性
        public string channelTropism { get; set; }// String 是 归经
        public string prescriptionName { get; set; }// String 是 方剂名称
        public string TCMPrescriptionComposition { get; set; }// String 是 方剂组成（中药）
        public string Usage { get; set; } //String 是 用法
        public string Note { get; set; }// String 是 备注
        public string isDeleted { get; set; }// String 是 记录是否已逻辑删除，0 未删除 1 已删除
        public string createTime { get; set; }// Long 是 数据创建时间
        public string updateTime { get; set; }// Long 是 数据变更时间
    }
    //口腔病历明细信息
    public class SZJG_KQBLMX_Model
    {
        public string recordId { get; set; }// String 是 病历id
        public string acographyNo { get; set; }// String 是 就诊流水号
        public string modifyFlag { get; set; }// String 是 修改标志
        public string departmentCode { get; set; }// String 是 科室编码
        public string departmentName { get; set; }// String 是 科室名称
        public string doctorNum { get; set; }// String 是 医生编号
        public string doctorName { get; set; }// String 是 医生姓名
        public string attackRecord { get; set; }// String 是 发病记录
        public string visitDate { get; set; }// Long 是 就诊时间
        public string checkDentalPosition { get; set; }// String 是 检查牙位
        public string Check { get; set; }// String 是 检查
        public string auxiliaryCheckDentalPosition { get; set; }// String 是 辅助检查牙位
        public string auxiliaryCheck { get; set; }// String 是 辅助检查
        public string treatmentPlanDentalPosition { get; set; }// String 是 治疗计划牙位
        public string treatmentPlan { get; set; }// String 是 治疗计划
        public string diagnosisDentalPosition { get; set; }// String 是 诊断牙位
        public string diagnosis { get; set; }// String 是 诊断
        public string processDentalPosition { get; set; }// String 是 处理牙位
        public string process { get; set; }// String 是 处理
        public string adviceDentalPosition { get; set; }// String 是 医嘱牙位
        public string advice { get; set; }// String 是 医嘱
        public string isDeleted { get; set; }// String 是 记录是否已逻辑删除，0 未删除 1 已删除
        public string createTime { get; set; }// Long 是 数据创建时间
        public string updateTime { get; set; }// Long 是 数据变更时间
    }

    //监管平台创建人脸识别入参
    public class SZJG_RLSB_Model
    {
        public string channelId { get; set; }
        public string medicalOrgCode { get; set; }
        public string medicalOrgName { get; set; }
        public string doctorNum { get; set; }
        public string doctorName { get; set; }
        public string idNo { get; set; }
        public string title { get; set; }
        public string callbackUrl { get; set; }
    }

    //监管平台查询人脸识别结果入参
    public class SZJG_RLSB_Query_Model
    {
        public string channelId { get; set; }
        public string eventId { get; set; }
    }

    //监管平台查询人脸识别结果出参
    public class SZJG_Return_RLSB_Query_Model
    {
        public string evenCode { get; set; }//code 成功时，事件结果状态1：成功；0：采集失败；-1：拒绝采集
        public string medicalOrgCode { get; set; }// String 医疗机构代码
        public string doctorNum { get; set; }// String 医生编号
        public string doctorName { get; set; }// String 医生姓名
        public string editState { get; set; }// String 医生身份证是否编辑标识1：已编辑；0：未编辑
        public string originIdNo { get; set; }// String 医生身份证号(原始)
        public string editIdNo { get; set; }// String 医生身份证号(编辑后)
    }

    //医疗机构信息
    public class SZJG_JGXX_Model
    {
        public string medicalOrgCode { get; set; }
        public string medicalOrgName { get; set; }
        public string certList { get; set; }
        public string diagnosisSubject { get; set; }
        public string provinceCode { get; set; }// String 是 地址-省（自治区、直辖市）编码
        public string provinceName { get; set; }// String 是 地址-省（自治区、直辖市）名称
        public string cityCode { get; set; }// String 是 地址-市（地区、州）编码
        public string cityName { get; set; }// String 是 地址-市（地区、州）名称
        public string countyCode { get; set; }// String 是 地址-县（区）编码
        public string countyName { get; set; }// String 是 地址-县（区）名称
        public string streetCode { get; set; }
        public string streetName { get; set; }//街道
        public string address { get; set; }// string 详细地址
        public string medicalOrgGeneralCategory { get; set; }// String 是 医疗机构大类（详见字典说明）
        public string medicalOrgCategory { get; set; }// String 是 医疗机构类别（详见字典说明）
        public string phone { get; set; }
        public string insuranceUnitFlag { get; set; }// String 是 是否医保定点单位
        public string internetFlag { get; set; }// String 是 是否互联网医院
        public string disabled { get; set; }// String 是 是否停用(0 启用,1 停用)
        public string isDeleted { get; set; }// String 是 记录是否已逻辑删除，0 未删除 1 已删除
        public string createTime { get; set; }// Long 是 创建时间，时间戳
        public string updateTime { get; set; }// Long 是 变更时间，时间戳
    }

    //医疗机构中证书信息
    public class SZJG_JGXX_cert_Model
    {
        public string certType { get; set; }// String 是 证书类型（详见字典说明）
        public string certNo { get; set; }// String 是 证书编号
        public string certName { get; set; }// String 是 证书名称
        public long certExpiry { get; set; }//有效期
        public long nextCheckDate { get; set; }//下次年检时间
        public long issuanceDate { get; set; }
    }
    //职工证书
    public class SZJG_ZGXX_cert_Model
    {
        public string certType { get; set; }// String 是 证书类型（详见字典说明）
        public string certNo { get; set; }// String 是 证书编号
        public string certName { get; set; }// String 是 证书名称
        public long certExpiry { get; set; }//有效期
        public long submissionDate { get; set; }//提交时间
        public long issuanceDate { get; set; }//发证时间
    }

    //职工信息
    public class SZJG_ZGXX_Model
    {
        public string medicalOrgCode { get; set; }// String 是 医疗机构代码
        public string medicalOrgName { get; set; }// String 是 医疗机构名称
        public string employeeCode { get; set; }// String 是 职工编码
        public string employeeName { get; set; }// String 是 职工名称
        public string employeeGender { get; set; }// String 是 职工性别（参见字典说明）
        public string employeeCategory { get; set; }// String 是 职工类别（参见字典说明）
        public string idType { get; set; }// String 是 证件类型（参见字典说明）
        public string idNo { get; set; }// String 是 证件号码
        public string certList { get; set; }//
        public string disabled { get; set; }// String 是 是否停用(0 启用,1 停用)
        public string isDeleted { get; set; }// String 是 记录是否已逻辑删除，0 未删除 1 已删除
        public string createTime { get; set; }// Long 是 创建时间
        public string updateTime { get; set; }// Long 是 变更时间
    }

    //诊所月报
    public class SZJG_Month_Model
    {
        public string medicalOrgCode { get; set; }// String 是 医疗机构代码
        public string year { get; set; }// String 是 统计年度
        public string month { get; set; }// String 是 统计月份
        public string isDeleted { get; set; }// String 是 记录是否已逻辑删除，0 未删除 1 已删除
        public string createTime { get; set; }// Long 是 数据创建时间
        public string updateTime { get; set; }// Long 是 数据变更时间

    }

    //诊所年报
    public class SZJG_Year_Model
    {
        public string medicalOrgCode { get; set; }// String 是 医疗机构编码
        public string medicalOrgName { get; set; }// String 是 医疗机构名称
        public string year { get; set; }// String 是 统计年度
        public string isDeleted { get; set; }// String 是 记录是否已逻辑删除，0 未删除 1 已删除
        public string createTime { get; set; }// Long 是 数据创建时间
        public string updateTime { get; set; }// Long 是 数据变更时间
    }

    //附件上传
    public class SZJG_Attachment_Model
    {
        public string medicalOrgCode { get; set; }// String 是 机构编码
        public string objectType { get; set; }// String 是 对象类型【1 机构，2 医师，3 供应商】
        public string objectId { get; set; }// String 是 对应的唯一 ID
        public string certificateType { get; set; }// String 是 证件类型
        public string certificateNo { get; set; }// String 是 证件号码
        public string certificateTypeDesc { get; set; }// String 是 证件类型描述
        public string fileType { get; set; }//文件类型，例如 png、jpeg、pdf 等
    }

    //供应商
    public class SZJG_GYS_Model
    {
        public string medicalOrgCode { get; set; }// String 是 医疗机构编码
        public string vendorCode { get; set; }// String 是 供应商编码
        public string vendorName { get; set; }// String 是 供应商名称
        public string shortName { get; set; }// String 是 供应商简称
        public string vendorType { get; set; }// String 是 供应商类型（参见字典说明）
        public string productType { get; set; }// String 是 产品类型（参见字典说明）
        public string provinceCode { get; set; }// String 是 地址-省（自治区、直辖市）编码
        public string provinceName { get; set; }// String 是 地址-省（自治区、直辖市）名称
        public string cityCode { get; set; }// String 是 地址-市（地区、州）编码
        public string cityName { get; set; }// String 是 地址-市（地区、州）名称
        public string countyCode { get; set; }// String 是 地址-县（区）编码
        public string countyName { get; set; }// String 是 地址-县（区）名称
        public string certList { get; set; }//
        public string disabled { get; set; }// String 是 是否停用(0 启用,1 停用)
        public string isDeleted { get; set; }// String 是 记录是否已逻辑删除，0 未删除 1 已删除
        public string createTime { get; set; }// Long 是 数据创建时间
        public string updateTime { get; set; }// Long 是 数据变更时间
    }

    //科室信息
    public class SZJG_KSXX_Model
    {
        public string medicalOrgCode { get; set; }// String 是 医疗机构编码
        public string medicalOrgName { get; set; }// String 是 医疗机构名称
        public string deptCode { get; set; }// String 是 科室编码
        public string deptName { get; set; }// String 是 科室名称
        public string deptType { get; set; }// String 是 科室类型，不作映射
        public string disabled { get; set; }// String 是 是否停用(0 启用,1 停用)
        public string isDeleted { get; set; }// String 是 记录是否已逻辑删除，0 未删除 1 已删除
        public string createTime { get; set; }// Long 是 数据创建时间
        public string updateTime { get; set; }// Long 是 数据变更时间
    }

    //处方诊断
    public class SZJG_KBXX_ZD_Model
    {
        public string JBBM { get; set; }
        public string JBMC { get; set; }
    }

}

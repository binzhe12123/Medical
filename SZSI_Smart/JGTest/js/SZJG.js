function MillSecond(d) {
    var s = d.getMilliseconds();
    if (s.length == 1) {
        s = "00" + s;
        return s;
    } else if (s.length == 2) {
        s = "0" + s;
        return s;
    } else {
        return s;
    }
}

Date.prototype.format = function (format) {
    var args = {
        "yyyy": this.getFullYear(),
        "M+": this.getMonth() + 1,
        "d+": this.getDate(),
        "h+": this.getHours(),
        "m+": this.getMinutes(),
        "s+": this.getSeconds(),
        "q+": Math.floor((this.getMonth() + 3) / 3),  //quarter
        "S": MillSecond(this)
    };

    if (/(y+)/.test(format))
        format = format.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var i in args) {
        var n = args[i];
        if (new RegExp("(" + i + ")").test(format))
            format = format.replace(RegExp.$1, RegExp.$1.length == 1 ? n : ("00" + n).substr(("" + n).length));
    }
    return format; 
};

var key_mod = {};
var SZJGDataMZ = {
    "eventId": "",
    "personIdType": "",
    "personIdNo": "",
    "deptCode": "",
    "deptName": "",
    "employeeCode": "",
    "employeeName": "",
    "XMID": "",
    "XMMC": "",
    "YSSFZH":"",
}
//页面信息
function Datainit()
{
    key_mod = {
        "ZHID": "",
        "ZHMC": $("#txtYLJGMC").val(),
        "channelId": $("#txtChannel").val(),
        "accessKey": $("#txtAccessKey").val(),
        "secretKey": $("#txtSecretKey").val(),
        "publicKey": $("#txtPublicKey").val(),
        "ZHCode": $("#txtYLJGBM").val(),
       // "employeeCode": $("#txtYLZGBM").val(),
        "employeeName": $("#txtYLZGMC").val(),
        "drugCode": $("#txtYLYPBM").val(),
        "drugName": $("#txtYLYPMC").val(), 
        "YPID": $("#txtCGDBH").val(),
        "DeatilID": $("#txtDeatil").val(),
        "CGSL": $("#txtCGSL").val(),
        "YPGG": $("#txtYPGG").val(),
        "CGDBH": $("#txtCGZBID").val(),
        "HZID": $("#txtHZID").val(),
        "HZXM": $("#txtHZXM").val(),
        "HZXB": $("#HZXB").val(),
        "YSSFZH": $("#txtSFZH").val(),
        "YSXB": $("#RYXB").val(),
    }
}

//======================================深圳监管  Start=============================

var autoMethod = [];



function LoadData()
{
    autoMethod = [institution, Months, Years, GYSXX, KSXX,
        employee, KJquery,
        dictionary, depot, detail, YPKC,
        project, portfolio, projectDetail,
        HZXX, outpatient,
        RLbuild, YB, RL, RLquery];
    autoMethod = autoMethod.reverse();
    autoInterface();
}

function ClearData()
{
    autoMethod = [];
}


function autoInterface()
{
    if (autoMethod.length < 1)
    {
        return;
    }
    var method = autoMethod.pop();
    if (method != undefined && method.constructor.name == "Function") {
        Datainit();
        method();
    }    
}


function SZSI_Smart_AJAX(param,callback)
{
    param.key_mod = key_mod;
    $.ajax({
        async: true,
        type: "POST",
        url: $("#txtUrl").val(),
        data: param,//{ "": JSON.stringify(param) },
        error: function (msg) {
            viewWindow(param.infno, msg, "error");
        }
    }).then(function (result) {
        result = JSON.parse(result);
        if (result.code == "000000") {
            viewWindow(param.szjgtype, "成功", "success");
                callback(result);
            } else {
            viewWindow(param.szjgtype, result.msg, "error");
            }
    })
}

function Age(birthday) {
    var date = new Date();
    var startDate = new Date(birthday);
    var newDate = date.getTime() - startDate.getTime();  
    var age = Math.ceil(newDate / 1000 / 60 / 60 / 24 / 365);
    if (isNaN(age)) {
        age = "0";
    }
    return age;
}



//获取时间戳
//var timestamp4 = Number(new Date());

/*
        医疗机构信息,
        职工信息,
        药品字典,
        药品出入库信息,
        药品出入库明细,
        药品库存信息,
        患者基本信息,
        诊所月报,
        诊所年报,
        诊疗项目目录,
        组合项目目录,
        组合项目明细,
        附件上传,
        供应商信息,
        科室信息,
        人脸识别监管事件创建,
        人脸识别监管事件结果查询,
        查询抗菌处方权审核资质,
        患者门急诊信息   
*/

//医疗机构资质监管-医疗机构信息
function institution() {
    var szjgtype = "医疗机构信息";
    //处理证书
    var cert = [];
    for (var i = 1; i < $("#tableZS").find("tr").length ; i++)
    {
        if ($("#txtno0" + i).val() != "")
        {
            cert.push({
                "certType": $("#txtlx0" + i).val(), "certNo": $("#txtno0" + i).val(), "certName": $("#txtmc0" + i).val()
                , "certExpiry": Number(new Date($("#txtxq0" + i))).val(), "nextCheckDate": Number(new Date($("#txtnj0" + i))).val()});
        }
    }

    var data = [{
        "medicalOrgCode": $("#txtYLJGBM").val(),
        "medicalOrgName": $("#txtYLJGMC").val(),
        "certList": cert,
        "diagnosisSubject": "医疗机构诊疗科目",
        "provinceCode": "440000",
        "provinceName": "广东省",
        "cityCode": "440300",
        "cityName": "深圳市",
        "countyCode": "440303",
        "countyName": "罗湖区",
        "streetCode": "440303004",
        "streetName": "翠竹街道",
        "address": "桃花园路",
        "medicalOrgGeneralCategory": $("#selYLJGDL").val(),
        "medicalOrgCategory": $("#selYLJGLB").val(),
        "insuranceUnitFlag": "1",
        "internetFlag": "0",
        "disabled": "0",
        "isDeleted": "0",
        "createTime": Number(new Date()),
        "updateTime": Number(new Date())
    }];
    var param = {"szjgtype":szjgtype,data:JSON.stringify(data)}
    SZSI_Smart_AJAX(param, function (data) {
        autoInterface();
        
    })
    //return param;
}
//医疗机构资质监管-职工信息
function employee(){
    var szjgtype = "职工信息";
    //处理证书
    var cert = [];
    for (var i = 1; i < $("#tableYS").find("tr").length + 1; i++) {
        if ($("#txtno0" + i).val() != "") {
            cert.push({
                "certType": $("#txtz0" + i).val(), "certNo": $("#txtzg0" + i).val(), "certName": $("#txtzgl0" + i).val()
                
            });
        }
    }

    var data = [{
        "medicalOrgCode": $("#txtYLJGBM").val(),
        "medicalOrgName": $("#txtYLJGMC").val(),
        "employeeCode": $("#txtYLJGBM").val(),
        "employeeName": $("#txtYLZGMC").val(),
        "employeeGender": "9",// 0 未知的性别   1 男性 2 女性  9 未说明的性别
        "employeeCategory": "1",//1 医师
        "idType":"1",
        "idNo": "130532199606131047",
        "certList": cert,
        "birthday": "",
        "mobilePhone": "",
        "participationDate": Number(new Date()),
        "departmentCode": "",
        "departmentName": "",
        "titleCode": "",
        "title": "",
        "educationalCode": "",
        "isMultiPoint": "",
        "multiPointOrg": "",
        "disabled": "0",//是否停用(0 启用,1 停用)
        "isDeleted": "0",//记录是否已逻辑删除，0 未删除 1 已删除
        "createTime": Number(new Date()),
        "updateTime": Number(new Date()),
    }];
    var param = { "szjgtype": szjgtype, data: JSON.stringify(data)}

    SZSI_Smart_AJAX(param, function (res) {
        SZJGDataMZ.employeeCode = data[0].employeeCode;
        SZJGDataMZ.employeeName = data[0].employeeName;
        SZJGDataMZ.YSSFZH = data[0].idNo,
        console.log(SZJGDataMZ)
        autoInterface();
    })
}
//医疗机构资质监管-药品字典
function dictionary() {
    var szjgtype = "药品字典";
    var data = [{
        "medicalOrgCode": $("#txtYLJGBM").val(),
        "medicalOrgName": $("#txtYLJGMC").val(),
        "drugCode": $("#txtYLYPBM").val(),
        "drugName": $("#txtYLYPMC").val(),
        "commonName": "阿莫西林",
        "drugType": "药品类别",
        "drugSubtype": "药品分类",
        "retailPrice": "",
        "dosageCode": "片剂",
        "specifications": "片",
        "drugStandardCode": "",
        "drugStoreUnit": "片",
        "drugDosageUnit": "片",
        "miniDosage": "",
        "miniPackagingUnit": "",
        "miniPackagingMaterial": "",
        "approvalNo": "",
        "manufacturerCode": "",
        "manufacturerName": "",
        "drugDiscontinued": "",
        "drugBarCode": "",
        "isMaterial": "0",//是否是材料（0 否，1 是）
        "isPrescription": "",
        "isStandard": "",
        "antibacterialsFlag": "0",//抗菌药物标志
        "antibacterialsDrugsLevel": "",
        "antibacterialsDrugsLevelName": "",
        "disabled": "0",
        "isDeleted": "0",
        "createTime": Number(new Date()),
        "updateTime": Number(new Date()),
    }];
    var param = { "szjgtype": szjgtype, data: JSON.stringify(data) }
    SZSI_Smart_AJAX(param, function (data) {
        autoInterface();
    })
}
//医疗机构资质监管-药品出入库信息
function depot() {
    var szjgtype = "药品出入库信息";    
    var data = [{
        "medicalOrgCode": $("#txtYLJGBM").val(),
        "medicalOrgName": $("#txtYLJGMC").val(),
        "depotId": $("#txtCGDBH").val(),
        "billNo": $("#txtCGDBH").val(),
        "invoiceNo": "",
        "storehouseCode": "",
        "storehouseName": "",
        "depotIdentify": "1",//出入库标识（0 出 1 入）
        "depotType": "1",
        "depotTime": Number(new Date()),
        "totalAmount": "",
        "isDeleted": "0",
        "createTime": Number(new Date()),
        "updateTime": Number(new Date()),
    }];
    var param = { "szjgtype": szjgtype, data: JSON.stringify(data) }
    SZSI_Smart_AJAX(param, function (data) {
        autoInterface();
    })
}
//医疗机构资质监管-药品出入库明细
function detail() {
    var szjgtype = "药品出入库明细";
    var data = [{
        "medicalOrgCode": $("#txtYLJGBM").val(),
        "medicalOrgName": $("#txtYLJGMC").val(),
        "depotId": $("#txtCGDBH").val(),
        "billNo": $("#txtCGDBH").val(),
        "detailId": $("#txtDeatil").val(),
        "drugCode": $("#txtYLYPBM").val(),
        "drugName": $("#txtYLYPMC").val(),
        "unitPrice":"",
        "totalPrice": "",
        "variableQuantity": $("#txtCGSL").val(),
        "drugBatchNo": "",
        "drugOrigin": "",
        "specifications": $("#txtYPGG").val(),
        "manufacturerCode": "",
        "manufacturerName": "",
        "manufacturerBatchNo": "",
        "vendorCode": "",
        "vendorName": "",
        "expireDate": "",
        "approvalNo": "",
        "storeUnitCode": $("#txtYPGG").val(),
        "storeUnitName": $("#txtYPGG").val(),
        "isDeleted": "0",
        "createTime": Number(new Date()),
        "updateTime": Number(new Date()),

    }];
    var param = { "szjgtype": szjgtype, data: JSON.stringify(data) }
    SZSI_Smart_AJAX(param, function (data) {
        autoInterface();
    })
}
//医疗机构资质监管-药品库存信息
function YPKC() {
    var szjgtype = "药品库存信息";
    var data = [{
        "medicalOrgCode": $("#txtYLJGBM").val(),
        "medicalOrgName": $("#txtYLJGMC").val(),
        "storeId": Number(new Date()),
        "drugCode": $("#txtYLYPBM").val(),
        "drugName": $("#txtYLYPMC").val(),
        "commonName": $("#txtYLYPMC").val(),//CGZBID
        "pharmacyCode": $("#txtCGZBID").val(),
        "pharmacyName": "YF" + $("#txtCGZBID").val(),
        "drugType": "药品类别",
        "drugSubtype": "药品分类",
        "drugOrigin": "",
        "manufacturerCode": "",
        "manufacturerName": "",
        "manufacturerBatchNo": "",
        "vendorCode": "",
        "vendorName": "",
        "expireDate": "",
        "approvalNo": "",
        "drugBatchNo": "",
        "miniUnit": "",
        "packingQuantity": "",
        "packingUnit": "",
        "purchasingPrice": "",
        "retailPrice": "",
        "wholesalePrice": "",
        "storeUnitCode": $("#txtCGDBH").val(),
        "storeUnitName": $("#txtYLYPGG").val(),
        "stockQuantity": "10",
        "totalOutQuantity": "10",
        "totalInQuantity": "20",
        "isDeleted": "0",
        "createTime": Number(new Date()),
        "updateTime": Number(new Date()),

    }];
    var param = { "szjgtype": szjgtype, data: JSON.stringify(data) }
    SZSI_Smart_AJAX(param, function (data) {
        autoInterface();
    })
}
//医疗机构资质监管-患者基本信息
function HZXX() {
    var szjgtype = "患者基本信息";
    var data = [{
        "medicalOrgCode": $("#txtYLJGBM").val(),
        "medicalOrgName": $("#txtYLJGMC").val(),
        "personIdType":"99",
        "personIdNo": $("#txtHZID").val(),//hzbh
        "idType": "1",
        "idNo": SZJGDataMZ.YSSFZH,
        "healthRecordNo": "",
        "healthCardNo": "",
        "patientSex": "1",
        "patientName": $("#txtHZXM").val(),
        "patientType": "",
        "maritalStatus": "",
        "birthday": "",
        "birthRegion": "",
        "nation": "1",
        "countryCode": "152",
        "telephone": "",
        "mobilePhone": "",
        "workPostCode": "",
        "workUnitName": "",
        "workUnitAddress": "",
        "workUnitPhone": "",
        "occupation": "",
        "provinceCode": "",
        "provinceName": "",
        "cityCode": "",
        "cityName": "",
        "countyCode": "",
        "countyName": "",
        "streetCode": "",
        "streetName": "",
        "address": "",
        "postCode": "",
        "regAddress": "",
        "regAddressPostCode": "",
        "contactName": "",
        "contactRelation": "",
        "contactAddress": "",
        "contactPostCode": "",
        "contactPhone": "",
        "participationDate": "",
        "email": "",
        "healthCardId": "",
        "mindexId": "",
        "healthCardAttr": "",
        "healthCardStatus": "",
        "healthCardQrcodeData": "",
        "guardians": "",
        "isDeleted": "0",//0 未删除 1 已删除
        "createTime": Number(new Date()),
        "updateTime": Number(new Date()),
    }];
    var param = { "szjgtype": szjgtype, data: JSON.stringify(data) }
    SZSI_Smart_AJAX(param, function (data) {
        SZJGDataMZ.personIdNo = data.personIdNo;
            SZJGDataMZ.personIdType = data.personIdType;
            autoInterface();
    })
}
//医疗机构资质监管-诊所月报
function Months() {
    var szjgtype = "月报";
    var data = [{
        "medicalOrgCode": $("#txtYLJGBM").val(),
        "medicalOrgName": $("#txtYLJGMC").val(),
        "year": "2021",
        "month": "03",
        "areaCode": "",
        "bespeakNum": 0,
        "branch": 0,
        "channelId": "",
        "checkTechNum": 0,
        "clinicalTypeNum": 0,
        "clinicalTypeNumAss": 0,
        "cnLeaveNum": 0,
        "cnMdcNum": 0,
        "cnMdcTypeNum": 0,
        "cnMdcTypeNumAss": 0,
        "cnPharmacistNum": 0,
        "comOptNum": 0,
        "companyHarge": "",
        "creAssDoctorNum": 0,
        "creDoctorNum": 0,
        "creRegLocaDocNum": 0,        
        "deathNum": 0,
        "ecoTypeCode": "",
        "explain": "",
        "genDocNum": 0,
        "governmentCode": "",
        "heaCheckNum": 0,
        "heaTechStaffNum": 0,
        "healthMecTypeCode": "",
        "hpltDrugsIncome": 0,
        "hpltIncome": 0,
        "imageTechNum": 0,
        "inteCnDoctor": 0,
        "internshipNum": 0,
        "isDeleted": "",
        "leaveNum": 0,
        "manageAreaCode": "",
        "managerNum": 0,
        "mdcCnDrugsOutlay": 0,
        "mdcDrugsOutlay": 0,
        "mdcIncome": 0,
        "mdcOptCnDrugsIncome": 0,
        "mdcOptDrugsIncome": 0,
        "mdcOutlay": 0,
        "midwifeNum": 0,
        "mobilePhone": "",       
        "obtGenDocCertNum": 0,
        "onDutyNum": 0,
        "onWeaveNum": 0,
        "optDrugsIncome": 0,
        "optEmgNum": 0,
        "optIncome": 0,
        "organizersCode": "",
        "osTypeNum": 0,
        "osTypeNumAss": 0,
        "otherPubHeaTypeNum": 0,
        "otherTechStaff": 0,
        "pharmacistNum": 0,
        "preparer": "",
        "pubHeaTypeNum": 0,
        "pubHeaTypeNumAss": 0,
        "pubHealthOutlay": 0,
        "regGenDocNum": 0,
        "regNurseNum": 0,
        "staffOutlay": 0,
        "stitHarge": "",
        "streetCode": "",
        "submitDate": "",
        "telePhone": "string",
        "totalIncome": 0,
        "totalNum": 0,
        "totalOutlay": 0,      
        "visitNum": 0,
        "weaveNum": 0,
        "westPharmacistNum": 0,
        "workerNum": 0,
        "isDeleted": "0",
        "createTime": Number(new Date()),
        "updateTime": Number(new Date())

    }];
    var param = { "szjgtype": szjgtype, data: JSON.stringify(data) }
    SZSI_Smart_AJAX(param, function (data) {
        autoInterface();
    })
}

//医疗机构资质监管-诊所年报
function Years() {
    var szjgtype = "诊所年报";    
    var data = [{
        "medicalOrgCode": $("#txtYLJGBM").val(),
        "medicalOrgName": $("#txtYLJGMC").val(),
        "year": "2021",
        "address": "",
        "amClinicalCategory": 0,
        "amCnCategory": 0,
        "amMouthCategory": 0,
        "amPhysician": 0,
        "amPublicHealthCategory": 0,
        "amongThemDi": 0,
        "amongThemMi": 0,
        "atStaffing": 0,
        "avFrequency": 0,
        "cbPeople": 0,
        "cdNum": 0,
        "cellphoneNumber": "",
        "channelId": "",
        "checkerFrequency": 0,
        "chineseMedicine": 0,
        "clinicalCategory": 0,
        "cmDivision": 0,
        "cnCategory": 0,
        "contactNumber": "",      
        "divisionCode": "",
        "drugExpenditure": 0,
        "fillForm": "",
        "healthTechNum": 0,
        "houseArea": "",
        "imageTechnician": 0,
        "inflow": 0,
        "insCode": "",
        "insTechnician": 0,
        "isAutonomy": 0,
        "isBranch": 0,      
        "isNum": 0,
        "legalPerson": "",
        "managementCode": "",
        "managementPersonnel": 0,
        "managementZoning": "",
        "medCateCode": "",       
        "midwife": 0,
        "mouthCategory": 0,
        "onDutyStaffNum": 0,
        "openningHours": "",
        "organizerCode": "",
        "otPersonnel": 0,
        "otPhysician": 0,
        "otStaff": 0,
        "otherDescription": "",
        "outflow": 0,
        "pharmacist": 0,
        "practicePhysician": 0,
        "preparationNum": 0,
        "publicHealthCategory": 0,
        "regTypeCode": "string",
        "registeredNurse": 0,
        "reportDate": "",
        "saveState": 0,
        "streetCode": "string",
        "totalExpenses": 0,
        "totalRevenue": 0,
        "tyFrequency": 0,
        "unitPrincipal": "string",       
        "wmDivision": 0,
        "wsPersonnel": 0,
        "ydNum": 0,
        "yeBeds": 0,        
        "yearStatisticsRemark": "",
        "yfPersonnel": 0,
        "zipCode": "string",
        "isDeleted": "0",//0 未删除 1 已删除
        "createTime": Number(new Date()),
        "updateTime": Number(new Date()),

    }];
    var param = { "szjgtype": szjgtype, data: JSON.stringify(data) }
    SZSI_Smart_AJAX(param, function (data) {
        autoInterface();
    })
}
//医疗机构资质监管-诊疗项目目录
function project() {
    var szjgtype = "诊疗项目目录";   
    var data = [{
        "medicalOrgCode": $("#txtYLJGBM").val(),
        "medicalOrgName": $("#txtYLJGMC").val(),
        "channelId": $("#txtChannel").val(),       
        "treatmentCode": "2021051800000001",
        "treatmentId": "2021051800000001",
        "treatmentMemo": "",
        "treatmentName": "血常规五项",
        "treatmentPrice": 12,
        "treatmentTypeId": "2021051800000001",
        "treatmentUnit": "次",
        "disabled": "0",
        "isDeleted": "0",   
        "createTime": Number(new Date()),
        "updateTime": Number(new Date()),

    }];
    var param = { "szjgtype": szjgtype, data: JSON.stringify(data) }
    SZSI_Smart_AJAX(param, function (res) {
        SZJGDataMZ.XMID = data[0].treatmentCode;
        SZJGDataMZ.XMMC = data[0].treatmentName,
            console.log(SZJGDataMZ),
        autoInterface();
    })
}
//医疗机构资质监管-组合项目组合
function portfolio() {
    var szjgtype = "组合项目组合";    
    var data = [{
        "medicalOrgCode": $("#txtYLJGBM").val(),
        "medicalOrgName": $("#txtYLJGMC").val(),
        "examId": "2021051800000001",
        "pExamId": "2021051800000001",
        "examCode": "2021051800000001",
        "examName": "血常规五项",
        "examPrice": "20",
        "examFlag": "",
        "examPlace": "",
        "examSampleId":"",
        "examUnit": "",
        "zhPrice": "20",
        "zxPrice": "",
        "ccmSourceId": "",
        "royaltyRate": "",
        "royaltyAmount": "",
        "examPackage":"",
        "disabled": "0",
        "isDeleted": "0",
        "createTime": Number(new Date()),
        "updateTime": Number(new Date()),

    }];
    var param = { "szjgtype": szjgtype, data: JSON.stringify(data) }
    SZSI_Smart_AJAX(param, function (data) {
        autoInterface();
    })
}
//医疗机构资质监管-组合项目明细
function projectDetail() {
    var szjgtype = "";   
    var data = [{
        "medicalOrgCode": $("#txtYLJGBM").val(),
        "medicalOrgName": $("#txtYLJGMC").val(),       
        "examItemId": "2021051800000001",
        "examId": "2021051800000001",
        "pExamItemId": "2021051800000001",
        "examItemType": "1",
        "itemId": "2021051800000001",
        "examItemPrice": "20",
        "examItemNum":1,
        "disabled": "0",
        "isDeleted": "0",
        "createTime": Number(new Date()),
        "updateTime": Number(new Date()),
    }];
    var param = { "szjgtype": szjgtype, data: JSON.stringify(data) }
    SZSI_Smart_AJAX(param, function (data) {
        autoInterface();
    })
}
//医疗机构资质监管-附件上传
function attachment() {
    var szjgtype = "";
    //处理证书
    var cert = [];
    for (var i = 1; i < $("#").find("tr").length + 1; i++) {
        if ($("#txtno0" + i).val() != "") {
            cert.push({ "certType": $("#txtlx0" + i).val(), "certNo": $("#txtno0" + i).val(), "certName": $("#txtmc0" + i).val() });
        }
    }

    var data = [{

    }];
    var param = { "szjgtype": szjgtype, data: JSON.stringify(data) }
    SZSI_Smart_AJAX(param, function (data) {

    })
}
//医疗机构资质监管-供应商信息
function GYSXX() {
    var szjgtype = "供应商信息";
    //处理证书
    var cert = [];
    for (var i = 1; i < $("#tableGYS").find("tr").length + 1; i++) {
        if ($("#txtno0" + i).val() != "") {
            cert.push({ "certType": $("#txtg0" + i).val(), "certNo": $("#txtgy0" + i).val(), "certName": $("#txtgys0" + i).val() }
                );
        }
    }

    var data = [{
        "medicalOrgCode": $("#txtYLJGBM").val(),
        "vendorCode": $("#txtgy01").val(),//供应商编号。
        "vendorName": "测试供应商",// 是 供应商名称
        "shortName": "测试",//供应商简称
        "vendorType": "1",//是 供应商类型（参见字典说明）
        "productType": "1",//是 产品类型（参见字典说明）1是药品2 医用材料        3 耗材 4 设备
        "provinceCode": "440000",
        "provinceName": "广东省",
        "cityCode": "440300",
        "cityName": "深圳市",
        "countyCode": "440303",
        "countyName": "罗湖区",        
        "streetCode": "",// String 街道编码
        "streetName": "",// String 街道名称
        "address": "",// String 详细地址
        "postCode": "",// String 邮政编码
        "certList": cert,
        "disabled": "0",
        "isDeleted": "0",
        "createTime": Number(new Date()),
        "updateTime": Number(new Date()),


    }];
    var param = { "szjgtype": szjgtype, data: JSON.stringify(data) }
    SZSI_Smart_AJAX(param, function (data) {
        autoInterface();
    })
}
//医疗机构资质监管-科室信息
function KSXX() {
    var szjgtype = "";
    var data = [{
        "medicalOrgCode": $("#txtYLJGBM").val(),
        "medicalOrgName": $("#txtYLJGMC").val(),
        "deptCode": "07",
        "deptName": "内科",
        "shortName": "内科",
        "deptType": "其他",
        "disabled": "0",
        "isDeleted": "0",
        "createTime": Number(new Date()),
        "updateTime": Number(new Date()),
    }];
    var param = { "szjgtype": szjgtype, data: JSON.stringify(data) }
    SZSI_Smart_AJAX(param, function (outdata) {
        SZJGDataMZ.deptCode = data[0].deptCode;
        SZJGDataMZ.deptName = data[0].deptName;
        autoInterface();
    })
}
//医疗机构资质监管-人脸识别监管事件创建
function RLbuild() {
    var szjgtype = "人脸识别监管事件创建";
    var data = {
        "channelId": $("#txtChannel").val(),
        "medicalOrgCode": $("#txtYLJGBM").val(),
        "medicalOrgName": $("#txtYLJGMC").val(),
        "callbackUrl": "http://zsy.zsglrj.cn/CheckFaceSuccess.html",
        "doctorNum": $("#txtYLZGBM").val(),
        "doctorName": $("#txtYLZGMC").val(),
        "idNo": SZJGDataMZ.YSSFZH, 
        "title": "医师"
    };
    var param = { "szjgtype": szjgtype, data: JSON.stringify(data) }
    SZSI_Smart_AJAX(param, function (data) {
        SZJGDataMZ.eventId = data.data.eventId
        autoInterface();
    })    
}
//CreatYB
function CreatYB() {
    var szjgtype = "通用事件创建";
    var data = {
        "channelId": $("#txtChannel").val(),
        "medicalOrgCode": $("#txtYLJGBM").val(),
        "medicalOrgName": $("#txtYLJGMC").val(),
        "eventUser":"",
        "attach":"",
    };
    var param = { "szjgtype": szjgtype, data: JSON.stringify(data) }
    SZSI_Smart_AJAX(param, function (data) {
        SZJGDataMZ.eventId = data.data.eventId
        autoInterface();
    })
}
function YB() {
    var id = SZJGDataMZ.eventId;
    url = "http://nhiptest.city.pingan.com/clinic/yzs?eventId=" + id;
    href = url;
    window.open(this.href, '_blank');
}
function RL() {
    var id = SZJGDataMZ.eventId;
    url = "https://nhiptest.city.pingan.com/face/faceEntry?eventId=" + id;
    href = url;
    window.open(this.href, '_blank');      
}
function YB() {
    var id = SZJGDataMZ.eventId;
    url = "http://nhiptest.city.pingan.com/clinic/yzs?eventId=" + id;
    href = url;
    window.open(this.href, '_blank');
}
//医疗机构资质监管-人脸识别监管事件结果查询
function RLquery() {
    var szjgtype = "人脸识别监管事件结果查询";   
    var data = {
        "channelId": $("#txtChannel").val(),
        "eventId": SZJGDataMZ.eventId,
    };
    var param = { "szjgtype": szjgtype, data: JSON.stringify(data) }
   
    SZSI_Smart_AJAX(param, function (data) {
        
    })
}
//医疗机构资质监管-查询抗菌处方权审核资质
function KJquery() {
    var szjgtype = "查询抗菌处方权审核资质";
   
    var data = {
        "channelId": $("#txtChannel").val(),
        "medicalOrgCode": $("#txtYLJGBM").val(),
        "medicalOrgName": $("#txtYLJGMC").val(),
        "doctorNum":$("#txtYLZGBM").val(),
    };
    var param = { "szjgtype": szjgtype, data: JSON.stringify(data) }
    SZSI_Smart_AJAX(param, function (data) {
        autoInterface();
    })
}
//医疗机构资质监管-患者门急诊信息
function outpatient() {
    var szjgtype = "患者门急诊信息";
    var id = Number(new Date());
    var appointment = [{
        "registeredRecordId": id,// Number(new Date()) + 1,
        "acographyNo": id, //Number(new Date())+1,
        "patientName": $("#txtHZXM").val(),
        "registeredTime": Number(new Date()),
        "withdrawTime": "",// Long 退号时间
        "reExamine": "1",// String 是 是否初复诊（1 初诊，2 复诊）
        "withdrawFlag": "0",// String 退号标志(0 无 1 退)
        "emergencyFlag": "",// String 是否急诊
        "deptCode": '07',// String 是 科室编码
        "deptName": '内科',
        "doctorNo": $("#txtYLZGBM").val(),
        "doctorName": '骆晓娜',// String 是 挂号医生姓名
        "totalAmount": 0,// String 是 挂号总费用
        "isDeleted": "0",
        "createTime": Number(new Date()),
        "updateTime": Number(new Date()),
    }];
    var acography = [{
        "acographyId": id, //Number(new Date())+1,// String 是 就诊记录 ID
        "acographyNo": id, //Number(new Date())+1,// String 是 就诊流水号
        "reExamine": "1",// String 是 是否复诊（1 初诊，2 复诊）
        "outpatientNumber": "",// String 门（急）诊号
        "patientName": $("#txtHZXM").val(),// String 是 患者姓名
        "paymentType": "3",// String 是 结算方式（1: 医保 2: 商保 3: 自费) ）
        "acographyType": "0",// String 是 就诊类别：0-普通，1-急诊，2-儿科
        "departNo": '07',
        "departName": '内科',
        "acographyDate": Number(new Date()),// Long 是 门诊就诊日期
        "completeAcographyTime": "",// Long 完成就诊时间
        "doctorNo": $("#txtYLZGBM").val(),// String 是 主诊医生编号
        "doctorName": "骆晓娜",// String 是 主诊医生姓名
        "diagnosisCode": "58430",// String 是 门诊诊断代码（主要诊断，多个使用 & 隔开)
        "diagnosisName": "感冒",// String 是 门诊诊断名称（主要诊断，多个使用 &        隔开）
        "isDeleted": "0",
        "createTime": Number(new Date()),
        "updateTime": Number(new Date()),
    }];
    //诊断明细
    var diagnosis = [{
        "diagnoseId": id, //Number(new Date())+1,// String 是 就诊记录 ID
        "acographyNo": id, //Number(new Date())+1,// String 是 就诊流水号
        "acographyNo": id, //Number(new Date())+1,
        "diagnoseMethodCode": "01",// String 是 诊断方法代码，01：西医；02：中医；        03: 口腔
        "diagnoseStandardCode": "03",// String 是 诊断标准代码，01：ICD- 10；02：国标- 95；03: 自定义
        "diagnoseTypeCode": "58430",// String 是 诊断类别代码（参见字典说明）
        "diseaseSyndromeCode": "",// String 病证区别代码，01：病；02：证；诊断方法代码为 02 时必须填写
        "diagnosticOrderCode": "01",// String 诊断主次代码，01: 主；02: 次
        "diagnosticOrder": "01",//String 诊断顺序 
        "diagnosticCode": "58430",// String  是  诊断代码，填写医院业务系统实际的诊断代码
        "diagnosticName": "感冒",// String 是 诊断名称
        "suspectDiagnosis": "0",// String 是 否疑诊
        "diagnosticType": "01",// String 诊断类型：01: 初步诊断；02：修正诊断；03：确诊诊断
        "toothPosition": "",// String 牙位
        "isDeleted": "0",
        "createTime": Number(new Date()),
        "updateTime": Number(new Date()),
    }];
    //处方主表信息
    var mainPrescription = [{
        "prescriptionId": id, //Number(new Date())+1,// String 是 处方 ID
        "prescriptionNo": id, //Number(new Date())+1,//String 是 处方编号
        "acographyNo": id, //Number(new Date())+1,// String 是 就诊流水号
        "outpatientNumber": "",// String 门(急)诊号
        "prescriptionType": "1",// String 是 处方类型，参见字典说明 1西药处方
        "deptCode": '07',
        "deptName": '内科',
        "doctorNo": $("#txtYLZGBM").val(),
        "doctorName": '骆晓娜',
        "prescriptionTime": Number(new Date()),// Long 是 开方时间
        "costType": "1",
        "westernDiagnosticCode": "58430",// String 西医诊断代码
        "westernDiagnosticName": "感冒",// String 西医诊断名称
        "patientId": Number(new Date()) + 01,// String 是 患者 ID
        "patientName": $("#txtHZXM").val(),
        "patientSex": $("#HZXB").val(),// String 患者性别
        "patientAge": Age("1992-02-02"),// String 患者年龄
        "prescriptionAmount": 20,// Float 是 处方金额
        "isDeleted": "0",
        "createTime": Number(new Date()),
        "updateTime": Number(new Date()),
    }];
    var drugPrescription = [{
        "prescriptionDetailId": id, //Number(new Date())+1,// String 是 处方明细 ID
        "acographyNo": id, //Number(new Date())+1,// String 是 就诊流水号
        "prescriptionMajorId": id,// String 是 处方主 ID
        "diagnosticCategoryCode": "1",// String 是 诊疗项目类别编码
        "projectCode": SZJGDataMZ.XMID,// String 是 项目代码
        "projectName": SZJGDataMZ.XMMC,//String 是 项目名称, 药品通用名，中草药部分填 写院内使用药物名称
        "medicinalFormCode": "329",
        "drugSpecifications": "片",
        "medicationRouteCode": "1",
        "medicationRouteName": "口服",
        "useFrequencyCode": "11",
        "useDrugFrequency": "每日3次",
        "subDosage": "",
        "dosageUnit": "片",
        "dosageTotal": "3",
        "medicationDays": "1",
        "": "",
        "": "",
        "": "",
        "isDeleted": "0",
        "createTime": Number(new Date()),
        "updateTime": Number(new Date()),
    }];
    var otherPrescription = [];
    var cost = [];
    var settlement = [];
    var settlementPay = [];
    //门诊病历
    var medicalRecord = [{

        "acographyNo": id, //Number(new Date())+1,
        "recordNo": id, //Number(new Date())+1,
        "modifyFlag": "1",
        "doorNum": id,// String 是 门（急）诊号
        "recordType": "1", //String 是 病历类型（参见字典说明） 1西医 2 中医3 口腔
        "patientName": $("#txtHZXM").val(),//String 是 患者姓名
        "sexCode": "1",// String 是 性别代码
        "patientSex": "男",// String 是 性别
        "birthDate": "1992-02-02",// Long 是 出生日期
        "nation": "",// String 民族
        "AgeYears": "30",
        "patientTypeCode": "1",// String 是 患者类型代码  1门诊
        "iniDiagnosisCode": "1",// String 是 初诊标志代码（参见字典说明）
        "mainComplaint": "感冒，头疼",// String 是 主诉
        "visitDate": Number(new Date()),// Long 是 就诊时间
        "resDoctorName": "骆晓娜",
        "isDeleted": "0",
        "createTime": Number(new Date()),
        "updateTime": Number(new Date()),

    }];
    var medicalRecordDiagnosis = [{
        "recordNo": id, //Number(new Date())+1,// String 是 病历 id
        "acographyNo": id, //Number(new Date())+1,// String 是 就诊流水号
        "doorNum": id, //Number(new Date())+1,
        "departmentCode": '07',
        "departmentName": '内科',
        "visitDate": Number(new Date()),
        "auxiliaryCheckItem": "",
        "auxiliaryCheckResults": "",
        "fourTCMResults": "无",
        "iniWMDiagnosisCode": "58430",
        "iniWMDiagnosisName": "感冒",
        "iniTCMDiseaseCode": "",
        "iniTCMDiseaseName": "",
        "iniTCMSyndromeCode": "",
        "iniTCMSyndromeName": "",
        "dialecticalBasis": "",
        "principlesAndTreatment": "",
        "doctorNum": $("#txtYLZGBM").val(),
        "doctorSign": '骆晓娜',
        "isDeleted": "0",
        "createTime": Number(new Date()),
        "updateTime": Number(new Date()),

    }];
    var medicalRecordAdvice = [{
        "adviceRecordNum": id, //Number(new Date())+1,
        "recordNo": id, //Number(new Date())+1,
        "acographyNo": id, //Number(new Date())+1,
        "doorNum": id, //Number(new Date())+1,
        "adviceItemTypeCode": "",
        "adviceItemTypeName": "",
        "adviceItemContent": "医嘱信息",
        "adviceItemNote": "",
        "adviceDepartmentCode": '07',
        "adviceDepartment": '',
        "adviceOpenPerNum": "",
        "adviceOpenPerSign": "",
        "adviceOpenPerDate": Number(new Date()),
        "adviceAuditNum": "",
        "adviceAuditSign": "",
        "adviceAuditDate": "",
        "adviceExecDepartmentCode": "",
        "adviceExecDepartment": "",
        "adviceExecutorNum": "",
        "adviceExecutorSign": "",
        "adviceExecutorDate": "",
        "adviceExecStatus": "",
        "cancelAdviceNum": "",
        "cancelAdviceSign": "",
        "cancelAdviceDate": "",
        "electronicApplyNum": "",
        "isDeleted": "0",
        "createTime": Number(new Date()),
        "updateTime": Number(new Date()),

    }];
    var tcmRecord = [];
    var oralCavityRecord = [];
    var acographyTreatment = [{
        "medicalOrgCode": $("#txtYLJGBM").val(),
        "medicalOrgName": $("#txtYLJGMC").val(),
        "acographyTreatmentItemId": id, //Number(new Date())+1,//String 是就诊诊疗明细 id(治疗/ 检查 / 检验明细业务主键)
        "acographyTreatmentId": id, //Number(new Date())+1,//String 是就诊诊疗 id(对应[治疗 / 检查 / 检验 / 其它就诊诊疗主表信息]中的    acographyTreatmentId)
        "acographyId": id, //Number(new Date())+1, //String 是 就诊记录 id(就诊记录业务主键)
        "personIdType": SZJGDataMZ.personIdType,
        "personIdNo": SZJGDataMZ.personIdNo,
        "patientName": $("#txtHZXM").val(),
        "patientSex": "男",
        "patientAge": Age("1992-02-02"),
        "projectTotalAmount": 20,
        "projectRemark": "",
        "executeDeptCode": "",
        "executeDeptName": "",
        "executionFrequency": "",
        "executorNo": "",
        "executorName": "",
        "executorTime": "",
        "isDeleted": "0",
        "createTime": Number(new Date()),
        "updateTime": Number(new Date()),

    }];
    var acographyTreatmentItem = [];
    var acographyDoc = [];
    var data = {
        "medicalOrgCode": $("#txtYLJGBM").val(),
        "medicalOrgName": $("#txtYLJGMC").val(),
        "personIdType": "99",
        "personIdNo": $("#txtHZID").val(),
        "appointment": appointment,
        "acography": acography,
        "diagnosis": diagnosis,//诊断明细
        "mainPrescription": mainPrescription,//处方主表信息
        "drugPrescription": drugPrescription,//药品处方明细
        "otherPrescription": otherPrescription,//其他处方明细，
        "cost": cost,//费用明细
        "settlement": settlement,//结算明细 
        "settlementPay": settlementPay,//结算支付方式明细，
        "medicalRecord": medicalRecord,//门诊病历主表信息
        "medicalRecordDiagnosis": medicalRecordDiagnosis,//门诊病历诊断信息
        "medicalRecordAdvice": medicalRecordAdvice,//门诊病历医嘱信息
        "tcmRecord": tcmRecord,//中医门诊电子病历明细
        "oralCavityRecord": oralCavityRecord,// 口腔门诊电子病历明细
        "acographyTreatment": acographyTreatment,//治疗/检查/检验/其它就诊诊疗主表信息
        "acographyTreatmentItem": acographyTreatmentItem,//治疗 / 检查 / 检验 / 其它就诊诊疗明细信息，
        "acographyDoc": acographyDoc,//就诊文书明细信息
    };


    var param = { "szjgtype": szjgtype, data: JSON.stringify(data) }
    SZSI_Smart_AJAX(param, function (data) {
        autoInterface();
    })
}

function outpatient2() {
    var szjgtype = "患者门急诊信息";
    //挂号信息
    var appointment = [{

        "registeredRecordId ": "2021060200000008 ",
        "acographyNo ": "	2021060200000015 ",
        "patientName ": "	陈皓 ", //\r\n
        "registeredTime ": "	1622605280000 ",//   
        "reExamine ": "	1 ",//  
        "deptCode ": "	5 ", // 
        "deptName ": "	中医科 ", // 
        "doctorNo ": "	2020010300000020 ",//    
        "doctorName ": "李光海 ",//   
        "totalAmount ": "10.0000 ",//    
        "isDeleted ": "	0 ",//
        "createTime ": "1622605685716 ",//   
        "updateTime ": "1622605685716 "//
    }];
    var acography = [{
        "acographyId": "",//mzbh
        "acographyNo ": "2021060200000015 ",
        "patientName ": "陈皓 ",
        "departNo ": "5 ",
        "departName ": "中医科 ",
        "acographyDate ": "1622605685716 ",
        "doctorNo ": "2020010300000020 ",
        "doctorName ": "李光海 ",
        "diagnosisCode ": "	M75 .001 ",
        "diagnosisName ": "	肩周炎 ",
        "isDeleted ": "	0 ",
        "createTime ": "1622605685716 ",
        "updateTime ": "1622605685716 "
    },
    {
        "acographyNo ": "2021060200000015 ",
        "patientName ": "陈皓 ",
        "departNo ": "5 ",
        "departName ": "中医科 ",
        "acographyDate ": "1622605685716 ",
        "doctorNo ": "2020010300000020 ",
        "doctorName ": "李光海 ",
        "diagnosisCode ": "M75 .001 ",
        "diagnosisName ": "	肩周炎 ",
        "isDeleted ": "	0 ",
        "createTime ": "1622605685716 ",
        "updateTime ": "1622605685716",
    }];
    var diagnosis = [{

    }];
    var data = [{
        "medicalOrgCode": $("#txtYLJGBM").val(),
        "medicalOrgName": $("#txtYLJGMC").val(),
        "personIdType": "99",
        "personIdNo": $("#txtHZID").val(),
        "appointment": appointment,
        "acography": acography,
        "diagnosis": diagnosis,//诊断明细
        "mainPrescription": mainPrescription,//处方主表信息
        "drugPrescription": drugPrescription,//药品处方明细
        "otherPrescription": otherPrescription,//其他处方明细，
        "cost": cost,//费用明细
        "settlement": settlement,//结算明细 
        "settlementPay": settlementPay,//结算支付方式明细，
        "medicalRecord": medicalRecord,//门诊病历主表信息
        "medicalRecordDiagnosis": medicalRecordDiagnosis,//门诊病历诊断信息
        "medicalRecordAdvice": medicalRecordAdvice,//门诊病历医嘱信息
        "tcmRecord": tcmRecord,//中医门诊电子病历明细
        "oralCavityRecord": oralCavityRecord,// 口腔门诊电子病历明细
        "acographyTreatment": acographyTreatment,//治疗/检查/检验/其它就诊诊疗主表信息
        "acographyTreatmentItem": acographyTreatmentItem,//治疗 / 检查 / 检验 / 其它就诊诊疗明细信息，
        "acographyDoc": acographyDoc,//就诊文书明细信息
    }];
    var param = { "szjgtype": szjgtype, data: JSON.stringify(data) }
    SZSI_Smart_AJAX(param, function (data) {
        autoInterface();
    })
}
   
  



//签退
function SYB9002() {
    var signOut = {
        "opter_no": $("#opter_name").val(),
        "sign_no": $("#sign_no").val()
    };
    SYBDataEntityIn.infno = "9002";
    SYBDataEntityIn.input = { "signOut": signOut };
    var param = SYBDataEntityIn;
    SZSI_Smart_AJAX(param, function (data) {})
    //return param;
}


//1101获取人员信息
function SYB1101() {    
    var data = {
        "mdtrt_cert_type":SYBDataCommon.mdtrt_cert_type,
        "mdtrt_cert_no":SYBDataCommon.mdtrt_cert_no,
        "card_sn":SYBDataCommon.card_sn,
        "begntime":"",
        "psn_cert_type":SYBDataCommon.psn_cert_type,
        "certno":SYBDataCommon.certno,
        "psn_name": SYBDataCommon.psn_name
    }
    SYBDataEntityIn.infno = "1101";
    SYBDataEntityIn.input = { "data": data };
    var param = SYBDataEntityIn;
    SZSI_Smart_AJAX(param, function (data) {
        if (data.infcode == 0) {
            $("#certno").val(data.output.baseinfo.certno);
            $("#psn_name").val(data.output.baseinfo.psn_name);
            $("#psn_no").val(data.output.baseinfo.psn_no);
            SYBDataMZ.gend=data.output.baseinfo.gend;
            SYBDataMZ.brdy=data.output.baseinfo.brdy;
            SYBDataMZ.age=data.output.baseinfo.age;
            //SYBDataMZ.brdy=data.output.baseinfo.brdy;
            //$("#gend").val(data.output.baseinfo.gend);
            //$("#brdy").val(data.output.baseinfo.brdy);          
            $("#balc").val(data.output.insuinfo[0].balc);
            $("#psn_type").val(data.output.insuinfo[0].psn_type);
            $("#insutype").val(data.output.insuinfo[0].insutype);
            $("#insuplc_admdvs").val(data.output.insuinfo[0].insuplc_admdvs);
            autoInterface();
        }
    })
    //return param;
}
//======================================深圳监管  End=============================
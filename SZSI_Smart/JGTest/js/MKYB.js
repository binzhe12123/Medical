//======================================医保接口 start==========================
function SI001() {
    var paras = YBEntity.Parameters;
    paras.transTime = paras.Milliseconds();
    paras.transType = "SI001";
    paras.serialNumber = paras.hospitalCode + paras.dateString() + paras.RandomNum(7);
    return paras;//tasklinkinsert(paras);    
}

function SI002() {
    var paras = YBEntity.Parameters;
    paras.transTime = paras.Milliseconds();
    paras.transType = "SI002";
    var body = {
        aaa100: "",
        pageno: 1
    }
    paras.transBody = body;//body;//JSON.stringify(body);
    paras.serialNumber = paras.hospitalCode + paras.dateString() + paras.RandomNum(7);
    return paras;//tasklinkinsert(paras); 
}

function XX001() {
    var paras = YBEntity.Parameters;
    paras.transTime = paras.Milliseconds();
    paras.transType = "XX001";
    var body = {
        aaz500: "%GAAFSAKSXSUKKWDKHDAD?;07734724145330238292?",//医疗证号可为空
        bzz269: "000000",
        alc005: ""
    }
    paras.transBody = body;//JSON.stringify(body);
    paras.serialNumber = paras.hospitalCode + paras.dateString() + paras.RandomNum(7);
    return paras;//tasklinkinsert(paras); 
}


function XX002() {
    var paras = YBEntity.Parameters;
    paras.transTime = paras.Milliseconds();
    paras.transType = "XX002";
    var body = {
        aaz500: "%GAAFSAKSXSUKKWDKHDAD?;07734724145330238292?",//医疗证号可为空
        bzz269: "000000",
        alc005: ""
    }
    paras.transBody = body;//JSON.stringify(body);
    paras.serialNumber = paras.hospitalCode + paras.dateString() + paras.RandomNum(7);
    return paras;//tasklinkinsert(paras); 
}

function XX003() {
    var paras = YBEntity.Parameters;
    paras.transTime = paras.Milliseconds();
    paras.transType = "XX003";
    var body = {
        aaz500: "%GAAFSAKSXSUKKWDKHDAD?;07734724145330238292?",//医疗证号可为空
        aae140: "310",//险种类非空
        pageno: 1
    }
    paras.transBody = body;//JSON.stringify(body);
    paras.serialNumber = paras.hospitalCode + paras.dateString() + paras.RandomNum(7);
    return paras;//tasklinkinsert(paras); 
}

function ML001() {
    var paras = YBEntity.Parameters;
    paras.transTime = paras.Milliseconds();
    paras.transType = "ML001";
    var body = {
        pageno: 1
    }
    paras.transBody = body;//JSON.stringify(body);
    paras.serialNumber = paras.hospitalCode + paras.dateString() + paras.RandomNum(7);
    return paras;//tasklinkinsert(paras); 
}

function ML002() {
    var paras = YBEntity.Parameters;
    paras.transTime = paras.Milliseconds();
    paras.transType = "ML002";
    var body = {
        pageno: 1
    }
    paras.transBody = body;//JSON.stringify(body);
    paras.serialNumber = paras.hospitalCode + paras.dateString() + paras.RandomNum(7);
    return paras;//tasklinkinsert(paras); 
}

function ML003() {
    var paras = YBEntity.Parameters;
    paras.transTime = paras.Milliseconds();
    paras.transType = "ML003";
    var body = {
        pageno: 1
    }
    paras.transBody = body;//JSON.stringify(body);
    paras.serialNumber = paras.hospitalCode + paras.dateString() + paras.RandomNum(7);
    return paras;//tasklinkinsert(paras); 
}

function ML004() {
    var paras = YBEntity.Parameters;
    paras.transTime = paras.Milliseconds();
    paras.transType = "ML004";
    var body = {
        pageno: 1
    }
    paras.transBody = body;//JSON.stringify(body);
    paras.serialNumber = paras.hospitalCode + paras.dateString() + paras.RandomNum(7);
    return paras;//tasklinkinsert(paras); 
}

function ML005() {
    var paras = YBEntity.Parameters;
    paras.transTime = paras.Milliseconds();
    paras.transType = "ML005";
    var body = {
        pageno: 1,
        bkm077: ""
    }
    paras.transBody = body;//JSON.stringify(body);
    paras.serialNumber = paras.hospitalCode + paras.dateString() + paras.RandomNum(7);
    return paras;//tasklinkinsert(paras); 
}

function ML006() {
    var paras = YBEntity.Parameters;
    paras.transTime = paras.Milliseconds();
    paras.transType = "ML006";
    var body = {
        pageno: 1,
        bkm077: ""
    }
    paras.transBody = body;//JSON.stringify(body);
    paras.serialNumber = paras.hospitalCode + paras.dateString() + paras.RandomNum(7);
    return paras;//tasklinkinsert(paras); 
}

function ML007() {
    var paras = YBEntity.Parameters;
    paras.transTime = paras.Milliseconds();
    paras.transType = "ML007";
    var listInfo = [{
        ake001: DataBase.CLML[0].ake001,//社保目录编码 not null
        ake005: DataBase.CLML[0].ake005,//医疗机构三大目录编码 not null
        ake006: DataBase.CLML[0].ake006,//医药机构三大目录名称 not null
        bka053: DataBase.CLML[0].bka053,//厂家 
        ake004: DataBase.CLML[0].ake004,//生产地类别
        ckf261: DataBase.CLML[0].ckf261,//特殊医用材料标识
        aka067: DataBase.CLML[0].aka067,//计价单位         
        aka074: DataBase.CLML[0].aka074,//规格                     
        bka505: DataBase.CLML[0].bka505,//进货价格 not null
        bka506: DataBase.CLML[0].bka506,//收费价格 not null
        aae013: ""//备注     null

    }];
    var body = {
        listsize: 1,
        inputlist: listInfo
    }
    paras.transBody = body;//JSON.stringify(body);
    paras.serialNumber = paras.hospitalCode + paras.dateString() + paras.RandomNum(7);
    return paras;//tasklinkinsert(paras); 
}

function ML008() {//ML008-医药机构药品目录备案
    var paras = YBEntity.Parameters;
    paras.transTime = paras.Milliseconds();
    paras.transType = "ML008";
    var YP = JSON.parse(localStorage.getItem("ML001"));
    var listInfo = [{
        ake001: DataBase.YPML.ake001,//社保目录编码 not null
        ake002: DataBase.YPML.ake002,
        aka070: DataBase.YPML.aka070,
        bkm017: DataBase.YPML.bkm017,//药品本位码 not null
        ake005: DataBase.YPML.ake005,//医疗机构三大目录编码 not null
        ake006: DataBase.YPML.ake006,//医药机构三大目录名称 not null
        aka074: DataBase.YPML.aka074,//规格 not null
        aka070: DataBase.YPML.aka070,//剂型 not null
        aka064: DataBase.YPML.aka064,
        aka067: DataBase.YPML.aka067,//计价单位  null
        bka053: DataBase.YPML.bka053,//厂家     null
        bka505: DataBase.YPML.bka505,//药品进货价格   not  null
        bka506: DataBase.YPML.bka506,//药品收费价格   not  null
        aae030: DataBase.YPML.aae030,//备案日期   not  null
        aae013: DataBase.YPML.aae013//备注     null
    }];

    var body = {
        listsize: 1,
        inputlist: listInfo
    }
    paras.transBody = body;//JSON.stringify(body);
    paras.serialNumber = paras.hospitalCode + paras.dateString() + paras.RandomNum(7);
    return paras;//tasklinkinsert(paras); 
}

function ML009() {//4.4.9ML009-医疗机构诊疗目录备案
    var paras = YBEntity.Parameters;
    paras.transTime = paras.Milliseconds();
    paras.transType = "ML009";
    var listInfo = [];
    for (var i = 0; i < DataBase.ZLML.length; i++) {
        var model = {
            ake001: DataBase.ZLML[i].ake001,//社保目录编码 not null
            ake005: DataBase.ZLML[i].ake005,//医疗机构三大目录编码 not null
            ake006: DataBase.ZLML[i].ake006,//医药机构三大目录名称 not null
            bka506: DataBase.ZLML[i].bka506,//药品收费价格   not  null
            bkf131: DataBase.ZLML[i].bkf131,//医疗机构诊疗项目类别 not null  1:常规
            bkm062: DataBase.ZLML[i].bkm062,//门诊特检项目标识 not null  0 否  1 是
            aae030: DataBase.ZLML[i].aae030,//备案日期 not null
            aae013: DataBase.ZLML[i].aae013//诊疗项目备注  null
        };
        listInfo.push(model);
    }
    var body = {
        listsize: listInfo.length,
        inputlist: listInfo
    }
    paras.transBody = body;//JSON.stringify(body);
    paras.serialNumber = paras.hospitalCode + paras.dateString() + paras.RandomNum(7);
    return paras;//tasklinkinsert(paras); 
}

function ML010() {//ML010-医药机构目录备案撤销
    var paras = YBEntity.Parameters;
    paras.transTime = paras.Milliseconds();
    paras.transType = "ML010";
    var listInfo = [{
        ake003: DataBase.Cancel.ake003,//目录类别 not null
        ake005: DataBase.Cancel.ake005//医疗机构三大目录编码 not null
    }];
    var body = {
        listsize: 1,
        inputlist: listInfo
    }
    paras.transBody = body;//JSON.stringify(body);
    paras.serialNumber = paras.hospitalCode + paras.dateString() + paras.RandomNum(7);
    return paras;//tasklinkinsert(paras); 
}


function ML011() {//ML011-医药机构目录备案(申请)查询
    var paras = YBEntity.Parameters;
    paras.transTime = paras.Milliseconds();
    paras.transType = "ML011";
    var body = {
        pageno: 1,
        ake003: DataBase.Sreach.ake003,//目录类别
        ake005: DataBase.Sreach.ake005,//医疗机构三大目录编码  null
    }
    paras.transBody = body;//JSON.stringify(body);
    paras.serialNumber = paras.hospitalCode + paras.dateString() + paras.RandomNum(7);
    return paras;//tasklinkinsert(paras); 
}

function JG001() { //JG001-定点医药机构约定信息查询
    var paras = YBEntity.Parameters;
    paras.transTime = paras.Milliseconds();
    paras.transType = "JG001";
    var body = {}
    paras.transBody = body;//JSON.stringify(body);
    paras.serialNumber = paras.hospitalCode + paras.dateString() + paras.RandomNum(7);
    return paras;//tasklinkinsert(paras); 
}

function MZ001() {
    var paras = YBEntity.Parameters;
    NumberData.akc190 = YBEntity.Parameters.hospitalCode + paras.RandomNum(15);
    NumberData.aae072 = paras.RandomNum(20);//prompt("请输入挂号编号（长度<=20）：",NumberData.GH.aae072);
    NumberData.bkf500 = paras.RandomNum(18);//prompt("请输入结算序列号（长度<=18）：",NumberData.GH.bkf500);
    paras.transTime = paras.Milliseconds();
    paras.transType = "MZ001";
    var listInfo = [{
        aae072: NumberData.aae072,
        bkf500: NumberData.bkf500,
        ake001: DataBase.ZLML[1].ake001,
        ake005: DataBase.ZLML[1].ake005,
        ake006: DataBase.ZLML[1].ake006,
        aae019: DataBase.ZLML[1].bka506,
    }];
    var body = {
        akc190: NumberData.akc190,
        aaz500: "%GAAFSAKSXSUKKWDKHDAD?;07734724145330238292?",
        aka130: "11",
        akf001: "0200",
        bkc368: "1",
        akc264: "3",
        listsize: 1,
        inputlist: listInfo
    }
    paras.transBody = body;//JSON.stringify(body);
    paras.serialNumber = paras.hospitalCode + paras.dateString() + paras.RandomNum(7);
    return paras;//tasklinkinsert(paras); 
}

function MZ002() {
    var paras = YBEntity.Parameters;
    NumberData.bke384 = YBEntity.Parameters.hospitalCode + paras.dateString() + paras.RandomNum(7);//paras.hospitalCode+paras.dateString()+prompt('医疗结构结算序列号(长度<=7)','0000001')
    paras.transTime = paras.Milliseconds();
    paras.transType = "MZ002";
    var listInfo = [{
        aae072: NumberData.aae072,
        bkf500: NumberData.bkf500,
        ake001: DataBase.ZLML[1].ake001,
        ake005: DataBase.ZLML[1].ake005,
        ake006: DataBase.ZLML[1].ake006,
        aae019: DataBase.ZLML[1].bka506,
    }];
    var body = {
        akc190: NumberData.akc190,
        aaz500: "%GAAFSAKSXSUKKWDKHDAD?;07734724145330238292?",
        aka130: "11",
        bzz269: "000000",
        akf001: "0200",
        bkc368: "1",
        akc264: "3",
        bke384: NumberData.bke384,
        listsize: 1,
        inputlist: listInfo
    }
    paras.transBody = body;//JSON.stringify(body);
    paras.serialNumber = paras.hospitalCode + paras.dateString() + paras.RandomNum(7);
    return paras;//tasklinkinsert(paras); 
}


function FY001() {

    var paras = YBEntity.Parameters;    

    if (NumberData.akc190 == "") {
        swal({
            title: "失败",
            text: "请先挂号",
            icon: "error",
            button: "确定",
        });
        return;
    }
    //NumberData.MZ.aae072 = prompt("请输入处方单据号（长度<=20）：",NumberData.MZ.aae072);
    //NumberData.MZ.bkf500 = prompt("请输入结算序列号（长度<=18）：",NumberData.MZ.bkf500);
    NumberData.bke384 = paras.hospitalCode + paras.dateString() + paras.RandomNum(7);//  + prompt("请输入结算序列号（长度<=7）：",NumberData.MZ.bke384);
    paras.transTime = paras.Milliseconds();
    paras.transType = "FY001";
    var listInfo = [{
        aae072: NumberData.aae072,
        bkc369: "1",
        bkf500: NumberData.bkf500,
        ake001: DataBase.ZLML[0].ake001,
        ake002: DataBase.ZLML[0].ake006,
        aka064: 0,
        ake005: DataBase.ZLML[0].ake005,
        ake006: DataBase.ZLML[0].ake006,
        akc226: 1,
        akc264: DataBase.ZLML[0].bka506,
        akc225: DataBase.ZLML[0].bka506,        
        aka067: "次",
        akc271: 20180402,
        bkc320: DataBase.Doctor.bkc320
    }];
    var body = {
        akc190: NumberData.akc190,
        bke384: NumberData.bke384,
        listsize: 1,
        inputlist: listInfo
    }
    paras.transBody = body;//JSON.stringify(body);
    paras.serialNumber = paras.hospitalCode + paras.dateString() + paras.RandomNum(7);
    return paras;//tasklinkinsert(paras);    
}

function FY002() {
    var paras = YBEntity.Parameters;
    paras.transTime = paras.Milliseconds();
    paras.transType = "FY002";
    var listInfo = [{
        aae072: NumberData.aae072,
        bkf500: NumberData.bkf500,
    }];
    var body = {
        akc190: NumberData.akc190,
        bke384: NumberData.bke384,
        listsize: 1,
        inputlist: listInfo
    }
    paras.transBody = body;//JSON.stringify(body);
    paras.serialNumber = paras.hospitalCode + paras.dateString() + paras.RandomNum(7);
    return paras;//tasklinkinsert(paras); 
}

function FY003() {
    var paras = YBEntity.Parameters;
    paras.transTime = paras.Milliseconds();
    paras.transType = "FY003";

    var body = {
        akc190: NumberData.akc190,
        bke384: NumberData.bke384,
        aaz500: "%GAAFSAKSXSUKKWDKHDAD?;07734724145330238292?",
        pageno: 1
    }
    paras.transBody = body;//JSON.stringify(body);
    paras.serialNumber = paras.hospitalCode + paras.dateString() + paras.RandomNum(7);
    return paras;//tasklinkinsert(paras); 
}

function FY004() {
    if (NumberData.akc190 == "") {
        swal({
            title: "失败",
            text: "请先录入费用明细",
            icon: "error",
            button: "确定",
        });
    }
    var paras = YBEntity.Parameters;
    paras.transTime = paras.Milliseconds();
    paras.transType = "FY004";

    var body = {
        akc190: NumberData.akc190,
        bke384: NumberData.bke384,
        aka130: "11",
        bkc320: DataBase.Doctor.bkc320,
        ckc350: DataBase.Doctor.aac003,
        aka030: "12",
        akc264: DataBase.ZLML[0].bka506,
        ckc601: "0"
    }
    paras.transBody = body;//JSON.stringify(body);
    paras.serialNumber = paras.hospitalCode + paras.dateString() + paras.RandomNum(7);
    return paras;//tasklinkinsert(paras); 
}

function FY005() {
    var paras = YBEntity.Parameters;
    paras.transTime = paras.Milliseconds();
    paras.transType = "FY005";

    var body = {
        aaz500: "%GAAFSAKSXSUKKWDKHDAD?;07734724145330238292?",
        bzz269: "000000",
        akc190: NumberData.akc190,
        bke384: NumberData.bke384,
        aka130: "11",
        bkc320: DataBase.Doctor.bkc320,
        ckc350: DataBase.Doctor.aac003,
        aka030: "12",
        akc264: DataBase.ZLML[0].bka506,
        ckc601: "0"
    }
    paras.transBody = body;//JSON.stringify(body);
    paras.serialNumber = paras.hospitalCode + paras.dateString() + paras.RandomNum(7);
    return paras;//tasklinkinsert(paras); 
}

function JY001() {
    var paras = YBEntity.Parameters;
    paras.transTime = paras.Milliseconds();
    paras.transType = "JY001";

    var body = {
        akc190: NumberData.akc190,
        bke384: NumberData.bke384
        //ckc618: "",
    }
    paras.transBody = body;//JSON.stringify(body);
    paras.serialNumber = paras.hospitalCode + paras.dateString() + paras.RandomNum(7);
    return paras;//tasklinkinsert(paras); 
}

function JY002() {
    var paras = YBEntity.Parameters;
    paras.transTime = paras.Milliseconds();
    paras.transType = "JY002";

    var body = {
        akc190: NumberData.akc190,
        bke384: NumberData.bke384,
        //ckc618: "",
    }
    paras.transBody = body;//JSON.stringify(body);
    paras.serialNumber = paras.hospitalCode + paras.dateString() + paras.RandomNum(7);
    return paras;//tasklinkinsert(paras); 
}

function JY003() {
    var paras = YBEntity.Parameters;
    paras.transTime = paras.Milliseconds();
    paras.transType = "JY003";

    var body = {
        akc190: NumberData.akc190,
        bke384: NumberData.bke384
        //ckc618: "",
    }
    paras.transBody = body;//JSON.stringify(body);
    paras.serialNumber = paras.hospitalCode + paras.dateString() + paras.RandomNum(7);
    return paras;//tasklinkinsert(paras); 
}

function DZ001() {
    var paras = YBEntity.Parameters;
    paras.transTime = paras.Milliseconds();
    paras.transType = "DZ001";
    var listInfo = [{
        aaa036: "999999",
        aae019: 7.5
    }]
    var body = {
        bad766: paras.dateString(),
        //aae011: paras.operatorCode,
        akc264: 7.5,
        listsize: 1,
        inputlist: listInfo
    }
    paras.transBody = body;//JSON.stringify(body);
    paras.serialNumber = paras.hospitalCode + paras.dateString() + paras.RandomNum(7);
    return paras;//tasklinkinsert(paras); 
}


function DZ002() {
    var paras = YBEntity.Parameters;
    paras.transTime = paras.Milliseconds();
    paras.transType = "DZ002";

    var body = {
        bad766: paras.dateString(),
        //aae011: "",
        pageno: 1,
    }
    paras.transBody = body;//JSON.stringify(body);
    paras.serialNumber = paras.hospitalCode + paras.dateString() + paras.RandomNum(7);
    return paras;//tasklinkinsert(paras); 
}

function DZ003() {
    var paras = YBEntity.Parameters;
    paras.transTime = paras.Milliseconds();
    paras.transType = "DZ003";

    var body = {
        akc190: NumberData.akc190,
        bke384: NumberData.bke384,
        //aae072: "",
        pageno: 1
    }
    paras.transBody = body;//JSON.stringify(body);
    paras.serialNumber = paras.hospitalCode + paras.dateString() + paras.RandomNum(7);
    return paras;//tasklinkinsert(paras); 
}

function YS001() {
    var paras = YBEntity.Parameters;
    paras.transTime = paras.Milliseconds();
    paras.transType = "YS001";
    var listInfo = [{
        aac003: DataBase.Doctor.aac003,
        bka633: DataBase.Doctor.bka633,
        aac004: DataBase.Doctor.aac004,
        aac058: DataBase.Doctor.aac058,
        aac147: DataBase.Doctor.aac147,
        aae005: DataBase.Doctor.aae005,
        bkc322: DataBase.Doctor.bkc322,
        aac005: DataBase.Doctor.aac005,
        aac006: DataBase.Doctor.aac006,
        aac007: DataBase.Doctor.aac007,
        aac011: DataBase.Doctor.aac011,
        aac183: DataBase.Doctor.aac183,
        bkc323: DataBase.Doctor.bkc323,
        bke955: DataBase.Doctor.bke955,
        bkc324: DataBase.Doctor.bkc324,
        acc501: DataBase.Doctor.acc501,
        bkc321: DataBase.Doctor.bkc321,
        ckc302: DataBase.Doctor.ckc302,
        bkc325: DataBase.Doctor.bkc325,
        aae030: DataBase.Doctor.aae030,
        akc055: DataBase.Doctor.akc055,
        bcc950: DataBase.Doctor.bcc950,
        bcc955: DataBase.Doctor.bcc955,
        akf001: DataBase.Doctor.akf001
    }]
    var body = {
        listsize: 1,
        inputlist: listInfo
    }
    paras.transBody = body;//JSON.stringify(body);
    paras.serialNumber = paras.hospitalCode + paras.dateString() + paras.RandomNum(7);
    return paras;//tasklinkinsert(paras); 
}

function YS002() {
    var paras = YBEntity.Parameters;
    paras.transTime = paras.Milliseconds();
    paras.transType = "YS002";
    var listInfo = [{
        bkc320: DataBase.Doctor.bkc320,
        bke155: "3",
    }]
    var body = {
        listsize: 1,
        inputlist: listInfo
    }
    paras.transBody = body;//JSON.stringify(body);
    paras.serialNumber = paras.hospitalCode + paras.dateString() + paras.RandomNum(7);
    return paras;//tasklinkinsert(paras); 
}

function YS003() {
    var paras = YBEntity.Parameters;
    paras.transTime = paras.Milliseconds();
    paras.transType = "YS003";
    var listInfo = [{
        bkc320: DataBase.Doctor.bkc320,
        aac003: DataBase.Doctor.aac003,
        bka633: DataBase.Doctor.bka633,
        aac004: DataBase.Doctor.aac004,
        aac058: DataBase.Doctor.aac058,
        aac147: DataBase.Doctor.aac147,
        aae005: DataBase.Doctor.aae005,
        bkc322: DataBase.Doctor.bkc322,
        aac005: DataBase.Doctor.aac005,
        aac006: DataBase.Doctor.aac006,
        aac007: DataBase.Doctor.aac007,
        aac011: DataBase.Doctor.aac011,
        aac183: DataBase.Doctor.aac183,
        bkc323: DataBase.Doctor.bkc323,
        bke955: DataBase.Doctor.bke955,
        bkc324: DataBase.Doctor.bkc324,
        acc501: DataBase.Doctor.acc501,
        bkc321: DataBase.Doctor.bkc321,
        ckc302: DataBase.Doctor.ckc302,
        bkc325: DataBase.Doctor.bkc325,
        aae030: DataBase.Doctor.aae030,
        akc055: DataBase.Doctor.akc055,
        bcc950: DataBase.Doctor.bcc950,
        bcc955: DataBase.Doctor.bcc955,
        akf001: DataBase.Doctor.akf001
    }]
    var body = {
        listsize: 1,
        inputlist: listInfo
    }
    paras.transBody = body;//JSON.stringify(body);
    paras.serialNumber = paras.hospitalCode + paras.dateString() + paras.RandomNum(7);
    return paras;//tasklinkinsert(paras); 
}

function JX001() {
    var paras = YBEntity.Parameters;
    paras.transTime = paras.Milliseconds();
    NumberData.push_id = paras.RandomNum(16);
    paras.transType = "JX001";
    var listInfo = [{
        push_id: NumberData.push_id,
        inventory_record_id: "2018040200000001",
        standard_code: DataBase.YPML.bkm017,
        drug_code: DataBase.YPML.ake005,
        drug_name: DataBase.YPML.ake006,
        std: "100片/盒*1/箱",
        unit: "盒",
        inventory_number: "100",
        bid: "7.5",
        retail_price: "7.5",
        bid_amount: "750",
        retail_amount: "750",
        validtime: "20190105",
        inventorytime: "20180401175509",
        acceptime: "20180401175512",
        last_editedtime: "20180401175512"
    }]
    var body = {
        listsize: 1,
        inputlist: listInfo
    }
    paras.transBody = body;//JSON.stringify(body);
    paras.serialNumber = paras.hospitalCode + paras.dateString() + paras.RandomNum(7);
    return paras;//tasklinkinsert(paras); 
}

function JX002() {
    var paras = YBEntity.Parameters;
    paras.transTime = paras.Milliseconds();
    paras.transType = "JX002";
    var listInfo = [{
        push_id: NumberData.push_id,
        shelves_record_id: "20180402000120180401" + DataBase.YPML.bkm017 + "2018012809",
        inventory_record_id: "2018040200000001",
        standard_code: DataBase.YPML.bkm017,
        drug_code: DataBase.YPML.ake005,
        drug_name: DataBase.YPML.ake006,
        std: "100片/盒*1/箱",
        unit: "盒",
        numbers: "100",
        bid: "7.5",
        retail_price: "7.5",
        bid_amount: "750",
        retail_amount: "750",
        shelvestime: 20180401,
        validtime: 20190105,
        acceptime: 20180401175512,
        proc_type: "1",
        last_editedtime: 20180401175512
    }]
    var body = {
        listsize: 1,
        inputlist: listInfo
    }
    paras.transBody = body;//JSON.stringify(body);
    paras.serialNumber = paras.hospitalCode + paras.dateString() + paras.RandomNum(7);
    return paras;//tasklinkinsert(paras); 
}

function JX003() {
    var paras = YBEntity.Parameters;
    paras.transTime = paras.Milliseconds();
    paras.transType = "JX003";
    var listInfo = [{
        push_id: NumberData.push_id,
        business_type: "1",
        pres_sno: "2018040200000001",
        record_sno: "201804022018040200000001" + DataBase.YPML.bkm017,
        standard_code: DataBase.YPML.bkm017,
        drug_code: DataBase.YPML.ake005,
        drug_name: DataBase.YPML.ake006,
        drug_std: "100片/盒*1/箱",
        unit: "瓶",
        base_unit: "片",
        unit_factor: 100,
        numbers: 1,
        amount: 7.5,
        out_recordtime: 20180402,
        last_editedtime: 20180401175523
    }]
    var body = {
        listsize: 1,
        inputlist: listInfo
    }
    paras.transBody = body;//JSON.stringify(body);
    paras.serialNumber = paras.hospitalCode + paras.dateString() + paras.RandomNum(7);
    return paras;//tasklinkinsert(paras); 
}

function JX004() {
    var paras = YBEntity.Parameters;
    paras.transTime = paras.Milliseconds();
    paras.transType = "JX004";
    var listInfo = [{
        push_id: NumberData.push_id,
        stock_record_id: "2018040200000001",
        standard_code: DataBase.YPML.bkm017,
        drug_code: DataBase.YPML.ake005,
        drug_name: DataBase.YPML.ake006,
        std: "100片/盒*1/箱",
        unit: "盒",
        stock_number: "100",
        bid: "7.5",
        retail_price: "7.5",
        bid_amount: "750",
        retail_amount: "750",
        stocktime: 20180401175509,
        acceptime: 20180401175512,
        last_editedtime: 20180401175523
    }]
    var body = {
        listsize: 1,
        inputlist: listInfo
    }
    paras.transBody = body;//JSON.stringify(body);
    paras.serialNumber = paras.hospitalCode + paras.dateString() + paras.RandomNum(7);
    return paras;//tasklinkinsert(paras); 
}

function JX005() {
    var paras = YBEntity.Parameters;
    paras.transTime = paras.Milliseconds();
    paras.transType = "JX005";
    var listInfo = [{
        revoke_type: 4,
        push_id: NumberData.push_id,
        inventory_record_id: "",
        shelves_record_id: "",
        pres_sno: "",
        stock_record_id: "2018040200000001"
    }]
    var body = {
        listsize: 1,
        inputlist: listInfo
    }
    paras.transBody = body;//JSON.stringify(body);
    paras.serialNumber = paras.hospitalCode + paras.dateString() + paras.RandomNum(7);
    return paras;//tasklinkinsert(paras); 
}

function BL001() {
    var paras = YBEntity.Parameters;
    paras.transTime = paras.Milliseconds();
    paras.transType = "BL001";
    var body = {
        aaz500: "%GAAFSAKSXSUKKWDKHDAD?;07734724145330238292?",
        akc190: NumberData.akc190,
        bke384: NumberData.bke384,
        czy201: 20180402170359,
        akf001: "0200",
        bkc320: DataBase.Doctor.bkc320,
        bkc275: DataBase.Doctor.aac003
    }
    paras.transBody = body;//JSON.stringify(body);
    paras.serialNumber = paras.hospitalCode + paras.dateString() + paras.RandomNum(7);
    return paras;//tasklinkinsert(paras); 
}

//======================================医保接口 End==========================

//智慧医保结果判断
function resultSmart(data, box, callback) {
    if(data.window_url == undefined)
    {
        data = JSON.parse(data);
    }
    if (data.window_url != undefined && data.window_url != "") {

        swal({
            title: box + "成功",
            text: data.window_url,
            icon: "success",
            button: "确定",
        });
    } else {
        swal({
            title: box + "失败",
            text: data.window_url,
            icon: "error",
            button: "确定",
        });

    }
}

//智慧医保事前审核
function Remind() {
    var paras = SmartEntity.content;
    SZSI_Smart_post_zh(SmartEntity.API_Remind, paras, "POST", function (data) {
        resultSmart(data, "Remind", function () {
            //写什么呢
        });
    }, function (msg) {
        swal({
            title: "失败",
            text: msg,
            icon: "error",
            button: "确定",
        });
    });
}

//智慧医保事中审核
function Audit() {
    var paras = SmartEntity.content;
    SZSI_Smart_post_zh(SmartEntity.API_Audit, paras, "POST", function (data) {
        resultSmart(data, "Audit", function () {
            //请在此写

        });
    }, function (msg) {
        swal({
            title: "失败",
            text: msg,
            icon: "error",
            button: "确定",
        });
    });
}

//======================================电子医保  Start=============================

//微信电子医保获取token
function WXToken()
{
    var paras = {};
    paras.API_URL = WXYBUrl() + "/api/YBWX/getAccesstoken";
    paras.data = { "appid": WXEntity.appid };
    paras.transType = "WXToken";
    paras.Type = "GET";
    paras.flag = "wx";
    return paras;
    //tasklinkinsertWX(paras);
}

//微信电子医保扫码
function WXScan()
{
    var paras = {};
    paras.API_URL = WXYBUrl() + "/api/YBWX/scanWxYB";
    paras.data = { "YBWXKey": WXEntity.key, "YBWXParentId": WXEntity.id, "qrcode": NumberData.qcode };
    paras.transType = "WXScan";
    paras.Type = "POST";
    paras.flag = "wx";
    return paras;
    //tasklinkinsertWX(paras);
}

//微信电子医保下单
function WXOrderGH()
{    
    //先扫码
    NumberData.qcode = prompt('请扫码', '');
    tasklinkinsertWX(WXScan());
    //获取医保token
    tasklinkinsertWX(WXToken());
    //先执行MZ001                
    //tasklinkinsert(MZ001());
    //搞一个akc190
    NumberData.akc190 = YBEntity.Parameters.hospitalCode + YBEntity.Parameters.RandomNum(15);
    NumberData.aae072 = YBEntity.Parameters.RandomNum(20);//prompt("请输入挂号编号（长度<=20）：",NumberData.GH.aae072);
    NumberData.bkf500 = YBEntity.Parameters.RandomNum(18);//prompt("请输入结算序列号（长度<=18）：",NumberData.GH.bkf500);
    //然后获取MZ002的报文
    var request_content = MZ002();

    return WXOrder("RegPay",request_content);
}

//微信电子医保下单
function WXOrderMZ() {
    //先扫码
    NumberData.qcode = prompt('请扫码', '');
    tasklinkinsertWX(WXScan());
    //获取医保token
    //获取医保token
    tasklinkinsertWX(WXToken());
    //先执行YS001,ML008,ML009,FY001,FY004
    //tasklinkinsert(YS001());
    //tasklinkinsert(ML008());
    //tasklinkinsert(ML009());
    tasklinkinsert(FY001());
    tasklinkinsert(FY004());
    var request_content = FY005();
    return WXOrder("DiagPay",request_content);    
}

//微信电子医保统一下单
function WXOrder(order_type,request_content)
{
    var paras = {};
    paras.API_URL = WXYBUrl() + "/api/YBWX/mzWxYB";
    paras.data = {
        "accesstoken": NumberData.accesstoken, "order_type": order_type, "sub_appid": WXEntity.appid,
        "sub_mch_id": WXEntity.mchid, "auth_code": NumberData.qcode, "token": NumberData.token,
        "serial_no": NumberData.akc190, "hospital_name": WXEntity.YLJGMC, "total_fee": Number(request_content.transBody.akc264) * 100,
        "cash_fee": 0, "user_card_no": NumberData.user_card_no, "user_name": NumberData.user_name,
        "org_no": WXEntity.YLJGBM, "channel_no": WXEntity.channel, "bill_no": NumberData.bke384,
        "request_content": JSON.stringify(request_content)
    };
    paras.transType = "WXOrder";
    paras.Type = "POST";
    paras.flag = "wx";
    return paras;
}

//微信电子医保支付查询
function WXQuery()
{
    //获取医保token
    tasklinkinsertWX(WXToken());
    var paras = {};
    paras.API_URL = WXYBUrl() + "/api/YBWX/checkWxYBPay";
    paras.data = {
        "med_trans_id": NumberData.med_trans_id, "accesstoken": NumberData.accesstoken
        , "sub_appid": WXEntity.appid, "sub_mch_id": WXEntity.mchid
    };
    paras.transType = "WXQuery";
    paras.Type = "GET";
    paras.flag = "wx";
    return paras;
}

//微信电子医保退款
function WXRefund()
{
    //获取医保token
    tasklinkinsertWX(WXToken());
    var paras = {};
    paras.API_URL = WXYBUrl() + "/api/YBWX/refundWxYB";
    paras.data = {
        "med_trans_id": NumberData.med_trans_id, "accesstoken": NumberData.accesstoken, "serial_no": NumberData.akc190
        , "sub_appid": WXEntity.appid, "sub_mch_id": WXEntity.mchid, "bill_no": NumberData.bke384
    };
    paras.transType = "WXRefund";
    paras.Type = "POST";
    paras.flag = "wx";
    return paras;
}

//微信电子医保退款查询
function WXRefundQuery()
{
    //获取医保token
    tasklinkinsertWX(WXToken());
    var paras = {};
    paras.API_URL = WXYBUrl() + "/api/YBWX/refundWxYBCheck";
    paras.data = {
        "med_refund_id": NumberData.med_refund_id, "accesstoken": NumberData.accesstoken
        , "sub_appid": WXEntity.appid, "sub_mch_id": WXEntity.mchid
    };
    paras.transType = "WXRefundQuery";
    paras.Type = "GET";
    paras.flag = "wx";
    return paras;
}

//微信电子医保关闭订单
function WXCloseOrder()
{
    //获取医保token
    tasklinkinsertWX(WXToken());
    var paras = {};
    paras.API_URL = WXYBUrl() + "/api/YBWX/closeWxYB";
    paras.data = {
        "med_trans_id": NumberData.med_trans_id, "accesstoken": NumberData.accesstoken
        , "sub_appid": WXEntity.appid, "sub_mch_id": WXEntity.mchid
    };
    paras.transType = "WXCloseOrder";
    paras.Type = "POST";
    paras.flag = "wx";
    return paras;
}

//======================================电子医保  End=============================
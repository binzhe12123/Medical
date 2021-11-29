﻿using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SY.Com.Medical.Attribute;
using SY.Com.Medical.BLL.Clinic;
using SY.Com.Medical.Model;
using SY.Com.Medical.Model.SYB.RYBA;
using System.Collections.Generic;
using SZSI_Smart.Model.SYB;
using SZSI_Smart.Model.SYB.JBXX;
using static SY.Com.Medical.Model.Down9102;
using static SY.Com.Medical.Model.KS3401;
using static SY.Com.Medical.Model.KS3402;
using static SY.Com.Medical.Model.KS3403;
using static SY.Com.Medical.Model.QT9002;
using static SY.Com.Medical.Model.SYB.RYBA2505;
using static SY.Com.Medical.Model.SYBCommon;
using static SZSI_Smart.Model.SYB.GH2202;
using static SZSI_Smart.Model.SYB.JBXX.ML1301;
using static SZSI_Smart.Model.SYB.JBXX.ML1312;
using static SZSI_Smart.Model.SYB.JBXX.YP1304;
using static SZSI_Smart.Model.SYB.JS2207;
using static SZSI_Smart.Model.SYB.XXCX.RY5206;
using static SZSI_Smart.Model.SYB.XXCX.RY5302;
using static SZSI_Smart.Model.SYB.YBJS.CZ2601;
using static SZSI_Smart.Model.SYB.YBJS.RY2001;
using static SZSI_Smart.Model.SYB.YG7101;
using static SZSI_Smart.Model.SYB.YG7104;
using static SZSI_Smart.Model.SYB.YJS2206;
using static SZSI_Smart.Model.SYB.ZJ2203;
using static SZSI_Smart.Model.SYB.ZJ2204;
using static SZSI_Smart.Model.SYB.ZJ2205;
using static SZSI_Smart.Model.SYB.ZJCX2208;
using SY.Com.Medical.BLL;
using SY.Com.Medical.Extension;

namespace SY.Com.Medical.WebApi.Controllers.Clinic
{
    /// <summary>
    /// 省医保接口-此分部写获取省医保接口报文的接口
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    //[Api_Tenant]
    public partial class SYBController : ControllerBase
    {
        SYBbll bll = new SYBbll();
        Patient patientbll = new Patient();

        /// <summary>
        /// YB获取签到入参报文
        /// </summary>
        /// <param name="mod">复合结构</param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<InCommon> Message9001(SYBCommonModel<In9001model> mod)
        {
            BaseResponse<InCommon> rd = new BaseResponse<InCommon>();
            InCommon rd1 = new InCommon();
            rd1 = bll.getComm(mod.TenantId, mod.EmployeeId);
            try
            {             
                rd1.infno = "9001";                             
                In9001 qd = new In9001();
                qd.signIn = new In9001model();
                qd.signIn.mac = mod.input.mac;
                qd.signIn.ip = HttpContext.Connection.RemoteIpAddress.ToString();
                qd.signIn.opter_no = rd1.opter;
                //rd1.input = Newtonsoft.Json.JsonConvert.SerializeObject(qd);
                rd1.input = qd;
                //rd.Data = Newtonsoft.Json.JsonConvert.SerializeObject(rd1);
                rd.Data = rd1;
                return rd;
            }            
            catch (Exception ex)
            {
                return rd.sysException(ex.Message);
            }            
        }

        /// <summary>
        /// 签到解析报文
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<bool> Message9001Parse(SYBCommonParseModel<Out9001> mod)
        {
            BaseResponse<bool> result = new BaseResponse<bool>();
            if (mod.Message.infcode == -1)
            {
                throw new MyException(mod.Message.err_msg);
            }
            //更新签到信息
            bll.SignIn(mod.TenantId, mod.EmployeeId, mod.Message.output.sign_no);
            result.Data = true;
            return result;
        }

        /// <summary>
        /// 签退-获取报文
        /// </summary>
        /// <param name="mod">复合结构</param>                
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<InCommon> Messge9002(SYBCommonModel mod)
        {
            BaseResponse<InCommon> rd = new BaseResponse<InCommon>();
            InCommon rd1 = bll.getComm(mod.TenantId, mod.EmployeeId);
            //InCommon rd1 = bll.getComm(mod.fixmedins_code,mod.fixmedins_name,mod.opter,mod.opter_name,mod.sign_no);
            rd1.infno = "9002";            
            try
            {
                
                In9002 QT = new In9002();
                QT.signOut = new In9002model();
                QT.signOut.sign_no = rd1.sign_no;// mod.input.sign_no;
                QT.signOut.opter_no = rd1.opter;//  mod.input.opter_no; ;
                rd1.input = QT;// Newtonsoft.Json.JsonConvert.SerializeObject(QT);
                rd.Data = rd1;// Newtonsoft.Json.JsonConvert.SerializeObject(rd1);
                return rd;
            }
            catch (Exception ex)
            {
                return rd.sysException(ex.Message);
            }

        }

        /// <summary>
        /// 签退-解析报文
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<bool> Messge9002Parse(SYBCommonParseModel<Out9002> mod)
        {
            BaseResponse<bool> result = new BaseResponse<bool>();
            if (mod.Message.infcode == -1)
            {
                throw new MyException(mod.Message.err_msg);
            }
            //更新签退
            bll.SignOut(mod.TenantId, mod.EmployeeId);
            result.Data = true;
            return result;
        }



        /// <summary>
        /// 获取人员信息-获取报文
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>        
        [HttpPost]
        public BaseResponse<InCommon> Messge1101(SYBCommonModel<In1101data> mod)
        {
            BaseResponse<InCommon> rd = new BaseResponse<InCommon>();
            InCommon rd1 = new InCommon();
            //rd1 = bll.getComm(mod.fixmedins_code,mod.fixmedins_name,mod.opter,mod.opter_name,mod.sign_no) ;            
            rd1 = bll.getComm(mod.TenantId, mod.EmployeeId);

            try
            {
                if (mod.input.mdtrt_cert_no == null)
                {
                    return rd.busExceptino( Enum.ErrorCode.业务逻辑错误,"就诊凭证编号不能为空");
                }
                if (mod.input.mdtrt_cert_type=="03"&&mod.input.card_sn == null)
                {
                    return rd.busExceptino(Enum.ErrorCode.业务逻辑错误, "卡识别码不能为空");
                }
                In1101 model = new In1101();
                model.data = new In1101data();
                model.data.mdtrt_cert_type = mod.input.mdtrt_cert_type;//mod.input.data.mdtrt_cert_type;// 就诊凭证类型  字符型 3   Y Y
                model.data.mdtrt_cert_no = mod.input.mdtrt_cert_no;// 就诊凭证编号  字符型 50 Y 就诊凭证类型为“01”时填写电子凭证令牌，为“02”时填写身份证号，为“03”时填写社会保障卡卡号
                model.data.card_sn = mod.input.card_sn;// 卡识别码 字符型 32          就诊凭证类型为“03”时必填
                model.data.begntime = DateTime.Now;//开始时间 日期时间型               获取历史参保信息时传入
                model.data.psn_cert_type = "";//   人员证件类型 字符型 6   Y
                model.data.certno = "";//  证件号码 字符型 50
                model.data.psn_name = "";// 人员姓名    字符型 50
                rd1.infno = "1101";
                rd1.input = model;//Newtonsoft.Json.JsonConvert.SerializeObject(model);
                rd.Data = rd1;//Newtonsoft.Json.JsonConvert.SerializeObject(rd1);
            }
            catch(Exception e)
            {
                return rd.sysException(e.Message);
            }
            return rd;
        }

        /// <summary>
        /// 获取人员信息-解析报文
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>        
        [HttpPost]
        public BaseResponse<PatientYBModel> Messge1101Parse(SYBCommonParseModel<Out1101> mod)
        {
            BaseResponse<PatientYBModel> result = new BaseResponse<PatientYBModel>();
            if (mod.Message.infcode == -1)
            {
                throw new MyException(mod.Message.err_msg);
            }
            //查询患者是否存在,存在着返回
            var entity = patientbll.getBypsnNo(mod.TenantId, mod.Message.output.baseinfo.psn_no);
            if(entity == null)
            {
                //如果不不存在就需要插入
                var addresult = patientbll.add(new PatientAdddto
                {
                    TenantId = mod.TenantId,
                    PatientName = mod.Message.output.baseinfo.psn_name,
                    Phone = "",
                    Sex = int.Parse(mod.Message.output.baseinfo.gend),
                    CSRQ = mod.Message.output.baseinfo.brdy,
                    SFZ = mod.Message.output.baseinfo.certno,
                    psn_no = mod.Message.output.baseinfo.psn_no
                }) ;
                if(addresult > 0)
                {
                    entity = patientbll.getBypsnNo(mod.TenantId, mod.Message.output.baseinfo.psn_no);
                }
                else
                {
                    throw new MyException("解析失败,无法创建信息");
                }
            }
            result.Data = entity.EntityToDto<PatientYBModel>();
            result.Data.ybinfo = new List<YBinsuinfo>();
            foreach(var item in mod.Message.output.insuinfo)
            {
                YBinsuinfo node = new YBinsuinfo();
                node.balc = item.balc;
                node.insutype = item.insutype;
            }
            return result;
        }

        /// <summary>
        /// YB门诊挂号-获取报文
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<InCommon> GH2201(SYBCommonModel<In2201data> mod)
        {
            BaseResponse<InCommon> rd= new BaseResponse<InCommon>();
            //InCommon rd1 = bll.getComm(mod.fixmedins_code,mod.fixmedins_name,mod.opter,mod.opter_name,mod.sign_no);
            InCommon rd1 = bll.getComm(mod.TenantId, mod.EmployeeId);
            InCommon rd2 = bll.getComm(mod.TenantId, mod.input.DoctorId);
            YBDepartment department = bll.getYBDepartment(rd2.departname);
            In2201 model = new In2201();
            model.data = new In2201data();
            try
            {
                if (mod.input.mdtrt_cert_no == null)
                {
                    return rd.busExceptino(Enum.ErrorCode.业务逻辑错误,"就诊凭证编号不能为空");
                }
                if (mod.input.mdtrt_cert_type == null)
                {
                    return rd.busExceptino(Enum.ErrorCode.业务逻辑错误,"就诊类型不能为空");
                }              
                model.data.psn_no = mod.input.psn_no;
                model.data.insutype = mod.input.insutype;
                model.data.begntime = Convert.ToDateTime(DateTime.Now.ToString ("yyyy-MM-dd HH:mm:ss"));
                model.data.ipt_otp_no = rd1.fixmedins_code + DateTime.Now.ToString("yyyyMMddHHmmss"); //ipt_otp_no  住院 / 门诊号  字符型 30      Y 院内唯一流水
                model.data.atddr_no = rd2.opter; //mod.input.atddr_no;//atddr_no 医师编码    字符型 30      Y
                model.data.dr_name = rd2.opter_name;//mod.input.dr_name;//由医生编号，查询姓名
                model.data.mdtrt_cert_type = mod.input.mdtrt_cert_type;// 就诊凭证类型  字符型 3   Y Y
                model.data.mdtrt_cert_no = mod.input.mdtrt_cert_no;// 就诊凭证编号  字符型 50 Y 就诊凭证类型为“01”时填写电子凭证令牌，为“02”时填写身份证号，为“03”时填写社会保障卡卡号                
                model.data.dept_code = department.code;// mod.input.dept_code;
                model.data.dept_name = department.name;//mod.input.dept_name;
                model.data.caty = department.name;//mod.input.caty;
                rd1.infno = "2201";
                rd1.input = model;// Newtonsoft.Json.JsonConvert.SerializeObject(model);
                rd.Data = rd1;//Newtonsoft.Json.JsonConvert.SerializeObject(rd1);
            }
            catch (Exception e)
            {
                return rd.sysException(e.Message);
            }
            return rd;
            

        }

        /// <summary>
        /// YB门诊挂号-解析报文
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<RegisterYBReturn> GH2201Parse(SYBCommonParseModel<Out2201data> mod)
        {
            BaseResponse<RegisterYBReturn> result = new BaseResponse<RegisterYBReturn>();
            if (mod.Message.infcode == -1)
            {
                throw new MyException(mod.Message.err_msg);
            }
            RegisterYBReturn model = new RegisterYBReturn();
            model.ipt_otp_no = mod.Message.output.ipt_otp_no;
            model.mdtrt_id = mod.Message.output.mdtrt_id;
            model.psn_no = mod.Message.output.psn_no;
            result.Data = model;
            return result;
        }

        /// <summary>
        /// 挂号撤销-获取报文
        /// </summary>
        /// <param name="mod">复合结构</param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<InCommon> GH2202(SYBCommonModel<In2202data> mod) {
            BaseResponse<InCommon> rd = new BaseResponse<InCommon>();
            try {
                //InCommon rd1 = bll.getComm(mod.fixmedins_code, mod.fixmedins_name, mod.opter, mod.opter_name, mod.sign_no);
                InCommon rd1 = bll.getComm(mod.TenantId, mod.EmployeeId);
                In2202 model = new In2202();
                model.data = new In2202data();
                model.data = new SZSI_Smart.Model.SYB.GH2202.In2202data();
                model.data.psn_no = mod.input.psn_no;
                model.data.mdtrt_id = mod.input.mdtrt_id;
                model.data.ipt_otp_no = mod.input.ipt_otp_no;
                rd1.input = model;
                rd1.infno = "2202";
                rd.Data = rd1;// Newtonsoft.Json.JsonConvert.SerializeObject(rd1);
                return rd;
            } 
            catch (Exception e)
            {
                return rd.sysException(e.Message);
            }
        }

        /// <summary>
        /// 挂号撤销-报文解析
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<bool> GH2202Parse(SYBCommonParseModel mod)
        {
            BaseResponse<bool> result = new BaseResponse<bool>();
            if (mod.Message.infcode == -1)
            {
                throw new MyException(mod.Message.err_msg);
            }
            return result;
        }


        /// <summary>
        /// 门诊就诊信息上传-获取报文
        /// </summary>
        /// <param name="mod">复合结构</param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<InCommon> MZ2203(SYBMZUploadModel mod) {
            BaseResponse<InCommon> rd = new BaseResponse<InCommon>();
            
            try {
                //11
                //InCommon rd1 = bll.getComm(mod.fixmedins_code, mod.fixmedins_name, mod.opter, mod.opter_name, mod.sign_no);
                InCommon rd1 = bll.getComm(mod.TenantId, mod.EmployeeId);
                var rentity = bll.getRegisterById(mod.RegisterId);
                var doctor = bll.getEmployeeById( mod.DoctorId);

                In2203 model = new In2203();
                MdtrtInfo mmod = new MdtrtInfo();
                mmod.mdtrt_id = rentity.mdtrt_id;
                mmod.psn_no = rentity.psn_no;
                mmod.med_type = "11";
                mmod.begntime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                List<ZJ2203.Diseinfo> dmods = new List<ZJ2203.Diseinfo>();
                ZJ2203.Diseinfo dmod = new ZJ2203.Diseinfo();
                dmod.diag_type = rentity.DepartmentName.IndexOf("中医") > 0 ?  "3" : "1";
                dmod.diag_srt_no = "1";
                dmod.diag_code = bll.getDiagnosisCode(mod.Diagnosis);
                dmod.diag_name = mod.Diagnosis;
                dmod.diag_dept = bll.getYBDepartment(rentity.DepartmentName).code;
                dmod.dise_dor_no = doctor.YBCode;
                dmod.dise_dor_name = doctor.EmployeeName;
                dmod.diag_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                dmod.vali_flag = "1";
                dmods.Add(dmod);
                model.diseinfo = dmods;
                model.mdtrtinfo = mmod;
                //model.mdtrtInfo.birctrl_matn_date = DateTime.Now.ToString("yyyy-MM-dd");
                rd1.infno = "2203";
                rd1.input = model;
                rd.Data = rd1;//Newtonsoft.Json.JsonConvert.SerializeObject(rd1);
                return rd;
            }
            catch (Exception ex) {
                return rd.sysException(ex.Message);
            }
        }

        /// <summary>
        /// 门诊就诊信息上传-解析报文
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<bool> MZ2203Parse(SYBCommonParseModel mod)
        {
            BaseResponse<bool> result = new BaseResponse<bool>();
            if (mod.Message.infcode == -1)
            {
                throw new MyException(mod.Message.err_msg);
            }
            return result;
        }



        /// <summary>
        /// 门诊费用上传-获取报文
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<InCommon> MZ2204(SYBMZ2204Model mod)
        {
            BaseResponse<InCommon> rd = new BaseResponse<InCommon>();
            try
            {
                //InCommon rd1 = bll.getComm(mod.fixmedins_code, mod.fixmedins_name, mod.opter, mod.opter_name, mod.sign_no);
                InCommon rd1 = bll.getComm(mod.TenantId, mod.EmployeeId);
                Outpatient opbll = new Outpatient();
                var opstructure= opbll.getStructure(mod.TenantId, mod.OutpatientId);
                var department = bll.getYBDepartment(opstructure.Doctor.Department);
                List <FeeDetail> fdlist = new List<FeeDetail>();
                foreach(var item in opstructure.Prescriptions)
                {
                    foreach(var node in item.Details)
                    {
                        FeeDetail fdmod = new FeeDetail();
                        fdmod.feedetl_sn = rd1.fixmedins_code + DateTime.Now.ToString("yyyyMMddHHmmss") + (9999 - fdlist.Count).ToString();
                        fdmod.mdtrt_id = opstructure.mdtrt_id;
                        fdmod.psn_no = opstructure.Patient.psn_no;
                        fdmod.chrg_bchno = opstructure.chrg_bchno;
                        fdmod.rxno = rd1.fixmedins_code + DateTime.Now.ToString("yyyyMMddHHmmssfff") + item.PreNo;
                        fdmod.rx_circ_flag = "0";
                        fdmod.fee_ocur_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        fdmod.med_list_codg = node.GoodsYBCode;
                        fdmod.medins_list_codg = node.GoodsYBSelfCode;
                        fdmod.det_item_fee_sumamt = Math.Round(decimal.Parse(node.GoodsCost.ToString()),2);
                        fdmod.cnt = node.GoodsNum;
                        fdmod.pric = Math.Round(decimal.Parse(node.GoodsPrice.ToString()), 4);
                        fdmod.bilg_dept_codg = department.code;
                        fdmod.bilg_dept_name = department.name;
                        fdmod.bilg_dr_codg = opstructure.Doctor.YBCode;
                        fdmod.bilg_dr_name = opstructure.Doctor.EmployeeName;
                        fdmod.hosp_appr_flag = "1";
                        fdlist.Add(fdmod);
                    }
                }
                In2204 model = new In2204();
                model.feedetail = fdlist;
                rd1.infno = "2204";
                rd1.input = model;
                rd.Data = rd1;// Newtonsoft.Json.JsonConvert.SerializeObject(rd1);
                return rd;
            }
            catch (Exception ex)
            {
                return rd.sysException(ex.Message);
            }
        }

        /// <summary>
        /// 门诊费用上传-解析报文
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<bool> MZ2204Parse(SYBCommonParseModel<ZJ2204> mod)
        {
            BaseResponse<bool> result = new BaseResponse<bool>();
            if (mod.Message.infcode == -1)
            {
                throw new MyException(mod.Message.err_msg);
            }
            return result;
        }

        /// <summary>
        /// 门诊费用撤销-获取报文
        /// </summary>
        /// <param name="mod">复合结构</param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<InCommon> MZ2205(SYBEasyCommon<In2205> mod) {
            BaseResponse<InCommon> rd = new BaseResponse<InCommon>();
            try
            {
                InCommon rd1 = bll.getComm(mod.fixmedins_code, mod.fixmedins_name, mod.opter, mod.opter_name, mod.sign_no);
                In2205data model = new In2205data();
                model.data = new In2205();
                model.data.chrg_bchno = "0000";
                model.data.mdtrt_id = mod.input.mdtrt_id;
                model.data.psn_no = mod.input.psn_no;
                rd1.infno = "2205";
                rd1.input = model;
                rd.Data = rd1;// Newtonsoft.Json.JsonConvert.SerializeObject(rd1);
                return rd;
            }
            catch (Exception ex)
            {
                return rd.sysException(ex.Message);
            }
        }


        /// <summary>
        /// 门诊费用撤销-解析报文
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<bool> MZ2205Parse(SYB2205ParseModel mod)
        {
            BaseResponse<bool> result = new BaseResponse<bool>();
            if (mod.Message.infcode == -1)
            {
                throw new MyException(mod.Message.err_msg);
            }
            //更新门诊的chrg_bchno,可以再次收费
            Outpatient opbll = new Outpatient();
            opbll.Updatechrgbchno(mod.TenantId, mod.OutpatientId);
            result.Data = true;
            return result;
        }


        /// <summary>
        /// 门诊预结算-获取报文
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<InCommon> JS2206(SYJS2206Model mod){
            BaseResponse<InCommon> rd = new BaseResponse<InCommon>();
            try
            {
                //InCommon rd1 = bll.getComm(mod.fixmedins_code, mod.fixmedins_name, mod.opter, mod.opter_name, mod.sign_no);
                InCommon rd1 = bll.getComm(mod.TenantId, mod.EmployeeId);
                Outpatient opbll = new Outpatient();
                var opstructure = opbll.getStructure(mod.TenantId, mod.OutpatientId);                
                In2206Data model = new In2206Data();
                model.data = new In2206();
                model.data.chrg_bchno = opstructure.chrg_bchno;
                model.data.mdtrt_id = opstructure.mdtrt_id;
                model.data.psn_no = opstructure.Patient.psn_no;
                model.data.mdtrt_cert_type = mod.Mdtrt_cert_type;
                model.data.mdtrt_cert_no = mod.Mdtrt_cert_no;
                model.data.med_type = "11";
                model.data.medfee_sumamt = Math.Round(decimal.Parse(opstructure.Cost.ToString()),2);
                model.data.psn_setlway = "02";
                model.data.acct_used_flag = "1";
                model.data.insutype = "310";
                rd1.infno = "2206";
                rd1.input = model;
                rd.Data = rd1;//Newtonsoft.Json.JsonConvert.SerializeObject(rd1);
                return rd;
            }
            catch (Exception ex)
            {
                return rd.sysException(ex.Message);
            }
        }

        /// <summary>
        /// 门诊预结算-解析报文
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<SYJS2206OutModel> JS2206Parse(SYBCommonParseModel<Out2206> mod)
        {
            BaseResponse<SYJS2206OutModel> result = new BaseResponse<SYJS2206OutModel>();
            if (mod.Message.infcode == -1)
            {
                throw new MyException(mod.Message.err_msg);
            }
            result.Data = new SYJS2206OutModel();
            result.Data.Cost = mod.Message.output.setlinfo.medfee_sumamt;
            result.Data.Balc = mod.Message.output.setlinfo.balc;
            result.Data.YBCost= mod.Message.output.setlinfo.acct_pay;
            result.Data.CashCost = mod.Message.output.setlinfo.psn_cash_pay;
            return result;
        }


        /// <summary>
        /// 门诊结算-获取报文
        /// </summary>
        /// <param name="mod">复合结构</param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<InCommon> JS2207(SYJS2207Model mod){
            BaseResponse<InCommon> rd = new BaseResponse<InCommon>();
            try
            {
                //InCommon rd1 = bll.getComm(mod.fixmedins_code, mod.fixmedins_name, mod.opter, mod.opter_name, mod.sign_no);
                InCommon rd1 = bll.getComm(mod.TenantId, mod.EmployeeId);
                Outpatient opbll = new Outpatient();
                var opstructure = opbll.getStructure(mod.TenantId, mod.OutpatientId);                
                In2207data model = new In2207data();
                model.data = new In2207();
                model.data.psn_no = opstructure.Patient.psn_no;
                model.data.mdtrt_cert_type = mod.Mdtrt_cert_type;
                model.data.med_type = "11";
                model.data.medfee_sumamt = Math.Round(decimal.Parse(opstructure.Cost.ToString()), 2); ;
                model.data.psn_setlway = "02";
                model.data.mdtrt_id = opstructure.mdtrt_id;
                model.data.chrg_bchno = opstructure.chrg_bchno;
                model.data.insutype = "310";
                model.data.mdtrt_cert_no = mod.Mdtrt_cert_no;
                model.data.acct_used_flag ="1";
                model.data.fulamt_ownpay_amt = mod.fulamt_ownpay_amt;
                model.data.overlmt_selfpay = mod.overlmt_selfpay;
                model.data.preselfpay_amt = mod.preselfpay_amt;
                model.data.inscp_scp_amt = mod.inscp_scp_amt;
                rd1.infno = "2207";
                rd1.input = model;
                rd.Data = rd1;//Newtonsoft.Json.JsonConvert.SerializeObject(rd1);
                return rd;
            }
            catch (Exception ex)
            {
                return rd.sysException(ex.Message);
            }
        }

        /// <summary>
        /// 门诊结算-解析报文
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<SYJS2207OutModel> JS2207Parse(SYBCommonParseModel<Out2207> mod)
        {
            BaseResponse<SYJS2207OutModel> result = new BaseResponse<SYJS2207OutModel>();
            if (mod.Message.infcode == -1)
            {
                throw new MyException(mod.Message.err_msg);
            }
            result.Data = new SYJS2207OutModel();
            result.Data.setl_id = mod.Message.output.setlinfo.setl_id;
            result.Data.Cost = mod.Message.output.setlinfo.medfee_sumamt;
            result.Data.Balc = mod.Message.output.setlinfo.balc;
            result.Data.YBCost = mod.Message.output.setlinfo.acct_pay;
            result.Data.CashCost = mod.Message.output.setlinfo.psn_cash_pay;
            return result;
        }


        /// <summary>
        /// 门诊结算撤销-获取报文
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<InCommon> JS2208(SYB2208Model mod){
            BaseResponse<InCommon> rd = new BaseResponse<InCommon>();
            try
            {
                //InCommon rd1 = bll.getComm(mod.fixmedins_code, mod.fixmedins_name, mod.opter, mod.opter_name, mod.sign_no);
                InCommon rd1 = bll.getComm(mod.TenantId, mod.EmployeeId);
                Outpatient opbll = new Outpatient();
                var opstructure = opbll.getStructure(mod.TenantId, mod.OutpatientId);
                In2208data model = new In2208data();
                model.data = new In2208();
                model.data.psn_no = opstructure.Patient.psn_no;
                model.data.mdtrt_id = opstructure.mdtrt_id;
                model.data.setl_id = opstructure.setl_id;
                rd1.infno = "2208";
                rd1.input = model;
                rd.Data = rd1;//Newtonsoft.Json.JsonConvert.SerializeObject(rd1);
                return rd;
            }
            catch (Exception ex)
            {
                return rd.sysException(ex.Message);
            }
        }

        /// <summary>
        /// 门诊结算撤销-解析报文
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<bool> JS2208Parse(SYBCommonParseModel<Out2208> mod)
        {
            BaseResponse<bool> result = new BaseResponse<bool>();
            if (mod.Message.infcode == -1)
            {
                throw new MyException(mod.Message.err_msg);
            }
            result.Data = true;
            return result;
        }

        /// <summary>
        /// 交易冲正
        /// </summary>
        /// <param name="mod">复合结构</param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<InCommon> JY2601(SYBEasyCommon<In2601> mod) {
            BaseResponse<InCommon> rd = new BaseResponse<InCommon>();
            try
            {
                InCommon rd1 = bll.getComm(mod.fixmedins_code, mod.fixmedins_name, mod.opter, mod.opter_name, mod.sign_no);
                In2601data model = new In2601data();
                model.data = new In2601();
                model.data.psn_no = mod.input.psn_no;
                model.data.omsgid = mod.input.omsgid;
                model.data.oinfno = mod.input.oinfno;
                rd1.infno = "2601";
                rd1.input = model;
                rd.Data = rd1;
                //rd.Data = Newtonsoft.Json.JsonConvert.SerializeObject(rd1);
                return rd;
            }
            catch (Exception ex)
            {
                return rd.sysException(ex.Message);
            }
        }

        /// <summary>
        /// 人员定点备案
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<InCommon> RYBA2505(SYBEasyCommon<In2505> mod)
        {
            BaseResponse<InCommon> rd = new BaseResponse<InCommon>();
            try
            {
                InCommon rd1 = bll.getComm(mod.fixmedins_code, mod.fixmedins_name, mod.opter, mod.opter_name, mod.sign_no);
                In2505data model = new In2505data();                
                model.data = new In2505();
                model.data.psn_no = mod.input.psn_no;
                model.data.biz_appy_type = mod.input.biz_appy_type;
                model.data.begndate = DateTime.Now.ToString("yyyy-MM-dd");
                model.data.fix_srt_no = "";
                model.data.fixmedins_code = mod.input.fixmedins_code;
                model.data.fixmedins_name = mod.input.fixmedins_name;
                rd1.infno = "2505";
                rd1.input = model;
                rd.Data = rd1;
                //rd.Data = Newtonsoft.Json.JsonConvert.SerializeObject(rd1);
                return rd;
            }
            catch (Exception ex)
            {
                return rd.sysException(ex.Message);
            }
        }

        /// <summary>
        /// 人员定点备案撤销
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<InCommon> RYBA2506(SYBEasyCommon<In2506> mod)
        {
            BaseResponse<InCommon> rd = new BaseResponse<InCommon>();
            try
            {
                InCommon rd1 = bll.getComm(mod.fixmedins_code, mod.fixmedins_name, mod.opter, mod.opter_name, mod.sign_no);
                In2506data model = new In2506data();
                model.data = new In2506();
                model.data.psn_no = mod.input.psn_no;
                model.data.trt_dcla_detl_sn = mod.input.trt_dcla_detl_sn;
                model.data.memo = mod.input.memo;
                rd1.infno = "2506";
                rd1.input = model;
                rd.Data = rd1;                
                return rd;
            }
            catch (Exception ex)
            {
                return rd.sysException(ex.Message);
            }
        }
        /// <summary>
        /// 待遇检查2001
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<InCommon> RYDY2001(SYBEasyCommon<In2001> mod)
        {
            BaseResponse<InCommon> rd = new BaseResponse<InCommon>();
            try
            {
                InCommon rd1 = bll.getComm(mod.fixmedins_code, mod.fixmedins_name, mod.opter, mod.opter_name, mod.sign_no);
                In2001data model = new In2001data();
                model.data = new In2001();
                model.data.psn_no = mod.input.psn_no;
                model.data.insutype = mod.input.insutype;
                model.data.fixmedins_code = mod.input.fixmedins_code;
                model.data.med_type = mod.input.med_type;
                model.data.begntime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));              
                //model.endtime = ;
                //model.dise_codg = "";
                //model.dise_name = "";
                //model.oprn_oprt_code = "";
                //model.oprn_oprt_name = "";
                //model.matn_type = "";
                //model.birctrl_type = "";              
                rd1.infno = "2001";
                rd1.input = model;
                rd.Data = rd1;
                return rd;
            }
            catch (Exception ex)
            {
                return rd.sysException(ex.Message);
            }
        }
        /// <summary>
        /// 科室上传3401
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<InCommon> KSSC3401(SYBEasyCommon<KS3401.Deptinfo> mod)
        {
            BaseResponse<InCommon> rd = new BaseResponse<InCommon>();
            try
            {
                InCommon rd1 = bll.getComm(mod.fixmedins_code, mod.fixmedins_name, mod.opter, mod.opter_name, mod.sign_no);
                In3401 model = new In3401();
                model.deptinfo = new KS3401.Deptinfo();
                model.deptinfo.aprv_bed_cnt =0;
                model.deptinfo.hi_crtf_bed_cnt = 0;
                model.deptinfo.begntime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                model.deptinfo.poolarea_no = "440300";
                model.deptinfo.aprv_bed_cnt=1;
                model.deptinfo.hosp_dept_codg = mod.input.hosp_dept_codg;
                model.deptinfo.caty = mod.input.caty;
                model.deptinfo.hosp_dept_name = mod.input.hosp_dept_name;
                model.deptinfo.itro = "";//??
                model.deptinfo.dept_resper_name = mod.input.dept_resper_name;
                model.deptinfo.dept_resper_tel = mod.input.dept_resper_tel;
                model.deptinfo.dept_estbdat = mod.input.dept_estbdat;
                if (mod.input.dr_psncnt.ToString() == "") 
                {
                    model.deptinfo.dr_psncnt = 0;
                }
                else { 
                    model.deptinfo.dr_psncnt = mod.input.dr_psncnt;
                }
                if (mod.input.phar_psncnt.ToString() == "")
                {  
                    model.deptinfo.phar_psncnt = 0; 
                }
                else {
                    model.deptinfo.phar_psncnt = mod.input.phar_psncnt;
                }
                if (mod.input.nurs_psncnt.ToString() == "")
                { 
                    model.deptinfo.nurs_psncnt = 0; 
                }
                else {
                    model.deptinfo.nurs_psncnt = mod.input.nurs_psncnt;
                }
                if (mod.input.tecn_psncnt.ToString() == "")
                {
                    model.deptinfo.tecn_psncnt = 0;
                }
                else
                {
                    model.deptinfo.tecn_psncnt = mod.input.tecn_psncnt;
                }                
                rd1.infno = "3401";
                rd1.input = model;
                rd.Data = rd1;
                return rd;
            }
            catch (Exception ex)
            {
                return rd.sysException(ex.Message);
            }
        }

        /// <summary>
        /// 科室信息变更
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<InCommon> KSBG3402(SYBEasyCommon<KS3402.Deptinfo> mod)
        {
            BaseResponse<InCommon> rd = new BaseResponse<InCommon>();
            try
            {
                InCommon rd1 = bll.getComm(mod.fixmedins_code, mod.fixmedins_name, mod.opter, mod.opter_name, mod.sign_no);
                In3402 model = new In3402();
                model.deptinfo = new KS3402.Deptinfo();
                model.deptinfo.aprv_bed_cnt = 0;
                model.deptinfo.hi_crtf_bed_cnt = 0;
                //model.deptinfo.begntime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                model.deptinfo.poolarea_no = "440300";
                model.deptinfo.aprv_bed_cnt = 1;
                model.deptinfo.hosp_dept_codg = mod.input.hosp_dept_codg;
                model.deptinfo.caty = mod.input.caty;
                model.deptinfo.hosp_dept_name = mod.input.hosp_dept_name;
                model.deptinfo.itro = "";//??
                model.deptinfo.dept_resper_name = mod.input.dept_resper_name;
                model.deptinfo.dept_resper_tel = mod.input.dept_resper_tel;
                model.deptinfo.dept_estbdat = mod.input.dept_estbdat;
                if (mod.input.dr_psncnt.ToString() == "")
                {
                    model.deptinfo.dr_psncnt = 0;
                }
                else
                {
                    model.deptinfo.dr_psncnt = mod.input.dr_psncnt;
                }
                if (mod.input.phar_psncnt.ToString() == "")
                {
                    model.deptinfo.phar_psncnt = 0;
                }
                else
                {
                    model.deptinfo.phar_psncnt = mod.input.phar_psncnt;
                }
                if (mod.input.nurs_psncnt.ToString() == "")
                {
                    model.deptinfo.nurs_psncnt = 0;
                }
                else
                {
                    model.deptinfo.nurs_psncnt = mod.input.nurs_psncnt;
                }
                if (mod.input.tecn_psncnt.ToString() == "")
                {
                    model.deptinfo.tecn_psncnt = 0;
                }
                else
                {
                    model.deptinfo.tecn_psncnt = mod.input.tecn_psncnt;
                }
                model.deptinfo.begntime = mod.input.begntime;
                rd1.infno = "3402";
                rd1.input = model;
                rd.Data = rd1;
                return rd;
            }
            catch (Exception ex)
            {
                return rd.sysException(ex.Message);
            }
        }
        /// <summary>
        /// 科室撤销
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<InCommon> KSCX3403(SYBEasyCommon<In3403> mod)
        {
            BaseResponse<InCommon> rd = new BaseResponse<InCommon>();
            try
            {
                InCommon rd1 = bll.getComm(mod.fixmedins_code, mod.fixmedins_name, mod.opter, mod.opter_name, mod.sign_no);               
                In3403data model = new In3403data();
                model.data = new In3403();
                model.data.begntime = mod.input.begntime;
                model.data.hosp_dept_codg = mod.input.hosp_dept_codg;
                model.data.hosp_dept_name = mod.input.hosp_dept_name;
                rd1.infno = "3403";             
                rd1.input = model;
                rd.Data = rd1;
                return rd;
            }
            catch (Exception ex)
            {
                return rd.sysException(ex.Message);
            }
        }
        /// <summary>
        /// 文件下载9102
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<InCommon> Down9102(SYBEasyCommon<FsDownloadIn> mod)
        {
            BaseResponse<InCommon> rd = new BaseResponse<InCommon>();
            try
            {
                InCommon rd1 = bll.getComm(mod.fixmedins_code, mod.fixmedins_name, mod.opter, mod.opter_name, mod.sign_no);
                In9102 model = new In9102();
                model.fsDownloadIn = new FsDownloadIn();
                model.fsDownloadIn.filename = mod.input.filename;
                model.fsDownloadIn.file_qury_no = mod.input.file_qury_no;
                model.fsDownloadIn.fixmedins_code = "plc";
                rd1.infno = "9102";
                rd1.input = model;
                rd.Data = rd1;
                return rd;
            }
            catch (Exception ex)
            {
                return rd.sysException(ex.Message);
            }
        }
        /// <summary>
        /// 医药机构信息获取
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<InCommon> JG1201(SYBEasyCommon<In1201> mod)
        {
            BaseResponse<InCommon> rd = new BaseResponse<InCommon>();
            try
            {
                InCommon rd1 = bll.getComm(mod.fixmedins_code, mod.fixmedins_name, mod.opter, mod.opter_name, mod.sign_no);
                In1201data model = new In1201data();
                model.medinsinfo = new In1201();
                model.medinsinfo.fixmedins_code = mod.fixmedins_code;
                model.medinsinfo.fixmedins_name = mod.fixmedins_name;
                model.medinsinfo.fixmedins_type = "1";
                rd1.infno = "1201";
                rd1.input = model;
                rd.Data = rd1;
                return rd;
            }
            catch (Exception ex)
            {
                return rd.sysException(ex.Message);
            }
        }

        /// <summary>
        /// 人员累计信息查询
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        public BaseResponse<InCommon> RY5206(SYBEasyCommon<In5206> mod)
        {
            BaseResponse<InCommon> rd = new BaseResponse<InCommon>();
            try
            {
                InCommon rd1 = bll.getComm(mod.fixmedins_code, mod.fixmedins_name, mod.opter, mod.opter_name, mod.sign_no);
                In5206data model = new In5206data();
                model.data = new In5206();
                model.data.psn_no = mod.input.psn_no;
                model.data.cum_ym = mod.input.cum_ym;
                //model.medinsinfo.fixmedins_type = "1";
                rd1.infno = "5206";
                rd1.input = model;
                rd.Data = rd1;
                return rd;
            }
            catch (Exception ex)
            {
                return rd.sysException(ex.Message);
            }
        }
        /// <summary>
        /// 人员定点信息查询
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        public BaseResponse<InCommon> RY5302(SYBEasyCommon<In5302> mod)
        {
            BaseResponse<InCommon> rd = new BaseResponse<InCommon>();
            try
            {
                InCommon rd1 = bll.getComm(mod.fixmedins_code, mod.fixmedins_name, mod.opter, mod.opter_name, mod.sign_no);
                In5302data model = new In5302data();
                model.data = new In5302();
                model.data.psn_no = mod.input.psn_no;
                model.data.biz_appy_type = mod.input.biz_appy_type;               
                rd1.infno = "5302";
                rd1.input = model;
                rd.Data = rd1;
                return rd;
            }
            catch (Exception ex)
            {
                return rd.sysException(ex.Message);
            }
        }
        /// <summary>
        /// 1301西药下载
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<InCommon> Down1301(SYBEasyCommon<In1301> mod)
        {
            BaseResponse<InCommon> rd = new BaseResponse<InCommon>();
            try
            {
                InCommon rd1 = bll.getComm(mod.fixmedins_code, mod.fixmedins_name, mod.opter, mod.opter_name, mod.sign_no);
                In1301 model = new In1301();
                model.ver = "1.0";
                rd1.infno = "1301";
                rd1.input = model;
                rd.Data = rd1;
                return rd;
            }
            catch (Exception ex)
            {
                return rd.sysException(ex.Message);
            }
        }

        /// <summary>
        /// 中药饮片目录下载
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<InCommon> Down1302(SYBEasyCommon<In1301> mod)
        {
            BaseResponse<InCommon> rd = new BaseResponse<InCommon>();
            try
            {
                InCommon rd1 = bll.getComm(mod.fixmedins_code, mod.fixmedins_name, mod.opter, mod.opter_name, mod.sign_no);
                In1301 model = new In1301();
                model.ver = "1.0";
                rd1.infno = "1302";
                rd1.input = model;
                rd.Data = rd1;
                return rd;
            }
            catch (Exception ex)
            {
                return rd.sysException(ex.Message);
            }
        }
        /// <summary>
        /// 医疗机构制剂目录下载
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<InCommon> Down1303(SYBEasyCommon<In1301> mod)
        {
            BaseResponse<InCommon> rd = new BaseResponse<InCommon>();
            try
            {
                InCommon rd1 = bll.getComm(mod.fixmedins_code, mod.fixmedins_name, mod.opter, mod.opter_name, mod.sign_no);
                In1301 model = new In1301();
                model.ver = "1.0";
                rd1.infno = "1303";
                rd1.input = model;
                rd.Data = rd1;
                return rd;
            }
            catch (Exception ex)
            {
                return rd.sysException(ex.Message);
            }
        }
        /// <summary>
        /// 医疗服务项目目录下载
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<InCommon> Down1305(SYBEasyCommon<In1301> mod)
        {
            BaseResponse<InCommon> rd = new BaseResponse<InCommon>();
            try
            {
                InCommon rd1 = bll.getComm(mod.fixmedins_code, mod.fixmedins_name, mod.opter, mod.opter_name, mod.sign_no);
                In1301 model = new In1301();
                model.ver = "1.0";
                rd1.infno = "1305";
                rd1.input = model;
                rd.Data = rd1;
                return rd;
            }
            catch (Exception ex)
            {
                return rd.sysException(ex.Message);
            }
        }

        /// <summary>
        /// 医用耗材目录下载
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<InCommon> Down1306(SYBEasyCommon<In1301> mod)
        {
            BaseResponse<InCommon> rd = new BaseResponse<InCommon>();
            try
            {
                InCommon rd1 = bll.getComm(mod.fixmedins_code, mod.fixmedins_name, mod.opter, mod.opter_name, mod.sign_no);
                Indata1301 model = new Indata1301();
                model.data = new In1301();
                model.data.ver = "1.0";
                rd1.infno = "1306";
                rd1.input = model;
                rd.Data = rd1;
                return rd;
            }
            catch (Exception ex)
            {
                return rd.sysException(ex.Message);
            }
        }

        /// <summary>
        /// 疾病与诊断目录下载
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<InCommon> Down1307(SYBEasyCommon<In1301> mod)
        {
            BaseResponse<InCommon> rd = new BaseResponse<InCommon>();
            try
            {
                InCommon rd1 = bll.getComm(mod.fixmedins_code, mod.fixmedins_name, mod.opter, mod.opter_name, mod.sign_no);
                Indata1301 model = new Indata1301();
                model.data = new In1301();
                model.data.ver = "1.0";
                rd1.infno = "1307";
                rd1.input = model;
                rd.Data = rd1;
                return rd;
            }
            catch (Exception ex)
            {
                return rd.sysException(ex.Message);
            }
        }

        /// <summary>
        /// 中医疾病目录下载
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<InCommon> Down1314(SYBEasyCommon<In1301> mod)
        {
            BaseResponse<InCommon> rd = new BaseResponse<InCommon>();
            try
            {
                InCommon rd1 = bll.getComm(mod.fixmedins_code, mod.fixmedins_name, mod.opter, mod.opter_name, mod.sign_no);
                Indata1301 model = new Indata1301();
                model.data = new In1301();
                model.data.ver = "1.0";               
                rd1.infno = "1314";
                rd1.input = model;
                rd.Data = rd1;
                return rd;
            }
            catch (Exception ex)
            {
                return rd.sysException(ex.Message);
            }
        }

        /// <summary>
        /// 中医证候目录下载
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<InCommon> Down1315(SYBEasyCommon<In1301> mod)
        {
            BaseResponse<InCommon> rd = new BaseResponse<InCommon>();
            try
            {
                InCommon rd1 = bll.getComm(mod.fixmedins_code, mod.fixmedins_name, mod.opter, mod.opter_name, mod.sign_no);
                Indata1301 model = new Indata1301();
                model.data = new In1301();
                model.data.ver = "1.0";             
                rd1.infno = "1315";
                rd1.input = model;
                rd.Data = rd1;
                return rd;
            }
            catch (Exception ex)
            {
                return rd.sysException(ex.Message);
            }
        }

        /// <summary>
        /// 民族药品目录下载
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<InCommon> Down1304(SYBEasyCommon<In1304> mod)
        {
            BaseResponse<InCommon> rd = new BaseResponse<InCommon>();
            try
            {
                InCommon rd1 = bll.getComm(mod.fixmedins_code, mod.fixmedins_name, mod.opter, mod.opter_name, mod.sign_no);
                In1304data model = new In1304data();
                model.data = new In1304();
                model.data.updt_time = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                model.data.page_num = 1;
                model.data.page_size = 100;
                rd1.infno = "1304";
                rd1.input = model;
                rd.Data = rd1;
                return rd;
            }
            catch (Exception ex)
            {
                return rd.sysException(ex.Message);
            }
        }

        /// <summary>
        /// 医保目录信息下载
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<InCommon> Down1312(SYBEasyCommon<In1312> mod)
        {
            BaseResponse<InCommon> rd = new BaseResponse<InCommon>();
            try
            {
                InCommon rd1 = bll.getComm(mod.fixmedins_code, mod.fixmedins_name, mod.opter, mod.opter_name, mod.sign_no);
                In1312data model = new In1312data();
                model.data = new In1312();
                model.data.updt_time = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                model.data.page_num = 1;
                model.data.page_size = 100;
                rd1.infno = "1312";
                rd1.input = model;
                rd.Data = rd1;
                return rd;
            }
            catch (Exception ex)
            {
                return rd.sysException(ex.Message);
            }
        }

        /// <summary>
        /// 医保目录限价信息下载
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<InCommon> Down1318(SYBEasyCommon<In1318> mod)
        {
            BaseResponse<InCommon> rd = new BaseResponse<InCommon>();
            try
            {
                InCommon rd1 = bll.getComm(mod.fixmedins_code, mod.fixmedins_name, mod.opter, mod.opter_name, mod.sign_no);
                In1318data model = new In1318data();
                model.data = new In1318();
                model.data.updt_time = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                model.data.page_num = 1;
                model.data.page_size = 100;
                rd1.infno = "1318";
                rd1.input = model;
                rd.Data = rd1;
                return rd;
            }
            catch (Exception ex)
            {
                return rd.sysException(ex.Message);
            }
        }

        /// <summary>
        /// 医保目录先自付比例信息下载
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<InCommon> Down1319(SYBEasyCommon<In1319> mod)
        {
            BaseResponse<InCommon> rd = new BaseResponse<InCommon>();
            try
            {
                if (mod.zhid == null)
                {
                    return rd.busExceptino( Enum.ErrorCode.业务逻辑错误,"租户ID不能为空");
                }
               
                InCommon rd1 = bll.getComm(mod.fixmedins_code, mod.fixmedins_name, mod.opter, mod.opter_name, mod.sign_no);
                In1319data model = new In1319data();
                model.data = new In1319();
                model.data.updt_time = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));     
                //model.data.updt_time = Convert.ToDateTime(DateTime.Now.AddDays(yyts).ToString("yyyy-MM-dd hh:mm:ss"));
                model.data.page_num = 1;
                model.data.page_size = 100;
                rd1.infno = "1319";
                rd1.input = model;
                rd.Data = rd1;
                return rd;
            }
            catch (Exception ex)
            {
                return rd.sysException(ex.Message);
            }
        }
        /// <summary>
        /// 电子处方上传
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<InCommon> CFSC7101(SYBEasyCommon<In7101> mod)
        {
            BaseResponse<InCommon> rd = new BaseResponse<InCommon>();
            InCommon rd1 = bll.getComm(mod.fixmedins_code, mod.fixmedins_name, mod.opter, mod.opter_name, mod.sign_no);
            In7101 model = new In7101();
            #region data
            model.data = new In7101data();
            model.data.hosp_rxno = mod.input.data.hosp_rxno;
            model.data.rx_type_code = mod.input.data.rx_type_code;
            model.data.prsc_time = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            model.data.rx_drug_nums = mod.input.data.rx_drug_nums;
            model.data.valid_days = mod.input.data.valid_days;
            model.data.valid_end_time = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            model.data.rx_cotn_flag = mod.input.data.rx_cotn_flag;
            model.data.rx_file = mod.input.data.rx_file;
            model.data.rx_circ_flag = mod.input.data.rx_circ_flag;
            #endregion

            #region rxdrugdetail
            model.rxdrugdetail = new List<Rxdrugdetail>();
            foreach (var item in mod.input.rxdrugdetail)
            {
                Rxdrugdetail temp = new Rxdrugdetail();
                temp.med_list_codg = item.med_list_codg;
                temp.drug_genname = item.drug_genname;
                temp.drug_dosform = item.drug_dosform;
                temp.drug_spec = item.drug_spec;
                temp.drug_cnt = item.drug_cnt;
                temp.drug_cnt_unit = item.drug_cnt_unit;
                temp.medc_way_codg = item.medc_way_codg;
                temp.medc_way_dscr = item.medc_way_dscr;
                temp.medc_starttime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                temp.medc_endtime = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd hh:mm:ss");
                temp.medc_days = item.medc_days;
                model.rxdrugdetail.Add(temp);
            }

            #endregion rxdrugdetail

            #region mdtrtinfo
            model.mdtrtinfo = new Mdtrtinfo();
            model.mdtrtinfo.mdtrt_id = mod.input.mdtrtinfo.mdtrt_id;
            model.mdtrtinfo.med_type = mod.input.mdtrtinfo.med_type;
            model.mdtrtinfo.ipt_op_no = mod.input.mdtrtinfo.ipt_op_no;
            model.mdtrtinfo.psn_no = mod.input.mdtrtinfo.psn_no;
            model.mdtrtinfo.patn_name = mod.input.mdtrtinfo.patn_name;
            model.mdtrtinfo.age = mod.input.mdtrtinfo.age;
            model.mdtrtinfo.gend = mod.input.mdtrtinfo.gend;
            model.mdtrtinfo.insuplc_admdvs = mod.input.mdtrtinfo.insuplc_admdvs;
            model.mdtrtinfo.psn_cert_type = mod.input.mdtrtinfo.psn_cert_type.StartsWith("0") ? mod.input.mdtrtinfo.psn_cert_type.Substring(1): mod.input.mdtrtinfo.psn_cert_type;
            model.mdtrtinfo.certno = mod.input.mdtrtinfo.certno;
            model.mdtrtinfo.insutype = mod.input.mdtrtinfo.insutype;
            model.mdtrtinfo.prsc_dept_name = mod.input.mdtrtinfo.prsc_dept_name;
            model.mdtrtinfo.prsc_dept_code = mod.input.mdtrtinfo.prsc_dept_code;
            model.mdtrtinfo.prsc_dr_name = mod.input.mdtrtinfo.prsc_dr_name;
            model.mdtrtinfo.phar_name = mod.input.mdtrtinfo.phar_name;
            model.mdtrtinfo.phar_chk_time = DateTime.Now.ToString("yyyy-MM-dd hh:mm:sss");
            model.mdtrtinfo.mdtrt_time = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            model.mdtrtinfo.sp_dise_flag = mod.input.mdtrtinfo.sp_dise_flag;
            model.mdtrtinfo.diag_code = mod.input.mdtrtinfo.diag_code;
            model.mdtrtinfo.diag_name = mod.input.mdtrtinfo.diag_name;
            model.mdtrtinfo.rgst_fee = mod.input.mdtrtinfo.rgst_fee;

            #endregion

            #region diseinfo
            model.diseinfo = new List<YG7101.Diseinfo>();
            foreach(var item in mod.input.diseinfo)
            {
                YG7101.Diseinfo temp = new YG7101.Diseinfo();
                temp.diag_type = item.diag_type;                
                temp.maindiag_flag = item.maindiag_flag;
                temp.diag_srt_no = item.diag_srt_no;
                temp.diag_code = item.diag_code;
                temp.diag_name = item.diag_name;
                temp.diag_dept = item.diag_dept;
                temp.dise_dor_no = item.dise_dor_no;
                temp.dise_dor_name = item.dise_dor_name;
                temp.diag_time = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                model.diseinfo.Add(temp);
            }

            #endregion

            try
            {
                if (mod.zhid == null)
                {
                    return rd.busExceptino( Enum.ErrorCode.业务逻辑错误,"租户ID不能为空");
                }
                for ( int i=0;i<model.rxdrugdetail.Count;i++)
                {
                    model.rxdrugdetail[i].bas_medn_flag = mod.input.rxdrugdetail[i].bas_medn_flag;
                }
                
                rd1.infno = "7101";
                rd1.input = model;
                rd.Data = rd1;
            }

            catch (Exception e)
            {
                return rd.sysException(e.Message);
            }
            return rd;
        }

        /// <summary>
        /// 电子处方撤销
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<InCommon> CFCX7104(SYBEasyCommon<In7104> mod)
        {
            BaseResponse<InCommon> rd = new BaseResponse<InCommon>();
            InCommon rd1 = bll.getComm(mod.fixmedins_code, mod.fixmedins_name, mod.opter, mod.opter_name, mod.sign_no);            
            In7104data model = new In7104data();
            model.data= new In7104();
            model.data.hi_rxno = mod.input.hi_rxno;
            model.data.prsc_dr_name = mod.input.prsc_dr_name;
            model.data.undo_dr_certno = mod.input.undo_dr_certno;
            model.data.undo_rea = mod.input.undo_rea;
            model.data.undo_time = DateTime.Now.ToString("yyyy-mm-dd hh:mm:ss");
            try
            {
                if (mod.zhid == null)
                {
                    return rd.busExceptino( Enum.ErrorCode.业务逻辑错误, "租户ID不能为空");
                }
                rd1.infno = "7104";
                rd1.input = model;
                rd.Data = rd1;
            }
            catch (Exception e)
            {
                return rd.sysException(e.Message);
            }
            return rd;
        }

        /// <summary>
        /// 处方支付状态同步
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        public BaseResponse<InCommon> CFCX7105(SYBEasyCommon<In7105> mod)
        {
            BaseResponse<InCommon> rd = new BaseResponse<InCommon>();
            InCommon rd1 = bll.getComm(mod.fixmedins_code, mod.fixmedins_name, mod.opter, mod.opter_name, mod.sign_no);
            In7105data model = new In7105data();
            model.data = new In7105();
            model.data.hi_rxno = mod.input.hi_rxno;
            model.data.prsc_dr_name = mod.input.prsc_dr_name;
            model.data.undo_dr_certno = mod.input.undo_dr_certno;
            model.data.undo_dr_cert_type = mod.input.undo_dr_cert_type;
            model.data.undo_rea = mod.input.undo_rea;
            model.data.undo_time = mod.input.undo_time;                                         
            try
            {
                if (mod.zhid == null)
                {
                    return rd.busExceptino( Enum.ErrorCode.业务逻辑错误,"租户ID不能为空");
                }
                rd1.infno = "7105";
                rd1.input = model;
                rd.Data = rd1;
            }
            catch (Exception e)
            {
                return rd.sysException(e.Message);
            }
            return rd;
        }
    }


}

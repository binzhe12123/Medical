using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace YB.FrameWork
{
    public static class SZJG_Task_Object
    {
        public static string getObject(SZJG_Type_Enum key)
        {
            string ApiPath = "";                                            
            switch (key.ToString())
            {
                case "医疗机构信息":
                    ApiPath = "/institution"; break;
                case "职工信息":
                    ApiPath = "/employee"; break;
                case "药品字典":
                    ApiPath = "/drug/dictionary"; break;
                case "药品出入库信息":
                    ApiPath = "/drug/depot"; break;
                case "药品出入库明细":
                    ApiPath = "/drug/depot/detail"; break;
                case "药品库存信息":
                    ApiPath = "/drug/storage"; break;
                case "患者基本信息":
                    ApiPath = "/patient"; break;
                case "诊所月报":
                    ApiPath = "/report/monthly"; break;
                case "诊所年报":
                    ApiPath = "/report/annual"; break;
                case "诊疗项目目录":
                    ApiPath = "/diagnosis/project"; break;
                case "组合项目目录":
                    ApiPath = "/portfolio/project"; break;
                case "组合项目明细":
                    ApiPath = "/portfolio/projectDetail"; break;
                case "附件上传":
                    ApiPath = "/attachment"; break;
                case "供应商信息":
                    ApiPath = "/supplier"; break;
                case "科室信息":
                    ApiPath = "/department"; break;
                case "人脸识别监管事件创建":
                    ApiPath = "/event/user/recognize/build"; break;
                case "人脸识别监管事件结果查询":
                    ApiPath = "/event/user/recognize/query"; break;
                case "查询抗菌处方权审核资质":
                    ApiPath = "/antibacterial/prescription/query"; break;
                case "患者门急诊信息":
                    ApiPath = "/outpatient"; break;
                case "通用事件创建":
                    ApiPath = "/active/event/build"; break;              
                default: break;
            }
            return ApiPath;
        }
    }


    public enum SZJG_Type_Enum
    {
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
        患者门急诊信息,
        通用事件创建
    }

}

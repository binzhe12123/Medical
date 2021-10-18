using YB.FrameWork;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Client.Model;

namespace Client.Controllers
{
    /// <summary>
    /// 深圳监管接口
    /// </summary>
    public class SZJGController : ApiController
    {
        [HttpPost]
        public string send(SZJGModel mod)
        {
            try
            {
                #region 发送数据
                //SZJG_Key_Model key_mod = new SZJG_Key_Model();
                //key_mod.ZHMC = mod.ZHMC;
                //key_mod.channelId = mod.channelId;
                //key_mod.accessKey = mod.accessKey;
                //key_mod.secretKey = mod.secretKey;
                //key_mod.publicKey = mod.publicKey;
                //key_mod.ZHCode = mod.ZHCode;
                                                                
                SZJGInterface szjgapi = new SZJGInterface(mod.key_mod, mod.szjgtype, mod.data);
                SZJG_Return_Model szjgreturn = szjgapi.send();
                #endregion
                #region 成功记录数据库
                //var jsonSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
                //LogHelper.Debug(mod.szjgtype.ToString() + "入参:" + Newtonsoft.Json.JsonConvert.SerializeObject(mod.data, Formatting.Indented, jsonSetting));
                //LogHelper.Debug(mod.szjgtype.ToString() + "出参:" + szjgapi.returnData);
                #endregion
                return szjgapi.returnData;
            }
            catch (Exception ex)
            {
                ex.Source += "SZJG.sendCommon";                
                LogHelper.Error("SZJG.sendCommon:" + ex.Message);
                throw ex;
            }
        }
        


    }
}

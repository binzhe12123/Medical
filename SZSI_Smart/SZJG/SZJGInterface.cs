using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Configuration;
using com.pasc.medical.dc.clinic.sdk.common.dto;
using com.pasc.medical.dc.clinic.sdk.common.config;
using java.util;
using com.pasc.medical.dc.clinic.sdk.common.utils.security;
using net.bytebuddy.utility;
using com.pasc.medical.dc.clinic.sdk.utils;
using com.alibaba.fastjson;
using org.apache.http.util;
using org.apache.http.impl.client;
using org.apache.http.client.methods;
using java.io;
using org.apache.http.entity;
using org.apache.http;
using org.apache.commons.crypto.stream;
using javax.crypto;
using java.nio.charset;

namespace YB.FrameWork
{
    //监管对接类
    public class SZJGInterface
    {
        private SZJG_Key_Model szjg_zhkey;
        private string apiname;
        private string apipath;
        private object Data;
        public string returnData;

        //需要初始化对接的参数
        public SZJGInterface(SZJG_Key_Model key, SZJG_Type_Enum type, object data)
        {
            szjg_zhkey = key;
            apiname = type.ToString();
            apipath = SZJG_Task_Object.getObject(type);
            Data = data;
        }

        //发送消息
        public SZJG_Return_Model send(bool isFile = false,string filepath = "")
        {
            try {
                //测试服务器地址：https://nhiptest.city.pingan.com/api/nhip/dc
                //生产服务器地址：https://nhip.city.pingan.com/api/nhip/dc
                string url = "";
                string enviroment = ConfigurationManager.AppSettings.Get("Enviroment");
                if (!string.IsNullOrEmpty(enviroment) && enviroment.ToLower() != "produce" && enviroment.ToLower() != "abtest")
                {
                    url = "https://nhiptest.city.pingan.com/api/nhip/dc";
                }
                else
                {
                    url = "https://nhip.city.pingan.com/api/nhip/dc";
                }
                SdkRequestUtils sdktempe = new SdkRequestUtils();
                String aesKey = RandomString.make(16);
                //String aesKey = "1234567891234567";
                SdkRequestUtils.httpUrl = url;
                APSKConstant.channelId = szjg_zhkey.channelId;// "10000030";
                APSKConstant.accessKey = szjg_zhkey.accessKey;//"db8JrM7E9JiGQD8qkICdmo3aP16LA3L78j6fb6hAqRE4y3oMbE6ceVQePFYuz-xbcHrv-TQBRNSTNZomFT_5UizDXJGecQ_GXZ_p9NYfxNIBxQ1j7K7YC0ijdsAaIjwgpnLsSgAgF3TnMsLjIrvZ_S-eYh6Czw42tg9tKzv_X00";
                APSKConstant.secretKey = szjg_zhkey.secretKey;//"AqOAjaNwULSk6Qcgk0wb3frv-M70aY22uC3luaXbOudJ7JoPxYTxYfzyQNZtm4jZTsvlVO2gQKBT6kg4MJ1gwb19LvLHiItP4Oc5hSKW845ZEI6TUrlLi7yDXWrcN08aTUMYdnPxM7AllBtPeF9i8Z-wRq6B_Gf0hRKxHkXYNqc";
                APSKConstant.publicKey = szjg_zhkey.publicKey;//"MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCjenwa5gonfZHb7ZCJUOCZABeM8lr_jJFqradu1icihrlfroY43uQg_sl7SLLNUF_KQZa9ua87sGaSqYzJLwaAapxGix6003E3RZ5s3XMR34Yl6PRBaHtLkTtBb5GMr6cQk29tbZGKUuLj9iQw8MYPp6XLnJ7oA2sKLQuNHyI3xwIDAQAB";                
                RequestDTO requestCommonDTO = buildRequestDTO2(Data, aesKey);
                String authorization = buildAuthorization2(apipath, requestCommonDTO);
                Dictionary<string, string> headers = new Dictionary<string, string>();
                if (isFile)
                {
                    headers.Add("fileUploadInfo", JSONObject.toJSONString(requestCommonDTO));
                }
                headers.Add("Authorization", authorization);
                string result = "";
                if (isFile)
                {

                    #region filebytes读取文件流
                    Stream fileStream = WebRequest.Create(new Uri(filepath)).GetResponse().GetResponseStream();
                    var memoryStream = new MemoryStream();
                    //将基础流写入内存流
                    const int bufferLength = 1024;
                    byte[] buffer = new byte[bufferLength];
                    int actual;
                    while ((actual = fileStream.Read(buffer, 0, bufferLength)) != 0)
                    {
                        memoryStream.Write(buffer, 0, actual);
                    }
                    memoryStream.Position = 0;

                    byte[] bytes = new byte[memoryStream.Length];
                    memoryStream.Read(bytes, 0, bytes.Length);

                    #endregion

                    #region 加密文件流
                    RijndaelManaged rijndaelCipher = new RijndaelManaged();
                    rijndaelCipher.Mode = CipherMode.CBC;
                    rijndaelCipher.Padding = PaddingMode.PKCS7;
                    rijndaelCipher.KeySize = 128;
                    rijndaelCipher.BlockSize = 128;
                    byte[] pwdBytes = System.Text.Encoding.UTF8.GetBytes(aesKey);
                    byte[] keyBytes = new byte[16];
                    int len = pwdBytes.Length;
                    if (len > keyBytes.Length)
                        len = keyBytes.Length;
                    System.Array.Copy(pwdBytes, keyBytes, len);
                    rijndaelCipher.Key = keyBytes;
                    rijndaelCipher.IV = Encoding.UTF8.GetBytes(aesKey);
                    ICryptoTransform transform = rijndaelCipher.CreateEncryptor();
                    
                    byte[] jmfilebytes = transform.TransformFinalBlock(bytes, 0, bytes.Length);


                    #endregion

                    #region 文件流解密

                    //RijndaelManaged rijndaelCipher2 = new RijndaelManaged();
                    //rijndaelCipher2.Mode = CipherMode.CBC;
                    //rijndaelCipher2.Padding = PaddingMode.PKCS7;
                    //rijndaelCipher2.KeySize = 128;
                    //rijndaelCipher2.BlockSize = 128;
                    
                    //byte[] pwdBytes2 = System.Text.Encoding.UTF8.GetBytes(aesKey);
                    //byte[] keyBytes2 = new byte[16];
                    //int len2 = pwdBytes2.Length;
                    //if (len2 > keyBytes2.Length)
                    //    len2 = keyBytes2.Length;
                    //System.Array.Copy(pwdBytes2, keyBytes2, len2);
                    //rijndaelCipher2.Key = keyBytes2;
                    //rijndaelCipher2.IV = Encoding.UTF8.GetBytes(aesKey);
                    //ICryptoTransform transform2 = rijndaelCipher2.CreateDecryptor();
                    //byte[] filebytes = transform2.TransformFinalBlock(jmfilebytes, 0, jmfilebytes.Length);


                    #endregion

                    #region 获取文件类型
                    //string fileContentType = "";
                    //if (filepath.LastIndexOf(".jpg") > 0 || filepath.LastIndexOf(".jpeg") > 0)
                    //{
                    //    fileContentType = "image/jpeg";
                    //} else if (filepath.LastIndexOf(".png") > 0)
                    //{
                    //    fileContentType = "image/png";
                    //} else if (filepath.LastIndexOf(".pdf") > 0)
                    //{
                    //    fileContentType = "application/pdf";
                    //}
                    //fileContentType = "application/octet-stream";
                    #endregion

                    //List<MK.FrameWork.PostDateClass> datasfile = new List<MK.FrameWork.PostDateClass>();
                    //datasfile.Add(new MK.FrameWork.PostDateClass("", filepath, 2, jmfilebytes, fileContentType, "翠都执业许可证.jpg")); 
                    //datasfile.Add(new MK.FrameWork.PostDateClass("entity", filepath, 2, jmfilebytes, fileContentType, "测试图片.png"));
                    //datasfile.Add(new MK.FrameWork.PostDateClass("", "D:\\temp\\测试图片.png", 1, jmfilebytes, fileContentType, "测试图片.png"));
                    //result = MK.FrameWork.WebClient.postMessage("http://localhost:8012/api/Clinic/UploadFile", datasfile, headers, false, true);
                    //result = MK.FrameWork.WebClient.postMessage(SdkRequestUtils.httpUrl + apipath, datasfile, headers, false, true);
                    List<YB.FrameWork.FormItemModel> datafiles = new List<FormItemModel>();
                    YB.FrameWork.FormItemModel tempfile = new FormItemModel();
                    tempfile.Key = "";
                    tempfile.FileName = "测试图片.png";
                    MemoryStream file = new MemoryStream(jmfilebytes);
                    tempfile.FileContent = file;
                    datafiles.Add(tempfile);
                    result = YB.FrameWork.WebClient.PostForm(SdkRequestUtils.httpUrl + apipath, datafiles, headers, null, null, null);
                    file.Close();
                }
                else {
                    List<YB.FrameWork.PostDateClass> datas = new List<YB.FrameWork.PostDateClass>();
                    datas.Add(new YB.FrameWork.PostDateClass("channelId", requestCommonDTO.getChannelId()));
                    datas.Add(new YB.FrameWork.PostDateClass("requestId", requestCommonDTO.getRequestId()));
                    datas.Add(new YB.FrameWork.PostDateClass("encodeKey", requestCommonDTO.getEncodeKey()));
                    datas.Add(new YB.FrameWork.PostDateClass("sign", requestCommonDTO.getSign()));
                    datas.Add(new YB.FrameWork.PostDateClass("signMethod", requestCommonDTO.getSignMethod()));
                    datas.Add(new YB.FrameWork.PostDateClass("timestamp", requestCommonDTO.getTimestamp()));
                    datas.Add(new YB.FrameWork.PostDateClass("version", requestCommonDTO.getVersion()));
                    datas.Add(new YB.FrameWork.PostDateClass("encodeData", requestCommonDTO.getEncodeData()));
                    var jsonSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
                    //Log4Net.LogHelper.Debug(szjg_zhkey.ZHMC + "监管" + SdkRequestUtils.httpUrl + apipath + "入参:" + Newtonsoft.Json.JsonConvert.SerializeObject(Data, Formatting.None, jsonSetting));
                    result = YB.FrameWork.WebClient.postMessage(SdkRequestUtils.httpUrl + apipath, datas, headers, false);
                    //Log4Net.LogHelper.Debug(szjg_zhkey.ZHMC + "监管" + apiname + "出参:" + result);
                }
                //string result = MK.FrameWork.WebClient.PostForm(SdkRequestUtils.httpUrl + urlPath, formDatas, headers);
                SZJG_Return_Model wuha = Newtonsoft.Json.JsonConvert.DeserializeObject<SZJG_Return_Model>(result);
                returnData = result;
                return wuha;
            }
            catch (Exception ex) {
                ex.Source = "SZJG.send:" + ex.Message;
                throw ex;
            }
        }

        //发送文件
        public SZJG_Return_Model sendFile()
        {
            SZJG_Return_Model wuha = new FrameWork.SZJG_Return_Model();
            return wuha;
        }

        //发送文件by调用java

        private  RequestDTO buildRequestDTO2(object obj,string aesKey)
        {
            try {
                long timestamp = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
                RequestDTO requestDTO = new RequestDTO();
                requestDTO.setChannelId(APSKConstant.channelId);
                requestDTO.setRequestId(UUID.randomUUID().toString());
                requestDTO.setSignMethod("sha256");
                requestDTO.setVersion("1.0");
                requestDTO.setTimestamp(timestamp.ToString());
                requestDTO.setEncodeKey(RSAUtil.encryptByPublicKey(aesKey, APSKConstant.publicKey));
                //requestDTO.setEncodeData(AESUtil.encrypt(JSONObject.toJSONString(obj), aesKey));
                var jsonSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
                if (obj.GetType() != typeof(string))
                {
                    requestDTO.setEncodeData(AESUtil.encrypt(Newtonsoft.Json.JsonConvert.SerializeObject(obj, Formatting.None, jsonSetting), aesKey));
                }
                else {
                    requestDTO.setEncodeData(AESUtil.encrypt(obj.ToString(), aesKey));
                }
                requestDTO.setSign(SignUtil.buildSign(requestDTO));
                return requestDTO;
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        private  String buildAuthorization2(String apiUrl, RequestDTO requestCommonDTO)
        {
            return AuthorityUtil.buildAuthorization(apiUrl, "POST", requestCommonDTO.getSign(), requestCommonDTO.getTimestamp(), "127.0.0.1", APSKConstant.accessKey, APSKConstant.secretKey);
        }

        /// <summary>
        /// DateTime转换为13位时间戳（单位：毫秒）
        /// </summary>
        /// <param name="dateTime"> DateTime</param>
        /// <returns>13位时间戳（单位：毫秒）</returns>
        public  long DateTimeToLongTimeStamp(DateTime dateTime)
        {
            DateTime timeStampStartTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (long)(dateTime.ToUniversalTime() - timeStampStartTime).TotalMilliseconds;
        }



    }
}

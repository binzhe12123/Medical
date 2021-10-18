using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Client.Model
{
    public class ReturnData<T>
    {
        public ReturnData()
        {
            //Msg = string.Empty;
            Ret = Convert.ToInt32(ReturnRetEnum.Success);
        }

        /// <summary>
        /// 返回错误信息
        /// </summary>
        /// <param name="errorInfo"></param>
        /// <param name="cec"></param>
        /// <returns></returns>
        public ReturnData<T> ErrorInfos(string errorInfo, ConstErrorCode cec)
        {
            ReturnData<T> rd = new ReturnData<T>();
            rd.Ret = 1;
            rd.Msg = errorInfo;
            rd.ErrorCode = cec;
            return rd;
        }

        /// <summary>
        ///所有调用查询接口时
        /// 返回:数据为空时的提示信息
        /// </summary>
        /// <param name="emptyMsg"></param>
        /// <returns></returns>
        public ReturnData<T> EmptyInfos()
        {
            ReturnData<T> rd = new ReturnData<T>();
            rd.Ret = 0;
            rd.Msg = "暂未查询到相关记录！";
            rd.ErrorCode = ConstErrorCode.DataIsEmpty;

            return rd;
        }

        /// <summary>
        /// 返回状态码 0：成功  1 失败
        /// </summary>
        public int Ret { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Msg { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public T Data { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]

        [DefaultValue(null)]
        public ConstErrorCode? ErrorCode { get; set; }
    }

    /// <summary>
    /// 错误异常代码
    /// </summary>
    public enum ConstErrorCode
    {
        DataIsEmpty = 10001,
        ParmarIsEmpty = 10002,
        SystemException = 10003,
        ExecFail = 10004,
        ParmarIsError = 10005,
        DataFormatIsError=10006,
        JsonSerializeError = 10007,
        JsonDeserializeError = 10008
    }

    /// <summary>
    /// 返回状态 0 成功 1 失败
    /// </summary>
    public enum ReturnRetEnum
    {
        Success = 0,
        Error = 1
    }
}
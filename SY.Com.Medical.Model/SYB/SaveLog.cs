using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SY.Com.Medical.Model.SYBCommon;

namespace SY.Com.Medical.Model.SYB
{
    /// <summary>
    /// 
    /// </summary>
    public class SaveLog
    {
        /// <summary>
        /// 
        /// </summary>
        public long zhid { get; set; }//  是
        /// <summary>
        /// 
        /// </summary>
        public string  infno { get; set; }//   字符串 是   交易编号
        /// <summary>
        /// 
        /// </summary>
        public string msgid { get; set; }//   字符串 是   发送方报文ID
        /// <summary>
        /// 
        /// </summary>
        public string infcode { get; set; }// 数值型 是   交易状态码
        /// <summary>
        /// 
        /// </summary>
        public string inf_refmsgid { get; set; }//    字符串 是   接收方报文ID
        /// <summary>
        /// 
        /// </summary>
        public DateTime refmsg_time { get; set; }// 字符型 否   接收报文时间
        /// <summary>
        /// 
        /// </summary>
        public DateTime respond_time { get; set; }//    字符型 否   响应报文时间
        /// <summary>
        /// 
        /// </summary>
        public string err_msg { get; set; }// 字符串 否   错误信息
        /// <summary>
        /// 
        /// </summary>
        public string MessgeIn { get; set; }//  字符串 是   完整输入报文
        /// <summary>
        /// 
        /// </summary>
        public string MessageOut { get; set; }//  字符串 是   完整输出报文

    }

    /// <summary>
    /// 
    /// </summary>
    //前端调用是的入参模型
    public class SaveLogModel
    {
        /// <summary>
        /// 
        /// </summary>
        public long zhid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public InCommon MessgeIn { get; set; }//入参报文
        /// <summary>
        /// 
        /// </summary>
        public OutCommon MessageOut { get; set; }//出参报文
    }

    /// <summary>
    /// 
    /// </summary>
    public class outlog
    {
        /// <summary>
        /// 
        /// </summary>
        public string SYBLogID { get; set; }
    }
}

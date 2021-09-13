using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Infrastructure
{
    /// <summary>
    /// 返回状态 0 成功 1 失败
    /// </summary>
    public enum ReturnRetEnum
    {

        Success = 0,
        Error = 1
    }



    public enum SysDicEnum
    {
        /// <summary>
        /// 药品分类
        /// </summary>
        DrugCategory
    }


    /// <summary>
    /// 打印报表类型
    /// </summary>
    public enum ReportType
    {
        /// <summary>
        /// 
        /// </summary>
        MZFP = 1,
        /// <summary>
        /// 
        /// </summary>
        SYFP = 2,
        /// <summary>
        /// 
        /// </summary>
        XYCF = 3,
        /// <summary>
        /// 
        /// </summary>
        ZYCF = 4,
        /// <summary>
        /// 
        /// </summary>
        XMCF = 5,
        /// <summary>
        /// 
        /// </summary>
        SYK = 6,
        /// <summary>
        /// 
        /// </summary>
        SYT = 7,
        /// <summary>
        /// 
        /// </summary>
        GHD = 8,
        /// <summary>
        /// 
        /// </summary>
        BLD = 9,
        /// <summary>
        /// 
        /// </summary>
        CZD = 10,
        /// <summary>
        /// 
        /// </summary>
        YPBQ = 11,
        /// <summary>
        /// 
        /// </summary>
        SZD = 12,
        /// <summary>
        /// 
        /// </summary>
        HKD = 13,
        /// <summary>
        /// 
        /// </summary>
        HKXXD = 14,
        /// <summary>
        /// 
        /// </summary>
        TFD = 15,
        /// <summary>
        /// 
        /// </summary>
        MZFPMX = 16,
        /// <summary>
        /// 
        /// </summary>
        SYFPMX = 17,
        ZYBL = 19,
        XYBL=18,
        QBBL = 20,
        GHTF = 21,
        JYD=22,//检验单
        CFZLD=23,//治疗单
        CFCZD=24,//处置单
        XMDJ=25//项目登记

    }
}

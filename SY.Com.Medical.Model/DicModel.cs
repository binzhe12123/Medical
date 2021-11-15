using SY.Com.Medical.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace SY.Com.Medical.Model
{
    /// <summary>
    /// 键值对
    /// </summary>
    public class DicKeyValueModel
    {
        /// <summary>
        /// 键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }
    }

    /// <summary>
    /// 查询入参
    /// </summary>
    public class DicSearchModel
    {
        /// <summary>
        /// 租户id
        /// </summary>
        public int tenantid { get; set; }
        /// <summary>
        /// 关键词一
        /// </summary>
        public string keyFirst { get; set; }
        /// <summary>
        /// 关键词二
        /// </summary>
        public string keySecond { get; set; }
        /// <summary>
        /// 搜索词
        /// </summary>
        public string searchKey { get; set; }
    }
	
} 
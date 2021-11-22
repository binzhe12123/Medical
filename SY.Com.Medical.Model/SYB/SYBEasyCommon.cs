using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class SYBEasyCommon<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public long? zhid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string opter { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string opter_name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fixmedins_code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fixmedins_name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sign_no { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public T input { get; set; }
    }
}

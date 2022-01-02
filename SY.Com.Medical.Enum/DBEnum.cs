using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Enum
{
    /// <summary>
    /// 
    /// </summary>
    public class DBEnum
    {
    }

    /// <summary>
    /// 门诊病历类型
    /// </summary>
    public enum CaseBookType
    {
        /// <summary>
        /// 全科
        /// </summary>
        门诊全科 = 1,
        /// <summary>
        /// 中医
        /// </summary>
        门诊中医 = 2,
        /// <summary>
        /// 西医
        /// </summary>
        门诊西医 = 3,
        /// <summary>
        /// 口腔
        /// </summary>
        门诊口腔=4,
        /// <summary>
        /// 儿科
        /// </summary>
        门诊儿科=5,
        /// <summary>
        /// 妇科
        /// </summary>
        门诊妇科 = 6
    }
}

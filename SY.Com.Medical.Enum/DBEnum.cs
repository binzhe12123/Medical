using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Enum
{
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
        门诊全科 = 0,
        /// <summary>
        /// 中医
        /// </summary>
        门诊中医 = 1,
        /// <summary>
        /// 西医
        /// </summary>
        门诊西医 = 2,
        /// <summary>
        /// 口腔
        /// </summary>
        门诊口腔=3,
        /// <summary>
        /// 儿科
        /// </summary>
        门诊儿科=4,
        /// <summary>
        /// 妇科
        /// </summary>
        门诊妇科 = 5
    }
}

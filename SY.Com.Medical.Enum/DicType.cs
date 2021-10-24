using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Enum
{
    /// <summary>
    /// 字典类型
    /// </summary>
    public enum DicType
    {
        /// <summary>
        /// 无
        /// </summary>
        无=0,
        /// <summary>
        /// 物品.药品.西药中成药
        /// </summary>
        物品_药品_西药中成药,
        /// <summary>
        /// 物品.药品.中药
        /// </summary>
        物品_药品_中药,
        /// <summary>
        /// 物品.项目
        /// </summary>
        物品_项目,
        /// <summary>
        /// 材料
        /// </summary>
        物品_材料
    }
}

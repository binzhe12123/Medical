using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Attribute
{
    /// <summary>
    /// 处理实体的导航属性
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class DB_Navigate : DBBaseAttribute
    {
        /// <summary>
        /// 导航表名
        /// </summary>
        public string _navigateTable { get; private set; }
        public List<string> _linkProperty { get; private set; }
        /// <summary>
        /// 初始化导航表信息
        /// </summary>
        /// <param name="navigateTable">导航表名称(用来关联查询)</param>
        /// <param name="navigateKey">用来匹配的键</param>
        public DB_Navigate(string navigateTable,params string[] navigateKey)
        {
            _navigateTable = navigateTable;
            _linkProperty = navigateKey.ToList();
        }        
    }
}

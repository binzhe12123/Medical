using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SY.Com.Infrastructure
{
    public static class DataTableHelper
    {
        /// <summary>
        /// 根据条件过滤DataTable数据后，返回DataTable
        /// </summary>
        /// <param name="t">元数据（需要过滤的DataTable）</param>
        /// <param name="filterWhere">过滤条件</param>
        /// <returns>返回过滤后的DataTable</returns>
        public static DataTable FilterToDataTable(this DataTable t, string filterWhere)
        {
            DataRow[] drs = t.Select(filterWhere);
            if (drs != null && drs.Length > 0)
            {
                return drs.CopyToDataTable();
            }
            return null;
        }
        /// <summary>  
        /// 数据行转DataTable  
        /// </summary>  
        /// <param name="drs">数据行</param>  
        /// <returns></returns>  
        public static DataTable RowsToTable(DataRow[] drs)
        {
            DataTable dt = null;
            if (drs != null && drs.Length > 0)
            {
                dt = drs[0].Table.Clone();
                for (int i = 0; i < drs.Length; i++)
                {
                    dt.ImportRow(drs[i]);
                }
            }
            return dt;
        }

        /// <summary>  
        /// 条件过滤  
        /// </summary>  
        /// <param name="dt">DataTable</param>  
        /// <param name="condition">条件</param>  
        /// <returns></returns>  
        public static DataTable TableSelect(DataTable dt, string condition)
        {
            DataTable Result = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow[] drs = dt.Select(condition);
                Result = RowsToTable(drs);
            }
            return Result;
        }
    }
}

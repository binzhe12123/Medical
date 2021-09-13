using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SY.Com.Infrastructure
{
    public class RegexHelper
    {
        /// <summary>
        /// json转datatable
        /// </summary>
        /// <param name="dt">定义一个空datatable</param>
        /// <param name="source">每一条json(相当于datatable的一行)</param>
        /// <returns></returns>
        public static DataTable AddJsonToDataTable(DataTable dt,string source)
        {
            string regStr = "\"(?<column>\\w*)\":\\s?\"?(?<colValue>[^\",]*)\"?";
            MatchCollection mc = Regex.Matches(source, regStr);
            if (dt.Columns == null || dt.Columns.Count == 0)
            {
                foreach (Match m in mc)
                {
                    DataColumn dc = new DataColumn(m.Groups["column"].Value);
                    dt.Columns.Add(dc);
                }
            }
            DataRow dr = dt.NewRow();
            foreach (Match m in mc)
            {
                dr[m.Groups["column"].Value] = m.Groups["colValue"].Value.TrimEnd(new char[] { '}' });
            }
            dt.Rows.Add(dr);
            return dt;
        }

        public static DataTable AddJsonToDataTableByHZXXB(DataTable dt, string source)
        {
            string regStr = "\"(?<column>\\w*)\":\\s?\"?(?<colValue>[^\",]*)\"?";
            MatchCollection mc = Regex.Matches(source, regStr);
            if (dt.Columns == null || dt.Columns.Count == 0)
            {
                foreach (Match m in mc)
                {
                    DataColumn dc = new DataColumn(m.Groups["column"].Value);
                    dt.Columns.Add(dc);
                }
                DataColumn dcAge = new DataColumn("Age");
                dt.Columns.Add(dcAge);
            }
            DataRow dr = dt.NewRow();
            foreach (Match m in mc)
            {
                dr[m.Groups["column"].Value] = m.Groups["colValue"].Value.TrimEnd(new char[] { '}' });
            }
            dt.Rows.Add(dr);
            return dt;
        }
    }
}

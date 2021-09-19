using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SY.Com.Infrastructure
{
    /// <summary>
    /// 生成SqlParameter参数的委托
    /// </summary>
    /// <returns></returns>
    public delegate SqlParameter[] CreateSqlParameterHandle();
    public class SqlParameterHelper
    {
        private static ConcurrentDictionary<string, ConcurrentQueue<SqlParameter[]>> _dicSqlParameter;
        private static Dictionary<string, CreateSqlParameterHandle> _CreateSqlParameterHandleList;
        private static ConcurrentQueue<SqlParameter[]>[] _sqlParameter;

        static SqlParameterHelper()
        {
            _CreateSqlParameterHandleList = new Dictionary<string, CreateSqlParameterHandle>();
            _dicSqlParameter = new ConcurrentDictionary<string, ConcurrentQueue<SqlParameter[]>>();
            //初始化队列字典
            string sqlparaPath = System.AppDomain.CurrentDomain.BaseDirectory + "Config/SqlParameter.xml";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(sqlparaPath);
            XmlNodeList xnl = xmlDoc.SelectNodes("Items/Item");
            if (xnl != null && xnl.Count > 0)
            {
                _sqlParameter = new ConcurrentQueue<SqlParameter[]>[xnl.Count];
                int i = 0;
                foreach (XmlNode xn in xnl)
                {
                    _sqlParameter[i] = new ConcurrentQueue<SqlParameter[]>();
                    _dicSqlParameter.TryAdd(xn.Attributes["description"].Value, _sqlParameter[i]);
                    i++;
                }
            }
        }
        public static void RegisterCreateSqlParameter(string key, CreateSqlParameterHandle sqlParameter)
        {
            try
            {
                if (null == sqlParameter)
                {
                    throw new ArgumentNullException("GetSqlParameterHandle");
                }
                CreateSqlParameterHandle tempSqlParameter;
                if (!_CreateSqlParameterHandleList.TryGetValue(key, out tempSqlParameter))
                {
                    _CreateSqlParameterHandleList.Add(key, sqlParameter);
                }
            }
            catch (Exception ex)
            {
                
            }

        }

        public static void PutSqlParamterToQuene(string key, SqlParameter[] parameters)
        {
            ConcurrentQueue<SqlParameter[]> cq = _dicSqlParameter[key];
            if (cq != null)
            {
                cq.Enqueue(parameters);
            }
        }

        /// <summary>
        /// 获取SqlParameter
        /// </summary>
        /// <param name="key"></param>
        /// <param name="sqlParameter"></param>
        /// <param name="parameters"></param>
        public static SqlParameter[] GetSqlParameter(string key)
        {
            SqlParameter[] parameters = null;
            ConcurrentQueue<SqlParameter[]> cq = _dicSqlParameter[key];
            if (cq != null)
            {
                CreateSqlParameterHandle createHandle;
                cq.TryDequeue(out parameters);
                if (parameters == null && _CreateSqlParameterHandleList.TryGetValue(key, out createHandle))
                {
                    parameters = createHandle();
                }
            }
            return parameters;
        }
    }
}

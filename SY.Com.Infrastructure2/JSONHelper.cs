/************************************************** 
* 版权所有: Mr_Sheng 
* 文 件 名: JSONHelper.cs 
* 文件描述: 
* 类型说明: JSONHelper JSON帮助类 
* 授权声明: 
* 本程序为自由软件； 
* 您可依据自由软件基金会所发表的GPL v3授权条款，对本程序再次发布和/或修改； 
* 本程序是基于使用目的而加以发布，然而不负任何担保责任； 
* 亦无对适售性或特定目的适用性所为的默示性担保。 
* 详情请参照GNU通用公共授权 v3（参见license.txt文件）。 
* 版本历史: 
* v2.0.0 Mr_Sheng 2009-09-09 修改 
***************************************************/
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Script.Serialization;
using System.Data;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Collections;
using System.Text.RegularExpressions;
using System.Reflection;

namespace SY.Com.Infrastructure
{
    /// <summary> 
    /// JSON帮助类 
    /// </summary> 
    public static class JSONHelper
    {
        /// <summary> 
        /// 对象转JSON 
        /// </summary> 
        /// <param name="obj">对象</param> 
        /// <returns>JSON格式的字符串</returns> 
        public static string ObjectToJSON(object obj)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            try
            {
                return jss.Serialize(obj);
            }
            catch (Exception ex)
            {
                throw new Exception("JSONHelper.ObjectToJSON(): " + ex.Message);
            }
        }

        public static string ObjectToJson<T>(T obj)
        {
            string result;
            try
            {
                DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(obj.GetType());
                MemoryStream memoryStream = new MemoryStream();
                dataContractJsonSerializer.WriteObject(memoryStream, obj);
                string @string = Encoding.UTF8.GetString(memoryStream.ToArray());
                memoryStream.Dispose();
                result = @string;
            }
            catch (Exception ex)
            {
                result = null;
            }
            return result;
        }

        /// <summary> 
        /// 数据表转键值对集合 
        /// 把DataTable转成 List集合, 存每一行 
        /// 集合中放的是键值对字典,存每一列 
        /// </summary> 
        /// <param name="dt">数据表</param> 
        /// <returns>哈希表数组</returns> 
        public static List<Dictionary<string, object>> DataTableToList(DataTable dt)
        {
            List<Dictionary<string, object>> list
            = new List<Dictionary<string, object>>();
            foreach (DataRow dr in dt.Rows)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns)
                {
                    dic.Add(dc.ColumnName, dr[dc.ColumnName].ToString());
                }
                list.Add(dic);
            }
            return list;
        }

        /// <summary>
        /// 数据表转List集合
        /// 把DataTable转成 List集合, 只区特定的一列
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <param name="columnsName">想要获取DataTable值的一列</param>
        /// <returns></returns>
        public static List<string> DataTableToListOneColumn(DataTable dt,string columnsName)
        {
            List<string> list = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    if (dc.ColumnName == columnsName)
                    {
                        list.Add(dr[dc.ColumnName].ToString());
                    }
                }
                
            }
            return list;
        }


        /// <summary> 
        /// 数据集转键值对数组字典 
        /// </summary> 
        /// <param name="dataSet">数据集</param> 
        /// <returns>键值对数组字典</returns> 
        public static Dictionary<string, List<Dictionary<string, object>>> DataSetToDic(DataSet ds)
        {
            Dictionary<string, List<Dictionary<string, object>>> result = new Dictionary<string, List<Dictionary<string, object>>>();
            foreach (DataTable dt in ds.Tables)
                result.Add(dt.TableName, DataTableToList(dt));
            return result;
        }
        /// <summary> 
        /// 数据表转JSON 
        /// </summary> 
        /// <param name="dataTable">数据表</param> 
        /// <returns>JSON字符串</returns> 
        public static string DataTableToJSON(DataTable dt)
        {
            return ObjectToJSON(DataTableToList(dt));
        }

        #region Json 字符串 转换为 DataTable数据集合
        /// <summary>
        /// 将json转换为DataTable
        /// </summary>
        /// <param name="strJson">得到的json</param>
        /// <returns></returns>
        public static DataTable JsonToDataTable(string strJson)
        {
            //转换json格式
            strJson = strJson.Replace(",\"", "*\"").Replace("\":", "\"#").ToString();
            //取出表名   
            var rg = new Regex(@"(?<={)[^:]+(?=:\[)", RegexOptions.IgnoreCase);
            string strName = rg.Match(strJson).Value;
            DataTable tb = null;
            ////去除表名   
            //strJson = strJson.Substring(strJson.IndexOf("[") + 1);
            //strJson = strJson.Substring(0, strJson.IndexOf("]"));

            //获取数据   
            rg = new Regex(@"(?<={)[^}]+(?=})");
            MatchCollection mc = rg.Matches(strJson);
            for (int i = 0; i < mc.Count; i++)
            {
                string strRow = mc[i].Value;
                string[] strRows = strRow.Split('*');

                //创建表   
                if (tb == null)
                {
                    tb = new DataTable();
                    tb.TableName = strName;
                    foreach (string str in strRows)
                    {
                        var dc = new DataColumn();
                        string[] strCell = str.Split('#');

                        if (strCell[0].Substring(0, 1) == "\"")
                        {
                            int a = strCell[0].Length;
                            dc.ColumnName = strCell[0].Substring(1, a - 2);
                        }
                        else
                        {
                            dc.ColumnName = strCell[0];
                        }
                        tb.Columns.Add(dc);
                    }
                    tb.AcceptChanges();
                }

                //增加内容   
                DataRow dr = tb.NewRow();
                for (int r = 0; r < strRows.Length; r++)
                {
                    dr[r] = strRows[r].Split('#')[1].Trim().Replace("，", ",").Replace("：", ":").Replace("\"", "");
                }
                tb.Rows.Add(dr);
                tb.AcceptChanges();
            }
            tb.TableName = "tableName";
            return tb;
        }
        #endregion

        #region json转DataSet(只包含一个datatable)
        /// <summary>
        /// json转DataSet
        /// </summary>
        /// <param name="Json"></param>
        /// <returns></returns>
        public static DataSet JsonToDataSet(string strJson)
        {
            try
            {
                DataSet ds = new DataSet();
                //转换json格式
                strJson = strJson.Replace(",\"", "*\"").Replace("\":", "\"#").ToString();
                //取出表名   
                var rg = new Regex(@"(?<={)[^:]+(?=:\[)", RegexOptions.IgnoreCase);
                string strName = rg.Match(strJson).Value;
                DataTable tb = null;
                ////去除表名   
                //strJson = strJson.Substring(strJson.IndexOf("[") + 1);
                //strJson = strJson.Substring(0, strJson.IndexOf("]"));

                //获取数据   
                rg = new Regex(@"(?<={)[^}]+(?=})");
                MatchCollection mc = rg.Matches(strJson);
                for (int i = 0; i < mc.Count; i++)
                {
                    string strRow = mc[i].Value;
                    string[] strRows = strRow.Split('*');

                    //创建表   
                    if (tb == null)
                    {
                        tb = new DataTable();
                        tb.TableName = strName;
                        foreach (string str in strRows)
                        {
                            var dc = new DataColumn();
                            string[] strCell = str.Split('#');

                            if (strCell[0].Substring(0, 1) == "\"")
                            {
                                int a = strCell[0].Length;
                                dc.ColumnName = strCell[0].Substring(1, a - 2);
                            }
                            else
                            {
                                dc.ColumnName = strCell[0];
                            }
                            tb.Columns.Add(dc);
                        }
                        tb.AcceptChanges();
                    }

                    //增加内容   
                    DataRow dr = tb.NewRow();
                    for (int r = 0; r < strRows.Length; r++)
                    {
                        dr[r] = strRows[r].Split('#')[1].Trim().Replace("，", ",").Replace("：", ":").Replace("\"", "");
                    }
                    tb.Rows.Add(dr);
                    tb.AcceptChanges();
                }
                tb.TableName = "0";
                ds.Tables.Add(tb);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        /// <summary> 
        /// JSON文本转对象,泛型方法 
        /// </summary> 
        /// <typeparam name="T">类型</typeparam> 
        /// <param name="jsonText">JSON文本</param> 
        /// <returns>指定类型的对象</returns> 
        public static T JSONToObject<T>(string jsonText)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            try
            {
                return jss.Deserialize<T>(jsonText);
            }
            catch (Exception ex)
            {
                throw new Exception("JSONHelper.JSONToObject(): " + ex.Message);
            }
        }

        /// <summary>
        /// 将JSON字符串转换成List<T>集合
        /// </summary>
        /// <typeparam name="T">Object</typeparam>
        /// <param name="jsonText">JSON</param>
        /// <returns></returns>
        public static List<T> JSONToList<T>(string jsonText)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();

            try
            {
                return jss.Deserialize<List<T>>(jsonText);
            }
            catch (Exception e)
            {
                throw new Exception("JSONHelper.JSONToList():" + e.Message);
            }

        }

        /// <summary> 
        /// 将JSON文本转换为数据表数据 
        /// </summary> 
        /// <param name="jsonText">JSON文本</param> 
        /// <returns>数据表字典</returns> 
        public static Dictionary<string, List<Dictionary<string, object>>> TablesDataFromJSON(string jsonText)
        {
            return JSONToObject<Dictionary<string, List<Dictionary<string, object>>>>(jsonText);
        }
        /// <summary> 
        /// 将JSON文本转换成数据行 
        /// </summary> 
        /// <param name="jsonText">JSON文本</param> 
        /// <returns>数据行的字典</returns> 
        public static Dictionary<string, object> DataRowFromJSON(string jsonText)
        {
            return JSONToObject<Dictionary<string, object>>(jsonText);
        }

        /// <summary>    
        /// 将泛型集合类转换成DataTable
        /// </summary>    
        /// <typeparam name="T">集合项类型</typeparam>
        /// <param name="list">集合</param>    
        /// <returns>数据集(表)</returns>    
        public static DataTable ToDataTable<T>(IList<T> list)
        {
            return ToDataTable<T>(list, null);

        }

        /// <summary>    
        /// 将泛型集合类转换成DataTable    
        /// </summary>    
        /// <typeparam name="T">集合项类型</typeparam>    
        /// <param name="list">集合</param>    
        /// <param name="propertyName">需要返回的列的列名</param>    
        /// <returns>数据集(表)</returns>    
        public static DataTable ToDataTable<T>(IList<T> list, params string[] propertyName)
        {
            List<string> propertyNameList = new List<string>();
            if (propertyName != null)
                propertyNameList.AddRange(propertyName);
            DataTable result = new DataTable();
            if (list.Count > 0)
            {
                PropertyInfo[] propertys = list[0].GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    if (propertyNameList.Count == 0)
                    {
                        result.Columns.Add(pi.Name, pi.PropertyType);
                    }
                    else
                    {
                        if (propertyNameList.Contains(pi.Name))
                            result.Columns.Add(pi.Name, pi.PropertyType);
                    }
                }

                for (int i = 0; i < list.Count; i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in propertys)
                    {
                        if (propertyNameList.Count == 0)
                        {
                            object obj = pi.GetValue(list[i], null);
                            tempList.Add(obj);
                        }
                        else
                        {
                            if (propertyNameList.Contains(pi.Name))
                            {
                                object obj = pi.GetValue(list[i], null);
                                tempList.Add(obj);
                            }
                        }
                    }
                    object[] array = tempList.ToArray();
                    result.LoadDataRow(array, true);
                }
            }
            return result;
        }

        /// <summary>    
        /// 将集合类转换成DataTable    
        /// </summary>    
        /// <param name="list">集合</param>    
        /// <returns></returns>    
        public static DataTable ListToDataTable(IList list)
        {
            DataTable dt = new DataTable();
            if (list.Count > 0)
            {
                PropertyInfo[] propertys = list[0].GetType().GetProperties();

                foreach (PropertyInfo pi in propertys)
                {
                    dt.Columns.Add(pi.Name, pi.PropertyType);
                }
                for (int i = 0; i < list.Count; i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in propertys)
                    {
                        object obj = pi.GetValue(list[i], null);
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    dt.LoadDataRow(array, true);
                }
            }
            return dt;
        }

        /// <summary>  
        /// 转化一个DataTable  
        /// </summary>  
        /// <typeparam name="T"></typeparam>  
        /// <param name="list"></param>  
        /// <returns></returns>  
        public static DataTable ListToDataTable<T>(this IEnumerable<T> list)
        {
            //创建属性的集合  
            List<PropertyInfo> pList = new List<PropertyInfo>();
            //获得反射的入口  
            Type type = typeof(T);
            DataTable dt = new DataTable();
            //把所有的public属性加入到集合 并添加DataTable的列  
            Array.ForEach<PropertyInfo>(type.GetProperties(), p => { pList.Add(p); dt.Columns.Add(p.Name, p.PropertyType); });
            foreach (var item in list)
            {
                //创建一个DataRow实例  
                DataRow row = dt.NewRow();
                //给row 赋值  
                pList.ForEach(p => row[p.Name] = p.GetValue(item, null));
                //加入到DataTable  
                dt.Rows.Add(row);
            }
            return dt;
        }

        /// <summary> 
        /// 转化一个DataTable 
        /// </summary> 
        /// <typeparam name="T"></typeparam> 
        /// <param name="list"></param> 
        /// <returns></returns> 
        public static DataTable ListToDataTable<T>(this IEnumerable<T> list, params string[] tableName)
        {
            //创建属性的集合 
            List<PropertyInfo> pList = new List<PropertyInfo>();
            //获得反射的入口 
            Type type = typeof(T);
            string tname = "Table1";
            if (tableName.Length >= 1)
            {
                tname = tableName[0];
            }
            DataTable dt = new DataTable(tname);
            //把所有的public属性加入到集合 并添加DataTable的列 
            Array.ForEach<PropertyInfo>(type.GetProperties(), p =>
            {
                pList.Add(p);
                var theType = p.PropertyType;
                //处理可空类型
                if (theType.IsGenericType && theType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                {
                    dt.Columns.Add(p.Name, Nullable.GetUnderlyingType(theType));
                }
                else
                {
                    dt.Columns.Add(p.Name, theType);
                }
            });
            foreach (var item in list)
            {
                //创建一个DataRow实例 
                DataRow row = dt.NewRow();
                //给row 赋值 
                pList.ForEach(p =>
                {
                    var v = p.GetValue(item, null);
                    row[p.Name] = v == null ? DBNull.Value : v;

                });
                //加入到DataTable 
                dt.Rows.Add(row);
            }
            return dt;
        }

        /// <summary>
        /// 将泛类型集合List类转换成DataTable
        /// </summary>
        /// <param name="list">泛类型集合</param>
        /// <returns></returns>
        public static DataTable ListToDataTable<T>(List<T> entitys)
        {
            //检查实体集合不能为空
            if (entitys == null || entitys.Count < 1)
            {
                throw new Exception("需转换的集合为空");
            }
            //取出第一个实体的所有Propertie
            Type entityType = entitys[0].GetType();
            PropertyInfo[] entityProperties = entityType.GetProperties();

            //生成DataTable的structure
            //生产代码中，应将生成的DataTable结构Cache起来，此处略
            DataTable dt = new DataTable();
            for (int i = 0; i < entityProperties.Length; i++)
            {
                //dt.Columns.Add(entityProperties[i].Name, entityProperties[i].PropertyType);
                dt.Columns.Add(entityProperties[i].Name);
            }
            //将所有entity添加到DataTable中
            foreach (object entity in entitys)
            {
                //检查所有的的实体都为同一类型
                if (entity.GetType() != entityType)
                {
                    throw new Exception("要转换的集合元素类型不一致");
                }
                object[] entityValues = new object[entityProperties.Length];
                for (int i = 0; i < entityProperties.Length; i++)
                {
                    entityValues[i] = entityProperties[i].GetValue(entity, null);
                }
                dt.Rows.Add(entityValues);
            }
            return dt;
        }




    }

    public class Json_Result
    {
        public Json_Result()
        {

        }
        public Json_Result(int rcode, string rmsg)
        {
            this.Rcode = rcode;
            this.Rmsg = rmsg;
        }
        public int Rcode { get; set; }
        public string Rmsg { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SY.Com.Infrastructure
{
    public static class ListHelper
    {
        /// <summary>
        /// 把传进来类进行反射,输入属性数组
        /// </summary>
        /// <returns></returns>
        private static PropertyInfo[] GetPropertyInfoArray(Type type)
        {
            PropertyInfo[] props = null;
            try
            {
                object obj = Activator.CreateInstance(type);
                props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            }
            catch (Exception ex)
            { }
            return props;
        }

        /// <summary>
        /// 把DataTable转换成List,List里面的属性只能是基础数据类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> DataTableToList<T>(DataTable dt ) where T:new()
        {
            try
            {
                PropertyInfo[] props = GetPropertyInfoArray(typeof(T));
                List<T> result = new List<T>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    T obj = new T();
                    DataRow dr = dt.Rows[i];
                    foreach (var item in props)
                    {
                        #region 给属性赋值
                        if (!dr.Table.Columns.Contains(item.Name))
                        {
                            //如果不存在此列,就跳过
                            continue;
                        }
                        if (item.PropertyType == typeof(Int32))
                        {
                            item.SetValue(obj, int.Parse( dr[item.Name] == DBNull.Value ? "0" : dr[item.Name].ToString()));
                        }
                        else if (item.PropertyType == typeof(long))
                        {
                            item.SetValue(obj, long.Parse(dr[item.Name] == DBNull.Value ? "0" : dr[item.Name].ToString()));
                        }
                        else if (item.PropertyType == typeof(decimal))
                        {
                            item.SetValue(obj, decimal.Parse(dr[item.Name] == DBNull.Value ? "0" : dr[item.Name].ToString()));
                        }
                        else if (item.PropertyType == typeof(string))
                        {
                            item.SetValue(obj, dr[item.Name] == DBNull.Value ? "" : dr[item.Name].ToString());
                        }
                        else if (item.PropertyType == typeof(DateTime))
                        {
                            item.SetValue(obj, DateTime.Parse(dr[item.Name] == DBNull.Value ? "1900-01-01" : dr[item.Name].ToString()));
                        }
                        else if (item.PropertyType == typeof(float))
                        {
                            item.SetValue(obj, float.Parse(dr[item.Name] == DBNull.Value ? "0" : dr[item.Name].ToString()));
                        }
                        else if (item.PropertyType == typeof(double))
                        {
                            item.SetValue(obj, double.Parse(dr[item.Name] == DBNull.Value ? "0" : dr[item.Name].ToString()));
                        }
                        else if (item.PropertyType == typeof(bool))
                        {
                            item.SetValue(obj, bool.Parse(dr[item.Name] == DBNull.Value ? "false" : dr[item.Name].ToString()));
                        }
                        else if (item.PropertyType == typeof(uint))
                        {
                            item.SetValue(obj, uint.Parse(dr[item.Name] == DBNull.Value ? "0" : dr[item.Name].ToString()));
                        }
                        else if (item.PropertyType == typeof(ulong))
                        {
                            item.SetValue(obj, ulong.Parse(dr[item.Name] == DBNull.Value ? "0" : dr[item.Name].ToString()));
                        }
                        else if (item.PropertyType == typeof(ushort))
                        {
                            item.SetValue(obj, ushort.Parse(dr[item.Name] == DBNull.Value ? "0" : dr[item.Name].ToString()));
                        }
                        else if (item.PropertyType == typeof(short))
                        {
                            item.SetValue(obj, short.Parse(dr[item.Name] == DBNull.Value ? "0" : dr[item.Name].ToString()));
                        }
                        else if (item.PropertyType == typeof(Nullable<Int32>))
                        {
                            if (dr[item.Name] != DBNull.Value)
                            {
                                item.SetValue(obj, int.Parse(dr[item.Name].ToString()));
                            }

                        }
                        else if (item.PropertyType == typeof(Nullable<long>))
                        {
                            if (dr[item.Name] != DBNull.Value)
                            {
                                item.SetValue(obj, long.Parse(dr[item.Name].ToString()));
                            }

                        }
                        else if (item.PropertyType == typeof(Nullable<decimal>))
                        {
                            if (dr[item.Name] != DBNull.Value)
                            {
                                item.SetValue(obj, decimal.Parse(dr[item.Name].ToString()));
                            }

                        }
                        else if (item.PropertyType == typeof(Nullable<bool>))
                        {
                            if (dr[item.Name] != DBNull.Value)
                            {
                                item.SetValue(obj, bool.Parse(dr[item.Name].ToString()));
                            }

                        }
                        else if (item.PropertyType == typeof(Nullable<DateTime>))
                        {
                            if (dr[item.Name] != DBNull.Value)
                            {
                                item.SetValue(obj, DateTime.Parse(dr[item.Name].ToString()));
                            }

                        }
                        #endregion
                    }
                    result.Add(obj);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// 单条的DataTable记录转成一个实体,字段名称相同
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static T DataTableToSingleFiled<T>(DataTable dt) where T : new()
        {
            List<T> list = DataTableToList<T>(dt);
            return list.First();            
        }

        /// <summary>
        /// 公共的根据类型不为空或者默认值去拼接查询条件Sql语句
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string DBQueryWhereSqlByTableModel(Object obj,string TableNick = "")
        {
            string sqlWhere = "";
            Type t = obj.GetType();
            PropertyInfo[] propers = t.GetProperties();

            #region 获取条件语句
            foreach (PropertyInfo item in propers)
            {
                if (item.PropertyType == typeof(Int32))
                {
                    Int32 value = (Int32)item.GetValue(obj);
                    if (value != 0)
                    {
                        if (!string.IsNullOrEmpty(TableNick))
                        {
                            sqlWhere += " And " + TableNick + "." + item.Name + "=" + value;
                        }
                        else {
                            sqlWhere += " And " + item.Name + "=" + value;
                        }                        
                    }
                }
                else if (item.PropertyType == typeof(long))
                {
                    long value = (long)item.GetValue(obj);
                    if (value != 0)
                    {
                        if (!string.IsNullOrEmpty(TableNick))
                        {
                            sqlWhere += " And " + TableNick + "." + item.Name + "=" + value;
                        }
                        else
                        {
                            sqlWhere += " And " + item.Name + "=" + value;
                        }
                    }
                }
                else if (item.PropertyType == typeof(decimal))
                {
                    decimal value = (decimal)item.GetValue(obj);
                    if (value != 0)
                    {
                        if (!string.IsNullOrEmpty(TableNick))
                        {
                            sqlWhere += " And " + TableNick + "." + item.Name + "=" + value;
                        }
                        else
                        {
                            sqlWhere += " And " + item.Name + "=" + value;
                        }
                    }
                }
                else if (item.PropertyType == typeof(string))
                {
                    string value = (string)item.GetValue(obj);
                    if (!string.IsNullOrEmpty(value))
                    {
                        if (!string.IsNullOrEmpty(TableNick))
                        {
                            sqlWhere += " And " + TableNick + "." + item.Name + " like '%" + value + "%'";
                        }
                        else
                        {
                            sqlWhere += " And " + item.Name + " like '%" + value + "%'";
                        }
                    }
                }
                else if (item.PropertyType == typeof(float))
                {
                    float value = (float)item.GetValue(obj);
                    if (value != 0.00)
                    {
                        if (!string.IsNullOrEmpty(TableNick))
                        {
                            sqlWhere += " And " + TableNick + "." + item.Name + "=" + value;
                        }
                        else
                        {
                            sqlWhere += " And " + item.Name + "=" + value;
                        }
                    }
                }
                else if (item.PropertyType == typeof(double))
                {
                    double value = (double)item.GetValue(obj);
                    if (value != 0.00)
                    {
                        if (!string.IsNullOrEmpty(TableNick))
                        {
                            sqlWhere += " And " + TableNick + "." + item.Name + "=" + value;
                        }
                        else
                        {
                            sqlWhere += " And " + item.Name + "=" + value;
                        }
                    }
                }
                else if (item.PropertyType == typeof(bool))
                {
                    bool value = (bool)item.GetValue(obj);
                    if (!value)
                    {
                        if (!string.IsNullOrEmpty(TableNick))
                        {
                            sqlWhere += " And " + TableNick + "." + item.Name + "=" + value;
                        }
                        else
                        {
                            sqlWhere += " And " + item.Name + "=" + value;
                        }
                    }
                }
                else if (item.PropertyType == typeof(Nullable<Int32>))
                {
                    Nullable<Int32> value = (Nullable<Int32>)item.GetValue(obj);
                    if (value != null && value != 0)
                    {
                        if (!string.IsNullOrEmpty(TableNick))
                        {
                            sqlWhere += " And " + TableNick + "." + item.Name + "=" + value;
                        }
                        else
                        {
                            sqlWhere += " And " + item.Name + "=" + value;
                        }
                    }
                }
                else if (item.PropertyType == typeof(Nullable<long>))
                {
                    Nullable<long> value = (Nullable<long>)item.GetValue(obj);
                    if (value != null && value != 0)
                    {
                        if (!string.IsNullOrEmpty(TableNick))
                        {
                            sqlWhere += " And " + TableNick + "." + item.Name + "=" + value;
                        }
                        else
                        {
                            sqlWhere += " And " + item.Name + "=" + value;
                        }
                    }
                }
                else if (item.PropertyType == typeof(Nullable<decimal>))
                {
                    Nullable<decimal> value = (Nullable<decimal>)item.GetValue(obj);
                    if (value != null && value != 0)
                    {
                        if (!string.IsNullOrEmpty(TableNick))
                        {
                            sqlWhere += " And " + TableNick + "." + item.Name + "=" + value;
                        }
                        else
                        {
                            sqlWhere += " And " + item.Name + "=" + value;
                        }
                    }
                }
                else if (item.PropertyType == typeof(Nullable<bool>))
                {
                    Nullable<bool> value = (Nullable<bool>)item.GetValue(obj);
                    if (value != null && value == false)
                    {
                        if (!string.IsNullOrEmpty(TableNick))
                        {
                            sqlWhere += " And " + TableNick + "." + item.Name + "=" + value;
                        }
                        else
                        {
                            sqlWhere += " And " + item.Name + "=" + value;
                        }
                    }
                }
                else if (item.PropertyType == typeof(Nullable<DateTime>))
                {
                    Nullable<DateTime> value = (Nullable<DateTime>)item.GetValue(obj);
                    if (value != null)
                    {
                        if (!string.IsNullOrEmpty(TableNick))
                        {
                            if (item.Name.IndexOf('1') > 0)
                            {
                                sqlWhere += " And " + TableNick + "." + item.Name.Substring(0, item.Name.Length - 1) + ">='" + value + "'";
                            } else if (item.Name.IndexOf('2') > 0)
                            {
                                sqlWhere += " And " + TableNick + "." + item.Name.Substring(0, item.Name.Length - 1) + "<='" + value + "'";
                            }
                        }
                        else
                        {
                            sqlWhere += " And " + item.Name + "=" + value;
                        }
                    }
                }
            }
            #endregion

            return sqlWhere;
        }

        /// <summary>
        /// 从一个类赋值到另一个类,以目标类的属性为准
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="O"></typeparam>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static O FromOneObjectToOtherObject<T, O>(T source, O target)
        {
            try {
                Type t = target.GetType();
                PropertyInfo[] propers = t.GetProperties();
                #region 转换过程
                foreach (PropertyInfo item in propers)
                {
                    if (source.GetType().GetProperty(item.Name) == null)
                    {
                        item.SetValue(target, item.GetValue(target));
                        continue;
                    }
                    if (item.PropertyType == typeof(Int32))
                    {
                        int value;
                        if (int.TryParse(source.GetType().GetProperty(item.Name).GetValue(source).ToString(), out value))
                        {
                            item.SetValue(target, source.GetType().GetProperty(item.Name).GetValue(source));
                        }
                        else
                        {
                            item.SetValue(target, 0);
                        }
                    }else if(item.PropertyType == typeof(long))
                    {
                        long value;
                        if (long.TryParse(source.GetType().GetProperty(item.Name).GetValue(source).ToString(), out value))
                        {
                            item.SetValue(target, source.GetType().GetProperty(item.Name).GetValue(source));
                        }
                        else
                        {
                            item.SetValue(target, 0);
                        }
                    }
                    else if (item.PropertyType == typeof(decimal))
                    {
                        decimal value;
                        if (decimal.TryParse(source.GetType().GetProperty(item.Name).GetValue(source).ToString(), out value))
                        {
                            item.SetValue(target, source.GetType().GetProperty(item.Name).GetValue(source));
                        }
                        else
                        {
                            item.SetValue(target, 0);
                        }
                    }
                    else if (item.PropertyType == typeof(string))
                    {
                        if (source.GetType().GetProperty(item.Name).PropertyType != typeof(string))
                        {
                            item.SetValue(target, "");
                        }
                        else {
                            item.SetValue(target, source.GetType().GetProperty(item.Name).GetValue(source));
                        }
                        
                    }
                    else if (item.PropertyType == typeof(float))
                    {
                        float value;
                        if (float.TryParse(source.GetType().GetProperty(item.Name).GetValue(source).ToString(), out value))
                        {
                            item.SetValue(target, source.GetType().GetProperty(item.Name).GetValue(source));
                        }
                        else
                        {
                            item.SetValue(target, 0);
                        }
                    }
                    else if (item.PropertyType == typeof(double))
                    {
                        double value;
                        if (double.TryParse(source.GetType().GetProperty(item.Name).GetValue(source).ToString(), out value))
                        {
                            item.SetValue(target, source.GetType().GetProperty(item.Name).GetValue(source));
                        }
                        else
                        {
                            item.SetValue(target, 0);
                        }
                    }
                    else if (item.PropertyType == typeof(bool))
                    {
                        bool value;
                        if (bool.TryParse(source.GetType().GetProperty(item.Name).GetValue(source).ToString(), out value))
                        {
                            item.SetValue(target, source.GetType().GetProperty(item.Name).GetValue(source));
                        }
                        else
                        {
                            item.SetValue(target, 0);
                        }
                    }
                    else if (item.PropertyType == typeof(DateTime))
                    {
                        DateTime value;
                        if (DateTime.TryParse(source.GetType().GetProperty(item.Name).GetValue(source).ToString(), out value))
                        {
                            item.SetValue(target, source.GetType().GetProperty(item.Name).GetValue(source));
                        }
                        else
                        {
                            item.SetValue(target, 0);
                        }
                    }
                }
                #endregion
                return target;
            } catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}

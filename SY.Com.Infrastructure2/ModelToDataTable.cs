
using System.Reflection;
using System.Data;
using System.Collections.Generic;
using System;

namespace SY.Com.Infrastructure
{
    public static class ModelToDataTable
    {
        /// <summary>
        /// 适用于多条记录转换
        /// 实体类转换成DataTable
        /// 调用示例：DataTable dt= FillDataTable(Entitylist.ToList());
        /// </summary>
        /// <param name="modelList">实体类列表</param>
        /// <returns></returns>
        public static DataTable MultiFillDataTable<T>(List<T> modelList)
        {
            if (modelList == null || modelList.Count == 0)
            {
                return null;
            }
            DataTable dt = CreateData(modelList[0]);//创建表结构

            foreach (T model in modelList)
            {
                DataRow dataRow = dt.NewRow();
                foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
                {
                    dataRow[propertyInfo.Name] = propertyInfo.GetValue(model, null);
                }
                dt.Rows.Add(dataRow);
            }
            return dt;
        }

        /// <summary>
        /// 适用于一条记录转换
        /// 实体类转换成DataTable
        /// 调用示例：DataTable dt= FillDataTable(Entitylist[0]);
        /// </summary>
        /// <param name="SingleModel">实体类列表</param>
        /// <returns></returns>
        public static DataTable SingleFillDataTable<T>(T SingleModel)
        {
            if (SingleModel == null)
            {
                return null;
            }
            DataTable dt = CreateData(SingleModel);//创建表结构

            DataRow dataRow = dt.NewRow();
            foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
            {
                dataRow[propertyInfo.Name] = propertyInfo.GetValue(SingleModel, null);
            }
            dt.Rows.Add(dataRow);

            return dt;
        }




        /// <summary>
        /// 根据实体类得到表结构
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns></returns>
        private static DataTable CreateData<T>(T model)
        {
            
            DataTable dataTable = new DataTable(typeof(T).Name);
            foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
            {
                if (propertyInfo.Name != "CTimestamp")//些字段为oracle中的Timesstarmp类型
                {
                    dataTable.Columns.Add(new DataColumn(propertyInfo.Name));
                }
                else
                {
                    dataTable.Columns.Add(new DataColumn(propertyInfo.Name, typeof(DateTime)));
                }
            }
            return dataTable;
        }


    }
}

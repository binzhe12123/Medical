using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SY.Com.Clinic.Repository
{
    /// 哈希表中单项值的扩展类
    public class HashtableExClass
    {
        /// <summary>
        /// 关键字
        /// </summary>
        public object Key;

        /// <summary>
        /// 关键字对应的值
        /// </summary>
        public object Value;
    }

    /// 哈希表的扩展类
    public class HashtableEx
    {
        private ArrayList keyArray = new ArrayList();//哈希表的扩展类存储KEY
        private ArrayList ValueArray = new ArrayList();//哈希表的扩展类存储Value

        /// <summary>
        /// 获取哈希表中的记录总数
        /// </summary>
        public int Count
        {

            get { return keyArray.Count; }
        }

        /// <summary>
        /// 向扩展类的哈希表中添加数据
        /// </summary>
        /// <param name="key">对应哈希表中的Key</param>
        /// <param name="Value">对应哈希表中的每一个KEY对应的值</param>
        public void Add(object key, object Value)
        {
            keyArray.Add(key);
            ValueArray.Add(Value);
        }

        /// <summary>
        /// 增加清除HT的事务项
        /// @author lianghaifeng 2015-10-08
        /// </summary>
        public void Clear()
        {
            keyArray.Clear();
            ValueArray.Clear();
        }

        /// <summary>
        /// 获取扩展类的哈希表中的对应索引Index的行
        /// </summary>
        /// <param name="Index">索引Index在扩展类的哈希表所处的行(从0开始计数)</param>
        /// <returns>返回扩展类的哈希表中的对应索引Index的行,其类型为HashtableExClass</returns>
        public HashtableExClass Item(int Index)
        {
            HashtableExClass retValue = new HashtableExClass();
            retValue.Key = keyArray[Index];
            retValue.Value = ValueArray[Index];
            return retValue;
        }

    }
}

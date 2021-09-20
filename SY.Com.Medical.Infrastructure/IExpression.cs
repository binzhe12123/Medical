using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Medical.Infrastructure
{
    /// <summary>
    /// 自定义一个表达式集合接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IExpression<T> : ICollection<KeyValuePair<string,T>>
    {
        object Parsing(T t);


    }
}

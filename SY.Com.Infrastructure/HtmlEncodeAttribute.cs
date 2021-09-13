using System;

namespace SY.Com.Infrastructure
{
    ///<summary>
    /// 指示实体对象中的字符串类型的属性需要进行HTML编码和解码
    ///</summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public sealed class HtmlCodingAttribute : Attribute
    {
    }
}
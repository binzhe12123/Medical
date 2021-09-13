using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;


namespace SY.Com.Infrastructure
{
    /// <summary>
    /// Xml操作类
    /// </summary>
    public class XmlUtil
    {
        /// <summary>
        /// 序列化对象为xml(或字节流)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string XmlSerialize(object obj)
        {
            string result = null;

            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    XmlTextWriter xmlTextWriter = new XmlTextWriter(stream, new UTF8Encoding(false));
                    xmlTextWriter.Formatting = Formatting.Indented;
                    xmlSerializer.Serialize(xmlTextWriter, obj);
                    xmlTextWriter.Flush();
                    xmlTextWriter.Close();
                    UTF8Encoding uTF8Encoding = new UTF8Encoding(false, true);
                    result = uTF8Encoding.GetString(stream.ToArray());
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Couldn't serialize object:" + obj.GetType().Name, ex);
            }
            return result;
        }

        /// <summary>
        /// 反序列xml为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <param name="xmlPath"></param>
        /// <returns></returns>
        public static T XmlDeserialize<T>(Type type, string xmlPath)
        {
            T obj = default(T);

            XmlSerializer xmlSerializer = new XmlSerializer(type);
            try
            {
                using (StreamReader sr = new StreamReader(xmlPath))
                {
                    obj = (T)xmlSerializer.Deserialize(sr);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Couldn't parse xml:{0};Type:{1}", xmlPath, type.FullName), ex);
            }
            return obj;
        }
    }
}


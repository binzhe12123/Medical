using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Checksums;
using System.Data;

namespace SY.Com.Infrastructure
{
    /// <summary>
    /// ZIP文件压缩处理类
    /// </summary>
    public class ZipStream
    {
        private ZipOutputStream _ZipOutputStream;
        private Stream _zipStream;
        public ZipStream()
        {
            MemoryStream zipStream = new MemoryStream();
            _zipStream = zipStream;
            _ZipOutputStream = new ZipOutputStream(zipStream);
            _ZipOutputStream.SetLevel(6);//设置压缩级别
        }

        #region 压缩字符串 ZipStrings
        public bool ZipStrings(StringBuilder sb, string FileName)
        {
            if (sb.Length < 1) return false;
            byte[] buffer = System.Text.Encoding.Default.GetBytes(sb.ToString());

            ZipEntry entry = new ZipEntry(FileName);
            entry.DateTime = DateTime.Now;
            entry.Size = buffer.Length;

            Crc32 crc = new Crc32();
            crc.Reset();
            crc.Update(buffer);
            entry.Crc = crc.Value;
            _ZipOutputStream.PutNextEntry(entry);
            _ZipOutputStream.Write(buffer, 0, buffer.Length);
            return true;
        }

        public bool ZipStrings(string sb, string FileName)
        {
            if (sb.Length < 1) return false;
            byte[] buffer = System.Text.Encoding.Default.GetBytes(sb);

            ZipEntry entry = new ZipEntry(FileName);
            entry.DateTime = DateTime.Now;
            entry.Size = buffer.Length;

            Crc32 crc = new Crc32();
            crc.Reset();
            crc.Update(buffer);
            entry.Crc = crc.Value;
            _ZipOutputStream.PutNextEntry(entry);
            _ZipOutputStream.Write(buffer, 0, buffer.Length);
            return true;
        }
        #endregion

        #region 压缩DataTable ZipDataTable
        /// <summary>
        /// 返回指定数据表的XML形式
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <returns></returns>
        private StringBuilder DataTableToXML(System.Data.DataTable dt)
        {
            StringBuilder strXML = new StringBuilder();
            strXML.Append("<?xml version=\"1.0\" standalone=\"yes\"?>  <DATAPACKET Version=\"2.0\"><METADATA><FIELDS>");
            strXML.Append("<FIELD attrname=\"XHID\" fieldtype=\"i4\" />");
            int i, icol;
            icol = dt.Columns.Count;
            for (i = 0; i < icol; i++)
            {

                DataColumn col = dt.Columns[i];

                //判断类型
                Type ty = col.DataType;

                //Boolean    TimeSpan  
                int colMaxLength = col.MaxLength;
                string strTypeName = "string";
                string tyName = ty.Name;
                if ((tyName == "String") || (tyName == "Char"))
                {
                    strTypeName = "string";
                    if (colMaxLength < 0)
                        colMaxLength = 8000;
                    strXML.Append("<FIELD attrname=\"" + col.ColumnName + "\" fieldtype=\"" + strTypeName + "\" WIDTH=\"" + colMaxLength + "\"/>");
                }
                else if ((tyName == "Int16") || (tyName == "Int32") || (tyName == "Int64") || (tyName == "SByte") ||
                          (tyName == "UInt16") || (tyName == "UInt32") || (tyName == "UInt64") || (tyName == "Byte"))
                {
                    strTypeName = "i4";
                    strXML.Append("<FIELD attrname=\"" + col.ColumnName + "\" fieldtype=\"" + strTypeName + "\" />");
                }
                else if ((tyName == "Decimal") || (tyName == "Double") || (tyName == "Single"))
                {
                    strTypeName = "r8";
                    strXML.Append("<FIELD attrname=\"" + col.ColumnName + "\" fieldtype=\"" + strTypeName + "\" />");
                }
                else if (tyName == "DateTime")
                {
                    strTypeName = "dateTime";
                    strXML.Append("<FIELD attrname=\"" + col.ColumnName + "\" fieldtype=\"" + strTypeName + "\" />");
                }
                else if (tyName == "")
                {
                    strTypeName = "boolean";
                    strXML.Append("<FIELD attrname=\"" + col.ColumnName + "\" fieldtype=\"" + strTypeName + "\" />");
                }
                else
                {
                    strTypeName = "string";
                    if (colMaxLength < 0)
                        colMaxLength = 8000;
                    strXML.Append("<FIELD attrname=\"" + col.ColumnName + "\" fieldtype=\"" + strTypeName + "\" WIDTH=\"" + colMaxLength + "\"/>");
                };

                //设置表中的列的信息            
                //<FIELD attrname="NL" fieldtype="i4"/>
                //<FIELD attrname="GZ" fieldtype="r8" SUBTYPE="Money"/>
                //<FIELD attrname="CSRQ" fieldtype="dateTime"/>
                //<FIELD attrname="SJ" fieldtype="time"/>
                //<FIELD attrname="RQ" fieldtype="date"/>
                //<FIELD attrname="BL" fieldtype="boolean"/>
            };
            strXML.Append("</FIELDS><PARAMS/></METADATA><ROWDATA>");

            //写数据
            int k, irow = dt.Rows.Count;
            for (k = 0; k < irow; k++)
            {
                DataRow dr = dt.Rows[k];
                strXML.Append("<ROW  ");
                strXML.Append(" XHID=\"" + k.ToString() + "\" ");
                for (i = 0; i < icol; i++)
                {

                    DataColumn col = dt.Columns[i];
                    //注意日期转换
                    if (col.DataType.Name == "DateTime")
                    {
                        if (dr[i] == DBNull.Value)
                            strXML.Append(col.ColumnName + "=\"\" ");
                        else
                        {
                            DateTime dtDate = (DateTime)dr[i];
                            strXML.Append(col.ColumnName + "=\"" + dtDate.ToString("yyyyMMddTHH:mm:ss") + "\" ");
                        };
                    }
                    else
                    {
                        //过虑非法的XML字符如 <小于号 >大于号 &和 '单引号 "双引号 
                        string strV = dr[i].ToString();
                        if (strV.IndexOf("&") >= 0) strV = strV.Replace("&", "&amp;");//和
                        if (strV.IndexOf("<") >= 0) strV = strV.Replace("<", "&lt;");//小于号
                        if (strV.IndexOf(">") >= 0) strV = strV.Replace(">", "&gt;");//大于号
                        if (strV.IndexOf("'") >= 0) strV = strV.Replace("'", "&apos;");//单引号
                        if (strV.IndexOf("\"") >= 0) strV = strV.Replace("\"", "&quot;");//双引号
                        strXML.Append(col.ColumnName + "=\"" + strV + "\" ");
                    };
                };
                strXML.Append("/>");
            }
            strXML.Append("</ROWDATA></DATAPACKET>");
            return strXML;
        }

        public bool ZipDataTable(System.Data.DataTable dt, string FileName)
        {
            if (dt == null) return false;
            StringBuilder sb = DataTableToXML(dt);
            return ZipStrings(sb, FileName);
        }
        #endregion

        #region 压缩文件 ZipFile()
        /// <summary>
        /// 压缩文件 ZipFile
        /// </summary>
        /// <param name="sourceFile">原始文件</param>
        /// <param name="FileName">压缩后的文件名称,可重命名</param>
        /// <returns></returns>
        public bool ZipFile(string sourceFile, string FileName)
        {
            //如果文件没有找到，则报错 
            if (!System.IO.File.Exists(sourceFile))
            {
                return false;//要压缩的文件不存在。
                throw new System.IO.FileNotFoundException("The specified file " + sourceFile + " could not be found. Zipping aborderd");
            };
            //读取文件 
            FileStream fs = File.OpenRead(sourceFile);

            byte[] buffer = new byte[fs.Length];
            fs.Read(buffer, 0, buffer.Length);
            ZipEntry entry = new ZipEntry(FileName);
            entry.DateTime = DateTime.Now;
            entry.Size = fs.Length;
            fs.Close();
            Crc32 crc = new Crc32();
            crc.Reset();
            crc.Update(buffer);
            entry.Crc = crc.Value;
            _ZipOutputStream.PutNextEntry(entry);
            _ZipOutputStream.Write(buffer, 0, buffer.Length);
            return true;
        }
        #endregion

        #region 完成压缩文件 Finish
        public void Finish()
        {
            _ZipOutputStream.Finish();
        }
        #endregion

        /// <summary>
        /// 将当前的压缩流转为二进制流的数组
        /// </summary>
        /// <returns></returns>
        public byte[] ToByteArray()
        {
            int iCount = (int)_zipStream.Length;
            _zipStream.Position = 0;
            byte[] buffer = new byte[iCount];
            _zipStream.Read(buffer, 0, iCount);
            return buffer;
        }

        #region 保存为压缩文件 SaveZipFile
        /// <summary>
        /// 保存为压缩文件 SaveZipFile
        /// </summary>
        /// <param name="zipfile">要保存的压缩文件名称，含路径</param>
        /// <param name="OverWrite">是否覆盖</param>
        /// <returns></returns>
        public bool SaveZipFile(string zipfile, bool OverWrite)
        {
            if (OverWrite == true)
            {
                File.Delete(zipfile);
            }
            else
            {
                if (File.Exists(zipfile) == true)//文件已经存在
                    return false;
            };
            //创建Zip文件 
            int iCount = (int)_zipStream.Length;
            _zipStream.Position = 0;
            byte[] buffer = new byte[iCount];
            _zipStream.Read(buffer, 0, iCount);
            FileStream fs = File.Create(zipfile);
            fs.Write(buffer, 0, iCount);
            fs.Close();
            return true;
        }
        #endregion
    }
}

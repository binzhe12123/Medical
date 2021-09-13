using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SY.Com.Infrastructure
{
    /// <summary>
    /// 数据导入、导出帮助类
    /// @author lianghaifeng
    /// </summary>
    public static class NpoiHelper
    {
        public static HttpResponseMessage ExportExcel(string excelname,DataTable dt, List<ExcelColumn> ecs)
        {
            Stream ms = NpoiHelper.ExportExcel(dt, ecs);
            return DataExportHelper.ExportDataOfExcel2007(excelname, ms);
        }



        public static MemoryStream ExportExcelForAll(string excelname, DataTable dt, List<ExcelColumn> ecs)
        {
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("sheet1");
            IRow headRow = sheet.CreateRow(0);

            int columnindex = 0;
            foreach (ExcelColumn ec in ecs)
            {
                ICell cell = headRow.CreateCell(columnindex);
                cell.SetCellValue(ec.ColumnName);
                sheet.SetColumnWidth(columnindex, ec.ColumnWidth * 256);
                cell.CellStyle = NpoiCellType.CenterBlodStyle(workbook);
                columnindex++;
            }
            IRow headRowone = sheet.CreateRow(1);
            columnindex = 0;
            foreach (ExcelColumn ec in ecs)
            {
                ICell cell = headRowone.CreateCell(columnindex);
                cell.SetCellValue(ec.ColumnName);
                sheet.SetColumnWidth(columnindex, ec.ColumnWidth * 256);
                cell.CellStyle = NpoiCellType.CenterBlodStyle(workbook);
                columnindex++;
            }
            int rowindex = 2;

            //添加一行空数据生成表格
          //  dt.Columns.Add("ID");
          //  dt.Columns.Add("Name");
          //  DataRow dw = dt.NewRow();
          //  object[] objs = { 1, 1 };
          //  dw.ItemArray = objs;
          ////  dt.Rows.Add(dw);

          //  dt.Rows.InsertAt(dw, 0);
          //  dt.Rows.Add(dw);




            foreach (DataRow dr in dt.Rows)
            {
                columnindex = 0;
                IRow row = sheet.CreateRow(rowindex);
                foreach (ExcelColumn ec in ecs)
                {
                    ICell cell = row.CreateCell(columnindex);
                    string strVal = dr[ec.ExcelColumnNameToDtColumnName].ToString();
                    if (ec.IsValueType)
                    {
                        decimal value = 0M;
                        decimal.TryParse(strVal, out value);
                        cell.SetCellValue((double)value);
                    }
                    else
                    {
                        cell.SetCellValue(strVal);
                    }
                    cell.CellStyle = NpoiCellType.CenterStyle(workbook);
                    columnindex++;
                }
                rowindex++;
            }

            NpoiMemoryStream ms = new NpoiMemoryStream();
            ms.AllowClose = false;
            workbook.Write(ms);
            ms.Flush();
            ms.Seek(0, SeekOrigin.Begin);
            ms.AllowClose = true;
            return ms;

        }


        public static MemoryStream ExportExcel(DataTable dt, List<ExcelColumn> ecs)
        {
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("sheet1");
            IRow headRow = sheet.CreateRow(0);
            int columnindex = 0;
            foreach (ExcelColumn ec in ecs)
            {
                ICell cell = headRow.CreateCell(columnindex);
                cell.SetCellValue(ec.ColumnName);
                sheet.SetColumnWidth(columnindex, ec.ColumnWidth * 256);
                cell.CellStyle = NpoiCellType.CenterBlodStyle(workbook);
                columnindex++;
            }
            int rowindex = 1;
            foreach (DataRow dr in dt.Rows)
            {
                columnindex = 0;
                IRow row = sheet.CreateRow(rowindex);
                foreach (ExcelColumn ec in ecs)
                {
                    ICell cell = row.CreateCell(columnindex);
                    string strVal = dr[ec.ExcelColumnNameToDtColumnName].ToString();
                    if (ec.IsValueType)
                    {
                        decimal value = 0M;
                        decimal.TryParse(strVal, out value);
                        cell.SetCellValue((double)value);
                    }
                    else
                    {
                        cell.SetCellValue(strVal);
                    }
                    cell.CellStyle = NpoiCellType.CenterStyle(workbook);
                    columnindex++;
                }
                rowindex++;
            }
            
            NpoiMemoryStream ms = new NpoiMemoryStream();
            ms.AllowClose = false;
            workbook.Write(ms);
            ms.Flush();
            ms.Seek(0, SeekOrigin.Begin);
            ms.AllowClose = true;
            return ms;

        }

        public static Stream ExportExcels(string excelname, DataTable dt, List<ExcelColumn> ecs)
        {
            Stream ms = NpoiHelper.ExportExcel(dt, ecs);
            return ms;
        }
    }

    public class ExcelColumn
    {
        public string ColumnName { get; set; }
        public int ColumnWidth { get; set; }
        /// <summary>
        /// 是数值类型还是字符串
        /// </summary>
        public bool IsValueType { get; set; }
        public String ExcelColumnNameToDtColumnName { get; set; }

    }

    public class NpoiMemoryStream : MemoryStream
    {
        public NpoiMemoryStream(bool colse = false)
        {
            AllowClose = colse;
        }

        public bool AllowClose { get; set; }

        public override void Close()
        {
            if (AllowClose)
                base.Close();
        }
    }

    public static class NpoiCellType
    {

        public static ICellStyle CenterStyle(IWorkbook workbook)
        {
            ICellStyle centerstyle = workbook.CreateCellStyle();
            centerstyle.Alignment = HorizontalAlignment.Center;
            
            return centerstyle;
        }
        public static ICellStyle CenterBlodStyle(IWorkbook workbook)
        {
            ICellStyle centerstyle = workbook.CreateCellStyle();
            centerstyle.CloneStyleFrom(CenterStyle(workbook));
            IFont font = workbook.CreateFont();
            font.Boldweight = (short)FontBoldWeight.Bold;
            font.FontHeightInPoints = 12;
            centerstyle.SetFont(font);
            return centerstyle;
        }
    }
}

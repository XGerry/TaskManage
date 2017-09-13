using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using TaskManage.Utils.Data;

namespace TaskManage.Utils.Excel
{
    public static class NPOIHelper
    {
        public static ICellStyle GetStyle(HSSFWorkbook hssfworkbook)
        {
            ICellStyle cellstyle = hssfworkbook.CreateCellStyle();
            cellstyle.Alignment = HorizontalAlignment.Center;
            cellstyle.VerticalAlignment = VerticalAlignment.Center;
            cellstyle.FillForegroundColor = HSSFColor.Blue.Index;
            cellstyle.FillPattern = FillPattern.SolidForeground;
            IFont font = hssfworkbook.CreateFont();
            font.FontHeightInPoints = 20;
            font.Boldweight = short.MaxValue;
            font.FontName = "Times New Roman";
            font.Color = HSSFColor.White.Index;
            font.Underline = FontUnderlineType.Single;
            cellstyle.SetFont(font);
            cellstyle.BorderLeft = BorderStyle.Thin;
            cellstyle.BorderRight = BorderStyle.Thin;
            cellstyle.BorderBottom = BorderStyle.Thin;
            cellstyle.BorderTop = BorderStyle.Thin;
            return cellstyle;
        }

        public static HSSFWorkbook ExportStream(HSSFWorkbook workbook, HSSFSheet sheet, DataTable dt, string[] magin)
        {
            ICellStyle cellstyle = workbook.CreateCellStyle();//设置垂直居中格式
            cellstyle.Alignment = HorizontalAlignment.Center;
            cellstyle.VerticalAlignment = VerticalAlignment.Top;//垂直居中
            cellstyle.BorderBottom = BorderStyle.Thin;
            cellstyle.BorderLeft = BorderStyle.Thin;
            cellstyle.BorderRight = BorderStyle.Thin;
            cellstyle.BorderTop = BorderStyle.Thin;

            if (dt != null && dt.Rows.Count > 0)
            {
                //創建新增
                HSSFRow headerRow = (HSSFRow)sheet.CreateRow(0);
                //表頭
                ICell cell = null;
                foreach (DataColumn column in dt.Columns)
                {
                    cell = headerRow.CreateCell(column.Ordinal);
                    cell.CellStyle = cellstyle;
                    cell.SetCellValue(column.ColumnName);
                }
                //表身
                int r = 1;
                string rValue = string.Empty;
                double doutValue = 0;
                foreach (DataRow row in dt.Rows)
                {
                    HSSFRow bodyRow = (HSSFRow)sheet.CreateRow(r);

                    foreach (DataColumn column in dt.Columns)
                    {
                        rValue = row[column.ColumnName].ToString();
                        if (double.TryParse(rValue, out doutValue))
                        {
                            cell = bodyRow.CreateCell(column.Ordinal);
                            cell.CellStyle = cellstyle;
                            cell.SetCellValue(Convert.ToDouble(rValue));
                        }
                        else
                        {
                            cell = bodyRow.CreateCell(column.Ordinal);

                            cell.CellStyle = cellstyle;
                            cell.SetCellValue(Convert.ToString(rValue));
                        }
                    }
                    r++;
                }
                List<string> list = new List<string>(magin);
                for (int j = 1; j <= dt.Rows.Count; j++)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (j <= dt.Rows.Count - 1)
                        {
                            if (dt.Rows[j - 1][0].ToString() == dt.Rows[j][0].ToString() && dt.Rows[j - 1][i].ToString() == dt.Rows[j][i].ToString() && list.Contains(dt.Columns[i].ColumnName))
                            {
                                SetCellRangeAddress(sheet, j, j + 1, i, i, workbook);
                            }
                        }
                    }
                }
                SetSheetWidth(sheet);
            }
            return workbook;
        }

        public static void SetCellRangeAddress(ISheet sheet, int rowstart, int rowend, int colstart, int colend, HSSFWorkbook hssfworkbook)
        {
            for (int i = rowstart; i < rowend; i++)
            {
                var currCell = sheet.GetRow(rowend).GetCell(colstart);
                switch (currCell.CellType)
                {
                    case CellType.Numeric:
                        currCell.SetCellValue(0);
                        break;
                    default:
                        currCell.SetCellValue("");
                        break;
                }
            }
            ICellStyle cellstyle = hssfworkbook.CreateCellStyle();//设置垂直居中格式
            CellRangeAddress cellRangeAddress = new CellRangeAddress(rowstart, rowend, colstart, colend);
            sheet.AddMergedRegion(cellRangeAddress);
            IRow row = sheet.GetRow(rowstart);
            ICell cell = row.GetCell(colstart);
            cellstyle.Alignment = HorizontalAlignment.Center;
            cellstyle.VerticalAlignment = VerticalAlignment.Top;//垂直居中
            cellstyle.BorderBottom = BorderStyle.Thin;
            cellstyle.BorderLeft = BorderStyle.Thin;
            cellstyle.BorderRight = BorderStyle.Thin;
            cellstyle.BorderTop = BorderStyle.Thin;
            cell.CellStyle = cellstyle;
        }

        public static void SetSheetWidth(ISheet sheet)
        {
            for (int columnNum = 0; columnNum <= sheet.GetRow(0).LastCellNum + 12; columnNum++) //columnNum为列的数量
            {
                int columnWidth = sheet.GetColumnWidth(columnNum) / 256; //获取当前列宽度
                for (int rowNum = 0; rowNum <= sheet.LastRowNum; rowNum++) //在这一列上循环行
                {
                    IRow currentRow = sheet.GetRow(rowNum);
                    if (currentRow != null)
                    {
                        ICell currentCell = currentRow.GetCell(columnNum);
                        if (currentCell != null)
                        {
                            //currentCell.CellStyle = style;
                            int length = Encoding.Default.GetBytes(currentCell.ToString()).Length;
                            //单元格的宽度
                            if (columnWidth < length + 5)
                            {
                                columnWidth = length + 5;
                            }
                        }
                    }
                }
                if (columnWidth > 255)
                {
                    columnWidth = 255;//由于最大宽度是255，所以这里需要判断下，否则会报错
                }
                sheet.SetColumnWidth(columnNum, columnWidth * 256);//设置最终宽度
            }
        }

        public static void SetBorderStyle(CellRangeAddress rangeAddress, ICellStyle style, HSSFSheet sheet)
        {
            for (int i = rangeAddress.FirstRow; i <= rangeAddress.LastRow; i++)
            {
                IRow row1 = HSSFCellUtil.GetRow(i, sheet);
                for (int j = rangeAddress.FirstColumn; j <= rangeAddress.LastColumn; j++)
                {
                    ICell singleCell = HSSFCellUtil.GetCell(row1, (short)j);
                    singleCell.CellStyle = style;
                }
            }
        }

        public static string ExportExcel(HSSFWorkbook workbook, string exportname)
        {
            string strFilename = AppDomain.CurrentDomain.BaseDirectory;
            strFilename = strFilename + "File";

            if (Directory.Exists(strFilename) == false)
            {
                Directory.CreateDirectory(strFilename);
            }
            string[] filearr = Directory.GetFiles(strFilename, "*" + exportname + "*");
            foreach (string dir in filearr)
            {
                try
                {
                    File.Delete(dir);
                }
                catch (Exception ex) { }
            }

            strFilename = strFilename + "\\" + exportname + DateTime.Now.UnixTicks() + ".xls";

            using (FileStream stream = new FileStream(@strFilename, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                workbook.Write(stream);
                workbook = null;
                stream.Close();
                stream.Dispose();
            }

            return strFilename;
        }

    }
}

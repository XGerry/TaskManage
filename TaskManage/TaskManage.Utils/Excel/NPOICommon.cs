using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;

namespace TaskManage.Utils.Excel
{
    public class Excel
    {
        public static IFont GetFontStyle(HSSFWorkbook hssfworkbook)
        {
            IFont font = hssfworkbook.CreateFont();
            font.FontHeightInPoints = 10;
            font.FontName = "宋体";
            return font;
        }

        public static ICellStyle GetDateDescStyle(HSSFWorkbook hssfworkbook)
        {
            ICellStyle cellstyle = hssfworkbook.CreateCellStyle();
            cellstyle.VerticalAlignment = VerticalAlignment.Center;
            cellstyle.Alignment = HorizontalAlignment.Left;
            IFont font = hssfworkbook.CreateFont();
            font.FontHeightInPoints = 18;
            font.FontName = "Calibri";
            font.Boldweight = short.MaxValue;
            cellstyle.SetFont(font);
            cellstyle.WrapText = true;
            return cellstyle;
        }

        /// <summary>
        /// 针对内容列：获取单元格样式
        /// </summary>
        /// <param name="hssfworkbook">Excel操作类</param>
        /// <returns></returns>
        public static ICellStyle GetCellContentStyle(HSSFWorkbook hssfworkbook)
        {
            ICellStyle cellstyle = hssfworkbook.CreateCellStyle();
            cellstyle.VerticalAlignment = VerticalAlignment.Center;
            IFont font = hssfworkbook.CreateFont();
            font.FontHeightInPoints = 10;
            font.FontName = "宋体";
            cellstyle.SetFont(font);
            //有边框
            cellstyle.BorderBottom = BorderStyle.Thin;
            cellstyle.BorderLeft = BorderStyle.Thin;
            cellstyle.BorderRight = BorderStyle.Thin;
            cellstyle.BorderTop = BorderStyle.Thin;
            cellstyle.WrapText = true;
            return cellstyle;
        }

        public static ICellStyle GetCellNumContentStyle(HSSFWorkbook hssfworkbook)
        {
            ICellStyle cellstyle = hssfworkbook.CreateCellStyle();
            cellstyle.VerticalAlignment = VerticalAlignment.Center;
            IFont font = hssfworkbook.CreateFont();
            font.FontHeightInPoints = 10;
            font.Boldweight = short.MaxValue;
            font.FontName = "宋体";
            cellstyle.SetFont(font);
            //有边框
            cellstyle.BorderBottom = BorderStyle.Thin;
            cellstyle.BorderLeft = BorderStyle.Thin;
            cellstyle.BorderRight = BorderStyle.Thin;
            cellstyle.BorderTop = BorderStyle.Thin;
            cellstyle.WrapText = true;
            return cellstyle;
        }

        /// <summary>
        /// 针对Heaer:创建有边框，居中对齐的单元格样式
        /// </summary>
        /// <param name="hssfworkbook"></param>
        /// <returns></returns>
        public static ICellStyle GetICellHeaderStyle(HSSFWorkbook hssfworkbook)
        {
            ICellStyle cellstyle = hssfworkbook.CreateCellStyle();
            IFont font = hssfworkbook.CreateFont();
            font.FontHeightInPoints = 10;
            font.Boldweight = short.MaxValue;
            font.FontName = "宋体";
            cellstyle.SetFont(font);
            cellstyle.Alignment = HorizontalAlignment.Center;
            cellstyle.VerticalAlignment = VerticalAlignment.Center;
            cellstyle.BorderBottom = BorderStyle.Thin;
            cellstyle.BorderLeft = BorderStyle.Thin;
            cellstyle.BorderRight = BorderStyle.Thin;
            cellstyle.BorderTop = BorderStyle.Thin;
            return cellstyle;
        }

        /// <summary>
        /// 针对时间列格式化
        /// </summary>
        /// <param name="hssfworkbook"></param>
        /// <returns></returns>
        public static ICellStyle GetCellDateStyle(HSSFWorkbook hssfworkbook)
        {
            ICellStyle cellstyle = hssfworkbook.CreateCellStyle();
            cellstyle.VerticalAlignment = VerticalAlignment.Center;

            IFont font = hssfworkbook.CreateFont();
            font.FontHeightInPoints = 10;
            font.FontName = "宋体";
            cellstyle.SetFont(font);
            IDataFormat format = (HSSFDataFormat)hssfworkbook.CreateDataFormat();
            cellstyle.DataFormat = format.GetFormat("yyyy/m/d h:mm");
            //有边框
            cellstyle.BorderBottom = BorderStyle.Thin;
            cellstyle.BorderLeft = BorderStyle.Thin;
            cellstyle.BorderRight = BorderStyle.Thin;
            cellstyle.BorderTop = BorderStyle.Thin;
            cellstyle.WrapText = true;
            return cellstyle;
        }

        public static ICellStyle GetCellRXTStyle(HSSFWorkbook hssfworkbook)
        {
            ICellStyle cellstyle = hssfworkbook.CreateCellStyle();
            cellstyle.Alignment = HorizontalAlignment.Left;
            //cellstyle.FillForegroundColor = HSSFColor.LightCornflowerBlue.Index;
            //cellstyle.FillPattern = FillPattern.SolidForeground;
            IFont font = hssfworkbook.CreateFont();
            font.FontHeightInPoints = 10;
            font.Boldweight = short.MaxValue;
            font.FontName = "宋体";
            cellstyle.SetFont(font);
            //cellstyle.BorderBottom = BorderStyle.None;
            //cellstyle.BorderLeft = BorderStyle.None;
            //cellstyle.BorderRight = BorderStyle.None;
            //cellstyle.BorderTop = BorderStyle.None;
            cellstyle.BorderBottom = BorderStyle.Thin;
            cellstyle.BorderLeft = BorderStyle.Thin;
            cellstyle.BorderRight = BorderStyle.Thin;
            cellstyle.BorderTop = BorderStyle.Thin;
            return cellstyle;
        }

        public static ICellStyle GetCellYellowStyle(HSSFWorkbook hssfworkbook)
        {
            ICellStyle cellstyle = hssfworkbook.CreateCellStyle();
            cellstyle.Alignment = HorizontalAlignment.Left;
            cellstyle.FillForegroundColor = HSSFColor.Yellow.Index;
            cellstyle.FillPattern = FillPattern.SolidForeground;
            IFont font = hssfworkbook.CreateFont();
            font.FontHeightInPoints = 10;
            font.FontName = "宋体";
            cellstyle.SetFont(font);
            cellstyle.BorderBottom = BorderStyle.Thin;
            cellstyle.BorderLeft = BorderStyle.Thin;
            cellstyle.BorderRight = BorderStyle.Thin;
            cellstyle.BorderTop = BorderStyle.Thin;
            return cellstyle;
        }

        public static ICellStyle GetCellInvStyle(HSSFWorkbook hssfworkbook)
        {
            ICellStyle cellstyle = hssfworkbook.CreateCellStyle();
            cellstyle.Alignment = HorizontalAlignment.Right;
            cellstyle.FillForegroundColor = HSSFColor.White.Index;
            cellstyle.FillPattern = FillPattern.SolidForeground;
            IFont font = hssfworkbook.CreateFont();
            font.FontHeightInPoints = 10;
            font.FontName = "宋体";
            cellstyle.SetFont(font);
            cellstyle.BorderBottom = BorderStyle.None;
            cellstyle.BorderLeft = BorderStyle.None;
            cellstyle.BorderRight = BorderStyle.None;
            cellstyle.BorderTop = BorderStyle.None;
            return cellstyle;
        }


        /// <summary>
        /// 合并单元格
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="rowstart"></param>
        /// <param name="rowend"></param>
        /// <param name="colstart"></param>
        /// <param name="colend"></param>
        public static void SetCellRangeAddress(ISheet sheet, int rowstart, int rowend, int colstart, int colend)
        {
            CellRangeAddress cellRangeAddress = new CellRangeAddress(rowstart, rowend, colstart, colend);
            sheet.AddMergedRegion(cellRangeAddress);
        }

        /// <summary>
        /// 创建列名
        /// </summary>
        /// <param name="cellNo"></param>
        /// <param name="cellName"></param>
        /// <param name="cellStyle"></param>
        /// <param name="row"></param>
        /// <param name="sheet"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public static IRow CreateCell(IRow row, int cellNo, string cellName, ICellStyle cellStyle, ISheet sheet, int width)
        {
            ICell cell;
            cell = row.CreateCell(cellNo);
            cell.SetCellValue(cellName);
            cell.CellStyle = cellStyle;
            sheet.SetColumnWidth(cellNo, width * 256);
            return row;
        }

        public static HSSFWorkbook ExportStream(HSSFWorkbook workbook, HSSFSheet sheet, DataTable dt, string[] magin)
        {
            ICellStyle cellstyle = workbook.CreateCellStyle();//设置垂直居中格式
            ICellStyle cellstyle2 = workbook.CreateCellStyle();//设置垂直居中格式

            IDataFormat format = workbook.CreateDataFormat();
            cellstyle.Alignment = HorizontalAlignment.Center;
            cellstyle.VerticalAlignment = VerticalAlignment.Top;//垂直居中
            cellstyle.BorderBottom = BorderStyle.Thin;
            cellstyle.BorderLeft = BorderStyle.Thin;
            cellstyle.BorderRight = BorderStyle.Thin;
            cellstyle.BorderTop = BorderStyle.Thin;

            cellstyle2.Alignment = HorizontalAlignment.Center;
            cellstyle2.VerticalAlignment = VerticalAlignment.Top;
            cellstyle2.DataFormat = format.GetFormat("0");
            cellstyle2.BorderBottom = BorderStyle.Thin;
            cellstyle2.BorderLeft = BorderStyle.Thin;
            cellstyle2.BorderRight = BorderStyle.Thin;
            cellstyle2.BorderTop = BorderStyle.Thin;

            if (dt != null && dt.Rows.Count > 0)
            {
                //創建新增
                HSSFRow headerRow = (HSSFRow)sheet.CreateRow(0);
                //表頭
                int c = 0;
                ICell cell = null;
                foreach (DataColumn column in dt.Columns)
                {
                    cell = headerRow.CreateCell(column.Ordinal);
                    cell.CellStyle = cellstyle;
                    cell.SetCellValue(column.ColumnName);
                    c++;
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
                        if (double.TryParse(rValue, out doutValue) && column.ColumnName != "ERP#")
                        {
                            cell = bodyRow.CreateCell(column.Ordinal);
                            if (column.ColumnName == "HAWB#" || column.ColumnName == "Order No")
                            {
                                cell.CellStyle = cellstyle2;
                                cell.SetCellValue(doutValue);
                            }
                            else
                            {
                                cellstyle.DataFormat = format.GetFormat("@");
                                cell.CellStyle = cellstyle;
                                cell.SetCellValue(doutValue);
                            }
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

        //宽度自适应
        public static void SetSheetWidth(ISheet sheet)
        {
            for (int columnNum = 0; columnNum <= sheet.GetRow(0).LastCellNum + 12; columnNum++)
            {
                int columnWidth = sheet.GetColumnWidth(columnNum) / 256;
                for (int rowNum = 0; rowNum <= sheet.LastRowNum; rowNum++)
                {
                    IRow currentRow = sheet.GetRow(rowNum);
                    if (currentRow != null)
                    {
                        ICell currentCell = currentRow.GetCell(columnNum);
                        if (currentCell != null)
                        {
                            //currentCell.CellStyle = style;
                            int length = Encoding.Default.GetBytes(currentCell.ToString()).Length;

                            if (columnWidth < length + 5)
                            {
                                columnWidth = length + 5;
                            }

                        }
                    }
                }
                if (columnWidth > 255)
                {
                    columnWidth = 255;
                }
                sheet.SetColumnWidth(columnNum, columnWidth * 256);
            }
        }

        public static IRow CreateCellNoStyle(IRow row,int cellNo,object cellName)
        {
            ICell cell;
            cell = row.CreateCell(cellNo);
            switch (cellName.GetType().Name)
            {
                case "Int32":
                    cell.SetCellValue(Convert.ToInt32(cellName));
                    break;
                case "Decimal":
                    cell.SetCellValue(Convert.ToDouble(cellName));
                    break;
                default:
                    cell.SetCellValue(Convert.ToString(cellName));
                    break;
            }
            
            return row;
        }
        public static IRow CreateCell(IRow row, int cellNo, object cellName, ICellStyle cellStyle, int height)
        {
            ICell cell;
            cell = row.CreateCell(cellNo);
            if (cellName.GetType() == typeof(int))
            {
                cell.SetCellValue(Convert.ToInt32(cellName));
            }
            else if (cellName.GetType() == typeof(Decimal))
            {
                cell.SetCellValue(Convert.ToDouble(cellName));
            }
            else
            {
                cell.SetCellValue(Convert.ToString(cellName));
            }

            cell.CellStyle = cellStyle;
            row.HeightInPoints = height;
            return row;
        }

    }
}

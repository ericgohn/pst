//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: ExcelHelper.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Npoi.Mapper;
using NPOI.SS.UserModel;
using PST.Domain;

namespace PST.Plugins.WDSDispatcher.Controls
{
    public static class ExcelHelper
    {
        public static List<ISheet> ReadFileBasicInfo(string filePath)
        {
            List<ISheet> list = new List<ISheet>();
            IWorkbook workbook;
            try
            {
                workbook = WorkbookFactory.Create(filePath);
                workbook.MissingCellPolicy = MissingCellPolicy.CREATE_NULL_AS_BLANK;
            }
            catch (IOException e)
            {
                throw new Exception("Excel文件读取错误，请确保该文件没有被打开。", e);
            }
            if (workbook.NumberOfSheets < 1)
            {
                throw new Exception("指定的Excel文件中没有找到可用的工作薄。");
            }

            foreach (ISheet sheet in workbook)
            {
                list.Add(sheet);
            }
            return list;
        }

        public static string AnalyzeFile<T>(string filePath, int sheetIndex, string sheetName)
        {
            var msg = "文件： {0}\r\n工作簿： {1}\r\n记录总数： {2}";
            var fileName = Path.GetFileName(filePath);
            var mapper = new Mapper(filePath);


            var rows = mapper.Take<T>(sheetIndex);
            int count = 0;
            int errorCount = 0;
            StringBuilder sb = new StringBuilder();
            foreach (var row in rows)
            {
                count++;
                if (!string.IsNullOrEmpty(row.ErrorMessage))
                {
                    errorCount++;
                    sb.Append(string.Format("\r\n{0}，错误位置：第{1}行第{2}列", row.ErrorMessage, row.RowNumber,
                        row.ErrorColumnIndex));
                }
            }
            var m = string.Format(msg, fileName, sheetName, count);
            if (sb.Length > 0)
            {
                var errorMsg = string.Format("\r\n总计{0}个错误：", errorCount);
                errorMsg = errorMsg + sb;
                m += errorMsg;
            }
            return m;
        }
    }
}
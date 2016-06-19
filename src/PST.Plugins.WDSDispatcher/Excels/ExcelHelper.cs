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
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using Zeexone.Framework.Core.Excels;

namespace PST.Plugins.WDSDispatcher.Excels
{
    public static class ExcelHelper
    {
        private const string CONNECT_STRING_TEMPLATE =
            "Provider=Microsoft.{0}.OLEDB.{1};Data Source={2};Extended Properties=\"Excel {3};HDR={4}\"";

        private const string ANALYZE_MSG = "文件： {0}\r\n工作簿： {1}\r\n记录总数： {2}";

        /// <summary>
        ///     Get OLEDB connection string according to specified excel file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>OLEDB connection string.</returns>
        /// <exception cref="ExcelException">Excel file format is not supported.</exception>
        public static string GetConnectString(string filePath)
        {
            return GetConnectString(filePath, true);
        }

        /// <summary>
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="hdr">true： First row as column name.</param>
        /// <returns></returns>
        private static string GetConnectString(string filePath, bool hdr)
        {
            string extension = Path.GetExtension(filePath);
            if (string.IsNullOrWhiteSpace(extension))
                throw new ExcelException("Invalid excel file: file with no extension is not supported.");
            string hdrStr = hdr ? "YES" : "NO";
            if (extension.Equals(".xls", StringComparison.OrdinalIgnoreCase))
            {
                return string.Format(CONNECT_STRING_TEMPLATE, "Ace", "12.0", filePath, "8.0", hdrStr);
            }
            if (extension.Equals(".xlsx", StringComparison.OrdinalIgnoreCase) ||
                extension.Equals(".xlsb", StringComparison.OrdinalIgnoreCase))
            {
                return string.Format(CONNECT_STRING_TEMPLATE, "Ace", "12.0", filePath, "12.0 XML", hdrStr);
            }
            throw new ExcelException(string.Format("Invalid excel file: file with extension \"{0}\" is not supported.",
                extension));
        }

        public static List<string> ReadFileBasicInfo(string filePath)
        {
            List<string> list = new List<string>();
            var connectionString = GetConnectString(filePath);
            using (var conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                var table = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (table == null)
                    return list;
                list.AddRange(
                    table.Rows.Cast<DataRow>()
                        .Select(dr => dr["TABLE_NAME"].ToString())
                        .Where(sheetName => sheetName.Contains("$")));
                return list;
            }
        }

        public static string ReadColumnNames(string filePath, string sheetName)
        {
            var connectionString = GetConnectString(filePath);
            using (var conn = new OleDbConnection(connectionString))
            {
                var cmd = new OleDbCommand("select top 1 * from [" + sheetName + "]", conn);
                conn.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader == null)
                    return string.Empty;
                StringBuilder cols = new StringBuilder();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        cols.Append(string.Format("[{0}],", reader.GetName(i)));
                    }
                    break;
                }

                if (cols.Length == 0)
                    return string.Empty;
                return cols.ToString(0, cols.Length - 1);
            }
        }

        public static string AnalyzeFile(string filePath, string sheetName)
        {
            var fileName = Path.GetFileName(filePath);
            var connectionString = GetConnectString(filePath);
            using (var conn = new OleDbConnection(connectionString))
            {
                var cmd = new OleDbCommand("select * from [" + sheetName + "]", conn);
                conn.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader == null)
                    return string.Empty;
                int count = 0;
                while (reader.Read())
                {
                    count++;
                }
                reader.Close();
                var m = string.Format(ANALYZE_MSG, fileName, sheetName, count);
                return m;
            }
        }
    }
}
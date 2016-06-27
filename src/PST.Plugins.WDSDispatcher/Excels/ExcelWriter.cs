//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: ExcelWriter.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PST.Plugins.WDSDispatcher.Excels
{
    public class ExcelWriter
    {
        private readonly string _connectionString;
        private readonly string _filePath;

        public ExcelWriter(string filePath)
        {
            _filePath = filePath;
            _connectionString = ExcelHelper.GetConnectString(filePath);
        }

        public void CreateSheet(string createSql)
        {
            using (OleDbConnection conn = new OleDbConnection(_connectionString))
            using(OleDbCommand command = new OleDbCommand(createSql,conn))
            {
                conn.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Insert(string insertSql)
        {
            using (OleDbConnection conn = new OleDbConnection(_connectionString))
            using (OleDbCommand command = new OleDbCommand(insertSql, conn))
            {
                conn.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Insert(List<string> insertSqls)
        {
            using (OleDbConnection conn = new OleDbConnection(_connectionString))
            using (OleDbCommand command = new OleDbCommand())
            {
                conn.Open();
                command.Connection = conn;
                foreach (var sql in insertSqls)
                {
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
        }

        public Task InsertAsync(List<string> insertSqls)
        {
            return Task.Run(() =>
            {
                using (OleDbConnection conn = new OleDbConnection(_connectionString))
                using (OleDbCommand command = new OleDbCommand())
                {
                    conn.Open();
                    command.Connection = conn;
                    foreach (var sql in insertSqls)
                    {
                        command.CommandText = sql;
                        command.ExecuteNonQuery();
                    }
                }
            });
        }
    }

    public class ExcelReader
    {
        private readonly string _filePath;
        private readonly string _connectionString;

        public ExcelReader(string filePath)
        {
            _filePath = filePath;
            _connectionString = ExcelHelper.GetConnectString(filePath);
        }

        /// <summary>
        /// 获取工作簿名称
        /// </summary>
        /// <returns></returns>
        public List<string> GetSheets()
        {
            List<string> list = new List<string>();
            using (var conn = new OleDbConnection(_connectionString))
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
    }
}
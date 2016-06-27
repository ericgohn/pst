//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: ExcelWriter.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Threading.Tasks;

namespace PST.Plugins.WDSDispatcher.Excels
{
    public class ExcelWriter : IDisposable
    {
        private readonly string _filePath;
        private OleDbCommand _command;
        private OleDbConnection _connection;
        private bool _disposed;

        public ExcelWriter(string filePath)
        {
            _filePath = filePath;
            var connectionString = ExcelHelper.GetConnectString(filePath);
            _connection = new OleDbConnection(connectionString);
            _command = new OleDbCommand {Connection = _connection};
        }

        /// <summary>
        ///     执行与释放或重置非托管资源相关的应用程序定义的任务。
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void CreateSheet(string createSql)
        {
            using (OleDbCommand command = new OleDbCommand(createSql, _connection))
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Insert(string insertSql)
        {
            using (OleDbCommand command = new OleDbCommand(insertSql, _connection))
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Insert(List<string> insertSqls)
        {
            using (OleDbCommand command = new OleDbCommand())
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                command.Connection = _connection;
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
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                foreach (var sql in insertSqls)
                {
                    _command.CommandText = sql;
                    _command.ExecuteNonQuery();
                }
            });
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_command != null)
                    {
                        _command.Dispose();
                        _command = null;
                    }
                    if (_connection != null)
                    {
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                _disposed = true;
            }
        }
    }

    public class ExcelReader : IDisposable
    {
        private const string SELECT_SQL = "SELECT * FROM [{0}]";
        private readonly string _filePath;
        private OleDbConnection _connection;
        private bool _disposed;

        public ExcelReader(string filePath)
        {
            _filePath = filePath;
            var connectionString = ExcelHelper.GetConnectString(filePath);
            _connection = new OleDbConnection(connectionString);
        }

        /// <summary>
        ///     执行与释放或重置非托管资源相关的应用程序定义的任务。
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     获取工作簿名称
        /// </summary>
        /// <returns></returns>
        public List<string> GetSheets()
        {
            List<string> list = new List<string>();
            if (_connection.State != ConnectionState.Open)
                _connection.Open();
            var table = _connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            if (table == null)
                return list;
            list.AddRange(
                table.Rows.Cast<DataRow>()
                    .Select(dr => dr["TABLE_NAME"].ToString())
                    .Where(sheetName => sheetName.Contains("$")));
            return list;
        }

        public OleDbDataReader Read(string sheetName)
        {
            var sql = string.Format(SELECT_SQL, sheetName);
            var command = new OleDbCommand(sql, _connection);
            if (_connection.State != ConnectionState.Open)
                _connection.Open();
            return command.ExecuteReader();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_connection != null)
                    {
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                _disposed = true;
            }
        }
    }
}
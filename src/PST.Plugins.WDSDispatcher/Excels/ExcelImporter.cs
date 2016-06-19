//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: ExcelImporter.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System;
using System.Data.OleDb;
using System.Text;

namespace PST.Plugins.WDSDispatcher.Excels
{
    public abstract class ExcelImporter
    {
        private const string INSERT_SQL = "INSERT INTO dbo.[{0}] ({1}) VALUES ";
        private const string SELECT_SQL = "select * from [{0}]";
        private readonly string _filePath;
        private readonly string _sheetName;
        private readonly string _tableName;

        protected ExcelImporter(string filePath, string sheetName, string tableName)
        {
            _filePath = filePath;
            _sheetName = sheetName;
            _tableName = tableName;
        }

        public event EventHandler<string> InProcess;
        public event EventHandler<string> PostProcess;

        public void Process(int setId, bool removeExists)
        {
            if (removeExists)
            {
                OnInProcess("正在清除已有数据...");
                RemoveExists(setId);
                OnInProcess("已有数据清除完毕。");
            }

            var colNames = ExcelHelper.ReadColumnNames(_filePath, _sheetName);
            var insertSql = string.Format(INSERT_SQL, _tableName, ColNamesPrefix + colNames);

            var connectionString = ExcelHelper.GetConnectString(_filePath);
            using (var conn = new OleDbConnection(connectionString))
            {
                var cmd = new OleDbCommand(string.Format(SELECT_SQL, _sheetName), conn);
                conn.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader == null)
                    return;
                var sb = new StringBuilder();
                int seq = 0;
                int index = 0;
                int lastIndex = 0;
                while (reader.Read())
                {
                    if (reader.FieldCount == 0)
                        continue;
                    var row = GetRowPrefix(setId, seq);
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        if (reader.IsDBNull(i))
                        {
                            row.Append("'',");
                        }
                        else
                        {
                            var type = reader.GetFieldType(i);
                            var v = Convert.ChangeType(reader.GetValue(i), type);
                            row.Append("'").Append(v).Append("',");
                        }
                    }
                    var str = row.ToString(0, row.Length - 1);
                    sb.Append(str).Append("),");
                    seq++;
                    index++;
                    //每次插入100条数据
                    if (index%100 == 0)
                    {
                        if (sb.Length != 0)
                        {
                            lastIndex = ProcessData(insertSql, sb, index, lastIndex);
                        }
                    }
                }
                reader.Close();
                ProcessData(insertSql, sb, index, lastIndex);
                OnPostProcess("导入完成");
            }
        }

        #region Private Methods

        private int ProcessData(string insertSql, StringBuilder sbDataSql, int index, int lastIndex)
        {
            var msg = string.Format("正在导入第{0} - {1}条数据...", lastIndex + 1, index);
            OnInProcess(msg);
            string sql = GenerateSql(insertSql, sbDataSql);
            if (!string.IsNullOrEmpty(sql))
                DoProcessData(sql);
            return index;
        }

        private string GenerateSql(string insertSql, StringBuilder stringBuilder)
        {
            if (stringBuilder.Length == 0)
            {
                return string.Empty;
            }
            var dataSql = stringBuilder.ToString(0, stringBuilder.Length - 1);
            stringBuilder.Clear();
            return insertSql + dataSql;
        }

        #endregion

        #region Protected Methods

        protected abstract string ColNamesPrefix { get; }

        protected abstract void DoProcessData(string sql);

        protected abstract StringBuilder GetRowPrefix(int setId, int seq);

        protected virtual void RemoveExists(int setId)
        {
        }


        protected void OnInProcess(string message)
        {
            if (InProcess == null)
                return;
            var temp = InProcess;
            temp(this, message);
        }

        protected void OnPostProcess(string message)
        {
            if (PostProcess == null)
                return;
            var temp = PostProcess;
            temp(this, message);
        }

        #endregion
    }
}
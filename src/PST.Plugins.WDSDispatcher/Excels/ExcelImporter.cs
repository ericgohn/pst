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
        private const string INSERT_SQL = "INSERT INTO dbo.[{0}] VALUES ";
        private const string SELECT_SQL = "select * from [{0}]";
        private readonly string _filePath;
        private readonly string _insertSql;
        private readonly string _sheetName;

        protected ExcelImporter(string filePath, string sheetName, string tableName)
        {
            _filePath = filePath;
            _sheetName = sheetName;
            _insertSql = string.Format(INSERT_SQL, tableName);
        }

        public event EventHandler<string> PreProcess;
        public event EventHandler<string> PostProcess;

        public void Process()
        {
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
                    var row = new StringBuilder("('").Append(Guid.NewGuid())
                        .Append("',")
                        .Append(1)
                        .Append(",")
                        .Append(seq)
                        .Append(",");
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
                            lastIndex = ProcessData(sb, index, lastIndex);
                        }
                    }
                }
                reader.Close();
                ProcessData(sb, index, lastIndex);
                OnPostProcess("导入完成");
            }
        }

        #region Private Methods

        private int ProcessData(StringBuilder sbDataSql, int index, int lastIndex)
        {
            var msg = string.Format("正在导入第{0} - {1}条数据...", lastIndex + 1, index);
            OnPreProcess(msg);
            string sql = GenerateSql(sbDataSql);
            if (!string.IsNullOrEmpty(sql))
                DoProcessData(sql);
            return index;
        }

        private string GenerateSql(StringBuilder stringBuilder)
        {
            if (stringBuilder.Length == 0)
            {
                return string.Empty;
            }
            var dataSql = stringBuilder.ToString(0, stringBuilder.Length - 1);
            stringBuilder.Clear();
            return _insertSql + dataSql;
        }

        #endregion

        #region Protected Methods

        protected abstract void DoProcessData(string sql);


        protected void OnPreProcess(string message)
        {
            if (PreProcess == null)
                return;
            var temp = PreProcess;
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
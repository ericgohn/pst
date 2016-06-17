//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: FFPImportControl.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System;
using System.Data.OleDb;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using PST.UI.Common;
using PST.UI.Common.FFPService;
using PST.UI.Common.Helpers;

namespace PST.Plugins.WDSDispatcher.Controls
{
    public partial class FFPImportControl : UserControlBase
    {
        private const string INSERT_SQL = "INSERT INTO dbo.[FFP] VALUES ";

        public FFPImportControl()
        {
            InitializeComponent();
        }

        #region Private Methods

        private void SetRunningWidgetStatus(bool isRunning, string text = "")
        {
            btnOpenFile.Enabled = cbSheets.Enabled = !isRunning;

            if (isRunning)
            {
                circularProgress.IsRunning = true;
                lblMessage.Text = text;
                lblMessage.Visible = true;
            }
            else
            {
                circularProgress.IsRunning = false;
                lblMessage.Visible = false;
            }
        }

        #endregion

        public async void ImportData(string fftSetName)
        {
            if (!superValidator.Validate())
            {
                return;
            }
            var filePath = tbFile.Text.Trim();
            var sheetName = cbSheets.SelectedItem as string;
            var confirmMsg = string.Format("您确定要导入工作簿\"{0}\"中的所有数据吗？", sheetName);
            if (DialogHelper.ShowConfirm("FFP数据导入", confirmMsg) != eTaskDialogResult.Yes)
                return;
            SetRunningWidgetStatus(true, "正在导入数据...");
            await Task.Run(() => ImportData(filePath, sheetName));
            SetRunningWidgetStatus(false);
        }

        #region Control Events

        private async void btnOpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tbFile.Text = openFileDialog.FileName;
                SetRunningWidgetStatus(true, "正在读取文件...");
                await Task.Run(() => ExcelHelper.ReadFileBasicInfo(tbFile.Text)).ContinueWith(task =>
                {
                    if (task.IsFaulted)
                    {
                        TaskHelper.HandleException(task.Exception);
                        SetRunningWidgetStatus(false);
                        return;
                    }
                    int selectedIndex = 0;
                    int i = -1;
                    cbSheets.Items.Clear();
                    foreach (var sheet in task.Result)
                    {
                        cbSheets.Items.Add(sheet);
                        if (sheet.ToLower().Contains("ffp"))
                            selectedIndex = i;
                        i++;
                    }
                    if (selectedIndex == -1 && cbSheets.Items.Count > 0)
                        selectedIndex = 0;
                    SetRunningWidgetStatus(false);
                    cbSheets.SelectedIndex = selectedIndex;
                }, uiTaskScheduler);
            }
        }

        private void ImportData(string filePath, string sheetName)
        {
            var connectionString = ExcelHelper.GetConnectString(filePath);
            using (var conn = new OleDbConnection(connectionString))
            {
                var cmd = new OleDbCommand("select * from [" + sheetName + "]", conn);
                conn.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader == null)
                    return;
                var service = ServiceFactory.S.GetFFPService();
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
                    ;
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
                            lastIndex = ProcessData(service, sb, index, lastIndex);
                        }
                    }
                }
                reader.Close();
                ProcessData(service, sb, index, lastIndex);
                SetImportMessage("导入完成");
            }
        }

        private string GenerateSql(StringBuilder stringBuilder)
        {
            if (stringBuilder.Length == 0)
            {
                return string.Empty;
            }
            var dataSql = stringBuilder.ToString(0, stringBuilder.Length - 1);
            stringBuilder.Clear();
            return INSERT_SQL + dataSql;
        }

        private int ProcessData(IFFPService service, StringBuilder sb, int index, int lastIndex)
        {
            var sql = GenerateSql(sb);
            var msg = string.Format("正在导入第{0} - {1}条数据...", lastIndex + 1, index);
            SetImportMessage(msg);
            var res = service.AddFfp(sql);
            return index;
        }

        private void SetImportMessage(string text)
        {
            if (InvokeRequired)
            {
                Action<string> callback = SetImportMessage;
                Invoke(callback, text);
            }
            else
            {
                tbAnalyzeResult.Focus();
                tbAnalyzeResult.AppendText("\r\n"+text);
                tbAnalyzeResult.SelectionStart = tbAnalyzeResult.TextLength;
                lblMessage.Text = text;
            }
        }

        private async void cbSheets_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbSheets.SelectedIndex;
            if (index < 0)
                return;
            var filePath = tbFile.Text.Trim();
            var sheetName = cbSheets.SelectedItem as string;
            SetRunningWidgetStatus(true, "正在分析文件...");
            await Task.Run(() => ExcelHelper.AnalyzeFile(filePath, sheetName)).ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    TaskHelper.HandleException(task.Exception);
                    SetRunningWidgetStatus(false);
                    return;
                }
                tbAnalyzeResult.Text = task.Result;
                SetRunningWidgetStatus(false);
            }, uiTaskScheduler);
        }

        #endregion
    }
}
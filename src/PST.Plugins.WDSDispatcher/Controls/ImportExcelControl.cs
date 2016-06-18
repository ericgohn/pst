//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: ImportExcelControl.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using PST.Plugins.WDSDispatcher.Excels;
using PST.UI.Common.Helpers;

namespace PST.Plugins.WDSDispatcher.Controls
{
    public partial class ImportExcelControl : UserControlBase
    {
        public ImportExcelControl()
        {
            InitializeComponent();
        }

        public event EventHandler<string> AsyncRun;
        public event EventHandler<EventArgs> AsyncRunComplete;

        public void AppendMessageAsync(string message)
        {
            if (InvokeRequired)
            {
                Action<string> callback = AppendMessageAsync;
                Invoke(callback, message);
            }
            else
            {
                tbAnalyzeResult.Focus();
                tbAnalyzeResult.AppendText("\r\n" + message);
                tbAnalyzeResult.SelectionStart = tbAnalyzeResult.TextLength;
            }
        }

        public bool ValidateInput()
        {
            return superValidator.Validate();
        }

        public void SetRunningWidgetStatus(bool isRunning)
        {
            btnOpenFile.Enabled = cbSheets.Enabled = !isRunning;
        }

        #region Private Methods

        private void OnAsyncRun(string text)
        {
            if (AsyncRun == null)
                return;
            var temp = AsyncRun;
            temp(this, text);
        }

        private void OnAsyncRunComplete()
        {
            if (AsyncRunComplete == null)
                return;
            var temp = AsyncRunComplete;
            temp(this, EventArgs.Empty);
        }

        #endregion

        #region Control Events

        private async void btnOpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tbFile.Text = openFileDialog.FileName;
                SetRunningWidgetStatus(true);
                OnAsyncRun("正在读取Excel文件...");
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
                    OnAsyncRunComplete();
                    cbSheets.SelectedIndex = selectedIndex;
                }, uiTaskScheduler);
            }
        }

        private async void cbSheets_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbSheets.SelectedIndex;
            if (index < 0)
                return;
            var filePath = tbFile.Text.Trim();
            var sheetName = cbSheets.SelectedItem as string;
            SetRunningWidgetStatus(true);
            OnAsyncRun(string.Format("正在分析工作簿\"{0}\"...", sheetName));
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
                OnAsyncRunComplete();
            }, uiTaskScheduler);
        }

        #endregion

        #region Properties

        public string FilePath
        {
            get { return tbFile.Text.Trim(); }
        }

        public string SheetName
        {
            get { return cbSheets.SelectedItem as string; }
        }

        [Browsable(true)]
        public string Title
        {
            get { return groupBox1.Text; }
            set { groupBox1.Text = value; }
        }

        public string WartermarkText
        {
            get { return tbFile.WatermarkText; }
            set { tbFile.WatermarkText = value; }
        }

        #endregion
    }
}
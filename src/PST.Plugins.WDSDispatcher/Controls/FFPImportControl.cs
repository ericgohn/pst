//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: FFPImportControl.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using PST.Plugins.WDSDispatcher.Excels;
using PST.UI.Common.Helpers;

namespace PST.Plugins.WDSDispatcher.Controls
{
    public partial class FFPImportControl : UserControlBase
    {
        public FFPImportControl()
        {
            InitializeComponent();
        }

        public async Task ImportData(string fftSetName)
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
            var importer = new FFPExcelImporter(filePath, sheetName);
            importer.InProcess += importer_PreProcess;
            importer.PostProcess += importer_PostProcess;
            await Task.Run(() => { importer.Process(); })
                .ContinueWith(t => { SetRunningWidgetStatus(false); }, uiTaskScheduler);
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
                tbAnalyzeResult.AppendText("\r\n" + text);
                tbAnalyzeResult.SelectionStart = tbAnalyzeResult.TextLength;
                lblMessage.Text = text;
            }
        }

        #endregion

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

        private void importer_PostProcess(object sender, string e)
        {
            SetImportMessage(e);
        }

        private void importer_PreProcess(object sender, string e)
        {
            SetImportMessage(e);
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
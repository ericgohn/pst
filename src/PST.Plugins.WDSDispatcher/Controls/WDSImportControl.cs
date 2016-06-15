//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: WDSImportControl.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Npoi.Mapper;
using PST.Domain;
using PST.UI.Common;
using PST.UI.Common.Helpers;

namespace PST.Plugins.WDSDispatcher.Controls
{
    public partial class WDSImportControl : UserControlBase
    {
        public WDSImportControl()
        {
            InitializeComponent();
        }

        #region Private Methods

        private void SetRunningWidgetStatus(bool isRunning, string text = "")
        {
            btnOpenFile.Enabled = cbSheets.Enabled = cmdImport.Enabled = !isRunning;

            if (isRunning)
            {
                circularProgress.IsRunning = true;
                lblImport.Text = text;
                lblImport.Visible = true;
            }
            else
            {
                circularProgress.IsRunning = false;
                lblImport.Visible = false;
            }
        }

        #endregion

        private void cmdImport_Executed(object sender, EventArgs e)
        {
            if (!superValidator.Validate())
            {
                return;
            }
            var filePath = tbFile.Text.Trim();
            var identity = tbIdentity.Text.ToUpper().Trim();
            var sheetName = cbSheets.SelectedItem as string;
            var confirmMsg = string.Format("您确定要导入工作簿\"{0}\"中的所有数据吗？", sheetName);
            if (DialogHelper.ShowConfirm("FFP数据导入", confirmMsg) != eTaskDialogResult.Yes)
                return;

            var mapper = new Mapper(filePath);
            var items = mapper.Take<FFP>(sheetName);

            if (bwImport.IsBusy)
                return;
            circularProgress.IsRunning = true;
            lblImport.Visible = true;
            bwImport.RunWorkerAsync(items);
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
                    foreach (string sheet in task.Result)
                    {
                        cbSheets.Items.Add(sheet);
                        if (sheet.ToLower().Contains("ffp"))
                            selectedIndex = i;
                        i++;
                    }
                    SetRunningWidgetStatus(false);
                    if (selectedIndex == -1 && cbSheets.Items.Count > 0)
                        selectedIndex = 0;
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

        #region bwImport

        private void bwImport_DoWork(object sender, DoWorkEventArgs e)
        {
            var service = ServiceFactory.S.GetFFPService();
            var items = (IEnumerable<RowInfo<FFP>>) e.Argument;
            var count = items.Count();
            int i = 1;
            bool result = true;
            foreach (var item in items)
            {
                UIHelper.AsyncSetControlText(lblImport, string.Format("正在导入第{0}/{1}条数据...", i, count));
                if (item.ErrorColumnIndex > -1)
                {
                    UIHelper.AsyncSetControlText(lblImport, item.ErrorMessage);
                    break;
                }
                item.Value.Id = Guid.NewGuid();
                //                item.Value.
                var res = service.Add(item.Value);
                i++;
                if (!res.Success)
                {
                    result = false;
                    break;
                }
            }
            e.Result = result;
        }

        private void bwImport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        #endregion
    }
}
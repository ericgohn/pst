//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: WDSResponseDispatcherControl.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using PST.Plugins.WDSDispatcher.Excels;
using PST.UI.Common;
using PST.UI.Common.Helpers;

namespace PST.Plugins.WDSDispatcher.Children
{
    public partial class WDSResponseDispatcherControl : UserControl
    {
        public WDSResponseDispatcherControl()
        {
            InitializeComponent();
        }

        #region Commands

        private async void cmdDispatch_Executed(object sender, EventArgs e)
        {
            bool isValid = importFFPExcelControl.ValidateInput();
            isValid = isValid && importWDSExcelControl.ValidateInput();
            isValid = isValid && superValidator.Validate();
            if (!isValid)
                return;
            var ffpFilPath = importFFPExcelControl.FilePath;
            var ffpSheetName = importFFPExcelControl.SheetName;
            var wdsFilePath = importWDSExcelControl.FilePath;
            var wdsSheetName = importWDSExcelControl.SheetName;
            var setName = tbSetName.Text.Trim().ToUpper();
            var confirmMsg = string.Format("您确定要导入工作簿\"{0}\"及\"{1}\"中的所有数据吗？", ffpSheetName, wdsSheetName);
            if (DialogHelper.ShowConfirm("数据导入", confirmMsg) != eTaskDialogResult.Yes)
                return;

            var setService = ServiceFactory.S.GetFFPSetService();
            var res = await setService.HasDataAsync(setName);

            if (!res.Success)
            {
                return;
            }

            if (res.Arg)
            {
                if (DialogHelper.ShowConfirm("期次下已存在数据", "您输入的期次下已存在数据， 继续导入将覆盖这些数据，是否继续？") != eTaskDialogResult.Yes)
                    return;
            }

            var setIdRes = await setService.UpsertAsync(setName);
            if (!res.Success)
            {
                DialogHelper.ShowAddError(res.Message);
                return;
            }
            var setId = setIdRes.Arg;
            SetRunningStatus(true, "正在准备导入...");

            //todo remove existing data.
            var ffpImporter = new FFPExcelImporter(ffpFilPath, ffpSheetName);
            ffpImporter.InProcess += ffpImporter_InProcess;
            ffpImporter.PostProcess += ffpImporter_PostProcess;
            await Task.Run(() => { ffpImporter.Process(setId); });

            var wdsImporter = new WDSExcelImporter(wdsFilePath, wdsSheetName);
            wdsImporter.InProcess += wdsImporter_InProcess;
            wdsImporter.PostProcess += wdsImporter_PostProcess;
            await Task.Run(() => { wdsImporter.Process(setId); });

            SetRunningStatus(false);
        }

        private void cmdGenerateIdentity_Executed(object sender, EventArgs e)
        {
            tbSetName.Text = GenerateSetName();
        }

        #endregion

        #region Private Methods

        private void SetRunningStatus(bool running, string text = "")
        {
            if (InvokeRequired)
            {
                Action<bool, string> callback = SetRunningStatus;
                Invoke(callback, running, text);
            }
            else
            {
                cmdDispatch.Enabled = !running;
                circularProgress.IsRunning = running;
                lblMessage.Text = text;
                lblMessage.Visible = running;
                importFFPExcelControl.SetRunningWidgetStatus(running);
                importWDSExcelControl.SetRunningWidgetStatus(running);
            }
        }

        private string GenerateSetName()
        {
            var now = DateTime.Now;
            return now.ToString("yyyyMMdd");
        }

        #endregion

        #region Control Events

        private void importExcelControl_AsyncRun(object sender, string e)
        {
            SetRunningStatus(true, e);
        }

        private void importExcelControl_AsyncRunComplete(object sender, EventArgs e)
        {
            SetRunningStatus(false);
        }

        private void ffpImporter_PostProcess(object sender, string e)
        {
            importFFPExcelControl.AppendMessageAsync(e);
            SetRunningStatus(false);
        }

        private void ffpImporter_InProcess(object sender, string e)
        {
            SetRunningStatus(true, e);
            importFFPExcelControl.AppendMessageAsync(e);
        }

        private void wdsImporter_PostProcess(object sender, string e)
        {
            importWDSExcelControl.AppendMessageAsync(e);
            SetRunningStatus(false);
        }

        private void wdsImporter_InProcess(object sender, string e)
        {
            SetRunningStatus(true, e);
            importWDSExcelControl.AppendMessageAsync(e);
        }

        #endregion
    }
}
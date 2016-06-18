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
using PST.UI.Common.Helpers;

namespace PST.Plugins.WDSDispatcher.Children
{
    public partial class WDSResponseDispatcherControl : UserControl
    {
        public WDSResponseDispatcherControl()
        {
            InitializeComponent();
        }

        private async void cmdDispatch_Executed(object sender, EventArgs e)
        {
            if (!importFFPExcelControl.ValidateInput())
                return;
            if (!importWDSExcelControl.ValidateInput())
                return;
            var ffpFilPath = importFFPExcelControl.FilePath;
            var ffpSheetName = importFFPExcelControl.SheetName;
            var wdsFilePath = importWDSExcelControl.FilePath;
            var wdsSheetName = importWDSExcelControl.SheetName;
            var confirmMsg = string.Format("您确定要导入工作簿\"{0}\"及\"{1}\"中的所有数据吗？", ffpSheetName, wdsSheetName);
            if (DialogHelper.ShowConfirm("数据导入", confirmMsg) != eTaskDialogResult.Yes)
                return;

            SetRunningStatus(true, "正在准备导入...");

            var ffpImporter = new FFPExcelImporter(ffpFilPath, ffpSheetName);
            ffpImporter.InProcess += ffpImporter_InProcess;
            ffpImporter.PostProcess += ffpImporter_PostProcess;
            await Task.Run(() => { ffpImporter.Process(); });

            var wdsImporter = new WDSExcelImporter(wdsFilePath, wdsSheetName);
            wdsImporter.InProcess += wdsImporter_InProcess;
            wdsImporter.PostProcess += wdsImporter_PostProcess;
            await Task.Run(() => { wdsImporter.Process(); });

            SetRunningStatus(false);
        }

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
            SetRunningStatus(true,e);
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
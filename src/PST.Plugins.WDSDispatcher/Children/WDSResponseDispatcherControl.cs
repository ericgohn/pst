//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: WDSResponseDispatcherControl.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System;
using System.Collections.Generic;
using System.Linq;
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
        private const string FFP_SCHEMA = @"CREATE TABLE [FFP](
	[Seq] int,
	[Dispatched] bit,
	[ResAmount] float,
	[Series] nvarchar(255),
	[Model Name] nvarchar(255),
	[Business No] nvarchar(255),
	[Sales Route] nvarchar(255),
	[PNO] nvarchar(255),
	[Sales PNO] nvarchar(255),
	[Sub Information] float,
	[Customer Name] nvarchar(255),
	[Rank] nvarchar(255),
	[Rate] float,
	[ACC Code] nvarchar(255),
	[Sales Staff] nvarchar(255),
	[Order Division] float,
	[Shipped Month] datetime,
	[Shipped QTY] float,
	[Shipped Qty2] float,
	[F/FP PNO] nvarchar(255),
	[F/FP Type] nvarchar(255),
	[CIG Name] nvarchar(255),
	[CIC Name] nvarchar(255)
)";

        public WDSResponseDispatcherControl()
        {
            InitializeComponent();
        }

        #region Commands

        private async void cmdExport_Executed(object sender, EventArgs e)
        {
            var writer = new ExcelWriter(@"D:\test.xlsx");
            writer.CreateSheet(FFP_SCHEMA);

            var ffpSetId = await GetFFPSetIdAsync();

            var service = ServiceFactory.S.GetFFPService();
            int currentPage = 1;
            int itemsPerPage = 100;
            while (true)
            {
                int start = (currentPage - 1)*itemsPerPage + 1;
                int end = start + itemsPerPage;
                SetRunningStatus(true, string.Format("正在导出第{0}-{1}条数据...", start, end));
                var res = await service.GetSqlDataAsync(currentPage, itemsPerPage, ffpSetId);
                if (res.Arg.Length == 0)
                {
                    SetRunningStatus(false);
                    break;
                }
                List<string> list = res.Arg.Select(sql => string.Format("INSERT INTO [FFP] VALUES {0};", sql)).ToList();
                await writer.InsertAsync(list);
                currentPage++;
            }
        }


        private async void cmdDispatch_Executed(object sender, EventArgs e)
        {
            var ffpSetId = await GetFFPSetIdAsync();
            SetRunningStatus(true, "正在获取PNO数据...");
            var service = ServiceFactory.S.GetWDResponseService();
            service.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(10);
            var pnoRes = await service.GetPNOsAsync(ffpSetId);
            if (!pnoRes.Success)
            {
                SetRunningStatus(false);
                DialogHelper.ShowLoadError(pnoRes.Message);
                return;
            }

            foreach (var pno in pnoRes.Arg)
            {
                if (string.IsNullOrWhiteSpace(pno))
                    continue;
                SetRunningStatus(true, string.Format("正在分配PNO:{0}...", pno));
                var dispatchRes = await service.DispatchAsync(ffpSetId, pno);
                if (!dispatchRes.Success)
                {
                    DialogHelper.ShowUpdateError(dispatchRes.Message);
                    break;
                }
            }
            SetRunningStatus(false);
        }

        private async void cmdImport_Executed(object sender, EventArgs e)
        {
            var commandSource = sender as ICommandSource;
            if (commandSource == null)
                return;
            var param = commandSource.CommandParameter as string;
            if (param == "1")
            {
                await ImportFfpAndWdsResponse();
            }
            else if (param == "2")
            {
                await ImportFfp();
            }
            else if (param == "3")
            {
                await ImportWdsResponse();
            }
        }

        private async void cmdRemove_Executed(object sender, EventArgs e)
        {
            var commandSource = sender as ICommandSource;
            if (commandSource == null)
                return;
            var param = commandSource.CommandParameter as string;
            if (param == "1")
            {
                await RemoveFfpAndWdsResponse();
            }
            else if (param == "2")
            {
                await RemoveFfp();
            }
            else if (param == "3")
            {
                await RemoveWdsResponse();
            }
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

        private async Task ImportFfpAndWdsResponse()
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

            bool dataExist = res.Arg;
            if (dataExist)
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

            var ffpImporter = new FFPExcelImporter(ffpFilPath, ffpSheetName);
            ffpImporter.InProcess += ffpImporter_InProcess;
            ffpImporter.PostProcess += ffpImporter_PostProcess;
            await Task.Run(() => { ffpImporter.Process(setId, dataExist); });

            var wdsImporter = new WDSExcelImporter(wdsFilePath, wdsSheetName);
            wdsImporter.InProcess += wdsImporter_InProcess;
            wdsImporter.PostProcess += wdsImporter_PostProcess;
            await Task.Run(() => { wdsImporter.Process(setId, dataExist); });

            SetRunningStatus(false);
        }

        private async Task ImportFfp()
        {
            bool isValid = importFFPExcelControl.ValidateInput();
            isValid = isValid && superValidator.Validate();
            if (!isValid)
                return;
            var ffpFilPath = importFFPExcelControl.FilePath;
            var ffpSheetName = importFFPExcelControl.SheetName;
            var setName = tbSetName.Text.Trim().ToUpper();
            var confirmMsg = string.Format("您确定要导入工作簿\"{0}\"中的所有数据吗？", ffpSheetName);
            if (DialogHelper.ShowConfirm("数据导入", confirmMsg) != eTaskDialogResult.Yes)
                return;

            var setService = ServiceFactory.S.GetFFPSetService();
            var res = await setService.HasDataAsync(setName);

            bool dataExist = res.Arg;
            if (dataExist)
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

            var ffpImporter = new FFPExcelImporter(ffpFilPath, ffpSheetName);
            ffpImporter.InProcess += ffpImporter_InProcess;
            ffpImporter.PostProcess += ffpImporter_PostProcess;
            await Task.Run(() => { ffpImporter.Process(setId, dataExist); });

            SetRunningStatus(false);
        }

        private async Task ImportWdsResponse()
        {
            bool isValid = importWDSExcelControl.ValidateInput();
            isValid = isValid && superValidator.Validate();
            if (!isValid)
                return;
            var wdsFilePath = importWDSExcelControl.FilePath;
            var wdsSheetName = importWDSExcelControl.SheetName;
            var setName = tbSetName.Text.Trim().ToUpper();
            var confirmMsg = string.Format("您确定要导入工作簿\"{0}\"中的所有数据吗？", wdsSheetName);
            if (DialogHelper.ShowConfirm("数据导入", confirmMsg) != eTaskDialogResult.Yes)
                return;

            var setService = ServiceFactory.S.GetFFPSetService();
            var res = await setService.HasDataAsync(setName);

            bool dataExist = res.Arg;
            if (dataExist)
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

            var wdsImporter = new WDSExcelImporter(wdsFilePath, wdsSheetName);
            wdsImporter.InProcess += wdsImporter_InProcess;
            wdsImporter.PostProcess += wdsImporter_PostProcess;
            await Task.Run(() => { wdsImporter.Process(setId, dataExist); });

            SetRunningStatus(false);
        }

        private async Task RemoveFfpAndWdsResponse()
        {
            if (!superValidator.Validate())
                return;
            var setName = tbSetName.Text.Trim().ToUpper();
            SetRunningStatus(true, "正在清除FFP数据...");
            var ffpService = ServiceFactory.S.GetFFPService();
            await ffpService.RemoveBySetNameAsync(setName);
            SetRunningStatus(true, "正在清除WDS Response数据...");
            var wdsService = ServiceFactory.S.GetWDResponseService();
            await wdsService.RemoveBySetNameAsync(setName);
            SetRunningStatus(false);
        }

        private async Task RemoveFfp()
        {
            if (!superValidator.Validate())
                return;
            var setName = tbSetName.Text.Trim().ToUpper();
            SetRunningStatus(true, "正在清除FFP数据...");
            var ffpService = ServiceFactory.S.GetFFPService();
            await ffpService.RemoveBySetNameAsync(setName);
            SetRunningStatus(false);
        }

        private async Task RemoveWdsResponse()
        {
            if (!superValidator.Validate())
                return;
            var setName = tbSetName.Text.Trim().ToUpper();
            SetRunningStatus(true, "正在清除WDS Response数据...");
            var wdsService = ServiceFactory.S.GetWDResponseService();
            await wdsService.RemoveBySetNameAsync(setName);
            SetRunningStatus(false);
        }

        private async Task<int> GetFFPSetIdAsync()
        {
            SetRunningStatus(true, "正在获取FFP Set数据...");
            var ffpSetService = ServiceFactory.S.GetFFPSetService();
            string setName = tbSetName.Text.Trim();
            var ffpSetRes = await ffpSetService.UpsertAsync(setName);
            if (!ffpSetRes.Success)
            {
                DialogHelper.ShowLoadError(ffpSetRes.Message);
                SetRunningStatus(false);
                return -1;
            }
            return ffpSetRes.Arg;
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
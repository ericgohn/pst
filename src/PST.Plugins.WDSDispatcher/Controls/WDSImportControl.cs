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
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Npoi.Mapper;
using NPOI.SS.UserModel;
using PST.Domain;
using PST.UI.Common;
using PST.UI.Common.Helpers;

namespace PST.Plugins.WDSDispatcher.Controls
{
    public partial class WDSImportControl : UserControl
    {
        public WDSImportControl()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tbFile.Text = openFileDialog.FileName;
                ReadFileBasicInfo();
            }
        }

        private void ReadFileBasicInfo()
        {
            IWorkbook workbook;
            try
            {
                workbook = WorkbookFactory.Create(tbFile.Text);
                workbook.MissingCellPolicy = MissingCellPolicy.CREATE_NULL_AS_BLANK;
            }
            catch (IOException e)
            {
                DialogHelper.ShowException("Excel文件读取错误。", e);
                return;
            }
            if (workbook.NumberOfSheets < 1)
            {
                DialogHelper.ShowError("Excel格式错误", "指定的Excel文件中没有找到可用的工作薄。");
                return;
            }
            int selectedIndex = 0;
            int i = 0;
            foreach (ISheet sheet in workbook)
            {
                cbSheets.Items.Add(sheet.SheetName);
                if (sheet.SheetName.ToLower().Contains("ffp"))
                    selectedIndex = i;
                i++;
            }
            cbSheets.SelectedIndex = selectedIndex;
            AnalyzeFile(workbook);
        }

        private void AnalyzeFile(IWorkbook workbook)
        {
            var msg = "文件：{0}\r\n工作簿：{1}\r\n记录总数：{2}";
            var filePath = tbFile.Text.Trim();
            var fileName = Path.GetFileName(filePath);
            var sheetName = cbSheets.SelectedItem as string;
            var mapper = new Mapper(workbook);


            var rows = mapper.Take<FFP>(sheetName);
            int count = 0;
            int errorCount = 0;
            StringBuilder sb = new StringBuilder();
            foreach (var row in rows)
            {
                count++;
                if (!string.IsNullOrEmpty(row.ErrorMessage))
                {
                    errorCount++;
                    sb.Append(string.Format("\r\n{0}，错误位置：第{1}行第{2}列", row.ErrorMessage, row.RowNumber,
                        row.ErrorColumnIndex));
                }
            }
            var m = string.Format(msg, fileName, sheetName, count);
            if (sb.Length > 0)
            {
                var errorMsg = string.Format("总计{0}个错误：", errorCount);
                errorMsg = errorMsg + sb;
                m += errorMsg;
            }

            UIHelper.AsyncSetControlText(tbAnalyzeResult, m);
        }

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
    }
}
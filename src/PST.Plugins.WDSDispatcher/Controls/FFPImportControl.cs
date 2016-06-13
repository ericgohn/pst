using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Ganss.Excel;
using NPOI.SS.UserModel;
using PST.Domain;
using PST.UI.Common;
using PST.UI.Common.Helpers;

namespace PST.Plugins.WDSDispatcher.Controls
{
    public partial class FFPImportControl : UserControl
    {
        public FFPImportControl()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tbFile.Text = this.openFileDialog.FileName;
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
                this.cbSheets.Items.Add(sheet.SheetName);
                if (sheet.SheetName.ToLower().Contains("ffp"))
                    selectedIndex = i;
                i++;
            }
            cbSheets.SelectedIndex = selectedIndex;
        }

        private void cmdImport_Executed(object sender, EventArgs e)
        {
            var filePath = tbFile.Text.Trim();
            if (string.IsNullOrEmpty(filePath))
            {
                DialogHelper.ShowError("请选择FFP文件", "请选择FFP文件");
                return;
            }
            var identity = tbIdentity.Text.ToUpper().Trim();
            if (string.IsNullOrEmpty(identity))
            {
                DialogHelper.ShowError("请输入FFP期次", "请输入FFP期次");
                return;
            }
            var sheetName = cbSheets.SelectedItem as string;
            if (string.IsNullOrEmpty(sheetName))
            {
                DialogHelper.ShowError("请选择Excel工作薄", "请选择要导入的Excel工作薄");
                return;
            }
            var confirmMsg = string.Format("您确定要导入工作簿\"{0}\"中的所有数据吗？", sheetName);
            if (DialogHelper.ShowConfirm("FFP数据导入", confirmMsg) != eTaskDialogResult.Yes)
                return;
            var mapper = new ExcelMapper(filePath);
            
            mapper.AddMapping<FFP>("Model Name", o => o.Model_Name);
            mapper.AddMapping<FFP>("Business No", o => o.Business_No);
            mapper.AddMapping<FFP>("Sales Route", o => o.Sales_Route);
            mapper.AddMapping<FFP>("Sales PNO", o => o.Sales_PNO);
            mapper.AddMapping<FFP>("Sub Information", o => o.Sub_Information);
            mapper.AddMapping<FFP>("Customer Name", o => o.Customer_Name);
            mapper.AddMapping<FFP>("ACC Code", o => o.ACC_Code);
            mapper.AddMapping<FFP>("Sales Staff", o => o.Sales_Staff);
            mapper.AddMapping<FFP>("Order Division", o => o.Order_Division);
            mapper.AddMapping<FFP>("Shipped Month", o => o.Shipped_Month);
            var items = mapper.Fetch<FFP>(sheetName);
            if (bwImport.IsBusy)
                return;
            circularProgress.IsRunning = true;
            lblImport.Visible = true;
            bwImport.RunWorkerAsync(items);
        }


        private void bwImport_DoWork(object sender, DoWorkEventArgs e)
        {
            var service = ServiceFactory.S.GetFFPService();
            var items = (IEnumerable<FFP>)e.Argument;
            var count = items.Count();
            int i = 1;
            bool result = true;
            foreach (var item in items)
            {
                UIHelper.AsyncSetControlText(lblImport, string.Format("正在导入第{0}/{1}条数据...", i, count));
                item.Id = Guid.NewGuid();
                var res = service.Add(item);
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

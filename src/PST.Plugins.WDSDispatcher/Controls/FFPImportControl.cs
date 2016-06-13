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
    }
}

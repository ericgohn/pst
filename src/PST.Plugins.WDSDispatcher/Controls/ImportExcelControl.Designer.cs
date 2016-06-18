namespace PST.Plugins.WDSDispatcher.Controls
{
    partial class ImportExcelControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportExcelControl));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbAnalyzeResult = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tbFile = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnOpenFile = new DevComponents.DotNetBar.ButtonX();
            this.cbSheets = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.superValidator = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter = new DevComponents.DotNetBar.Validator.Highlighter();
            this.requiredFieldValidator1 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("请选择Excel文件");
            this.requiredFieldValidator2 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("请选择工作簿");
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(869, 443);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FFP导入";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tbAnalyzeResult);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 48);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(863, 392);
            this.panel3.TabIndex = 15;
            // 
            // tbAnalyzeResult
            // 
            // 
            // 
            // 
            this.tbAnalyzeResult.BackgroundStyle.Class = "RichTextBoxBorder";
            this.tbAnalyzeResult.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbAnalyzeResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbAnalyzeResult.Location = new System.Drawing.Point(0, 0);
            this.tbAnalyzeResult.Name = "tbAnalyzeResult";
            this.tbAnalyzeResult.Rtf = "{\\rtf1\\ansi\\ansicpg936\\deff0\\deflang1033\\deflangfe2052{\\fonttbl{\\f0\\fnil\\fcharset" +
    "0 Microsoft Sans Serif;}}\r\n\\viewkind4\\uc1\\pard\\lang2052\\f0\\fs16\\par\r\n}\r\n";
            this.tbAnalyzeResult.Size = new System.Drawing.Size(863, 392);
            this.tbAnalyzeResult.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.tbFile);
            this.flowLayoutPanel1.Controls.Add(this.btnOpenFile);
            this.flowLayoutPanel1.Controls.Add(this.cbSheets);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 18);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(863, 30);
            this.flowLayoutPanel1.TabIndex = 16;
            // 
            // tbFile
            // 
            // 
            // 
            // 
            this.tbFile.Border.Class = "TextBoxBorder";
            this.tbFile.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbFile.Location = new System.Drawing.Point(3, 3);
            this.tbFile.Name = "tbFile";
            this.tbFile.PreventEnterBeep = true;
            this.tbFile.ReadOnly = true;
            this.tbFile.Size = new System.Drawing.Size(200, 22);
            this.tbFile.TabIndex = 0;
            this.superValidator.SetValidator1(this.tbFile, this.requiredFieldValidator1);
            this.tbFile.WatermarkText = "请选择FFP文件";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOpenFile.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOpenFile.Location = new System.Drawing.Point(209, 3);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOpenFile.TabIndex = 1;
            this.btnOpenFile.Text = "选择";
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // cbSheets
            // 
            this.cbSheets.DisplayMember = "Text";
            this.cbSheets.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSheets.FormattingEnabled = true;
            this.cbSheets.ItemHeight = 16;
            this.cbSheets.Location = new System.Drawing.Point(290, 3);
            this.cbSheets.Name = "cbSheets";
            this.cbSheets.Size = new System.Drawing.Size(121, 22);
            this.cbSheets.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbSheets.TabIndex = 2;
            this.superValidator.SetValidator1(this.cbSheets, this.requiredFieldValidator2);
            this.cbSheets.SelectedIndexChanged += new System.EventHandler(this.cbSheets_SelectedIndexChanged);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "Excel 2007|*.xlsx|Excle Macro|*.xlsb|Excel 97-2003|*.xls";
            // 
            // superValidator
            // 
            this.superValidator.ContainerControl = this;
            this.superValidator.ErrorProvider = this.errorProvider;
            this.superValidator.Highlighter = this.highlighter;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            this.errorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider.Icon")));
            // 
            // highlighter
            // 
            this.highlighter.ContainerControl = this;
            // 
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.ErrorMessage = "请选择Excel文件";
            this.requiredFieldValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // requiredFieldValidator2
            // 
            this.requiredFieldValidator2.ErrorMessage = "请选择工作簿";
            this.requiredFieldValidator2.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // ImportExcelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ImportExcelControl";
            this.Size = new System.Drawing.Size(869, 443);
            this.groupBox1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel3;
        private DevComponents.DotNetBar.Controls.RichTextBoxEx tbAnalyzeResult;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbSheets;
        private DevComponents.DotNetBar.Controls.TextBoxX tbFile;
        private DevComponents.DotNetBar.ButtonX btnOpenFile;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private DevComponents.DotNetBar.Validator.SuperValidator superValidator;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator1;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator2;
    }
}

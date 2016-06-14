namespace PST.Plugins.WDSDispatcher.Controls
{
    partial class WDSImportControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WDSImportControl));
            this.cmdImport = new DevComponents.DotNetBar.Command(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.bwImport = new System.ComponentModel.BackgroundWorker();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbIdentity = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblImport = new DevComponents.DotNetBar.LabelX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.circularProgress = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbAnalyzeResult = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbSheets = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.tbFile = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnOpenFile = new DevComponents.DotNetBar.ButtonX();
            this.superValidator = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.requiredFieldValidator2 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("请选择要导入的Excel工作薄");
            this.requiredFieldValidator1 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("请选择WDS Response文件");
            this.requiredFieldValidator3 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("请输入FFP期次");
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter = new DevComponents.DotNetBar.Validator.Highlighter();
            this.panelEx1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdImport
            // 
            this.cmdImport.Name = "cmdImport";
            this.cmdImport.Executed += new System.EventHandler(this.cmdImport_Executed);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "Excel 2007|*.xlsx|Excel 97-2003|*.xls";
            // 
            // bwImport
            // 
            this.bwImport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwImport_DoWork);
            this.bwImport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwImport_RunWorkerCompleted);
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.groupBox1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(468, 211);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(468, 211);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "WDS Response导入";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbIdentity);
            this.panel2.Controls.Add(this.lblImport);
            this.panel2.Controls.Add(this.buttonX1);
            this.panel2.Controls.Add(this.circularProgress);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 108);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(462, 100);
            this.panel2.TabIndex = 14;
            // 
            // tbIdentity
            // 
            // 
            // 
            // 
            this.tbIdentity.Border.Class = "TextBoxBorder";
            this.tbIdentity.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbIdentity.Location = new System.Drawing.Point(3, 6);
            this.tbIdentity.Name = "tbIdentity";
            this.tbIdentity.PreventEnterBeep = true;
            this.tbIdentity.Size = new System.Drawing.Size(200, 22);
            this.tbIdentity.TabIndex = 9;
            this.superValidator.SetValidator1(this.tbIdentity, this.requiredFieldValidator3);
            this.tbIdentity.WatermarkText = "请输入FFP期次";
            // 
            // lblImport
            // 
            this.lblImport.AutoSize = true;
            // 
            // 
            // 
            this.lblImport.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblImport.Location = new System.Drawing.Point(52, 37);
            this.lblImport.Name = "lblImport";
            this.lblImport.Size = new System.Drawing.Size(172, 19);
            this.lblImport.TabIndex = 11;
            this.lblImport.Text = "正在导入第{0}/{1}条数据...";
            this.lblImport.Visible = false;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Command = this.cmdImport;
            this.buttonX1.Location = new System.Drawing.Point(208, 6);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 8;
            this.buttonX1.Text = "导入";
            // 
            // circularProgress
            // 
            // 
            // 
            // 
            this.circularProgress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.circularProgress.FocusCuesEnabled = false;
            this.circularProgress.Location = new System.Drawing.Point(3, 35);
            this.circularProgress.Name = "circularProgress";
            this.circularProgress.Size = new System.Drawing.Size(42, 23);
            this.circularProgress.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.circularProgress.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tbAnalyzeResult);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 48);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(462, 60);
            this.panel3.TabIndex = 15;
            // 
            // tbAnalyzeResult
            // 
            // 
            // 
            // 
            this.tbAnalyzeResult.Border.Class = "TextBoxBorder";
            this.tbAnalyzeResult.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbAnalyzeResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbAnalyzeResult.Location = new System.Drawing.Point(0, 0);
            this.tbAnalyzeResult.Multiline = true;
            this.tbAnalyzeResult.Name = "tbAnalyzeResult";
            this.tbAnalyzeResult.PreventEnterBeep = true;
            this.tbAnalyzeResult.ReadOnly = true;
            this.tbAnalyzeResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbAnalyzeResult.Size = new System.Drawing.Size(462, 60);
            this.tbAnalyzeResult.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbSheets);
            this.panel1.Controls.Add(this.tbFile);
            this.panel1.Controls.Add(this.btnOpenFile);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(462, 30);
            this.panel1.TabIndex = 8;
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
            this.tbFile.WatermarkText = "请选择WDS Response文件";
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
            // superValidator
            // 
            this.superValidator.ContainerControl = this;
            this.superValidator.ErrorProvider = this.errorProvider;
            this.superValidator.Highlighter = this.highlighter;
            // 
            // requiredFieldValidator2
            // 
            this.requiredFieldValidator2.ErrorMessage = "请选择要导入的Excel工作薄";
            this.requiredFieldValidator2.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.ErrorMessage = "请选择WDS Response文件";
            this.requiredFieldValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // requiredFieldValidator3
            // 
            this.requiredFieldValidator3.ErrorMessage = "请输入FFP期次";
            this.requiredFieldValidator3.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
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
            // WDSImportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelEx1);
            this.Name = "WDSImportControl";
            this.Size = new System.Drawing.Size(468, 211);
            this.panelEx1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private DevComponents.DotNetBar.Command cmdImport;
        private System.ComponentModel.BackgroundWorker bwImport;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.Controls.TextBoxX tbIdentity;
        private DevComponents.DotNetBar.LabelX lblImport;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.Controls.CircularProgress circularProgress;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbSheets;
        private DevComponents.DotNetBar.Controls.TextBoxX tbFile;
        private DevComponents.DotNetBar.ButtonX btnOpenFile;
        private System.Windows.Forms.Panel panel3;
        private DevComponents.DotNetBar.Controls.TextBoxX tbAnalyzeResult;
        private DevComponents.DotNetBar.Validator.SuperValidator superValidator;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator1;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator2;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator3;
    }
}

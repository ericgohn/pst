namespace PST.Plugins.WDSDispatcher.Controls
{
    partial class FFPImportControl
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
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.tbIdentity = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.cmdImport = new DevComponents.DotNetBar.Command(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbSheets = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.tbFile = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnOpenFile = new DevComponents.DotNetBar.ButtonX();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.bwImport = new System.ComponentModel.BackgroundWorker();
            this.circularProgress = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.lblImport = new DevComponents.DotNetBar.LabelX();
            this.panelEx1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.lblImport);
            this.panelEx1.Controls.Add(this.circularProgress);
            this.panelEx1.Controls.Add(this.tbIdentity);
            this.panelEx1.Controls.Add(this.buttonX1);
            this.panelEx1.Controls.Add(this.panel1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(664, 152);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // tbIdentity
            // 
            // 
            // 
            // 
            this.tbIdentity.Border.Class = "TextBoxBorder";
            this.tbIdentity.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbIdentity.Location = new System.Drawing.Point(4, 36);
            this.tbIdentity.Name = "tbIdentity";
            this.tbIdentity.PreventEnterBeep = true;
            this.tbIdentity.Size = new System.Drawing.Size(200, 22);
            this.tbIdentity.TabIndex = 9;
            this.tbIdentity.WatermarkText = "请输入FFP期次";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Command = this.cmdImport;
            this.buttonX1.Location = new System.Drawing.Point(209, 36);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 8;
            this.buttonX1.Text = "导入";
            // 
            // cmdImport
            // 
            this.cmdImport.Name = "cmdImport";
            this.cmdImport.Executed += new System.EventHandler(this.cmdImport_Executed);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbSheets);
            this.panel1.Controls.Add(this.tbFile);
            this.panel1.Controls.Add(this.btnOpenFile);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(664, 30);
            this.panel1.TabIndex = 7;
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
            // circularProgress
            // 
            // 
            // 
            // 
            this.circularProgress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.circularProgress.FocusCuesEnabled = false;
            this.circularProgress.Location = new System.Drawing.Point(4, 65);
            this.circularProgress.Name = "circularProgress";
            this.circularProgress.Size = new System.Drawing.Size(42, 23);
            this.circularProgress.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.circularProgress.TabIndex = 10;
            // 
            // lblImport
            // 
            this.lblImport.AutoSize = true;
            // 
            // 
            // 
            this.lblImport.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblImport.Location = new System.Drawing.Point(53, 67);
            this.lblImport.Name = "lblImport";
            this.lblImport.Size = new System.Drawing.Size(172, 19);
            this.lblImport.TabIndex = 11;
            this.lblImport.Text = "正在导入第{0}/{1}条数据...";
            // 
            // FFPImportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelEx1);
            this.Name = "FFPImportControl";
            this.Size = new System.Drawing.Size(664, 320);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.TextBoxX tbFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private DevComponents.DotNetBar.ButtonX btnOpenFile;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbSheets;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.Controls.TextBoxX tbIdentity;
        private DevComponents.DotNetBar.Command cmdImport;
        private System.ComponentModel.BackgroundWorker bwImport;
        private DevComponents.DotNetBar.Controls.CircularProgress circularProgress;
        private DevComponents.DotNetBar.LabelX lblImport;
    }
}

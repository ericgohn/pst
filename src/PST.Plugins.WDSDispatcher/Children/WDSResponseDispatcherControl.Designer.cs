namespace PST.Plugins.WDSDispatcher.Children
{
    partial class WDSResponseDispatcherControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WDSResponseDispatcherControl));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.importWDSExcelControl = new PST.Plugins.WDSDispatcher.Controls.ImportExcelControl();
            this.importFFPExcelControl = new PST.Plugins.WDSDispatcher.Controls.ImportExcelControl();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.buttonX4 = new DevComponents.DotNetBar.ButtonX();
            this.buttonItem4 = new DevComponents.DotNetBar.ButtonItem();
            this.cmdRemove = new DevComponents.DotNetBar.Command(this.components);
            this.buttonItem5 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem6 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.cmdImport = new DevComponents.DotNetBar.Command(this.components);
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
            this.lblMessage = new DevComponents.DotNetBar.LabelX();
            this.circularProgress = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.cmdDispatch = new DevComponents.DotNetBar.Command(this.components);
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.cmdGenerateIdentity = new DevComponents.DotNetBar.Command(this.components);
            this.tbSetName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.superValidator = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.requiredFieldValidator1 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("请输入期次");
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter = new DevComponents.DotNetBar.Validator.Highlighter();
            this.command3 = new DevComponents.DotNetBar.Command(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.importWDSExcelControl, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.importFFPExcelControl, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 253F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 253F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(980, 253);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // importWDSExcelControl
            // 
            this.importWDSExcelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.importWDSExcelControl.Location = new System.Drawing.Point(493, 3);
            this.importWDSExcelControl.Name = "importWDSExcelControl";
            this.importWDSExcelControl.Size = new System.Drawing.Size(484, 247);
            this.importWDSExcelControl.TabIndex = 7;
            this.importWDSExcelControl.Title = "WDS Response导入";
            this.importWDSExcelControl.WartermarkText = "请选择WDS Response文件";
            this.importWDSExcelControl.AsyncRun += new System.EventHandler<string>(this.importExcelControl_AsyncRun);
            this.importWDSExcelControl.AsyncRunComplete += new System.EventHandler<System.EventArgs>(this.importExcelControl_AsyncRunComplete);
            // 
            // importFFPExcelControl
            // 
            this.importFFPExcelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.importFFPExcelControl.Location = new System.Drawing.Point(3, 3);
            this.importFFPExcelControl.Name = "importFFPExcelControl";
            this.importFFPExcelControl.Size = new System.Drawing.Size(484, 247);
            this.importFFPExcelControl.TabIndex = 8;
            this.importFFPExcelControl.Title = "FFP导入";
            this.importFFPExcelControl.WartermarkText = "请选择FFP文件";
            this.importFFPExcelControl.AsyncRun += new System.EventHandler<string>(this.importExcelControl_AsyncRun);
            this.importFFPExcelControl.AsyncRunComplete += new System.EventHandler<System.EventArgs>(this.importExcelControl_AsyncRunComplete);
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.buttonX4);
            this.panelEx1.Controls.Add(this.buttonX3);
            this.panelEx1.Controls.Add(this.lblMessage);
            this.panelEx1.Controls.Add(this.circularProgress);
            this.panelEx1.Controls.Add(this.buttonX2);
            this.panelEx1.Controls.Add(this.buttonX1);
            this.panelEx1.Controls.Add(this.tbSetName);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 253);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(980, 111);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 3;
            // 
            // buttonX4
            // 
            this.buttonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX4.AutoExpandOnClick = true;
            this.buttonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX4.Location = new System.Drawing.Point(285, 16);
            this.buttonX4.Name = "buttonX4";
            this.buttonX4.Size = new System.Drawing.Size(75, 23);
            this.buttonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX4.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem4,
            this.buttonItem5,
            this.buttonItem6});
            this.buttonX4.TabIndex = 6;
            this.buttonX4.Text = "删除";
            // 
            // buttonItem4
            // 
            this.buttonItem4.Command = this.cmdRemove;
            this.buttonItem4.CommandParameter = "1";
            this.buttonItem4.GlobalItem = false;
            this.buttonItem4.Name = "buttonItem4";
            this.buttonItem4.Text = "FFP及WDS Response";
            // 
            // cmdRemove
            // 
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Executed += new System.EventHandler(this.cmdRemove_Executed);
            // 
            // buttonItem5
            // 
            this.buttonItem5.Command = this.cmdRemove;
            this.buttonItem5.CommandParameter = "2";
            this.buttonItem5.GlobalItem = false;
            this.buttonItem5.Name = "buttonItem5";
            this.buttonItem5.Text = "FFP Only";
            // 
            // buttonItem6
            // 
            this.buttonItem6.Command = this.cmdRemove;
            this.buttonItem6.CommandParameter = "3";
            this.buttonItem6.GlobalItem = false;
            this.buttonItem6.Name = "buttonItem6";
            this.buttonItem6.Text = "WDS Response Only";
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.AutoExpandOnClick = true;
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX3.Location = new System.Drawing.Point(203, 17);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(75, 23);
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX3.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem1,
            this.buttonItem2,
            this.buttonItem3});
            this.buttonX3.TabIndex = 5;
            this.buttonX3.Text = "导入";
            // 
            // buttonItem1
            // 
            this.buttonItem1.Command = this.cmdImport;
            this.buttonItem1.CommandParameter = "1";
            this.buttonItem1.GlobalItem = false;
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "FFP及WDS Response";
            // 
            // cmdImport
            // 
            this.cmdImport.Name = "cmdImport";
            this.cmdImport.Executed += new System.EventHandler(this.cmdImport_Executed);
            // 
            // buttonItem2
            // 
            this.buttonItem2.Command = this.cmdImport;
            this.buttonItem2.CommandParameter = "2";
            this.buttonItem2.GlobalItem = false;
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.Text = "FFP Only";
            // 
            // buttonItem3
            // 
            this.buttonItem3.Command = this.cmdImport;
            this.buttonItem3.CommandParameter = "3";
            this.buttonItem3.GlobalItem = false;
            this.buttonItem3.Name = "buttonItem3";
            this.buttonItem3.Text = "WDS Response Only";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            // 
            // 
            // 
            this.lblMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblMessage.Location = new System.Drawing.Point(143, 55);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(75, 19);
            this.lblMessage.TabIndex = 4;
            this.lblMessage.Text = "lblMessage";
            this.lblMessage.Visible = false;
            // 
            // circularProgress
            // 
            // 
            // 
            // 
            this.circularProgress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.circularProgress.FocusCuesEnabled = false;
            this.circularProgress.Location = new System.Drawing.Point(97, 53);
            this.circularProgress.Name = "circularProgress";
            this.circularProgress.Size = new System.Drawing.Size(39, 23);
            this.circularProgress.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.circularProgress.TabIndex = 3;
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Command = this.cmdDispatch;
            this.buttonX2.Location = new System.Drawing.Point(15, 54);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(75, 23);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 2;
            this.buttonX2.Text = "Dispatch";
            // 
            // cmdDispatch
            // 
            this.cmdDispatch.Name = "cmdDispatch";
            this.cmdDispatch.Executed += new System.EventHandler(this.cmdDispatch_Executed);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Command = this.cmdGenerateIdentity;
            this.buttonX1.Location = new System.Drawing.Point(122, 17);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 1;
            this.buttonX1.Text = "生成";
            // 
            // cmdGenerateIdentity
            // 
            this.cmdGenerateIdentity.Name = "cmdGenerateIdentity";
            this.cmdGenerateIdentity.Executed += new System.EventHandler(this.cmdGenerateIdentity_Executed);
            // 
            // tbSetName
            // 
            this.tbSetName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tbSetName.Border.Class = "TextBoxBorder";
            this.tbSetName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbSetName.DisabledBackColor = System.Drawing.Color.White;
            this.tbSetName.ForeColor = System.Drawing.Color.Black;
            this.tbSetName.Location = new System.Drawing.Point(15, 17);
            this.tbSetName.Name = "tbSetName";
            this.tbSetName.PreventEnterBeep = true;
            this.tbSetName.Size = new System.Drawing.Size(100, 22);
            this.tbSetName.TabIndex = 0;
            this.superValidator.SetValidator1(this.tbSetName, this.requiredFieldValidator1);
            this.tbSetName.WatermarkText = "请输入期次";
            // 
            // superValidator
            // 
            this.superValidator.ContainerControl = this;
            this.superValidator.ErrorProvider = this.errorProvider;
            this.superValidator.Highlighter = this.highlighter;
            // 
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.ErrorMessage = "请输入期次";
            this.requiredFieldValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
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
            // command3
            // 
            this.command3.Name = "command3";
            // 
            // WDSResponseDispatcherControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "WDSResponseDispatcherControl";
            this.Size = new System.Drawing.Size(980, 674);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.TextBoxX tbSetName;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.LabelX lblMessage;
        private DevComponents.DotNetBar.Controls.CircularProgress circularProgress;
        private DevComponents.DotNetBar.Command cmdDispatch;
        private Controls.ImportExcelControl importWDSExcelControl;
        private Controls.ImportExcelControl importFFPExcelControl;
        private DevComponents.DotNetBar.Validator.SuperValidator superValidator;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator1;
        private DevComponents.DotNetBar.Command cmdGenerateIdentity;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
        private DevComponents.DotNetBar.ButtonItem buttonItem3;
        private DevComponents.DotNetBar.Command cmdImport;
        private DevComponents.DotNetBar.Command cmdRemove;
        private DevComponents.DotNetBar.Command command3;
        private DevComponents.DotNetBar.ButtonX buttonX4;
        private DevComponents.DotNetBar.ButtonItem buttonItem4;
        private DevComponents.DotNetBar.ButtonItem buttonItem5;
        private DevComponents.DotNetBar.ButtonItem buttonItem6;
    }
}

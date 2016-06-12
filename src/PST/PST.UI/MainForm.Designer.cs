namespace PST.UI
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ribbonControl1 = new DevComponents.DotNetBar.RibbonControl();
            this.rpModule = new DevComponents.DotNetBar.RibbonPanel();
            this.rbModules = new DevComponents.DotNetBar.RibbonBar();
            this.rtiModules = new DevComponents.DotNetBar.RibbonTabItem();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.qatCustomizeItem1 = new DevComponents.DotNetBar.QatCustomizeItem();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.statusBar = new DevComponents.DotNetBar.Bar();
            this.statusBarText = new DevComponents.DotNetBar.LabelItem();
            this.statusBarProgress = new DevComponents.DotNetBar.ProgressBarItem();
            this.StatusBarUser = new DevComponents.DotNetBar.LabelItem();
            this.statusBarSlider = new DevComponents.DotNetBar.SliderItem();
            this.cmdStatusBarSlider = new DevComponents.DotNetBar.Command(this.components);
            this.StatusBarInfo = new DevComponents.DotNetBar.LabelItem();
            this.stcMain = new DevComponents.DotNetBar.SuperTabControl();
            this.cmdModule = new DevComponents.DotNetBar.Command(this.components);
            this.ribbonControl1.SuspendLayout();
            this.rpModule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stcMain)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.ribbonControl1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonControl1.CaptionVisible = true;
            this.ribbonControl1.Controls.Add(this.rpModule);
            this.ribbonControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonControl1.Expanded = false;
            this.ribbonControl1.ForeColor = System.Drawing.Color.Black;
            this.ribbonControl1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.rtiModules});
            this.ribbonControl1.KeyTipsFont = new System.Drawing.Font("Tahoma", 7F);
            this.ribbonControl1.Location = new System.Drawing.Point(5, 1);
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.QuickToolbarItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem1,
            this.qatCustomizeItem1});
            this.ribbonControl1.Size = new System.Drawing.Size(791, 154);
            this.ribbonControl1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonControl1.SystemText.MaximizeRibbonText = "&Maximize the Ribbon";
            this.ribbonControl1.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon";
            this.ribbonControl1.SystemText.QatAddItemText = "&Add to Quick Access Toolbar";
            this.ribbonControl1.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>";
            this.ribbonControl1.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar...";
            this.ribbonControl1.SystemText.QatDialogAddButton = "&Add >>";
            this.ribbonControl1.SystemText.QatDialogCancelButton = "Cancel";
            this.ribbonControl1.SystemText.QatDialogCaption = "Customize Quick Access Toolbar";
            this.ribbonControl1.SystemText.QatDialogCategoriesLabel = "&Choose commands from:";
            this.ribbonControl1.SystemText.QatDialogOkButton = "OK";
            this.ribbonControl1.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon";
            this.ribbonControl1.SystemText.QatDialogRemoveButton = "&Remove";
            this.ribbonControl1.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon";
            this.ribbonControl1.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon";
            this.ribbonControl1.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar";
            this.ribbonControl1.TabGroupHeight = 14;
            this.ribbonControl1.TabIndex = 0;
            // 
            // rpModule
            // 
            this.rpModule.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.rpModule.Controls.Add(this.rbModules);
            this.rpModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpModule.Location = new System.Drawing.Point(0, 54);
            this.rpModule.Name = "rpModule";
            this.rpModule.Padding = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.rpModule.Size = new System.Drawing.Size(791, 100);
            this.rpModule.StretchLastRibbonBar = true;
            // 
            // 
            // 
            this.rpModule.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.rpModule.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.rpModule.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rpModule.TabIndex = 1;
            // 
            // rbModules
            // 
            this.rbModules.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.rbModules.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.rbModules.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbModules.ContainerControlProcessDialogKey = true;
            this.rbModules.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbModules.DragDropSupport = true;
            this.rbModules.Location = new System.Drawing.Point(3, 0);
            this.rbModules.Name = "rbModules";
            this.rbModules.Size = new System.Drawing.Size(100, 98);
            this.rbModules.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.rbModules.TabIndex = 0;
            this.rbModules.Text = "模块";
            // 
            // 
            // 
            this.rbModules.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.rbModules.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // rtiModules
            // 
            this.rtiModules.Checked = true;
            this.rtiModules.Name = "rtiModules";
            this.rtiModules.Panel = this.rpModule;
            this.rtiModules.Text = "模块";
            // 
            // buttonItem1
            // 
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "菜单";
            // 
            // qatCustomizeItem1
            // 
            this.qatCustomizeItem1.Name = "qatCustomizeItem1";
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.Black);
            // 
            // statusBar
            // 
            this.statusBar.AccessibleRole = System.Windows.Forms.AccessibleRole.StatusBar;
            this.statusBar.AntiAlias = true;
            this.statusBar.BarType = DevComponents.DotNetBar.eBarType.StatusBar;
            this.statusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusBar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.statusBar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.statusBarText,
            this.statusBarProgress,
            this.StatusBarUser,
            this.statusBarSlider,
            this.StatusBarInfo});
            this.statusBar.Location = new System.Drawing.Point(5, 427);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(791, 26);
            this.statusBar.Stretch = true;
            this.statusBar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.statusBar.TabIndex = 2;
            this.statusBar.TabStop = false;
            this.statusBar.Text = "bar1";
            // 
            // statusBarText
            // 
            this.statusBarText.Name = "statusBarText";
            this.statusBarText.Text = "就绪";
            // 
            // statusBarProgress
            // 
            // 
            // 
            // 
            this.statusBarProgress.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.statusBarProgress.BeginGroup = true;
            this.statusBarProgress.ChunkGradientAngle = 0F;
            this.statusBarProgress.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.statusBarProgress.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.statusBarProgress.Name = "statusBarProgress";
            this.statusBarProgress.ProgressType = DevComponents.DotNetBar.eProgressItemType.Marquee;
            this.statusBarProgress.RecentlyUsed = false;
            this.statusBarProgress.Visible = false;
            // 
            // StatusBarUser
            // 
            this.StatusBarUser.BeginGroup = true;
            this.StatusBarUser.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.StatusBarUser.Name = "StatusBarUser";
            this.StatusBarUser.PaddingRight = 20;
            this.StatusBarUser.Text = "Eric";
            // 
            // statusBarSlider
            // 
            this.statusBarSlider.BeginGroup = true;
            this.statusBarSlider.Command = this.cmdStatusBarSlider;
            this.statusBarSlider.Maximum = 10;
            this.statusBarSlider.Name = "statusBarSlider";
            this.statusBarSlider.Value = 0;
            // 
            // cmdStatusBarSlider
            // 
            this.cmdStatusBarSlider.Name = "cmdStatusBarSlider";
            this.cmdStatusBarSlider.Executed += new System.EventHandler(this.cmdStatusBarSlider_Executed);
            // 
            // StatusBarInfo
            // 
            this.StatusBarInfo.BeginGroup = true;
            this.StatusBarInfo.Name = "StatusBarInfo";
            this.StatusBarInfo.PaddingRight = 20;
            this.StatusBarInfo.Text = "Stock Assistant Version 1.1";
            // 
            // stcMain
            // 
            this.stcMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.stcMain.CloseButtonOnTabsVisible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.stcMain.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.stcMain.ControlBox.MenuBox.Name = "";
            this.stcMain.ControlBox.Name = "";
            this.stcMain.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.stcMain.ControlBox.MenuBox,
            this.stcMain.ControlBox.CloseBox});
            this.stcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stcMain.ForeColor = System.Drawing.Color.Black;
            this.stcMain.Location = new System.Drawing.Point(5, 155);
            this.stcMain.Name = "stcMain";
            this.stcMain.ReorderTabsEnabled = true;
            this.stcMain.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.stcMain.SelectedTabIndex = 0;
            this.stcMain.Size = new System.Drawing.Size(791, 272);
            this.stcMain.TabFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.stcMain.TabIndex = 11;
            this.stcMain.TabItemClose += new System.EventHandler<DevComponents.DotNetBar.SuperTabStripTabItemCloseEventArgs>(this.stcMain_TabItemClose);
            // 
            // cmdModule
            // 
            this.cmdModule.Name = "cmdModule";
            this.cmdModule.Executed += new System.EventHandler(this.cmdModule_Executed);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(801, 455);
            this.Controls.Add(this.stcMain);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.ribbonControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "PST";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ribbonControl1.ResumeLayout(false);
            this.ribbonControl1.PerformLayout();
            this.rpModule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.statusBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stcMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.RibbonControl ribbonControl1;
        private DevComponents.DotNetBar.RibbonPanel rpModule;
        private DevComponents.DotNetBar.RibbonTabItem rtiModules;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.QatCustomizeItem qatCustomizeItem1;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.Bar statusBar;
        private DevComponents.DotNetBar.LabelItem statusBarText;
        private DevComponents.DotNetBar.ProgressBarItem statusBarProgress;
        private DevComponents.DotNetBar.LabelItem StatusBarUser;
        private DevComponents.DotNetBar.LabelItem StatusBarInfo;
        private DevComponents.DotNetBar.SuperTabControl stcMain;
        private DevComponents.DotNetBar.Command cmdModule;
        private DevComponents.DotNetBar.RibbonBar rbModules;
        private DevComponents.DotNetBar.SliderItem statusBarSlider;
        private DevComponents.DotNetBar.Command cmdStatusBarSlider;
    }
}
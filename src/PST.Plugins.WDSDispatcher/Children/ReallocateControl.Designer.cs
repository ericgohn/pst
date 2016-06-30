namespace PST.Plugins.WDSDispatcher.Children
{
    partial class ReallocateControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.tbCicName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.cmdSearchFfpPno = new DevComponents.DotNetBar.Command(this.components);
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.lbFfpPno = new DevComponents.DotNetBar.ListBoxAdv();
            this.lbSeries = new DevComponents.DotNetBar.ListBoxAdv();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.dgvList = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.lbSeries);
            this.panelEx1.Controls.Add(this.labelX3);
            this.panelEx1.Controls.Add(this.lbFfpPno);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.buttonX1);
            this.panelEx1.Controls.Add(this.tbCicName);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1037, 142);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(4, 4);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(80, 19);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "CIC Name: ";
            // 
            // tbCicName
            // 
            // 
            // 
            // 
            this.tbCicName.Border.Class = "TextBoxBorder";
            this.tbCicName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbCicName.Location = new System.Drawing.Point(4, 33);
            this.tbCicName.Name = "tbCicName";
            this.tbCicName.PreventEnterBeep = true;
            this.tbCicName.Size = new System.Drawing.Size(200, 22);
            this.tbCicName.TabIndex = 1;
            this.tbCicName.Text = "45W19V-2pin(DOE)";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Command = this.cmdSearchFfpPno;
            this.buttonX1.Location = new System.Drawing.Point(4, 61);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 2;
            this.buttonX1.Text = "Search";
            // 
            // cmdSearchFfpPno
            // 
            this.cmdSearchFfpPno.Name = "cmdSearchFfpPno";
            this.cmdSearchFfpPno.Executed += new System.EventHandler(this.cmdSearchFfpPno_Executed);
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(210, 3);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(68, 19);
            this.labelX2.TabIndex = 3;
            this.labelX2.Text = "FFP PNO:";
            // 
            // lbFfpPno
            // 
            this.lbFfpPno.AutoScroll = true;
            // 
            // 
            // 
            this.lbFfpPno.BackgroundStyle.Class = "ListBoxAdv";
            this.lbFfpPno.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbFfpPno.CheckStateMember = null;
            this.lbFfpPno.ContainerControlProcessDialogKey = true;
            this.lbFfpPno.DragDropSupport = true;
            this.lbFfpPno.Location = new System.Drawing.Point(210, 33);
            this.lbFfpPno.Name = "lbFfpPno";
            this.lbFfpPno.Size = new System.Drawing.Size(200, 94);
            this.lbFfpPno.TabIndex = 4;
            this.lbFfpPno.Text = "listBoxAdv1";
            this.lbFfpPno.ItemDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbFfpPno_ItemDoubleClick);
            // 
            // lbSeries
            // 
            this.lbSeries.AutoScroll = true;
            // 
            // 
            // 
            this.lbSeries.BackgroundStyle.Class = "ListBoxAdv";
            this.lbSeries.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbSeries.ContainerControlProcessDialogKey = true;
            this.lbSeries.DragDropSupport = true;
            this.lbSeries.Location = new System.Drawing.Point(424, 34);
            this.lbSeries.Name = "lbSeries";
            this.lbSeries.Size = new System.Drawing.Size(200, 94);
            this.lbSeries.TabIndex = 6;
            this.lbSeries.Text = "listBoxAdv1";
            this.lbSeries.ItemDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbSeries_ItemDoubleClick);
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(424, 4);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(49, 19);
            this.labelX3.TabIndex = 5;
            this.labelX3.Text = "Series:";
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx2.Location = new System.Drawing.Point(0, 424);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(1037, 49);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 4;
            this.panelEx2.Text = "panelEx2";
            // 
            // dgvList
            // 
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvList.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvList.Location = new System.Drawing.Point(0, 142);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowTemplate.Height = 24;
            this.dgvList.Size = new System.Drawing.Size(1037, 282);
            this.dgvList.TabIndex = 8;
            // 
            // ReallocateControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.panelEx1);
            this.Name = "ReallocateControl";
            this.Size = new System.Drawing.Size(1037, 473);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX tbCicName;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.Command cmdSearchFfpPno;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.ListBoxAdv lbFfpPno;
        private DevComponents.DotNetBar.ListBoxAdv lbSeries;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvList;
    }
}

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
            this.ffpImportControl1 = new PST.Plugins.WDSDispatcher.Controls.FFPImportControl();
            this.wdsImportControl1 = new PST.Plugins.WDSDispatcher.Controls.WDSImportControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ffpImportControl1
            // 
            this.ffpImportControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ffpImportControl1.Location = new System.Drawing.Point(3, 3);
            this.ffpImportControl1.Name = "ffpImportControl1";
            this.ffpImportControl1.Size = new System.Drawing.Size(484, 188);
            this.ffpImportControl1.TabIndex = 0;
            // 
            // wdsImportControl1
            // 
            this.wdsImportControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wdsImportControl1.Location = new System.Drawing.Point(493, 3);
            this.wdsImportControl1.Name = "wdsImportControl1";
            this.wdsImportControl1.Size = new System.Drawing.Size(484, 188);
            this.wdsImportControl1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.ffpImportControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.wdsImportControl1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(980, 194);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // WDSResponseDispatcherControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "WDSResponseDispatcherControl";
            this.Size = new System.Drawing.Size(980, 516);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.FFPImportControl ffpImportControl1;
        private Controls.WDSImportControl wdsImportControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

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
            this.SuspendLayout();
            // 
            // ffpImportControl1
            // 
            this.ffpImportControl1.Location = new System.Drawing.Point(14, 19);
            this.ffpImportControl1.Name = "ffpImportControl1";
            this.ffpImportControl1.Size = new System.Drawing.Size(450, 185);
            this.ffpImportControl1.TabIndex = 0;
            // 
            // WDSResponseDispatcherControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ffpImportControl1);
            this.Name = "WDSResponseDispatcherControl";
            this.Size = new System.Drawing.Size(647, 272);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.FFPImportControl ffpImportControl1;
    }
}

namespace PST.Plugins.WDSDispatcher
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
            this.wdsResponseDispatcherControl1 = new PST.Plugins.WDSDispatcher.Children.WDSResponseDispatcherControl();
            this.SuspendLayout();
            // 
            // wdsResponseDispatcherControl1
            // 
            this.wdsResponseDispatcherControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wdsResponseDispatcherControl1.Location = new System.Drawing.Point(0, 0);
            this.wdsResponseDispatcherControl1.Name = "wdsResponseDispatcherControl1";
            this.wdsResponseDispatcherControl1.Size = new System.Drawing.Size(844, 414);
            this.wdsResponseDispatcherControl1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 414);
            this.Controls.Add(this.wdsResponseDispatcherControl1);
            this.Name = "MainForm";
            this.Text = "WDS Response Dispatcher";
            this.ResumeLayout(false);

        }

        #endregion

        private Children.WDSResponseDispatcherControl wdsResponseDispatcherControl1;
    }
}


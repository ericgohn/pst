//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: DialogFormBase.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Validator;
using Zeexone.Framework.Windows.Mementos;
using Padding = System.Windows.Forms.Padding;

namespace PST.UI.Common
{
    public class DialogFormBase : Office2007Form
    {
        private AutoScaleMode _autoScaleMode = AutoScaleMode.Inherit;
        private SuperValidator _validator;
        protected IMemento memento;
        protected readonly TaskScheduler uiThreadTaskScheduler = TaskScheduler.FromCurrentSynchronizationContext();

        public DialogFormBase()
        {
            InitializeComponent();
        }

        public new AutoScaleMode AutoScaleMode
        {
            get { return _autoScaleMode; }
            set { base.AutoScaleMode = _autoScaleMode; }
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // DialogFormBase
            // 
            ClientSize = new Size(282, 253);
            DoubleBuffered = true;
            EnableGlass = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DialogFormBase";
            Padding = new Padding(5);
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            ResumeLayout(false);
        }

        /// <summary>
        ///     Register super validator control so that super validator control won't prevent
        ///     form closing when user wants to close the form.
        /// </summary>
        /// <param name="validator"></param>
        protected void HookSuperValidator(SuperValidator validator)
        {
            _validator = validator;
        }

        /// <summary>
        ///     引发 <see cref="E:System.Windows.Forms.Form.FormClosing" /> 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.Windows.Forms.FormClosingEventArgs" />。</param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_validator != null)
                _validator.Enabled = DialogResult == DialogResult.OK;
            base.OnFormClosing(e);
        }
    }
}
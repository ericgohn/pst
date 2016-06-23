//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: MainForm.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Zeexone.Framework.Windows;
using Zeexone.Framework.Windows.Framework;
using Zeexone.Framework.Windows.Mdi;

namespace PST.UI
{
    public partial class MainForm : RibbonForm
    {
        private readonly float _defaultFontSize;
        private readonly PluginManager _pluginManager = new PluginManager();

        public MainForm()
        {
            InitializeComponent();
//            _defaultFontSize = Font.Size;
        }

        #region Command Events

        private void cmdModule_Executed(object sender, EventArgs e)
        {
            var button = sender as ButtonItem;
            if (button == null)
                return;
            var parameter = button.CommandParameter as string;
            if (parameter == null)
                return;
            var plugin = _pluginManager.GetPlugin(parameter);
            if (plugin == null)
                return;
            //遍历现有的Tab页面，如果存在，那么设置为选中即可
            foreach (SuperTabItem tabitem in stcMain.Tabs)
            {
                if (tabitem.Name == plugin.Key)
                {
                    stcMain.SelectedTab = tabitem;
                    return;
                }
            }

            var form = _pluginManager.FindOrCreatePluginMainForm(plugin);
            if (form == null)
                return;
            ((IPluginWindow) form).PluginContext.User = AppContext.S.User;
            ((IPluginWindow) form).BackgroundRunning += PluginForm_BackgroundRunning;
            ((IPluginWindow) form).Argument = ribbonControl1;
//            form.WindowState = FormWindowState.Maximized;
            SuperTabItem tabItem = stcMain.CreateTab(form.Text);
            tabItem.Name = plugin.Key;
            tabItem.AttachedControl.Controls.Add(form);
            var mergable = form as IMergable;
            if (mergable != null)
            {
                mergable.Merge();
            }
            //设置Visible属性会导致OnLoad事件触发，故放在此处
            form.Visible = true;
            stcMain.SelectedTab = tabItem;
        }


        private void cmdStatusBarSlider_Executed(object sender, EventArgs e)
        {
            var value = statusBarSlider.Value;
            float multiple = 1f + ((float) value)/10;
//            Font = new Font(Font.FontFamily, _defaultFontSize*multiple);
        }

        #endregion

        #region Control Events

        private void MainForm_Load(object sender, EventArgs e)
        {
            StatusBarUser.Text = AppContext.S.User.Name;
            _pluginManager.LoadPlugins();
            ButtonItem portfolioMangerPluginButton = null;
            foreach (var item in _pluginManager.Plugins)
            {
                var button = new ButtonItem {Text = item.Name};
                rbModules.Items.Add(button);
                button.CommandParameter = item.Key;
                button.Command = cmdModule;

                if (item.Key == "B511EEB9-BBB9-4720-B4A1-53F8EDE09E59")
                    portfolioMangerPluginButton = button;
            }
            rpModule.Dock = DockStyle.Fill;
            rpModule.Refresh();

            //默认启动组合管理
            if (portfolioMangerPluginButton != null)
                portfolioMangerPluginButton.RaiseClick();
        }

        private void PluginForm_BackgroundRunning(object sender, BackgroundRunningEventArgs e)
        {
            if (e.IsRunning)
            {
                statusBarProgress.Visible = true;
                statusBarText.Text = string.IsNullOrEmpty(e.Message) ? "���ڴ���....." : e.Message;
            }
            else
            {
                statusBarText.Text = "����";
                statusBarProgress.Visible = false;
            }
        }

        private void stcMain_TabItemClose(object sender, SuperTabStripTabItemCloseEventArgs e)
        {
            var key = e.Tab.Name;
            var form = _pluginManager.FindPluginMainForm(key);
            var mergeable = form as IMergable;
            if (mergeable != null)
            {
                mergeable.Unmerge();
            }
            _pluginManager.RemovePluginMainForm(key);
        }

        #endregion
    }
}
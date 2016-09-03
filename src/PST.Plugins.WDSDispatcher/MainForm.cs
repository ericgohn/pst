//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: MainForm.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using Zeexone.Framework.Windows.Framework;

namespace PST.Plugins.WDSDispatcher
{
    public partial class MainForm : PluginWindowBase
    {
        public MainForm()
        {
            InitializeComponent();
            AutoMapperBootstrap.InitializeMap();
            PluginContext = WDSDispatcherPluginContext.S;
        }
    }
}
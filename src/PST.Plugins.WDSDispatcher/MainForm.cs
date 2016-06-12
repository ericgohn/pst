//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: MainForm.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zeexone.Framework.Windows.Framework;

namespace PST.Plugins.WDSDispatcher
{
    public partial class MainForm : PluginWindowBase
    {
        public MainForm()
        {
            InitializeComponent();
            PluginContext = WDSDispatcherPluginContext.S;
        }
    }
}

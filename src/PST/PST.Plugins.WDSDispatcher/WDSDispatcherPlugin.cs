//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: WDSDispatcherPlugin.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System;
using System.Collections.Generic;
using Zeexone.Framework.Windows.Framework;

namespace PST.Plugins.WDSDispatcher
{
    public class WDSDispatcherPlugin : IPlugin
    {
        private readonly List<IModule> _modules = new List<IModule>();

        public string Key
        {
            get { return "9fe76887-71da-4dc0-81d5-0feeed698f14"; }
        }

        public string Name
        {
            get { return "WDSDispatcher"; }
        }

        public Type MainFormType
        {
            get { return typeof (MainForm); }
        }

        public List<IModule> Modules
        {
            get { return _modules; }
        }

        /// <summary>
        ///     安装插件
        /// </summary>
        public void Install()
        {
        }
    }
}
//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: UserControlBase.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System.Threading.Tasks;
using System.Windows.Forms;

namespace PST.Plugins.WDSDispatcher.Controls
{
    public class UserControlBase : UserControl
    {
        protected readonly TaskScheduler uiTaskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
    }
}
//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: WDSResponseDispatcherControl.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System.Threading.Tasks;
using System.Windows.Forms;

namespace PST.Plugins.WDSDispatcher.Children
{
    public partial class WDSResponseDispatcherControl : UserControl
    {
        public WDSResponseDispatcherControl()
        {
            InitializeComponent();
        }

        private void ImportFFP()
        {
        }

        private async void cmdDispatch_Executed(object sender, System.EventArgs e)
        {
            await ffpImportControl.ImportData("1");
            wdsImportControl.ImportData("1");
        }
    }
}
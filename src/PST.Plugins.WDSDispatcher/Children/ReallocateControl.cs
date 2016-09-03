//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: ReallocateControl.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PST.Plugins.WDSDispatcher.ViewModels;
using PST.UI.Common;
using PST.UI.Common.Helpers;

namespace PST.Plugins.WDSDispatcher.Children
{
    public partial class ReallocateControl : UserControl
    {
        public ReallocateControl()
        {
            InitializeComponent();
        }

        private async void cmdSearchFfpPno_Executed(object sender, EventArgs e)
        {
            var cicName = tbCicName.Text.Trim();
            var service = ServiceFactory.S.GetFFPService();
            var ffpPnos = await service.FindFfpPnoByCicNameAsync(cicName);
            lbFfpPno.Items.Clear();
            foreach (var p in ffpPnos.Arg)
            {
                lbFfpPno.Items.Add(p);
            }
        }

        private async void lbFfpPno_ItemDoubleClick(object sender, MouseEventArgs e)
        {
            var ffpPno = lbFfpPno.SelectedItem as string;
            if (string.IsNullOrEmpty(ffpPno))
                return;
            var service = ServiceFactory.S.GetFFPService();
            var series = await service.FindSeriesByFfpPnoAsync(ffpPno);
            lbSeries.Items.Clear();
            foreach (var s in series.Arg)
            {
                lbSeries.Items.Add(s);
            }
        }

        private async void lbSeries_ItemDoubleClick(object sender, MouseEventArgs e)
        {
            var series = lbSeries.SelectedItem as string;
            if (string.IsNullOrEmpty(series))
                return;
            var service = ServiceFactory.S.GetFFPService();
//            var res = await service.FindBySeriesAsync(series);
            var res = await service.FindSummarizedFfpBySeriesAsync(series);
            if (!res.Success)
            {
                DialogHelper.ShowLoadError(res.Message);
                return;
            }
            var items = AutoMapperBootstrap.M.Map<List<SummarizedFFPVm>>(res.Arg);
            foreach (var item in items)
            {
                item.ShippedQty = item.ShippedQty/(item.ItemCount/item.Factor);
                item.RevisedQty = item.ShippedQty;
            }
            dgvList.DataSource = items;
        }
    }
}
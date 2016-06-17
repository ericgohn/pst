//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: WDSExcelImporter.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using PST.UI.Common;
using PST.UI.Common.WDResponseService;

namespace PST.Plugins.WDSDispatcher.Excels
{
    public class WDSExcelImporter : ExcelImporter
    {
        private readonly IWDResponseService _service;

        public WDSExcelImporter(string filePath, string sheetName) : base(filePath, sheetName, "WDSResponse")
        {
            _service = ServiceFactory.S.GetWDResponseService();
        }

        protected override void DoProcessData(string sql)
        {
            _service.AddItems(sql);
        }
    }
}
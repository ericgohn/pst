//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: FFPExcelImporter.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using PST.UI.Common;
using PST.UI.Common.FFPService;

namespace PST.Plugins.WDSDispatcher.Excels
{
    public class FFPExcelImporter : ExcelImporter
    {
        private readonly IFFPService _service;

        public FFPExcelImporter(string filePath, string sheetName) : base(filePath, sheetName, "FFP")
        {
            _service = ServiceFactory.S.GetFFPService();
        }

        protected override void DoProcessData(string sql)
        {
            _service.AddItems(sql);
        }

        protected override void RemoveExists(int setId)
        {
            _service.RemoveBySetId(setId);
        }
    }
}
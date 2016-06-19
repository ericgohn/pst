//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: WDSExcelImporter.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System;
using System.Text;
using PST.UI.Common;
using PST.UI.Common.WDResponseService;

namespace PST.Plugins.WDSDispatcher.Excels
{
    public class WDSExcelImporter : ExcelImporter
    {
        private const string PREFIX = "('{0}',{1},{2},{3},";
        private const string COL_PREFIX = "[Id],[FFPSetId],[Seq],[Dispatched],";
        private readonly IWDResponseService _service;

        public WDSExcelImporter(string filePath, string sheetName) : base(filePath, sheetName, "WDSResponse")
        {
            _service = ServiceFactory.S.GetWDResponseService();
        }

        protected override string ColNamesPrefix
        {
            get { return COL_PREFIX; }
        }

        protected override void DoProcessData(string sql)
        {
            _service.AddItems(sql);
        }

        protected override StringBuilder GetRowPrefix(int setId, int seq)
        {
            return new StringBuilder(string.Format(PREFIX, Guid.NewGuid(), setId, seq, 0));
        }

        protected override void RemoveExists(int setId)
        {
            _service.RemoveBySetId(setId);
        }
    }
}
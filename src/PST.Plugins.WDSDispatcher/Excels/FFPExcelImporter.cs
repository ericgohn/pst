//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: FFPExcelImporter.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System;
using System.Text;
using PST.UI.Common;
using PST.UI.Common.FFPService;

namespace PST.Plugins.WDSDispatcher.Excels
{
    public class FFPExcelImporter : ExcelImporter
    {
        private const string PREFIX = "('{0}',{1},{2},{3},{4},";
        private const string COL_PREFIX = "[Id],[FFPSetId],[Seq],[Dispatched],";
        private readonly IFFPService _service;

        public FFPExcelImporter(string filePath, string sheetName) : base(filePath, sheetName, "FFP")
        {
            _service = ServiceFactory.S.GetFFPService();
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
            return new StringBuilder(string.Format(PREFIX, Guid.NewGuid(), setId, seq, 0, 0));
        }

        protected override void RemoveExists(int setId)
        {
            _service.RemoveBySetId(setId);
        }
    }
}
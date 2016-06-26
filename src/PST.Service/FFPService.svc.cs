﻿//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: FFPService.svc.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System.Collections.Generic;
using PST.Business;
using PST.Domain;
using Zeexone.Framework.Core.WCF;

namespace PST.Service
{
    [GlobalExceptionBehavior(typeof (GlobalExceptionHandler))]
    public class FFPService : IFFPService
    {
        private readonly FFPApp _app = new FFPApp();

        public Response AddItems(string sql)
        {
            return _app.Import(sql);
        }

        public Response RemoveBySetId(int setId)
        {
            return _app.RemoveBySetId(setId);
        }

        public Response RemoveBySetName(string name)
        {
            return _app.RemoveBySetName(name);
        }

        public Response<List<string>> GetSqlData(int currentPage, int itemsPerPage, int ffpSetId)
        {
            return _app.GetSqlData(currentPage, itemsPerPage, ffpSetId);
        }
    }
}
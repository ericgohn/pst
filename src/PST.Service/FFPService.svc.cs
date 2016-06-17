//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: FFPService.svc.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System;
using System.Collections.Generic;
using PST.Business;
using PST.Domain;
using Zeexone.Framework.Core.WCF;

namespace PST.Service
{
    [GlobalExceptionBehavior(typeof(GlobalExceptionHandler))]
    public class FFPService : IFFPService
    {
        private readonly FFPApp _app = new FFPApp();

        public Response<Guid> Add(FFP item)
        {
            return _app.Add(item);
        }

        public Response AddFfp(string sql)
        {
            return _app.Import(sql);
        }
    }
}
//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: FFPSetService.svc.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using PST.Business;
using PST.Domain;
using Zeexone.Framework.Core.WCF;

namespace PST.Service
{
    [GlobalExceptionBehavior(typeof (GlobalExceptionHandler))]
    public class FFPSetService : IFFPSetService
    {
        private readonly FFPSetApp _app = new FFPSetApp();

        public Response<bool> HasData(string setName)
        {
            return _app.HasData(setName);
        }

        public Response<int> Upsert(string setName)
        {
            return _app.Upsert(setName);
        }
    }
}
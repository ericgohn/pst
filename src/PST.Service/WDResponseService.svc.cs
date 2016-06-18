//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: WDResponseService.svc.cs
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
    public class WDResponseService : IWDResponseService
    {
        private readonly WDSResponseApp _app = new WDSResponseApp();

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
    }
}
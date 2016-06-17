//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: IFFPService.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System;
using System.ServiceModel;
using PST.Domain;

namespace PST.Service
{
    [ServiceContract]
    public interface IFFPService
    {
        [OperationContract]
        Response<Guid> Add(FFP item);

        [OperationContract]
        Response AddFfp(string sql);
    }
}
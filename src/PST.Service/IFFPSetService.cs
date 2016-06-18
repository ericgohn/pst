//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: IFFPSetService.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System.ServiceModel;
using PST.Domain;

namespace PST.Service
{
    [ServiceContract]
    public interface IFFPSetService
    {
        [OperationContract]
        Response<bool> HasData(string setName);

        [OperationContract]
        Response<int> Upsert(string setName);
    }
}
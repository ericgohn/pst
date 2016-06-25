//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: IWDResponseService.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System.Collections.Generic;
using System.ServiceModel;
using PST.Domain;

namespace PST.Service
{
    [ServiceContract]
    public interface IWDResponseService
    {
        [OperationContract]
        Response AddItems(string sql);

        [OperationContract]
        Response RemoveBySetId(int setId);

        [OperationContract]
        Response RemoveBySetName(string name);

        [OperationContract]
        Response<List<string>> GetPNOs(int ffpSetId);

        [OperationContract]
        Response Dispatch(int ffpSetId, string pno);
    }
}
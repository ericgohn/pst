//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: IFFPService.cs
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
    public interface IFFPService
    {
        [OperationContract]
        Response AddItems(string sql);

        [OperationContract]
        Response RemoveBySetId(int setId);

        [OperationContract]
        Response RemoveBySetName(string name);

        [OperationContract]
        Response<List<string>> GetSqlData(int currentPage, int itemsPerPage, int ffpSetId);

        [OperationContract]
        Response<List<string>> FindFfpPnoByCicName(string cicName);

        [OperationContract]
        Response<List<string>> FindSeriesByFfpPno(string ffpPno);

        [OperationContract]
        Response<List<FFP>> FindBySeries(string series);

        [OperationContract]
        Response<List<SummarizedFFP>> FindSummarizedFfpBySeries(string series);
    }
}
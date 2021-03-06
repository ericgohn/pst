﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PST.UI.Common.FFPService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="FFPService.IFFPService")]
    public interface IFFPService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFFPService/AddItems", ReplyAction="http://tempuri.org/IFFPService/AddItemsResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(PST.Domain.Response<string[]>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(PST.Domain.Response<PST.Domain.FFP[]>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(PST.Domain.Response<PST.Domain.SummarizedFFP[]>))]
        PST.Domain.Response AddItems(string sql);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFFPService/AddItems", ReplyAction="http://tempuri.org/IFFPService/AddItemsResponse")]
        System.Threading.Tasks.Task<PST.Domain.Response> AddItemsAsync(string sql);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFFPService/RemoveBySetId", ReplyAction="http://tempuri.org/IFFPService/RemoveBySetIdResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(PST.Domain.Response<string[]>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(PST.Domain.Response<PST.Domain.FFP[]>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(PST.Domain.Response<PST.Domain.SummarizedFFP[]>))]
        PST.Domain.Response RemoveBySetId(int setId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFFPService/RemoveBySetId", ReplyAction="http://tempuri.org/IFFPService/RemoveBySetIdResponse")]
        System.Threading.Tasks.Task<PST.Domain.Response> RemoveBySetIdAsync(int setId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFFPService/RemoveBySetName", ReplyAction="http://tempuri.org/IFFPService/RemoveBySetNameResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(PST.Domain.Response<string[]>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(PST.Domain.Response<PST.Domain.FFP[]>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(PST.Domain.Response<PST.Domain.SummarizedFFP[]>))]
        PST.Domain.Response RemoveBySetName(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFFPService/RemoveBySetName", ReplyAction="http://tempuri.org/IFFPService/RemoveBySetNameResponse")]
        System.Threading.Tasks.Task<PST.Domain.Response> RemoveBySetNameAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFFPService/GetSqlData", ReplyAction="http://tempuri.org/IFFPService/GetSqlDataResponse")]
        PST.Domain.Response<string[]> GetSqlData(int currentPage, int itemsPerPage, int ffpSetId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFFPService/GetSqlData", ReplyAction="http://tempuri.org/IFFPService/GetSqlDataResponse")]
        System.Threading.Tasks.Task<PST.Domain.Response<string[]>> GetSqlDataAsync(int currentPage, int itemsPerPage, int ffpSetId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFFPService/FindFfpPnoByCicName", ReplyAction="http://tempuri.org/IFFPService/FindFfpPnoByCicNameResponse")]
        PST.Domain.Response<string[]> FindFfpPnoByCicName(string cicName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFFPService/FindFfpPnoByCicName", ReplyAction="http://tempuri.org/IFFPService/FindFfpPnoByCicNameResponse")]
        System.Threading.Tasks.Task<PST.Domain.Response<string[]>> FindFfpPnoByCicNameAsync(string cicName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFFPService/FindSeriesByFfpPno", ReplyAction="http://tempuri.org/IFFPService/FindSeriesByFfpPnoResponse")]
        PST.Domain.Response<string[]> FindSeriesByFfpPno(string ffpPno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFFPService/FindSeriesByFfpPno", ReplyAction="http://tempuri.org/IFFPService/FindSeriesByFfpPnoResponse")]
        System.Threading.Tasks.Task<PST.Domain.Response<string[]>> FindSeriesByFfpPnoAsync(string ffpPno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFFPService/FindBySeries", ReplyAction="http://tempuri.org/IFFPService/FindBySeriesResponse")]
        PST.Domain.Response<PST.Domain.FFP[]> FindBySeries(string series);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFFPService/FindBySeries", ReplyAction="http://tempuri.org/IFFPService/FindBySeriesResponse")]
        System.Threading.Tasks.Task<PST.Domain.Response<PST.Domain.FFP[]>> FindBySeriesAsync(string series);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFFPService/FindSummarizedFfpBySeries", ReplyAction="http://tempuri.org/IFFPService/FindSummarizedFfpBySeriesResponse")]
        PST.Domain.Response<PST.Domain.SummarizedFFP[]> FindSummarizedFfpBySeries(string series);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFFPService/FindSummarizedFfpBySeries", ReplyAction="http://tempuri.org/IFFPService/FindSummarizedFfpBySeriesResponse")]
        System.Threading.Tasks.Task<PST.Domain.Response<PST.Domain.SummarizedFFP[]>> FindSummarizedFfpBySeriesAsync(string series);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFFPServiceChannel : PST.UI.Common.FFPService.IFFPService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FFPServiceClient : System.ServiceModel.ClientBase<PST.UI.Common.FFPService.IFFPService>, PST.UI.Common.FFPService.IFFPService {
        
        public FFPServiceClient() {
        }
        
        public FFPServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FFPServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FFPServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FFPServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public PST.Domain.Response AddItems(string sql) {
            return base.Channel.AddItems(sql);
        }
        
        public System.Threading.Tasks.Task<PST.Domain.Response> AddItemsAsync(string sql) {
            return base.Channel.AddItemsAsync(sql);
        }
        
        public PST.Domain.Response RemoveBySetId(int setId) {
            return base.Channel.RemoveBySetId(setId);
        }
        
        public System.Threading.Tasks.Task<PST.Domain.Response> RemoveBySetIdAsync(int setId) {
            return base.Channel.RemoveBySetIdAsync(setId);
        }
        
        public PST.Domain.Response RemoveBySetName(string name) {
            return base.Channel.RemoveBySetName(name);
        }
        
        public System.Threading.Tasks.Task<PST.Domain.Response> RemoveBySetNameAsync(string name) {
            return base.Channel.RemoveBySetNameAsync(name);
        }
        
        public PST.Domain.Response<string[]> GetSqlData(int currentPage, int itemsPerPage, int ffpSetId) {
            return base.Channel.GetSqlData(currentPage, itemsPerPage, ffpSetId);
        }
        
        public System.Threading.Tasks.Task<PST.Domain.Response<string[]>> GetSqlDataAsync(int currentPage, int itemsPerPage, int ffpSetId) {
            return base.Channel.GetSqlDataAsync(currentPage, itemsPerPage, ffpSetId);
        }
        
        public PST.Domain.Response<string[]> FindFfpPnoByCicName(string cicName) {
            return base.Channel.FindFfpPnoByCicName(cicName);
        }
        
        public System.Threading.Tasks.Task<PST.Domain.Response<string[]>> FindFfpPnoByCicNameAsync(string cicName) {
            return base.Channel.FindFfpPnoByCicNameAsync(cicName);
        }
        
        public PST.Domain.Response<string[]> FindSeriesByFfpPno(string ffpPno) {
            return base.Channel.FindSeriesByFfpPno(ffpPno);
        }
        
        public System.Threading.Tasks.Task<PST.Domain.Response<string[]>> FindSeriesByFfpPnoAsync(string ffpPno) {
            return base.Channel.FindSeriesByFfpPnoAsync(ffpPno);
        }
        
        public PST.Domain.Response<PST.Domain.FFP[]> FindBySeries(string series) {
            return base.Channel.FindBySeries(series);
        }
        
        public System.Threading.Tasks.Task<PST.Domain.Response<PST.Domain.FFP[]>> FindBySeriesAsync(string series) {
            return base.Channel.FindBySeriesAsync(series);
        }
        
        public PST.Domain.Response<PST.Domain.SummarizedFFP[]> FindSummarizedFfpBySeries(string series) {
            return base.Channel.FindSummarizedFfpBySeries(series);
        }
        
        public System.Threading.Tasks.Task<PST.Domain.Response<PST.Domain.SummarizedFFP[]>> FindSummarizedFfpBySeriesAsync(string series) {
            return base.Channel.FindSummarizedFfpBySeriesAsync(series);
        }
    }
}

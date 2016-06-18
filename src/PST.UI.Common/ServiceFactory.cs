//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: ServiceFactory.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System.ServiceModel;
using System.ServiceModel.Description;
using PST.UI.Common.FFPService;
using PST.UI.Common.FFPSetService;
using PST.UI.Common.WDResponseService;
using Zeexone.Framework.Core.WCF;

namespace PST.UI.Common
{
    public class ServiceFactory
    {
        private static readonly ServiceFactory _factory = new ServiceFactory();
        private IEndpointBehavior _behavior;

        private ServiceFactory()
        {
        }

        public static ServiceFactory S
        {
            get { return _factory; }
        }

        public void AddBehavior(string token)
        {
            _behavior = new ClientInterceptorBehaviorExtension(token);
        }

        public IFFPService GetFFPService()
        {
            var endPoint = GetServerEndPoint("FFPService.svc");
            var service = endPoint == null
                ? new FFPServiceClient()
                : new FFPServiceClient("FFPService", endPoint);
            if (_behavior != null)
                service.ChannelFactory.Endpoint.Behaviors.Add(_behavior);
            return service;
        }

        public IWDResponseService GetWDResponseService()
        {
            var endPoint = GetServerEndPoint("WDResponseService.svc");
            var service = endPoint == null
                ? new WDResponseServiceClient()
                : new WDResponseServiceClient("WDResponseService", endPoint);
            if (_behavior != null)
                service.ChannelFactory.Endpoint.Behaviors.Add(_behavior);
            return service;
        }

        public IFFPSetService GetFFPSetService()
        {
            var endPoint = GetServerEndPoint("FFPSetService.svc");
            var service = endPoint == null
                ? new FFPSetServiceClient()
                : new FFPSetServiceClient("FFPSetService", endPoint);
            if (_behavior != null)
                service.ChannelFactory.Endpoint.Behaviors.Add(_behavior);
            return service;
        }

        private static EndpointAddress GetServerEndPoint(string serviceName)
        {
            return null;
            /*if (string.IsNullOrEmpty(Configuration.CommonConfiguration.ServerAddress))
                return null;
            return new EndpointAddress("http://" + Configuration.CommonConfiguration.ServerAddress + "/" + serviceName);*/
        }
    }
}
﻿//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: ServiceFactory.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System.ServiceModel;
using System.ServiceModel.Description;
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


        private static EndpointAddress GetServerEndPoint(string serviceName)
        {
            return null;
            /*if (string.IsNullOrEmpty(Configuration.CommonConfiguration.ServerAddress))
                return null;
            return new EndpointAddress("http://" + Configuration.CommonConfiguration.ServerAddress + "/" + serviceName);*/
        }
    }
}
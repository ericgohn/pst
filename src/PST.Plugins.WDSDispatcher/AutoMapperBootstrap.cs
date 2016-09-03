//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: AutoMapperBootstrap.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using AutoMapper;
using PST.Domain;
using PST.Plugins.WDSDispatcher.ViewModels;

namespace PST.Plugins.WDSDispatcher
{
    public class AutoMapperBootstrap
    {
        private static IMapper _mapper;
        private static MapperConfiguration _configuration;

        public static IMapper M
        {
            get { return _mapper ?? (_mapper = _configuration.CreateMapper()); }
        }

        public static void InitializeMap()
        {
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SummarizedFFP, SummarizedFFPVm>();
                cfg.CreateMap<SummarizedFFPVm, SummarizedFFP>();
            });
        }
    }
}
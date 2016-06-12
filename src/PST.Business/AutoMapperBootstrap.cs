//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: AutoMapperBootstrap.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System;
using AutoMapper;
using PST.Data;
using PST.Domain;

namespace PST.Business
{
    public partial class AutoMapperBootstrap
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
                cfg.CreateMap<PST.Data.FFP, PST.Domain.FFP>();
                cfg.CreateMap<PST.Domain.FFP, PST.Data.FFP>();
                
                cfg.CreateMap<PST.Data.WDSResponse, PST.Domain.WDSResponse>();
                cfg.CreateMap<PST.Domain.WDSResponse, PST.Data.WDSResponse>();
                
                CustomConfiguration(cfg);
            });
        }
        
        static partial void CustomConfiguration(IMapperConfiguration cfg);
    }
}

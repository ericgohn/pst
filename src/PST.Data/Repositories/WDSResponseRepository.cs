//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: WDSResponseRepository.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System.Data.Entity;

namespace PST.Data.Repositories
{
    public interface IWDSResponseRepository : IRepository<WDSResponse>
    {
    }
    
    public class WDSResponseRepository : GenericRepository<WDSResponse>, IWDSResponseRepository
    {
        public WDSResponseRepository(DbContext context) : base(context)
        {
        }
    } 
}
//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: FFPSetRepository.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System.Data.Entity;

namespace PST.Data.Repositories
{
    public interface IFFPSetRepository : IRepository<FFPSet>
    {
    }
    
    public class FFPSetRepository : GenericRepository<FFPSet>, IFFPSetRepository
    {
        public FFPSetRepository(DbContext context) : base(context)
        {
        }
    } 
}
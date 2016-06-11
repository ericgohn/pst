//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: FFPRepository.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System.Data.Entity;

namespace PST.Data.Repositories
{
    public interface IFFPRepository : IRepository<FFP>
    {
    }
    
    public class FFPRepository : GenericRepository<FFP>, IFFPRepository
    {
        public FFPRepository(DbContext context) : base(context)
        {
        }
    } 
}
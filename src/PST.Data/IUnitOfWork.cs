//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: IUnitOfWork.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System;
using PST.Data.Repositories;

namespace PST.Data
{
    public interface IUnitOfWork : IDisposable
    {   
        IFFPRepository FFPRepository {get;}
        IWDSResponseRepository WDSResponseRepository {get;}
        

        /// <summary>
        ///     Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        int Commit();
    }
}

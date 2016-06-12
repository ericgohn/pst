//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: UnitOfWork.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System;
using System.Data.Entity;
using PST.Data.Repositories;

namespace PST.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _context;
        private IFFPRepository _fFPRepository;
        private IWDSResponseRepository _wDSResponseRepository;
        
        public UnitOfWork(DbContext context)
        {
            _context = context;
        }
        
        public IFFPRepository FFPRepository
        {
            get { return _fFPRepository ?? (_fFPRepository = new FFPRepository(_context)); }
        }
        
        public IWDSResponseRepository WDSResponseRepository
        {
            get { return _wDSResponseRepository ?? (_wDSResponseRepository = new WDSResponseRepository(_context)); }
        }
        
        
        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}

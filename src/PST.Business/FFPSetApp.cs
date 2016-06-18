//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: FFPSetApp.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System.Linq;
using PST.Data;
using PST.Domain;
using FFPSet = PST.Domain.FFPSet;

namespace PST.Business
{
    public partial class FFPSetApp
    {
        #region public Methods

        public Response<int> Upsert(string name)
        {
            name = name.Trim().ToUpper();
            using (var context = new Entities())
            using (IUnitOfWork uow = new UnitOfWork(context))
            {
                int id;
                var set = uow.FFPSetRepository.Get(o => o.Name == name).FirstOrDefault();
                if (set == null)
                {
                    var entity = new Data.FFPSet();
                    entity.Name = name;
                    uow.FFPSetRepository.Add(entity);
                    uow.Commit();
                    id = entity.Id;
                }
                else
                {
                    id = set.Id;
                }
                return Response<int>.Succeed(id);
            }
        }

        public Response<bool> HasData(string name)
        {
            name = name.Trim().ToUpper();
            using (var context = new Entities())
            using (IUnitOfWork uow = new UnitOfWork(context))
            {
                var set = uow.FFPSetRepository.Get(o => o.Name == name).FirstOrDefault();
                if (set == null)
                    return Response<bool>.Succeed(false);
                if (set.FFPs.Count > 0 || set.WDSResponses.Count > 0)
                    return Response<bool>.Succeed(true);
                return Response<bool>.Succeed(false);
            }
        }

        #endregion

        #region Private Methods

        private void AddAssignment(FFPSet src, Data.FFPSet dest)
        {
        }

        private void UpdateAssignment(FFPSet src, Data.FFPSet dest)
        {
        }

        #endregion
    }
}
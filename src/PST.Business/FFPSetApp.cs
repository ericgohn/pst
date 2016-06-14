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

namespace PST.Business
{
    public partial class FFPSetApp
    {
        #region public Methods

        public Response<int> GetOrAddFFPSet(string name)
        {
            name = name.Trim().ToUpper();
            using (var context = new Entities())
            using (IUnitOfWork uow = new UnitOfWork(context))
            {
                int id = 0;
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
        #endregion
        
        #region Private Methods
        
        private void AddAssignment(PST.Domain.FFPSet src, PST.Data.FFPSet dest){
        }
        
        private void UpdateAssignment(PST.Domain.FFPSet src, PST.Data.FFPSet dest){
        }
        
        #endregion
    }
}

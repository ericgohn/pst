//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: FFPApp.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System.Collections.Generic;
using PST.Data;
using PST.Domain;
using FFP = PST.Domain.FFP;

namespace PST.Business
{
    public partial class FFPApp
    {
        #region public Methods

        public Response AddRange(List<FFP> list)
        {
            using (var context = new Entities())
            using (IUnitOfWork uow = new UnitOfWork(context))
            {
                foreach (var item in list)
                {
                    var entity = AutoMapperBootstrap.M.Map<FFP, Data.FFP>(item);
                    uow.FFPRepository.Add(entity);
                }
                uow.Commit();
                return Response.Succeed();
            }
        }

        #endregion

        #region Private Methods

        private void AddAssignment(FFP src, Data.FFP dest)
        {
        }

        private void UpdateAssignment(FFP src, Data.FFP dest)
        {
        }

        #endregion
    }
}
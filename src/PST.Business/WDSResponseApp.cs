//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: WDSResponseApp.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using PST.Data;
using PST.Domain;
using WDSResponse = PST.Domain.WDSResponse;

namespace PST.Business
{
    public partial class WDSResponseApp
    {
        #region public Methods

        public Response Import(string sql)
        {
            using (var context = new Entities())
            {
                context.Database.ExecuteSqlCommand(sql);
                return Response.Succeed();
            }
        }

        public Response RemoveBySetId(int setId)
        {
            using (var context = new Entities())
            using (var uow = new UnitOfWork(context))
            {
                var entities = uow.WDSResponseRepository.Get(o => o.FFPSetId == setId);
                foreach (var entity in entities)
                {
                    uow.WDSResponseRepository.Remove(entity);
                }
                uow.Commit();
                return Response.Succeed();
            }
        }

        #endregion

        #region Private Methods

        private void AddAssignment(WDSResponse src, Data.WDSResponse dest)
        {
        }

        private void UpdateAssignment(WDSResponse src, Data.WDSResponse dest)
        {
        }

        #endregion
    }
}
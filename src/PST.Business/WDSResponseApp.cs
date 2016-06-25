//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: WDSResponseApp.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System.Linq;
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
            {
                context.Database.ExecuteSqlCommand("DELETE FROM [dbo].[WDSResponse] WHERE [FFPSetId] = @p0", setId);
                return Response.Succeed();
            }
        }

        public Response RemoveBySetName(string name)
        {
            using (var context = new Entities())
            using (var uow = new UnitOfWork(context))
            {
                var set = uow.FFPSetRepository.Get(o => o.Name == name).FirstOrDefault();
                if (set == null)
                    return Response.Succeed();
                context.Database.ExecuteSqlCommand("DELETE FROM [dbo].[WDSResponse] WHERE [FFPSetId] = @p0", set.Id);
                return Response.Succeed();
            }
        }

        public void Dispatch(string pno)
        {
            using (var context = new Entities())
            using (var uow = new UnitOfWork(context))
            {
                var wdsList = uow.WDSResponseRepository.Get(o => o.PNO == pno, q => q.OrderBy(o => o.Date));
                foreach (var wds in wdsList)
                {
                    double amount = wds.WDS_Response ?? 0;
                    if (amount == 0)
                        continue;
                    var ffpList =
                        uow.FFPRepository.Get(o => o.F_FP_PNO == pno && o.Shipped_Month >= wds.Date && !o.Dispatched, q=>q.OrderBy(o=>o.Shipped_Month));
                    foreach (var f in ffpList)
                    {
                        var needs = f.Shipped_QTY - f.ResAmount;
                        if (amount > needs)
                        {
                            f.ResAmount = (double) f.Shipped_QTY;
                            f.Dispatched = true;
                            wds.WDS_Response = amount - needs;
                        }
                        else if (amount == f.Shipped_QTY)
                        {
                            f.ResAmount = (double) f.Shipped_QTY;
                            f.Dispatched = true;
                            wds.Dispatched = true;
                            break;
                        }
                        else
                        {
                            f.ResAmount = amount;
                            wds.Dispatched = true;
                            break;
                        }
                    }
                }

                uow.Commit();
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
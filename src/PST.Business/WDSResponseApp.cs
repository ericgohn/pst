//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: WDSResponseApp.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System.Collections.Generic;
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

        public Response Dispatch(int ffpSetId, string pno)
        {
            using (var context = new Entities())
            using (var uow = new UnitOfWork(context))
            {
                var wdsList = uow.WDSResponseRepository.Get(
                    o => o.FFPSetId == ffpSetId && o.PNO == pno && !o.Dispatched,
                    q => q.OrderBy(o => o.Date).ThenBy(o => o.Seq));
                var ffpList =
                    uow.FFPRepository.Get(o => o.FFPSetId == ffpSetId && o.F_FP_PNO == pno && !o.Dispatched,
                        q => q.OrderBy(o => o.Shipped_Month).ThenBy(o => o.Seq));
                foreach (var wds in wdsList)
                {
                    foreach (var f in ffpList)
                    {
                        if (f.Dispatched)
                            continue;
                        if (f.Shipped_QTY == 0)
                            continue;
                        if (f.Shipped_Month < wds.Date)
                            continue;
                        var needs = f.Shipped_QTY - f.ResAmount;
                        if (wds.WDS_Response > needs)
                        {
                            f.ResAmount = (double) f.Shipped_QTY;
                            f.Dispatched = true;
                            wds.WDS_Response -= needs;
                        }
                        else if (wds.WDS_Response == f.Shipped_QTY)
                        {
                            f.ResAmount = (double) f.Shipped_QTY;
                            f.Dispatched = true;
                            wds.Dispatched = true;
                            break;
                        }
                        else
                        {
                            f.ResAmount = (double) wds.WDS_Response;
                            wds.Dispatched = true;
                            break;
                        }
                    }
                }

                uow.Commit();
                return Response.Succeed();
            }
        }

        public Response<List<string>> GetPNOs(int ffpSetId)
        {
            using (var context = new Entities())
            {
                var query =
                    context.Database.SqlQuery<string>(
                        "SELECT DISTINCT [PNO] FROM [dbo].[WDSResponse] WHERE [FFPSetId] = @p0", ffpSetId);
                return Response<List<string>>.Succeed(query.ToList());
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
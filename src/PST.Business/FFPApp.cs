//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: FFPApp.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System.Collections.Generic;
using System.Linq;
using System.Text;
using PST.Data;
using PST.Domain;
using FFP = PST.Domain.FFP;

namespace PST.Business
{
    public partial class FFPApp
    {
        public Response<List<string>> FindFfpPnoByCicName(string cicName)
        {
            using (var context = new Entities())
            {
                var query =
                    context.Database.SqlQuery<string>(
                        "SELECT DISTINCT [F/FP PNO] FROM [dbo].[FFP] WHERE [CIC Name] LIKE @p0+'%'", cicName);
                return Response<List<string>>.Succeed(query.ToList());
            }
        }

        public Response<List<string>> FindSeriesByFfpPno(string ffpPno)
        {
            using (var context = new Entities())
            {
                var query =
                    context.Database.SqlQuery<string>(
                        "SELECT DISTINCT [Series] FROM [dbo].[FFP] WHERE [F/FP PNO]= @p0", ffpPno);
                return Response<List<string>>.Succeed(query.ToList());
            }
        }

        public Response<List<FFP>> FindBySeries(string series)
        {
            using (var context = new Entities())
            using (var uow = new UnitOfWork(context))
            {
                var items = uow.FFPRepository.Get(o => o.Series == series, q => q.OrderBy(o => o.Seq));
                var list = AutoMapperBootstrap.M.Map<List<FFP>>(items);
                return Response<List<FFP>>.Succeed(list);
            }
        }

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
                context.Database.ExecuteSqlCommand("DELETE FROM [dbo].[FFP] WHERE [FFPSetId] = @p0", setId);
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
                context.Database.ExecuteSqlCommand("DELETE FROM [dbo].[FFP] WHERE [FFPSetId] = @p0", set.Id);
                return Response.Succeed();
            }
        }

        public Response<List<string>> GetSqlData(int currentPage, int itemsPerPage, int ffpSetId)
        {
            using (var context = new Entities())
            using (var uow = new UnitOfWork(context))
            {
                var items = uow.FFPRepository.Get(currentPage, itemsPerPage, q => q.OrderBy(o => o.Seq),
                    o => o.FFPSetId == ffpSetId);
                List<string> list = new List<string>();
                foreach (var item in items)
                {
                    var row = new StringBuilder();
                    row.Append("(").Append(item.Seq);
                    row.Append(",").Append(item.Dispatched ? 1 : 0);
                    row.Append(",").Append(item.ResAmount);
                    row.Append(",'").Append(item.Series).Append("'");
                    row.Append(",'").Append(item.Model_Name).Append("'");
                    row.Append(",'").Append(item.Business_No).Append("'");
                    row.Append(",'").Append(item.Sales_Route).Append("'");
                    row.Append(",'").Append(item.PNO).Append("'");
                    row.Append(",'").Append(item.Sales_PNO).Append("'");
                    row.Append(",'").Append(item.Sub_Information).Append("'");
                    row.Append(",'").Append(item.Customer_Name).Append("'");
                    row.Append(",'").Append(item.Rank).Append("'");
                    row.Append(",'").Append(item.Rate).Append("'");
                    row.Append(",'").Append(item.ACC_Code).Append("'");
                    row.Append(",'").Append(item.Sales_Staff).Append("'");
                    row.Append(",'").Append(item.Order_Division).Append("'");
                    row.Append(",'").Append(item.Shipped_Month).Append("'");
                    row.Append(",").Append(item.Shipped_QTY);
                    row.Append(",").Append(item.Shipped_Qty2);
                    row.Append(",'").Append(item.F_FP_PNO).Append("'");
                    row.Append(",'").Append(item.F_FP_Type).Append("'");
                    row.Append(",'").Append(item.CIG_Name).Append("'");
                    row.Append(",'").Append(item.CIC_Name).Append("')");
                    list.Add(row.ToString());
                }
                return Response<List<string>>.Succeed(list);
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
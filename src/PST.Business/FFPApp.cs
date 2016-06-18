//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: FFPApp.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using PST.Data;
using PST.Domain;
using FFP = PST.Domain.FFP;

namespace PST.Business
{
    public partial class FFPApp
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
                context.Database.ExecuteSqlCommand("DELETE FROM [dbo].[FFP] WHERE [FFPSetId] = @p0", setId);
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
//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: FFPSetApp.Generated.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System;
using System.Linq;
using Zeexone.Framework.Core.Utility;
using PST.Data;
using PST.Domain;

namespace PST.Business
{
    public partial class FFPSetApp
    {
        /// <summary>
        ///     Add entity.
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public Response<int> Add(PST.Domain.FFPSet arg){
            P.CheckArgNotNull(arg, "arg", "arg cannnot be null.");
            using (var context = new Entities())
            using (IUnitOfWork uow = new UnitOfWork(context))
            {
                var entity = AutoMapperBootstrap.M.Map<PST.Data.FFPSet>(arg);
                AddAssignment(arg, entity);
                uow.FFPSetRepository.Add(entity);
                uow.Commit();
                return Response<int>.Succeed(entity.Id);
            }
        }
        
        /// <summary>
        ///     Update entity.
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public Response Update(PST.Domain.FFPSet arg){
            P.CheckArgNotNull(arg, "arg", "arg cannnot be null.");
            using (var context = new Entities())
            using (IUnitOfWork uow = new UnitOfWork(context)){
                var exist = uow.FFPSetRepository.GetById(arg.Id);
                if (exist == null)
                    return Response.Failed("您要更新的数据不存在。");
                AutoMapperBootstrap.M.Map(arg, exist);
                UpdateAssignment(arg, exist);
                uow.Commit();
                return Response.Succeed();
            }
        }
        
        /// <summary>
        ///     Remove entity.
        /// </summary>
        /// <param name="id">Entity id.</param>
        /// <returns></returns>
        public Response Remove(int id){
            using (var context = new Entities())
            using (IUnitOfWork uow = new UnitOfWork(context)){
                var entity = uow.FFPSetRepository.GetById(id);
                if (entity == null)
                    return Response.Failed("您要删除的数据不存在。");
                if (HasRelatedData(entity))
                    return Response.Failed("删除失败，请先删除所有的关联数据。");
                uow.FFPSetRepository.Remove(entity);
                uow.Commit();
                return Response.Succeed();
            }
        }
        
        /// <summary>
        ///     Find object by entity's id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Response<PST.Domain.FFPSet> Find(int id){
            using (var context = new Entities())
            using (IUnitOfWork uow = new UnitOfWork(context)){
                var entity = uow.FFPSetRepository.GetById(id);
                if(entity == null)
                    return Response<PST.Domain.FFPSet>.Succeed(null);
                var obj = AutoMapperBootstrap.M.Map<PST.Domain.FFPSet>(entity);
                return Response<PST.Domain.FFPSet>.Succeed(obj);
            }
        }
        
        /// <summary>
        ///     Check whether rerversed properties has related data. 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private bool HasRelatedData(PST.Data.FFPSet entity){
            bool result = false;
            result = result || entity.FFPs.Any(o => o.FFPSetId == entity.Id);
            return result;
        }
    }
}

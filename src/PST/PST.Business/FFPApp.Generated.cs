﻿//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: FFPApp.Generated.cs
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
    public partial class FFPApp
    {
        /// <summary>
        ///     Add entity.
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public Response<Guid> Add(PST.Domain.FFP arg){
            P.CheckArgNotNull(arg, "arg", "arg cannnot be null.");
            using (var context = new Entities())
            using (IUnitOfWork uow = new UnitOfWork(context))
            {
                var entity = AutoMapperBootstrap.M.Map<PST.Data.FFP>(arg);
                AddAssignment(arg, entity);
                uow.FFPRepository.Add(entity);
                uow.Commit();
                return Response<Guid>.Succeed(entity.Id);
            }
        }
        
        /// <summary>
        ///     Update entity.
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public Response Update(PST.Domain.FFP arg){
            P.CheckArgNotNull(arg, "arg", "arg cannnot be null.");
            using (var context = new Entities())
            using (IUnitOfWork uow = new UnitOfWork(context)){
                var exist = uow.FFPRepository.GetById(arg.Id);
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
        public Response Remove(Guid id){
            using (var context = new Entities())
            using (IUnitOfWork uow = new UnitOfWork(context)){
                var entity = uow.FFPRepository.GetById(id);
                if (entity == null)
                    return Response.Failed("您要删除的数据不存在。");
                if (HasRelatedData(entity))
                    return Response.Failed("删除失败，请先删除所有的关联数据。");
                uow.FFPRepository.Remove(entity);
                uow.Commit();
                return Response.Succeed();
            }
        }
        
        /// <summary>
        ///     Find object by entity's id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Response<PST.Domain.FFP> Find(Guid id){
            using (var context = new Entities())
            using (IUnitOfWork uow = new UnitOfWork(context)){
                var entity = uow.FFPRepository.GetById(id);
                if(entity == null)
                    return Response<PST.Domain.FFP>.Succeed(null);
                var obj = AutoMapperBootstrap.M.Map<PST.Domain.FFP>(entity);
                return Response<PST.Domain.FFP>.Succeed(obj);
            }
        }
        
        /// <summary>
        ///     Check whether rerversed properties has related data. 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private bool HasRelatedData(PST.Data.FFP entity){
            bool result = false;
            return result;
        }
    }
}

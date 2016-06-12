//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: IRepository.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Zeexone.Framework.Core.PagedLists;

namespace PST.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        ///     添加数据。
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);

        /// <summary>
        ///     删除数据。
        /// </summary>
        /// <param name="entity"></param>
        void Remove(T entity);

        /// <summary>
        ///     根据ID删除数据。
        /// </summary>
        /// <param name="id"></param>
        void Remove(object id);

        /// <summary>
        ///     更新数据。
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        ///     查询指定条件的数据是否存在。
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        bool Any(Expression<Func<T, bool>> filter);

        /// <summary>
        ///     查询指定条件的数据数量。
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        int Count(Expression<Func<T, bool>> filter);

        /// <summary>
        ///     根据ID查询数据。
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(object id);

        /// <summary>
        ///     根据条件查询数据。
        /// </summary>
        /// <param name="filter">过滤条件</param>
        /// <param name="orderBy">排序条件</param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        IList<T> Get(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");

        /// <summary>
        ///     根据条件获取指定数目的数据。
        /// </summary>
        /// <param name="top"></param>
        /// <param name="orderBy"></param>
        /// <param name="filter"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        IList<T> GetTop(int top, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
            Expression<Func<T, bool>> filter = null,
            string includeProperties = "");

        /// <summary>
        ///     根据条件获取分页数据。
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="itemsPerPage"></param>
        /// <param name="orderBy"></param>
        /// <param name="filter"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        PagedList<T> Get(int currentPage, int itemsPerPage,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, Expression<Func<T, bool>> filter = null,
            string includeProperties = "");
            
        /// <summary>
        ///     查询符合<see cref="filter" />条件的第一个元素。 如果元素不存在，则返回null。
        /// </summary>
        /// <param name="filter">过滤条件</param>
        /// <param name="orderBy">排序条件</param>
        /// <returns></returns>
        T FirstOrDefault(Expression<Func<T, bool>> filter,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
    }
}
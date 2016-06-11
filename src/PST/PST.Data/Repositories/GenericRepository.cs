//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: GenericRepository.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Zeexone.Framework.Core.PagedLists;


namespace PST.Data.Repositories
{
    /// <summary>
    ///     Repository的基础类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext context;
        protected readonly DbSet<T> dbSet;

        public GenericRepository(DbContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            this.context = context;
            dbSet = context.Set<T>();
        }

        /// <summary>
        ///     添加数据。
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        /// <summary>
        ///     删除数据。
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        /// <summary>
        ///     根据ID删除数据。
        /// </summary>
        /// <param name="id"></param>
        public void Remove(object id)
        {
            var entity = dbSet.Find(id);
            dbSet.Remove(entity);
        }

        /// <summary>
        ///     更新数据。
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        ///     查询指定条件的数据是否存在。
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public bool Any(Expression<Func<T, bool>> filter)
        {
            return dbSet.Any(filter);
        }

        /// <summary>
        ///     查询指定条件的数据数量。
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public int Count(Expression<Func<T, bool>> filter)
        {
            return dbSet.Count(filter);
        }

        /// <summary>
        ///     根据ID查询数据。
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T GetById(object id)
        {
            return dbSet.Find(id);
        }

        /// <summary>
        ///     根据条件查询数据。
        /// </summary>
        /// <param name="filter">过滤条件</param>
        /// <param name="orderBy">排序条件</param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public virtual IList<T> Get(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            query = includeProperties.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return @orderBy == null ? query.ToList() : @orderBy(query).ToList();
        }

        /// <summary>
        ///     根据条件获取指定数目的数据。
        /// </summary>
        /// <param name="top"></param>
        /// <param name="orderBy"></param>
        /// <param name="filter"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public virtual IList<T> GetTop(int top, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
            Expression<Func<T, bool>> filter = null,
            string includeProperties = "")
        {
            if (orderBy == null)
                throw new ArgumentNullException("orderBy");
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            query = includeProperties.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return @orderBy(query).Take(top).ToList();
        }

        /// <summary>
        ///     根据条件获取分页数据。
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="itemsPerPage"></param>
        /// <param name="orderBy"></param>
        /// <param name="filter"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public virtual PagedList<T> Get(int currentPage, int itemsPerPage,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, Expression<Func<T, bool>> filter = null,
            string includeProperties = "")
        {
            if (orderBy == null)
                throw new ArgumentNullException("orderBy");
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            query = includeProperties.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return orderBy(query).ToPagedList(currentPage, itemsPerPage) as PagedList<T>;
        }
        
        /// <summary>
        ///     查询符合<see cref="filter" />条件的第一个元素。 如果元素不存在，则返回null。
        /// </summary>
        /// <param name="filter">过滤条件</param>
        /// <param name="orderBy">排序条件</param>
        /// <returns></returns>
        public T FirstOrDefault(Expression<Func<T, bool>> filter,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return @orderBy == null ? query.FirstOrDefault() : @orderBy(query).FirstOrDefault();
        }
    }
}


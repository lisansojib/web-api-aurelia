using AutoMapper;
using AutoMapper.QueryableExtensions;
using Starter.Core;
using Starter.Data.Abstracts;
using Starter.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace Starter.Data
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T>
        where T : class, IEntityBase, new()
    {
        private DbContext _dbContext;
        private readonly IDbSet<T> _dbSet;

        #region Ctor
        public EntityBaseRepository(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            _dbSet = DbContext.Set<T>();
        }
        #endregion

        #region Properties
        protected IDbFactory DbFactory { get; private set; }

        protected DbContext DbContext => _dbContext ?? (_dbContext = DbFactory.InitDbContext());
        #endregion

        #region Methods        

        public virtual int Count()
        {
            return _dbSet.Count();
        }

        public virtual int Count(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).Count();
        }

        public virtual bool Exists(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Any(predicate);
        }

        public virtual string ExistingId(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate).Id;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.AsEnumerable();
        }

        public virtual IEnumerable<T> GetAll(int currentPage, int currentPageSize)
        {
            return _dbSet
                .OrderBy(x => x.Id)
                .Skip((currentPage - 1) * currentPageSize)
                .Take(currentPageSize)
                .AsEnumerable();
        }

        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate, int currentPage, int currentPageSize)
        {
            return _dbSet
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip((currentPage - 1) * currentPageSize)
                .Take(currentPageSize)
                .AsEnumerable();
        }

        public virtual IEnumerable<SelectOptionModel> GetSelectOptions()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<T, SelectOptionModel>());
            return _dbSet
                .ProjectTo<SelectOptionModel>()
                .AsEnumerable();
        }

        public virtual IEnumerable<SelectOptionModel> GetSelectOptions(Expression<Func<T, bool>> predicate)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<T, SelectOptionModel>());
            return _dbSet
                .Where(predicate)
                .ProjectTo<SelectOptionModel>()
                .AsEnumerable();
        }

        public virtual IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.AsEnumerable();
        }

        public virtual T GetSingle(string id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public virtual T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public virtual T GetSingle(Expression<Func<T, bool>> predicate, bool withNew)
        {
            return _dbSet.FirstOrDefault(predicate) ?? new T();
        }

        public virtual T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet.Where(predicate);
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.FirstOrDefault() ?? new T();
        }

        public virtual IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public virtual IEnumerable<T> FindByIncluding(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet.Where(predicate);
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.AsEnumerable();
        }

        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void AddMany(IEnumerable<T> entities)
        {
            foreach (var item in entities)
                _dbSet.Add(item);
        }

        public virtual void Update(T entity)
        {
            _dbSet.AddOrUpdate(entity);
        }

        public void UpdateMany(IEnumerable<T> entities)
        {
            foreach (var item in entities)
                _dbSet.AddOrUpdate(item);
        }

        public virtual void Delete(T entity)
        {
            _dbSet.Attach(entity);
            _dbSet.Remove(entity);
        }

        public virtual void DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> entities = _dbSet.Where(predicate);

            foreach (var entity in entities)
            {
                _dbSet.Attach(entity);
                _dbSet.Remove(entity);
            }
        }

        #endregion
    }
}

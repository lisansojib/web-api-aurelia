using Starter.Core;
using Starter.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Starter.Data.Abstracts
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        int Count();

        int Count(Expression<Func<T, bool>> predicate);

        bool Exists(Expression<Func<T, bool>> predicate);

        string ExistingId(Expression<Func<T, bool>> predicate);

        IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetAll(int currentPage, int currentPageSize);

        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate, int currentPage, int currentPageSize);

        IEnumerable<SelectOptionModel> GetSelectOptions();

        IEnumerable<SelectOptionModel> GetSelectOptions(Expression<Func<T, bool>> predicate);

        T GetSingle(string id);

        T GetSingle(Expression<Func<T, bool>> predicate);

        T GetSingle(Expression<Func<T, bool>> predicate, bool withNew);

        T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);

        IEnumerable<T> FindByIncluding(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        void Add(T entity);

        void AddMany(IEnumerable<T> entities);

        void Update(T entity);

        void UpdateMany(IEnumerable<T> entities);

        void Delete(T entity);

        void DeleteWhere(Expression<Func<T, bool>> predicate);
    }
}

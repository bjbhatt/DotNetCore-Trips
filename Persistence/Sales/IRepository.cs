using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Sales.Persistence
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> List(); // GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity FindOne(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddMultiple(IEnumerable<TEntity> entities); //  AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveMultiple(IEnumerable<TEntity> entities); // RemoveRange(IEnumerable<TEntity> entities);
    }
}
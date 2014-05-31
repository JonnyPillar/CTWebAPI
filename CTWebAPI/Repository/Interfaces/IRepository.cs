using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CTWebAPI.Repository.Interfaces
{
    public interface IRepository<TEntity, in TKey> where TEntity : class
    {
        IEnumerable<TEntity> Get();
        TEntity Get(TKey id);
        IEnumerable<TEntity> GetRange(int quantity);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void Create(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
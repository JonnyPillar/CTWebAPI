using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CTWebAPI.Repository.Interfaces
{
    public interface IRepository<TEntity, in TKey> where TEntity : class
    {
        IEnumerable<TEntity> Get();
        TEntity Get(TKey id);
        Task<TEntity> GetAsync(TKey id);
        IEnumerable<TEntity> GetRange(int quantity);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void Create(TEntity entity);
        void Delete(TEntity entity);
        void Update(TKey key, TEntity entity);
        bool Exists(Expression<Func<TEntity, bool>> predicate);
    }
}
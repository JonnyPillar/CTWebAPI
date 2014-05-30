using System.Collections.Generic;

namespace CTWebAPI.Models.Repository
{
    public interface IRepository<TEntity, in TKey> where TEntity : class
    {
        TEntity Get(TKey id);
        IEnumerable<TEntity> GetAll();
        void Create(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
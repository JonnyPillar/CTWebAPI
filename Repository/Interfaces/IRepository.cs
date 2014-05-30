using System.Collections.Generic;

namespace CTWebAPI.Repository.Interfaces
{
    public interface IRepository<TEntity, in TKey> where TEntity : class
    {
        TEntity Get(TKey id);
        IEnumerable<TEntity> GetRange(int quantity);
        IEnumerable<TEntity> GetAll();
        void Create(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
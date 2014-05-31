using System.Collections.Generic;

namespace CTWebAPI.Repository.Interfaces
{
    public interface IRepository<TEntity, in TKey> where TEntity : class
    {
        IEnumerable<TEntity> Get();
        TEntity Get(TKey id);
        IEnumerable<TEntity> GetRange(int quantity);  
        void Create(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
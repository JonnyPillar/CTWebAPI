using System.Collections.Generic;

namespace CTWebAPI.Repository.Interfaces
{
    public interface IRepository<TEntity, in TKey> where TEntity : class
    {
        TEntity Retreive(TKey id);
        IEnumerable<TEntity> RetreiveAll();
        void Create(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
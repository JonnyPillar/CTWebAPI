using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CTWebAPI.Repository.Interfaces;

namespace CTWebAPI.Repository.DataLayer
{
    public class EntityFrameworkRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        private DbContext _dbContext;

        protected DbContext DbContext
        {
            get { return _dbContext; }
            set { _dbContext = value; }
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate);
        }

        public IEnumerable<TEntity> Get()
        {
            return _dbContext.Set<TEntity>();
        }

        public TEntity Get(TKey id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public async Task<TEntity> GetAsync(TKey id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public IEnumerable<TEntity> GetRange(int quantity)
        {
            IQueryable<TEntity> temp = _dbContext.Set<TEntity>();
            if (quantity > temp.Count()) return temp;
            return temp.Take(quantity);
        }

        public void Create(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            DbContext.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            DbContext.Set<TEntity>().Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            DbContext.Set<TEntity>().Attach(entity);
            DbContext.Set<TEntity>().Remove(entity);
        }

        public void Delete(int id)
        {
            TEntity entityToDelete = _dbContext.Set<TEntity>().Find(id);
            if (DbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbContext.Set<TEntity>().Attach(entityToDelete);
            }
            DbContext.Set<TEntity>().Remove(entityToDelete);
        }
    }
}
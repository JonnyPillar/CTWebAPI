using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using Ninject.Infrastructure.Language;

namespace CTWebAPI.Models.Repository
{
    public class EntityFrameworkRepository<TEntity, TKey> where TEntity : class, IRepository<TEntity, TKey>
    {
        private readonly DbContext _dbContext;

        public EntityFrameworkRepository()
            : this(new DbContext("CTEntities"))
        {
        }

        public EntityFrameworkRepository(DbContext dbContext)
        {
            if (dbContext == null) throw new ArgumentNullException("dbContext");
            _dbContext = dbContext;
        }

        protected DbContext DbContext
        {
            get { return _dbContext; }
        }

        public void Create(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            DbContext.Set<TEntity>().Add(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>();
        }

        public TEntity Get(TKey id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public void Delete(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            DbContext.Set<TEntity>().Attach(entity);
            DbContext.Set<TEntity>().Remove(entity);
        }

        public void Update(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            DbContext.Set<TEntity>().Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
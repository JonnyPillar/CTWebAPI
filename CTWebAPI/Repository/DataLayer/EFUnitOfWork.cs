using System;
using System.Data.Entity;
using System.Threading.Tasks;
using CTWebAPI.Models;
using CTWebAPI.Repository.Interfaces;

namespace CTWebAPI.Repository.DataLayer
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        private bool _disposed;
        private IRepository<User, int> _userRepository;
        private IRepository<Food, int> _foodRepository;

        public EFUnitOfWork()
        {
            _dbContext = new DbContext("CTEntities");
        }

        public IRepository<User, int> UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_dbContext);
                }
                return _userRepository;
            }
        }

        public IRepository<Food, int> FoodRepository
        {
            get
            {
                if (_foodRepository == null)
                {
                    _foodRepository = new FoodRepository(_dbContext);
                }
                return _foodRepository;
            }
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
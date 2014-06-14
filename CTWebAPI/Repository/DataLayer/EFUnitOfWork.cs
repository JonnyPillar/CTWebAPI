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
        private IRepository<Activity, int> _activityRepository;
        private IRepository<FoodGroup, int> _foodGroupRepository;
        private IRepository<Nutrient, int> _nutrientRepository;

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

        public IRepository<Activity, int> ActivityRepository
        {
            get
            {
                if (_activityRepository == null)
                {
                    _activityRepository = new ActivityRespository(_dbContext);
                }
                return _activityRepository;
            }
        }

        public IRepository<FoodGroup, int> FoodGroupRepository
        {
            get
            {
                if (_foodGroupRepository == null)
                {
                    _foodGroupRepository = new FoodGroupRepository(_dbContext);
                }
                return _foodGroupRepository;
            }
        }

        public IRepository<Nutrient, int> NutrientRepository
        {
            get
            {
                if (_nutrientRepository == null)
                {
                    _nutrientRepository = new NutrientRepository(_dbContext);
                }
                return _nutrientRepository;
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
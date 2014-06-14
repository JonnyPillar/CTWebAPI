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
        private IRepository<ActivityLog, int> _activityLogRepository;
        private IRepository<Activity, int> _activityRepository;
        private bool _disposed;
        private IRepository<FoodGroup, int> _foodGroupRepository;
        private IRepository<Food, int> _foodRepository;
        private IRepository<NutrientRDA, int> _nutrientRDARepository;
        private IRepository<Nutrient, int> _nutrientRepository;
        private IRepository<User, int> _userRepository;

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

        public IRepository<NutrientRDA, int> NutrientRDARepository
        {
            get
            {
                if (_nutrientRDARepository == null)
                {
                    _nutrientRDARepository = new NutrientRDARespository(_dbContext);
                }
                return _nutrientRDARepository;
            }
        }

        public IRepository<ActivityLog, int> ActivityLogRepository
        {
            get
            {
                if (_activityLogRepository == null)
                {
                    _activityLogRepository = new ActivityLogRepository(_dbContext);
                }
                return _activityLogRepository;
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
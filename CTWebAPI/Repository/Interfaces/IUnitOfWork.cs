using System;
using System.Threading.Tasks;
using CTWebAPI.Models;

namespace CTWebAPI.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User, int> UserRepository { get; }
        IRepository<Food, int> FoodRepository { get; }
        IRepository<FoodNutrientLog, int> FoodNutrientLogRepository { get; }
        IRepository<FoodGroup, int> FoodGroupRepository { get; }
        IRepository<FoodLog, int> FoodLogRepository { get; }
        IRepository<Activity, int> ActivityRepository { get; }
        IRepository<ActivityLog, int> ActivityLogRepository { get; }
        IRepository<Nutrient, int> NutrientRepository { get; }
        IRepository<NutrientRDA, int> NutrientRDARepository { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
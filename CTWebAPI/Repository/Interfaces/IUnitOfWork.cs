using System;
using System.Threading.Tasks;
using CTWebAPI.Models;

namespace CTWebAPI.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User, int> UserRepository { get; }
        IRepository<Food, int> FoodRepository { get; }
        IRepository<Activity, int> ActivityRepository { get; }
        IRepository<FoodGroup, int> FoodGroupRepository { get; }
        IRepository<Nutrient, int> NutrientRepository { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
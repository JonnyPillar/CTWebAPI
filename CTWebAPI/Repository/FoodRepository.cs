using System.Data.Entity;
using CTWebAPI.Models.DomainModels;
using CTWebAPI.Repository.DataLayer;
using CTWebAPI.Repository.Interfaces;

namespace CTWebAPI.Repository
{
    public class FoodRepository : EntityFrameworkRepository<Food, int>, IFoodRepository
    {
        public FoodRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
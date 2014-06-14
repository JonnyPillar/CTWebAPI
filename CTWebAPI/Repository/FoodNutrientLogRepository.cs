using System.Data.Entity;
using CTWebAPI.Models;
using CTWebAPI.Repository.DataLayer;
using CTWebAPI.Repository.Interfaces;

namespace CTWebAPI.Repository
{
    public class FoodNutrientLogRepository : EntityFrameworkRepository<FoodNutrientLog, int>, IFoodNutrientLog
    {
        public FoodNutrientLogRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
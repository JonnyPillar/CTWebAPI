using System.Data.Entity;
using CTWebAPI.Models.DomainModels;
using CTWebAPI.Repository.DataLayer;
using CTWebAPI.Repository.Interfaces;

namespace CTWebAPI.Repository
{
    public class FoodLogRepository : EntityFrameworkRepository<FoodLog, int>, IFoodLogRepository
    {
        public FoodLogRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
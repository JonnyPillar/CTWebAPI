using System.Data.Entity;
using CTWebAPI.Models.DomainModels;
using CTWebAPI.Repository.DataLayer;
using CTWebAPI.Repository.Interfaces;

namespace CTWebAPI.Repository
{
    public class FoodNutrientRecordRepository : EntityFrameworkRepository<FoodNutrientRecord, int>, IFoodNutrientLog
    {
        public FoodNutrientRecordRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
using System.Data.Entity;
using CTWebAPI.Models;
using CTWebAPI.Repository.DataLayer;
using CTWebAPI.Repository.Interfaces;

namespace CTWebAPI.Repository
{
    public class NutrientRepository : EntityFrameworkRepository<Nutrient, int>, INutrientRepository
    {
        public NutrientRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
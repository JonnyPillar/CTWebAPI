using System.Data.Entity;
using CTWebAPI.Domain.Data.Models.DomainModels;
using CTWebAPI.Domain.Services.Repository.DataLayer;
using CTWebAPI.Domain.Services.Repository.Interfaces;

namespace CTWebAPI.Domain.Services.Repository
{
    public class NutrientRepository : EntityFrameworkRepository<Nutrient, int>, INutrientRepository
    {
        public NutrientRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
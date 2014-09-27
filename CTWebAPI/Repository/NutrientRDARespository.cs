using System.Data.Entity;
using CTWebAPI.Models.DomainModels;
using CTWebAPI.Repository.DataLayer;
using CTWebAPI.Repository.Interfaces;

namespace CTWebAPI.Repository
{
    public class NutrientRDARespository : EntityFrameworkRepository<NutrientRDA, int>, INutrientRDARepository
    {
        public NutrientRDARespository(DbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
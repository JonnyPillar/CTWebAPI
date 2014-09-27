using System.Data.Entity;
using CTWebAPI.Domain.Data.Models.DomainModels;
using CTWebAPI.Domain.Services.Repository.DataLayer;
using CTWebAPI.Domain.Services.Repository.Interfaces;

namespace CTWebAPI.Domain.Services.Repository
{
    public class NutrientRDARespository : EntityFrameworkRepository<NutrientRDA, int>, INutrientRDARepository
    {
        public NutrientRDARespository(DbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
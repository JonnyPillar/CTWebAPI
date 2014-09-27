using System.Data.Entity;
using CTWebAPI.Domain.Data.Models.DomainModels;
using CTWebAPI.Domain.Services.Repository.DataLayer;
using CTWebAPI.Domain.Services.Repository.Interfaces;

namespace CTWebAPI.Domain.Services.Repository
{
    public class FoodGroupRepository : EntityFrameworkRepository<FoodGroup, int>, IFoodRepository
    {
        public FoodGroupRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
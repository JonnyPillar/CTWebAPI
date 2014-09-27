using System.Data.Entity;
using CTWebAPI.Domain.Data.Models.DomainModels;
using CTWebAPI.Domain.Services.Repository.DataLayer;
using CTWebAPI.Domain.Services.Repository.Interfaces;

namespace CTWebAPI.Domain.Services.Repository
{
    public class FoodRepository : EntityFrameworkRepository<Food, int>, IFoodRepository
    {
        public FoodRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
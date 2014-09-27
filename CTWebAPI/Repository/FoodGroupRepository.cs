using System.Data.Entity;
using CTWebAPI.Models;
using CTWebAPI.Models.DomainModels;
using CTWebAPI.Repository.DataLayer;
using CTWebAPI.Repository.Interfaces;

namespace CTWebAPI.Repository
{
    public class FoodGroupRepository : EntityFrameworkRepository<FoodGroup, int>, IFoodRepository
    {
        public FoodGroupRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
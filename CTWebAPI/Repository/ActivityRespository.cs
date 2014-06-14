using System.Data.Entity;
using CTWebAPI.Models;
using CTWebAPI.Repository.DataLayer;
using CTWebAPI.Repository.Interfaces;

namespace CTWebAPI.Repository
{
    public class ActivityRespository : EntityFrameworkRepository<Activity, int>, IActivityRespository
    {
        public ActivityRespository(DbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
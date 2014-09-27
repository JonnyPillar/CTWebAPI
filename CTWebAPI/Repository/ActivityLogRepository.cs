using System.Data.Entity;
using CTWebAPI.Models.DomainModels;
using CTWebAPI.Repository.DataLayer;
using CTWebAPI.Repository.Interfaces;

namespace CTWebAPI.Repository
{
    public class ActivityLogRepository : EntityFrameworkRepository<ActivityLog, int>, IActivityLog
    {
        public ActivityLogRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
using System.Data.Entity;
using CTWebAPI.Domain.Data.Models.DomainModels;
using CTWebAPI.Domain.Services.Repository.DataLayer;
using CTWebAPI.Domain.Services.Repository.Interfaces;

namespace CTWebAPI.Domain.Services.Repository
{
    public class ActivityLogRepository : EntityFrameworkRepository<ActivityLog, int>, IActivityLog
    {
        public ActivityLogRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
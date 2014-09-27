using System.Collections.Generic;
using CTWebAPI.Domain.Data.Models.DomainModels;

namespace CTWebAPI.Domain.Services.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User, int>
    {
        IEnumerable<User> GetAdminUsers();
    }
}
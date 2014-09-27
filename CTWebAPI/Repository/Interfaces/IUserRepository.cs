using System.Collections.Generic;
using CTWebAPI.Models;
using CTWebAPI.Models.DomainModels;

namespace CTWebAPI.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User, int>
    {
        IEnumerable<User> GetAdminUsers();
    }
}
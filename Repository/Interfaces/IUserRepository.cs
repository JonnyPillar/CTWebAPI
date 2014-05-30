using System.Collections.Generic;
using CTWebAPI.Models;

namespace CTWebAPI.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User, int>
    {
        IEnumerable<User> GetAdminUsers();
    }
}
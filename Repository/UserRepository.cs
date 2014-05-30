using System;
using System.Collections.Generic;
using CTWebAPI.Models;
using CTWebAPI.Repository.DataLayer;
using CTWebAPI.Repository.Interfaces;

namespace CTWebAPI.Repository
{
    public class UserRepository : EntityFrameworkRepository<User, int>, IUserRepository
    {
        public IEnumerable<User> GetAdminUsers()
        {
            throw new NotImplementedException();
        }
    }
}
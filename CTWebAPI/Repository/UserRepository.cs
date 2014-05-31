using System;
using System.Collections.Generic;
using System.Data.Entity;
using CTWebAPI.Models;
using CTWebAPI.Repository.DataLayer;
using CTWebAPI.Repository.Interfaces;

namespace CTWebAPI.Repository
{
    public class UserRepository : EntityFrameworkRepository<User, int>, IUserRepository
    {
        public UserRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public IEnumerable<User> GetAdminUsers()
        {
            throw new NotImplementedException();
        }
    }
}
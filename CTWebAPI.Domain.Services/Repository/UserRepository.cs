using System;
using System.Collections.Generic;
using System.Data.Entity;
using CTWebAPI.Domain.Data.Models.DomainModels;
using CTWebAPI.Domain.Services.Repository.DataLayer;
using CTWebAPI.Domain.Services.Repository.Interfaces;

namespace CTWebAPI.Domain.Services.Repository
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
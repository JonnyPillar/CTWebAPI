using System;
using CTWebAPI.Models;

namespace CTWebAPI.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User, int> UserRepository { get; }

        void SaveChanges();
    }
}
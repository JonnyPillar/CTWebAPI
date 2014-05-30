using System;
using CTWebAPI.Models.Repository;

namespace CTWebAPI.Models.UnitOfWork
{
    internal interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
        IRepository<User, int> UserRepository { get; }
    }
}
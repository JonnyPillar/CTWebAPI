using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTWebAPI.Models;

namespace CTWebAPI.Repository.Interfaces
{
    interface IUnitOfWork : IDisposable
    {
        IRepository<User, int> UserRepository { get; }

        void SaveChanges();
    }
}

using CTWebAPI.Models.Repository;

namespace CTWebAPI.Models.UnitOfWork
{
    public class EFUnitofWork : IUnitOfWork
    {
        private readonly CTEntities _context;

        private IRepository<User, int> _userRepository;

        public EFUnitofWork()
        {
            _context = new CTEntities();
        }

        public EFUnitofWork(CTEntities context)
        {
            _context = context;
        }

        public IRepository<User, int> UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_context);
                }
                return _userRepository;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
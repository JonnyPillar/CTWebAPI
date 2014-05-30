namespace CTWebAPI.Models.Repository
{
    public class UserRepository : EntityFrameworkRepository<User, int>, IUserRepository
    {
        private readonly CTEntities _dbContext;

        public UserRepository(CTEntities ctEntities)
        {
            _dbContext = ctEntities;
        }
    }
}
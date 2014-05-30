using System.Collections.Generic;
using System.Web.Http;
using CTWebAPI.Models;
using CTWebAPI.Models.Repository;
using CTWebAPI.Models.UnitOfWork;

namespace CTWebAPI.Controllers
{
    public class UserController : ApiController
    {
        private IUserRepository iUserRepository;

        public UserController(IUserRepository repository)
        {
            iUserRepository = repository;
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            List<User> userList = iUserRepository.Get();
        }

        // GET api/<controller>/5
        public User Get(int id)
        {
            User user = iUserRepository.Get(id);
            return user;
        }
    }
}
using System.Collections.Generic;
using System.Web.Http;
using CTWebAPI.Models;
using CTWebAPI.Repository.Interfaces;

namespace CTWebAPI.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Get(int id)
        {
            return _userRepository.Get(id);
        }

        public IEnumerable<User> Get()
        {
            return _userRepository.GetRange(100);
        }
    }
}
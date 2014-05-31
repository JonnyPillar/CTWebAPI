using System.Collections.Generic;
using System.Net;
using System.Net.Http;
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

        public IEnumerable<User> Get()
        {
            return _userRepository.GetRange(100);
        }

        public User Get(int id)
        {
            User user = _userRepository.Get(id);

            if (user == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }

            return user;
        }

        public IEnumerable<User> GetRange(int quantity)
        {
            return _userRepository.GetRange(quantity);
        }
    }
}
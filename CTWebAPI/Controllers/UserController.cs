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

        public IEnumerable<User> Get()
        {
            return _userRepository.Get();
        }

        public IHttpActionResult Get(int id)
        {
            User user = _userRepository.Get(id);

            if (user == null)
            {
                return NotFound();
                //throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }

            return Ok(user);
        }

        public IEnumerable<User> GetRange(int quantity)
        {
            return _userRepository.GetRange(quantity);
        }
    }
}
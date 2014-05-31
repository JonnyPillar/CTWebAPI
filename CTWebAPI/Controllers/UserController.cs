using System;
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
            }

            return Ok(user);
        }

        public IEnumerable<User> GetRange(int quantity)
        {
            return _userRepository.GetRange(quantity);
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userRepository.Create(user);
                    return Created("", user);
                }
                return BadRequest("Invalid Model");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult Put(int id, [FromBody] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    User originalUser = _userRepository.Get(id);
                    if (originalUser == null || originalUser.UserID != id)
                    {
                        return NotFound();
                    }
                    _userRepository.Update(user);
                    return Created("", user);
                }
                return BadRequest("Invalid Model");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult Delete([FromBody] User user)
        {
            try
            {
                if (user == null) return BadRequest("User Is Null");
                _userRepository.Delete(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }
    }
}
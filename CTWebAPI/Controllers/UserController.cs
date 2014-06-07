using System;
using System.Collections.Generic;
using System.Web.Http;
using CTWebAPI.Models;
using CTWebAPI.Repository.Interfaces;

namespace CTWebAPI.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _unitOfWork.UserRepository.Get();
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            User user = _unitOfWork.UserRepository.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet]
        public IEnumerable<User> GetRange(int quantity)
        {
            return _unitOfWork.UserRepository.GetRange(quantity);
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] User user)
        {
            try
            {
                if (user == null) return BadRequest("Invalid Model");
                if (ModelState.IsValid)
                {
                    _unitOfWork.UserRepository.Create(user);
                    _unitOfWork.SaveChanges();
                    return Created("Http://www.exmaple.com", user);
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
                    User originalUser = _unitOfWork.UserRepository.Get(id);
                    if (originalUser == null || originalUser.UserID != id)
                    {
                        return NotFound();
                    }
                    _unitOfWork.UserRepository.Update(user);
                    _unitOfWork.SaveChanges();
                    return Created("Http://www.exmaple.com", user);
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
                _unitOfWork.UserRepository.Delete(user);
                _unitOfWork.SaveChanges();
                return Ok("User Deleted Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }
    }
}
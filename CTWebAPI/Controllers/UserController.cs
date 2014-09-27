using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using CTWebAPI.Models.DomainModels;
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
        public async Task<IHttpActionResult> Get(int id)
        {
            User user = await _unitOfWork.UserRepository.GetAsync(id);

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
        public async Task<IHttpActionResult> Post([FromBody] User user)
        {
            try
            {
                if (user != null && ModelState.IsValid)
                {
                    bool userAlreadyExists =
                        _unitOfWork.UserRepository.Exists(x => x.EmailAddress.Equals(user.EmailAddress));
                    if (userAlreadyExists) return BadRequest("User Already Exists");

                    _unitOfWork.UserRepository.Create(user);
                    await _unitOfWork.SaveChangesAsync();
                    return Created("Http://www.exmaple.com", user);
                }
                return BadRequest("Invalid Model");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(int id, [FromBody] User user)
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
                    _unitOfWork.UserRepository.Update(id, user);
                    await _unitOfWork.SaveChangesAsync();
                    return Created("Http://www.exmaple.com", user);
                }
                return BadRequest("Invalid Model");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete([FromBody] User user)
        {
            try
            {
                if (user == null) return BadRequest("User Is Null");
                _unitOfWork.UserRepository.Delete(user);
                await _unitOfWork.SaveChangesAsync();
                return Ok("User Deleted Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }
    }
}
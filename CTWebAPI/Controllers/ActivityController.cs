using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using CTWebAPI.Domain.Data.Models.DomainModels;
using CTWebAPI.Domain.Services.Repository.Interfaces;

namespace CTWebAPI.Controllers
{
    public class ActivityController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActivityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Activity> Get()
        {
            return _unitOfWork.ActivityRepository.Get();
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            Activity activity = await _unitOfWork.ActivityRepository.GetAsync(id);

            if (activity == null)
            {
                return NotFound();
            }

            return Ok(activity);
        }


        [HttpGet]
        public IEnumerable<Activity> GetRange(int quantity)
        {
            return _unitOfWork.ActivityRepository.GetRange(quantity);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] Activity activity)
        {
            try
            {
                if (activity == null) return BadRequest("Invalid Model");
                
                if (ModelState.IsValid)
                {
                    if (activity.ActivityID != 0) return BadRequest("Activity Already Exists");

                    _unitOfWork.ActivityRepository.Create(activity);
                    await _unitOfWork.SaveChangesAsync();
                    return Created("Http://www.exmaple.com", activity);
                }
                return BadRequest("Invalid Model");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(int id, [FromBody] Activity activity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Activity originalActivity = _unitOfWork.ActivityRepository.Get(id);
                    if (originalActivity == null || originalActivity.ActivityID != id)
                    {
                        return NotFound();
                    }
                    _unitOfWork.ActivityRepository.Update(id, activity);
                    await _unitOfWork.SaveChangesAsync();
                    return Created("Http://www.exmaple.com", activity);
                }
                return BadRequest("Invalid Model");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete([FromBody] Activity activity)
        {
            try
            {
                if (activity == null) return BadRequest("Activity Is Null");
                _unitOfWork.ActivityRepository.Delete(activity);
                await _unitOfWork.SaveChangesAsync();
                return Ok("Activity Deleted Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }
    }
}
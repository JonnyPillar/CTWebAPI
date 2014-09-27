using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using CTWebAPI.Models.DomainModels;
using CTWebAPI.Repository.Interfaces;

namespace CTWebAPI.Controllers
{
    public class ActivityLogController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActivityLogController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<ActivityLog> Get()
        {
            return _unitOfWork.ActivityLogRepository.Get();
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            ActivityLog activityLog = await _unitOfWork.ActivityLogRepository.GetAsync(id);

            if (activityLog == null)
            {
                return NotFound();
            }

            return Ok(activityLog);
        }


        [HttpGet]
        public IEnumerable<ActivityLog> GetRange(int quantity)
        {
            return _unitOfWork.ActivityLogRepository.GetRange(quantity);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] ActivityLog activityLog)
        {
            try
            {
                if (activityLog == null) return BadRequest("Invalid Model");
                ActivityLog existingActivityLog = _unitOfWork.ActivityLogRepository.Get(activityLog.ActivityLogID);
                if (existingActivityLog != null) return BadRequest("ActivityLog Already Exists");
                if (ModelState.IsValid)
                {
                    _unitOfWork.ActivityLogRepository.Create(activityLog);
                    await _unitOfWork.SaveChangesAsync();
                    return Created("Http://www.exmaple.com", activityLog);
                }
                return BadRequest("Invalid Model");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(int id, [FromBody] ActivityLog activityLog)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ActivityLog originalActivityLog = _unitOfWork.ActivityLogRepository.Get(id);
                    if (originalActivityLog == null || originalActivityLog.ActivityLogID != id)
                    {
                        return NotFound();
                    }
                    _unitOfWork.ActivityLogRepository.Update(id, activityLog);
                    await _unitOfWork.SaveChangesAsync();
                    return Created("Http://www.exmaple.com", activityLog);
                }
                return BadRequest("Invalid Model");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete([FromBody] ActivityLog activityLog)
        {
            try
            {
                if (activityLog == null) return BadRequest("ActivityLog Is Null");
                _unitOfWork.ActivityLogRepository.Delete(activityLog);
                await _unitOfWork.SaveChangesAsync();
                return Ok("ActivityLog Deleted Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using CTWebAPI.Models;
using CTWebAPI.Repository.Interfaces;

namespace CTWebAPI.Controllers
{
    public class FoodLogController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public FoodLogController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<FoodLog> Get()
        {
            return _unitOfWork.FoodLogRepository.Get();
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            FoodLog foodLog = await _unitOfWork.FoodLogRepository.GetAsync(id);

            if (foodLog == null)
            {
                return NotFound();
            }

            return Ok(foodLog);
        }


        [HttpGet]
        public IEnumerable<FoodLog> GetRange(int quantity)
        {
            return _unitOfWork.FoodLogRepository.GetRange(quantity);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] FoodLog foodLog)
        {
            try
            {
                if (foodLog == null) return BadRequest("Invalid Model");
                FoodLog existingFoodLog = _unitOfWork.FoodLogRepository.Get(foodLog.FoodLogID);
                if (existingFoodLog != null) return BadRequest("FoodLog Already Exists");
                if (ModelState.IsValid)
                {
                    _unitOfWork.FoodLogRepository.Create(foodLog);
                    await _unitOfWork.SaveChangesAsync();
                    return Created("Http://www.exmaple.com", foodLog);
                }
                return BadRequest("Invalid Model");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(int id, [FromBody] FoodLog foodLog)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    FoodLog originalFoodLog = _unitOfWork.FoodLogRepository.Get(id);
                    if (originalFoodLog == null || originalFoodLog.FoodLogID != id)
                    {
                        return NotFound();
                    }
                    _unitOfWork.FoodLogRepository.Update(foodLog);
                    await _unitOfWork.SaveChangesAsync();
                    return Created("Http://www.exmaple.com", foodLog);
                }
                return BadRequest("Invalid Model");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete([FromBody] FoodLog foodLog)
        {
            try
            {
                if (foodLog == null) return BadRequest("FoodLog Is Null");
                _unitOfWork.FoodLogRepository.Delete(foodLog);
                await _unitOfWork.SaveChangesAsync();
                return Ok("FoodLog Deleted Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }
    }
}
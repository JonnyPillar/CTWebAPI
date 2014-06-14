using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using CTWebAPI.Models;
using CTWebAPI.Repository.Interfaces;

namespace CTWebAPI.Controllers
{
    public class FoodNutrientLogController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public FoodNutrientLogController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<FoodNutrientLog> Get()
        {
            return _unitOfWork.FoodNutrientLogRepository.Get();
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            FoodNutrientLog foodNutrientLog = await _unitOfWork.FoodNutrientLogRepository.GetAsync(id);

            if (foodNutrientLog == null)
            {
                return NotFound();
            }

            return Ok(foodNutrientLog);
        }


        [HttpGet]
        public IEnumerable<FoodNutrientLog> GetRange(int quantity)
        {
            return _unitOfWork.FoodNutrientLogRepository.GetRange(quantity);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] FoodNutrientLog foodNutrientLog)
        {
            try
            {
                if (foodNutrientLog == null) return BadRequest("Invalid Model");
                FoodNutrientLog existingFoodNutrientLog =
                    _unitOfWork.FoodNutrientLogRepository.Get(foodNutrientLog.NurtientLogID);
                if (existingFoodNutrientLog != null) return BadRequest("FoodNutrientLog Already Exists");
                if (ModelState.IsValid)
                {
                    _unitOfWork.FoodNutrientLogRepository.Create(foodNutrientLog);
                    await _unitOfWork.SaveChangesAsync();
                    return Created("Http://www.exmaple.com", foodNutrientLog);
                }
                return BadRequest("Invalid Model");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(int id, [FromBody] FoodNutrientLog foodNutrientLog)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    FoodNutrientLog originalFoodNutrientLog = _unitOfWork.FoodNutrientLogRepository.Get(id);
                    if (originalFoodNutrientLog == null || originalFoodNutrientLog.NurtientLogID != id)
                    {
                        return NotFound();
                    }
                    _unitOfWork.FoodNutrientLogRepository.Update(foodNutrientLog);
                    await _unitOfWork.SaveChangesAsync();
                    return Created("Http://www.exmaple.com", foodNutrientLog);
                }
                return BadRequest("Invalid Model");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete([FromBody] FoodNutrientLog foodNutrientLog)
        {
            try
            {
                if (foodNutrientLog == null) return BadRequest("FoodNutrientLog Is Null");
                _unitOfWork.FoodNutrientLogRepository.Delete(foodNutrientLog);
                await _unitOfWork.SaveChangesAsync();
                return Ok("FoodNutrientLog Deleted Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }
    }
}
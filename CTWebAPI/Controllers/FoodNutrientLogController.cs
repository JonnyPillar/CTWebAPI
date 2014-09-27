using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using CTWebAPI.Models.DomainModels;
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
        public IEnumerable<FoodNutrientRecord> Get()
        {
            return _unitOfWork.FoodNutrientRecordRepository.Get();
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            FoodNutrientRecord foodNutrientLog = await _unitOfWork.FoodNutrientRecordRepository.GetAsync(id);

            if (foodNutrientLog == null)
            {
                return NotFound();
            }

            return Ok(foodNutrientLog);
        }


        [HttpGet]
        public IEnumerable<FoodNutrientRecord> GetRange(int quantity)
        {
            return _unitOfWork.FoodNutrientRecordRepository.GetRange(quantity);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] FoodNutrientRecord foodNutrientLog)
        {
            try
            {
                if (foodNutrientLog == null) return BadRequest("Invalid Model");
                FoodNutrientRecord existingFoodNutrientLog =
                    _unitOfWork.FoodNutrientRecordRepository.Get(foodNutrientLog.FoodNutrientRecordID);
                if (existingFoodNutrientLog != null) return BadRequest("FoodNutrientLog Already Exists");
                if (ModelState.IsValid)
                {
                    _unitOfWork.FoodNutrientRecordRepository.Create(foodNutrientLog);
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
        public async Task<IHttpActionResult> Put(int id, [FromBody] FoodNutrientRecord foodNutrientLog)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    FoodNutrientRecord originalFoodNutrientLog = _unitOfWork.FoodNutrientRecordRepository.Get(id);
                    if (originalFoodNutrientLog == null || originalFoodNutrientLog.FoodNutrientRecordID != id)
                    {
                        return NotFound();
                    }
                    _unitOfWork.FoodNutrientRecordRepository.Update(id, foodNutrientLog);
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
        public async Task<IHttpActionResult> Delete([FromBody] FoodNutrientRecord foodNutrientLog)
        {
            try
            {
                if (foodNutrientLog == null) return BadRequest("FoodNutrientLog Is Null");
                _unitOfWork.FoodNutrientRecordRepository.Delete(foodNutrientLog);
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
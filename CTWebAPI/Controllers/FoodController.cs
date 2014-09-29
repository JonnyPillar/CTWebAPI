using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using CTWebAPI.Domain.Data.Models.APIContracts.Food;
using CTWebAPI.Domain.Data.Models.DomainModels;
using CTWebAPI.Domain.Services.Repository.Interfaces;

namespace CTWebAPI.Controllers
{
    public class FoodController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public FoodController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Food> Get()
        {
            return _unitOfWork.FoodRepository.Get();
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            Food food = await _unitOfWork.FoodRepository.GetAsync(id);

            if (food == null)
            {
                return NotFound();
            }

            return Ok(food);
        }

        [HttpGet]
        public IEnumerable<Food> GetRange(int quantity)
        {
            return _unitOfWork.FoodRepository.GetRange(quantity);
        }

        [HttpGet]
        public IEnumerable<Food> GetRange(int page, int quantity)
        {
            return _unitOfWork.FoodRepository.GetRange(page, quantity);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] FoodPostModel food)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (food == null) return BadRequest("Invalid Model");
                    bool foodExists = _unitOfWork.FoodRepository.Exists(x => x.Name.Equals(food.Name));
                    if (foodExists) return BadRequest("Food Item Already Exists");

                    var newFoodItem = new Food(food);

                    _unitOfWork.FoodRepository.Create(newFoodItem);
                    await _unitOfWork.SaveChangesAsync();
                    return Created("Http://www.exmaple.com", newFoodItem);
                }
                return BadRequest("Invalid Model");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(int id, [FromBody] FoodPutModel food)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Food originalFood = _unitOfWork.FoodRepository.Get(id);
                    if (originalFood == null || originalFood.FoodID != id)
                    {
                        return NotFound();
                    }

                    var updatedFoodItem = new Food(food);

                    _unitOfWork.FoodRepository.Update(id, updatedFoodItem);
                    await _unitOfWork.SaveChangesAsync();
                    return Created("Http://www.exmaple.com", updatedFoodItem);
                }
                return BadRequest("Invalid Model");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete([FromBody] Food food)
        {
            try
            {
                if (food == null) return BadRequest("ID Is Null");
                _unitOfWork.FoodRepository.Delete(food);
                await _unitOfWork.SaveChangesAsync();
                return Ok("Food Deleted Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }
    }
}
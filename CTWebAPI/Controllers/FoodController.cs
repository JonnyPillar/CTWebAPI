using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using CTWebAPI.Models.DomainModels;
using CTWebAPI.Repository.Interfaces;

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

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] Food food)
        {
            try
            {
                if (food == null) return BadRequest("Invalid Model");
                Food existingFood = _unitOfWork.FoodRepository.Get(food.FoodID);
                if (existingFood != null) return BadRequest("User Already Exists");
                if (ModelState.IsValid)
                {
                    _unitOfWork.FoodRepository.Create(food);
                    await _unitOfWork.SaveChangesAsync();
                    return Created("Http://www.exmaple.com", food);
                }
                return BadRequest("Invalid Model");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(int id, [FromBody] Food food)
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
                    _unitOfWork.FoodRepository.Update(food);
                    await _unitOfWork.SaveChangesAsync();
                    return Created("Http://www.exmaple.com", food);
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
                if (food == null) return BadRequest("User Is Null");
                _unitOfWork.FoodRepository.Delete(food);
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
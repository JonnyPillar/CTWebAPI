using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using CTWebAPI.Models.DomainModels;
using CTWebAPI.Repository.Interfaces;

namespace CTWebAPI.Controllers
{
    public class FoodGroupController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public FoodGroupController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<FoodGroup> Get()
        {
            return _unitOfWork.FoodGroupRepository.Get();
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            FoodGroup foodGroup = await _unitOfWork.FoodGroupRepository.GetAsync(id);

            if (foodGroup == null)
            {
                return NotFound();
            }

            return Ok(foodGroup);
        }

        [HttpGet]
        public IEnumerable<FoodGroup> GetRange(int quantity)
        {
            return _unitOfWork.FoodGroupRepository.GetRange(quantity);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] FoodGroup foodGroup)
        {
            try
            {
                if (foodGroup == null) return BadRequest("Invalid Model");
                FoodGroup existingFoodGroup = _unitOfWork.FoodGroupRepository.Get(foodGroup.FoodGroupID);
                if (existingFoodGroup != null) return BadRequest("User Already Exists");
                if (ModelState.IsValid)
                {
                    _unitOfWork.FoodGroupRepository.Create(foodGroup);
                    await _unitOfWork.SaveChangesAsync();
                    return Created("Http://www.exmaple.com", foodGroup);
                }
                return BadRequest("Invalid Model");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(int id, [FromBody] FoodGroup foodGroup)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    FoodGroup originalFoodGroup = _unitOfWork.FoodGroupRepository.Get(id);
                    if (originalFoodGroup == null || originalFoodGroup.FoodGroupID != id)
                    {
                        return NotFound();
                    }
                    _unitOfWork.FoodGroupRepository.Update(id, foodGroup);
                    await _unitOfWork.SaveChangesAsync();
                    return Created("Http://www.exmaple.com", foodGroup);
                }
                return BadRequest("Invalid Model");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete([FromBody] FoodGroup foodGroup)
        {
            try
            {
                if (foodGroup == null) return BadRequest("User Is Null");
                _unitOfWork.FoodGroupRepository.Delete(foodGroup);
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
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using CTWebAPI.Domain.Data.Models.APIContracts.FoodGroup;
using CTWebAPI.Domain.Data.Models.DomainModels;
using CTWebAPI.Domain.Services.Repository.Interfaces;

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
        public async Task<IHttpActionResult> Post([FromBody] FoodGroupPostModel foodGroup)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (foodGroup == null) return BadRequest("Invalid Model");
                    bool foodGroupExists = _unitOfWork.FoodGroupRepository.Exists(x => x.Name.Equals(foodGroup.Name));
                    if (foodGroupExists) return BadRequest("Food Group Already Exists");

                    var newFoodGroup = new FoodGroup(foodGroup);

                    _unitOfWork.FoodGroupRepository.Create(newFoodGroup);
                    await _unitOfWork.SaveChangesAsync();
                    return Created("Http://www.exmaple.com", newFoodGroup);
                }
                return BadRequest("Invalid Model");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(int id, [FromBody] FoodGroupPutModel foodGroup)
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
                    var updatedFoodGroup = new FoodGroup(foodGroup);
                    _unitOfWork.FoodGroupRepository.Update(id, updatedFoodGroup);
                    await _unitOfWork.SaveChangesAsync();
                    return Created("Http://www.exmaple.com", updatedFoodGroup);
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
                if (foodGroup == null) return BadRequest("ID Is Null");
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
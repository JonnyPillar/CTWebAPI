using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using CTWebAPI.Models.DomainModels;
using CTWebAPI.Repository.Interfaces;

namespace CTWebAPI.Controllers
{
    public class NutrientController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public NutrientController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Nutrient> Get()
        {
            return _unitOfWork.NutrientRepository.Get();
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            Nutrient nutrient = await _unitOfWork.NutrientRepository.GetAsync(id);

            if (nutrient == null)
            {
                return NotFound();
            }

            return Ok(nutrient);
        }


        [HttpGet]
        public IEnumerable<Nutrient> GetRange(int quantity)
        {
            return _unitOfWork.NutrientRepository.GetRange(quantity);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] Nutrient nutrient)
        {
            try
            {
                if (nutrient == null) return BadRequest("Invalid Model");
                Nutrient existingNutrient = _unitOfWork.NutrientRepository.Get(nutrient.NutrientID);
                if (existingNutrient != null) return BadRequest("Nutrient Already Exists");
                if (ModelState.IsValid)
                {
                    _unitOfWork.NutrientRepository.Create(nutrient);
                    await _unitOfWork.SaveChangesAsync();
                    return Created("Http://www.exmaple.com", nutrient);
                }
                return BadRequest("Invalid Model");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(int id, [FromBody] Nutrient nutrient)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Nutrient originalNutrient = _unitOfWork.NutrientRepository.Get(id);
                    if (originalNutrient == null || originalNutrient.NutrientID != id)
                    {
                        return NotFound();
                    }
                    _unitOfWork.NutrientRepository.Update(nutrient);
                    await _unitOfWork.SaveChangesAsync();
                    return Created("Http://www.exmaple.com", nutrient);
                }
                return BadRequest("Invalid Model");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete([FromBody] Nutrient nutrient)
        {
            try
            {
                if (nutrient == null) return BadRequest("Nutrient Is Null");
                _unitOfWork.NutrientRepository.Delete(nutrient);
                await _unitOfWork.SaveChangesAsync();
                return Ok("Nutrient Deleted Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }
    }
}
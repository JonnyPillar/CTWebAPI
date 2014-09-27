using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using CTWebAPI.Models.DomainModels;
using CTWebAPI.Repository.Interfaces;

namespace CTWebAPI.Controllers
{
    public class NutrientRDAController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public NutrientRDAController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<NutrientRDA> Get()
        {
            return _unitOfWork.NutrientRDARepository.Get();
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            NutrientRDA nutrientRDA = await _unitOfWork.NutrientRDARepository.GetAsync(id);

            if (nutrientRDA == null)
            {
                return NotFound();
            }

            return Ok(nutrientRDA);
        }

        [HttpGet]
        public IEnumerable<NutrientRDA> GetRange(int quantity)
        {
            return _unitOfWork.NutrientRDARepository.GetRange(quantity);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] NutrientRDA nutrientRDA)
        {
            try
            {
                if (nutrientRDA == null) return BadRequest("Invalid Model");
                NutrientRDA existingNutrientRDA = _unitOfWork.NutrientRDARepository.Get(nutrientRDA.NutrientRDAID);
                if (existingNutrientRDA != null) return BadRequest("NutrientRDA Already Exists");
                if (ModelState.IsValid)
                {
                    _unitOfWork.NutrientRDARepository.Create(nutrientRDA);
                    await _unitOfWork.SaveChangesAsync();
                    return Created("Http://www.exmaple.com", nutrientRDA);
                }
                return BadRequest("Invalid Model");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(int id, [FromBody] NutrientRDA nutrientRDA)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    NutrientRDA originalNutrientRDA = _unitOfWork.NutrientRDARepository.Get(id);
                    if (originalNutrientRDA == null || originalNutrientRDA.NutrientRDAID != id)
                    {
                        return NotFound();
                    }
                    _unitOfWork.NutrientRDARepository.Update(nutrientRDA);
                    await _unitOfWork.SaveChangesAsync();
                    return Created("Http://www.exmaple.com", nutrientRDA);
                }
                return BadRequest("Invalid Model");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete([FromBody] NutrientRDA nutrientRDA)
        {
            try
            {
                if (nutrientRDA == null) return BadRequest("NutrientRDA Is Null");
                _unitOfWork.NutrientRDARepository.Delete(nutrientRDA);
                await _unitOfWork.SaveChangesAsync();
                return Ok("NutrientRDA Deleted Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }
    }
}
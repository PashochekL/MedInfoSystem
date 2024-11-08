using MedInfoSystem.Data.DTO.Speciality;
using MedInfoSystem.Data.Entities;
using MedInfoSystem.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace MedInfoSystem.Controllers
{
    [ApiController]
    [Route("api/speciality")]
    public class SpecialityController : ControllerBase
    {
        private readonly ISpecialtyService _specialtyService;

        public SpecialityController(ISpecialtyService specialtyService)
        {
            _specialtyService = specialtyService;
        }

        /// <summary>
        /// Get List specialities
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">InternalServerError</response>
        [HttpGet("specialities")]
        public async Task<ActionResult<List<SpecialityGetDTO>>> GetAllSpecialties()
        {
            var specialties = await _specialtyService.GetAllSpecialtiesAsync();

            return Ok(specialties);
        }
    }
}

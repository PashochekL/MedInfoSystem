using MedInfoSystem.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MedInfoSystem.Data.DTO.Patient;
using Microsoft.AspNetCore.Http.HttpResults;
using MedInfoSystem.Data.Entities;
using MedInfoSystem.Data.DTO.Inspection;

namespace MedInfoSystem.Controllers
{
    [ApiController]
    [Route("api/patient")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddNewPatient([FromBody] PatientCreateDTO patientCreateDTO)
        {
            var idClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "doctorId");

            if (idClaim != null)
            {
                Guid patientId = await _patientService.AddPatient(patientCreateDTO);

                return Ok(new { patientId });
            }
        
            return Unauthorized("User is not authorized");
        }

        [HttpPost("{id}/inspections")]
        [Authorize]
        public async Task<IActionResult> AddInspection([FromRoute] Guid id, [FromBody] InspectionCreateDTO inspectionCreateDTO)
        {
            var authHeader = HttpContext.Request.Headers["Authorization"].FirstOrDefault();

            if (authHeader != null && authHeader.StartsWith("Bearer "))
            {
                var inspectionId = await _patientService.AddInspectionForpatient(id, inspectionCreateDTO);

                return Ok(new { inspectionId });
            }

            return Unauthorized("User is not authorized");
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetPatientId([FromRoute] Guid id)
        {
            var authHeader = HttpContext.Request.Headers["Authorization"].FirstOrDefault();

            if (authHeader != null && authHeader.StartsWith("Bearer "))
            {
                var patient = await _patientService.GetPatientById(id);

                return Ok(new { patient });
            }

            return Unauthorized("User is not authorized");
        }
    }
}

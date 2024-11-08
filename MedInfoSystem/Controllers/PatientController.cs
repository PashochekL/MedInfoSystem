using MedInfoSystem.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MedInfoSystem.Data.DTO.Patient;
using Microsoft.AspNetCore.Http.HttpResults;
using MedInfoSystem.Data.Entities;
using MedInfoSystem.Data.DTO.Inspection;
using MedInfoSystem.Data.DTO.Consultations;
using MedInfoSystem.Data.Entities.Enums;

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
            var doctorIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "doctorId");

            if (doctorIdClaim != null)
            {
                Guid patientId = await _patientService.AddPatient(patientCreateDTO);

                return Ok(new { patientId, message = "Patient was registered" });
            }
        
            return Unauthorized("User is not authorized");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetPationsList(string? name, [FromQuery] List<Conclusion>? conclusions,
            [FromQuery] Sorting? sorting = null, bool? scheduledVisits = false, bool? onlyMine = false, int page = 1, int size = 5)
        {
            var doctorIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "doctorId");

            if (doctorIdClaim != null)
            {
                if (Guid.TryParse(doctorIdClaim.Value, out Guid doctorId))
                {
                    var parients = await _patientService.GetPatientsList(doctorId, name, conclusions, sorting, scheduledVisits, onlyMine, page, size);

                    return Ok(parients);
                }
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
                var inspectionId = await _patientService.AddInspectionForPatient(id, inspectionCreateDTO);

                return Ok(new { inspectionId });
            }

            return Unauthorized("User is not authorized");
        }

        [HttpGet("{id}/inspections")]
        [Authorize]
        public async Task<IActionResult> GetListPatientInspections(Guid id, bool? groopedFlag = null, [FromQuery] List<string> icdRoots = null, int page = 1, int size = 5)
        {
            var doctorIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "doctorId");

            if (doctorIdClaim != null)
            {
                var listInspections = await _patientService.GetPatientInspections(id, groopedFlag, icdRoots, page, size);

                return Ok((InspectionPageListDTO)listInspections);
            }
            return Unauthorized("User is not authorized");
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetPatientId(Guid id)
        {
            var doctorIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "doctorId");

            if (doctorIdClaim != null)
            {
                var patient = await _patientService.GetPatientById(id);

                return Ok(new { patient });
            }

            return Unauthorized("User is not authorized");
        }

        [HttpGet("{id}/inspections/search")]
        [Authorize]
        public async Task<IActionResult> GetPationInspectionsWithoutChildInspections(Guid id, string? request)
        {
            var doctorIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "doctorId");

            if (doctorIdClaim != null)
            { 
                var inspectionsList = await _patientService.GetInspectionsWithoutChild(id, request);

                return Ok(inspectionsList);
            }
            return Unauthorized("User is not authorized");
        }
    }
}

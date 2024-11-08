using MedInfoSystem.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MedInfoSystem.Data.DTO.Patient;
using Microsoft.AspNetCore.Http.HttpResults;
using MedInfoSystem.Data.Entities;
using MedInfoSystem.Data.DTO.Inspection;
using MedInfoSystem.Data.DTO.Consultations;
using MedInfoSystem.Data.Entities.Enums;
using DocumentFormat.OpenXml.Math;

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

        /// <summary>
        /// Create new patient
        /// </summary>
        /// <response code="200">Patient was registered</response>
        /// <response code="400">Invalid arguments</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">InternalServerError</response>
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

        /// <summary>
        /// Get patient list
        /// </summary>
        /// <param name="name">part of the name for filtering</param>
        /// <param name="conclusions">conclusion list to filter by conclusions</param>
        /// <param name="sorting">option to sort patients</param>
        /// <param name="scheduledVisits">show only scheduled visits</param>
        /// <param name="page">page number</param>
        /// <param name="size">required number of elements per page</param>
        /// <response code="200">Patients paged list retrieved</response>
        /// <response code="400">Invalid arguments for filtration/pagination/sorting</response>
        /// <response code="401">Аuthorized</response>
        /// <response code="500">Unauthorized</response>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<PatientPageListDTO>> GetPationsList(string? name, [FromQuery] List<Conclusion>? conclusions,
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

        /// <summary>
        /// Create inspection for specified patient
        /// </summary>
        /// <param name="id">Patient's identifier</param>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Аuthorized</response>
        /// <response code="500">Unauthorized</response>
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

        /// <summary>
        /// Get a list of patient medical inspections
        /// </summary>
        /// <param name="id">Patient's identifier</param>
        /// <param name="grouped">flag - whether grouping by inspection chain is required - for filtration</param>
        /// <param name="icdRoots">root elements for ICD-10 - for filtration</param>
        /// <param name="page">page number</param>
        /// <param name="size">required number of elements per page</param>
        /// <response code="200">Patients inspections list retrieved</response>
        /// <response code="400">Invalid arguments for filtration/pagination/sorting</response>
        /// <response code="401">Аuthorized</response>
        /// <response code="404">Patient not found</response>
        /// <response code="500">Unauthorized</response>
        [HttpGet("{id}/inspections")]
        [Authorize]
        public async Task<ActionResult<InspectionPageListDTO>> GetListPatientInspections(Guid id, bool? groopedFlag = null, [FromQuery] List<string> icdRoots = null, int page = 1, int size = 5)
        {
            var doctorIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "doctorId");

            if (doctorIdClaim != null)
            {
                var listInspections = await _patientService.GetPatientInspections(id, groopedFlag, icdRoots, page, size);

                return Ok(listInspections);
            }
            return Unauthorized("User is not authorized");
        }

        /// <summary>
        /// Get patient card
        /// </summary>
        /// <param name="id">Patient's identifier</param>
        /// <response code="200">Success</response>
        /// <response code="401">Аuthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Unauthorized</response>
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<PatientInfoDTO>> GetPatientId(Guid id)
        {
            var doctorIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "doctorId");

            if (doctorIdClaim != null)
            {
                var patient = await _patientService.GetPatientById(id);

                return Ok(new { patient });
            }

            return Unauthorized("User is not authorized");
        }

        /// <summary>
        /// Search for patient medical inspections without child inspections
        /// </summary>
        /// <param name="id">Patient's identifier</param>
        /// <param name="request">part of the diagnosis name or code</param>
        /// <response code="200">Patients inspections list retrieved</response>
        /// <response code="401">Аuthorized</response>
        /// <response code="404">Patient not found</response>
        /// <response code="500">Unauthorized</response>
        [HttpGet("{id}/inspections/search")]
        [Authorize]
        public async Task<ActionResult<InspectionShortModelDTO>> GetPationInspectionsWithoutChildInspections(Guid id, string? request)
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

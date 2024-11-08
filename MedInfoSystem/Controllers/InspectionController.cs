using DocumentFormat.OpenXml.Spreadsheet;
using MedInfoSystem.Data.DTO.Inspection;
using MedInfoSystem.Data.Entities;
using MedInfoSystem.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedInfoSystem.Controllers
{
    [ApiController]
    [Route("api/inspection")]
    public class InspectionController : ControllerBase
    {
        private readonly IInspectionService _inspectionService;

        public InspectionController(IInspectionService inspectionService)
        {
            _inspectionService = inspectionService;
        }

        /// <summary>
        /// Get full information about specified inspection
        /// </summary>
        /// <param name="id">Inspection's identifier</param>
        /// <response code="200">Inspection found and successfully extracted</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">InternalServerError</response>
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<InspectionGetDTO>> GetFullInfAboutInspection(Guid id)
        {
            var doctorIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "doctorId");

            if (doctorIdClaim != null)
            {
                var inspection = await _inspectionService.GetFullInfInspection(id);

                return Ok( new {inspection} );
            }
            return Unauthorized("User is not authorized");
        }

        /// <summary>
        /// Edit concrete inspection
        /// </summary>
        /// <param name="id">Inspection's identifier</param>
        /// <response code="200">Success</response>
        /// <response code="400">Invalid arguments</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">User doesn't have editing rights (not the inspection author)</response>
        /// <response code="404">Patient not found</response>
        /// <response code="500">InternalServerError</response>
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> EditInspection(Guid id, [FromBody] InspectionEditModelDTO inspectionEditModelDTO)
        {
            var doctorIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "doctorId");

            if (doctorIdClaim != null)
            {
                if (Guid.TryParse(doctorIdClaim.Value, out Guid doctorId))
                {
                    await _inspectionService.EditInspection(doctorId, id, inspectionEditModelDTO);

                    return StatusCode(200, "Success");
                }
            }
            return Unauthorized("User is not authorized");
        }

        /// <summary>
        /// Get medical inspection chain for root inspection
        /// </summary>
        /// <param name="id">Root inspection's identifier</param>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Patient not found</response>
        /// <response code="500">InternalServerError</response>
        [HttpGet("{id}/chain")]
        [Authorize]
        public async Task<ActionResult<InspectionRootGetDTO>> GetInspectionRoot(Guid id)
        {
            var doctorIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "doctorId");

            if (doctorIdClaim != null)
            {
                var inspections = await _inspectionService.GetRootInspection(id);

                return Ok((inspections));
            }
            return Unauthorized("User is not authorized");
        }
    }
}

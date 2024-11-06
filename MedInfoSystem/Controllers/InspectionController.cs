using MedInfoSystem.Data.DTO.Inspection;
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

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetFullInfAboutInspection(Guid id)
        {
            var doctorIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "doctorId");

            if (doctorIdClaim != null)
            {
                var inspection = await _inspectionService.GetFullInfInspection(id);

                return Ok( new {inspection});
            }
            return Unauthorized("User is not authorized");
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> EditInspection(Guid id, [FromBody] InspectionEditModelDTO inspectionEditModelDTO)
        {
            var doctorIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "doctorId");

            if (doctorIdClaim != null)
            {
                await _inspectionService.EditInspection(id, inspectionEditModelDTO);

                return StatusCode(200, "Profile edit success");
            }
            return Unauthorized("User is not authorized");
        }

        [HttpGet("{id}/chain")]
        [Authorize]
        public async Task<IActionResult> GetInspectionRoot(Guid id)
        {
            var doctorIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "doctorId");

            if (doctorIdClaim != null)
            {
                var inspection = await _inspectionService.GetRootInspection(id);

                return Ok( new {inspection});
            }
            return Unauthorized("User is not authorized");
        }
    }
}

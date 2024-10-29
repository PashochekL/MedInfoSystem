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
        private readonly IInspectionService _InspectionService;

        public InspectionController(IInspectionService inspectionService)
        {
            _InspectionService = inspectionService;
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> EditInspection(Guid id, [FromBody] InspectionEditModelDTO inspectionEditModelDTO)
        {
            var doctorIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "doctorId");

            if (doctorIdClaim != null)
            {
                await _InspectionService.EditInspection(id, inspectionEditModelDTO);

                return StatusCode(200, "Profile edit success");
            }
            return Unauthorized("User is not authorized");
        }
    }
}

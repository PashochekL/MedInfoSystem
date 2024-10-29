using MedInfoSystem.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using MedInfoSystem.Data.Entities;
using MedInfoSystem.Data.DTO.Consultations;

namespace MedInfoSystem.Controllers
{
    [ApiController]
    [Route("api/consultation")]
    public class ConsultationController : ControllerBase
    {
        private readonly IConsultationService _consultationService;

        public ConsultationController(IConsultationService consultationService)
        {
            _consultationService = consultationService;
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetConsultation(Guid id)
        {
            var doctorIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "doctorId");

            if (doctorIdClaim != null)
            {
                var consultation = await _consultationService.GetConsultation(id);

                return Ok(new { consultation });
            }

            return Unauthorized("User is not authorized");
        }

        [HttpPut("comment/{id}")]
        [Authorize]
        public async Task<IActionResult> EditComment(Guid id, [FromBody] ConsultationEditCommentDTO consultationEditCommentDTO)
        {
            var doctorIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "doctorId");

            if (doctorIdClaim != null)
            {
                await _consultationService.EditComment(id, consultationEditCommentDTO);

                return StatusCode(200, "Profile edit success");
            }

            return Unauthorized("User is not authorized");
        }
    }
}

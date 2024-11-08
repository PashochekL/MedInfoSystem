using MedInfoSystem.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using MedInfoSystem.Data.Entities;
using MedInfoSystem.Data.DTO.Consultations;
using MedInfoSystem.Data.DTO.Comment;
using MedInfoSystem.Data.DTO.Inspection;

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

        /// <summary>
        /// Get a list of medical inspections for consultation
        /// </summary>
        /// <param name="groopedFlag">flag - whether grouping by inspection chain is required - for filtration</param>
        /// <param name="icdRoots">root elements for ICD-10 - for filtration</param>
        /// <param name="page">page number</param>
        /// <param name="size">required number of elements per page</param>
        /// <response code="200">Inspections for consultation list retrieved</response>
        /// <response code="400">Invalid arguments for filtration/pagination</response>
        /// <response code="401">Аuthorized</response>
        /// <response code="500">Unauthorized</response>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<InspectionPageListDTO>> GetListInspectionsForConsultation(bool? groopedFlag = false, [FromQuery] List<string> icdRoots = null, int page = 1, int size = 5)
        {
            var doctorIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "doctorId");

            if (doctorIdClaim != null)
            {

                if (Guid.TryParse(doctorIdClaim.Value, out Guid doctorId))
                {
                    var listInspection = await _consultationService.GetListInspections(doctorId, groopedFlag, icdRoots, page, size);

                    return Ok(listInspection);
                }
            }
            return Unauthorized("User is not authorized");
        }

        /// <summary>
        /// Get concrete consultation
        /// </summary>
        /// <param name="id">Consultation's identifier</param>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">InternalServerError</response>
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ConsultationGetModelDTO>> GetConsultation(Guid id)
        {
            var doctorIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "doctorId");

            if (doctorIdClaim != null)
            {
                var consultation = await _consultationService.GetConsultation(id);

                return Ok(new { consultation });
            }

            return Unauthorized("User is not authorized");
        }

        /// <summary>
        /// Add comment to concrete consultation
        /// </summary>
        /// <param name="id">Consultation's identifier</param>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">User doesn't have add comment to consultation (unsuitable specialty and not the inspection author)</response>
        /// <response code="404">Consultation or parent comment not found</response>
        /// <response code="500">InternalServerError</response>
        [HttpPost("{id}/comment")]
        [Authorize]
        public async Task<IActionResult> AddNewComment(Guid id, [FromBody] CommentCreateDTO commentCreateDTO)
        {
            var doctorIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "doctorId");

            if (doctorIdClaim != null)
            {
                if (Guid.TryParse(doctorIdClaim.Value, out Guid doctorId))
                {
                    var commentId = await _consultationService.AddComment(id, doctorId, commentCreateDTO);

                    return Ok(new { commentId });
                }
            }
            return Unauthorized("User is not authorized");
        }

        /// <summary>
        /// Edit comment
        /// </summary>
        /// <param name="id">Comment's identifier</param>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">User is not the author of the comment</response>
        /// <response code="404">Comment not found</response>
        /// <response code="500">InternalServerError</response>
        [HttpPut("comment/{id}")]
        [Authorize]
        public async Task<IActionResult> EditComment(Guid id, [FromBody] ConsultationEditCommentDTO consultationEditCommentDTO)
        {
            var doctorIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "doctorId");

            if (doctorIdClaim != null)
            {
                if (Guid.TryParse(doctorIdClaim.Value, out Guid doctorId))
                {
                    await _consultationService.EditComment(doctorId, id, consultationEditCommentDTO);

                    return StatusCode(200, "Profile edit success");
                }
            }

            return Unauthorized("User is not authorized");
        }
    }
}

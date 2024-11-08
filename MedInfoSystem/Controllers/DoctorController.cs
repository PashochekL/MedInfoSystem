using MedInfoSystem.Data.DTO.Doctor;
using MedInfoSystem.Data.Entities;
using MedInfoSystem.Services;
using MedInfoSystem.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedInfoSystem.Controllers
{
    [ApiController]
    [Route("api/doctor")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _service;
        private readonly TokenBlacklistService _tokenBlacklistService;

        public DoctorController(IDoctorService service, TokenBlacklistService tokenBlacklistService)
        {
            _service = service;
            _tokenBlacklistService = tokenBlacklistService;
        }

        /// <summary>
        /// Register new user
        /// </summary>
        /// <response code="200">Doctor was registered</response>
        /// <response code="400">Invalid arguments</response>
        /// <response code="500">InternalServerError</response>
        [HttpPost("register")]
        public async Task<IActionResult> AddNewUser([FromBody] DoctorRegisterDTO doctorRegisterDTO)
        {
            string tokenAutorize = await _service.AddDoctor(doctorRegisterDTO);
            
            return Ok(new { token = tokenAutorize });
        }

        /// <summary>
        /// Log in to the system
        /// </summary>
        /// <response code="200">Doctor was registered</response>
        /// <response code="400">Invalid arguments</response>
        /// <response code="500">InternalServerError</response>
        [HttpPost("login")]
        public async Task<IActionResult> AutorizeDoctor([FromBody] DoctorLoginDTO doctorLoginDTO)
        {
            string tokenAutorize = await _service.AutorizeDoctor(doctorLoginDTO);
            
            return Ok(new { token = tokenAutorize });
        }

        /// <summary>
        /// Log out system user
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">InternalServerError</response>
        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> LogoutUser()
        {
            var authHeader = HttpContext.Request.Headers["Authorization"].FirstOrDefault();

            if (authHeader != null && authHeader.StartsWith("Bearer "))
            {
                var token = authHeader.Substring("Bearer ".Length).Trim();

                await _tokenBlacklistService.RevokeTokenAsync(token);

                return Ok("Success");
            }

            return Unauthorized("User is not authorized");
        }

        /// <summary>
        /// Get user profile
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">InternalServerError</response>
        [HttpGet("profile")]
        [Authorize]
        public async Task<ActionResult<DoctorModelDTO>> GetUserProfile()
        {
            var doctorIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "doctorId");

            if (doctorIdClaim != null)
            {

                if (Guid.TryParse(doctorIdClaim.Value, out Guid doctorId))
                {
                    DoctorModelDTO doctorModelDTO = await _service.GetProfile(doctorId);

                    return Ok(new { doctorModelDTO });
                }
            }

            return Unauthorized("User is not authorized");
        }

        /// <summary>
        /// Edit user profile
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">InternalServerError</response>
        [HttpPut("profile")]
        [Authorize]
        public async Task<IActionResult> EditUserProfile([FromBody] DoctorEditDTO doctorEditDTO)
        {
            var doctorIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "doctorId");

            if (doctorIdClaim != null)
            {
                if (Guid.TryParse(doctorIdClaim.Value, out Guid doctorId))
                {
                    await _service.EditProfile(doctorId, doctorEditDTO);
                    
                    return StatusCode(200, "Profile edit success");
                }
            }

            return Unauthorized("User is not authorized");
        }
    }
}

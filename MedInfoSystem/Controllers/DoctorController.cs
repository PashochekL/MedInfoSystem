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

        [HttpPost("register")]
        public async Task<IActionResult> AddNewUser([FromBody] DoctorRegisterDTO doctorRegisterDTO)
        {
            string tokenAutorize = await _service.AddDoctor(doctorRegisterDTO);
            
            return Ok(new { token = tokenAutorize });
        }

        [HttpPost("login")]
        public async Task<IActionResult> AutorizeDoctor([FromBody] DoctorLoginDTO doctorLoginDTO)
        {
            string tokenAutorize = await _service.AutorizeDoctor(doctorLoginDTO);
            
            return Ok(new { token = tokenAutorize });
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> LogoutUser()
        {
            var authHeader = HttpContext.Request.Headers["Authorization"].FirstOrDefault();

            if (authHeader != null && authHeader.StartsWith("Bearer "))
            {
                var token = authHeader.Substring("Bearer ".Length).Trim();

                await _tokenBlacklistService.RevokeTokenAsync(token);

                return Ok("User logged out successfully.");
            }

            return Unauthorized("User is not authorized");
        }

        [HttpGet("profile")]
        [Authorize]
        public async Task<IActionResult> GetUserProfile()
        {
            var doctorIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "doctorId");

            if (doctorIdClaim != null)
            {

                if (Guid.TryParse(doctorIdClaim.Value, out Guid doctorId))
                {
                    DoctorModelDTO doctorModelDTO = await _service.GetProfile(doctorId);

                    if (doctorModelDTO == null)
                    {
                        return NotFound("Doctor not found");
                    }

                    return Ok(new { doctorModelDTO });
                }
            }

            return Unauthorized("User is not authorized");
        }

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

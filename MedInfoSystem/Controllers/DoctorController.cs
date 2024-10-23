using MedInfoSystem.Data.DTO.Doctor;
using MedInfoSystem.Data.Entities;
using MedInfoSystem.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedInfoSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _service;

        public DoctorController(IDoctorService service)
        {
            _service = service;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddNewUser([FromBody] DoctorRegisterDTO doctorRegisterDTO)
        {
            await _service.AddDoctor(doctorRegisterDTO);
            return Ok();
        }

        [HttpPost("authorize")]
        public async Task<IActionResult> AutorizeDoctor([FromBody] DoctorLoginDTO doctorLoginDTO)
        {
            string tokenAutorize = await _service.AutorizeDoctor(doctorLoginDTO);
            return Ok(new { token = tokenAutorize });
        }

        [HttpGet("logout")]
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
                        throw new Exception("Doctor not found");
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

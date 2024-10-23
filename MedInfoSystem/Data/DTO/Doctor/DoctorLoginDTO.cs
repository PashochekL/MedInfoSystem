using System.ComponentModel.DataAnnotations;

namespace MedInfoSystem.Data.DTO.Doctor
{
    public class DoctorLoginDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }
    }
}

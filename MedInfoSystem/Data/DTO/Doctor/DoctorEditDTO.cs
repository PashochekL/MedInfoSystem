using MedInfoSystem.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace MedInfoSystem.Data.DTO.Doctor
{
    public class DoctorEditDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [StringLength(15)]
        [RegularExpression(@"^\+?[0-9]{10,15}$", ErrorMessage = "Неверный формат номера телефона.")]
        public string Phone { get; set; }
    }
}

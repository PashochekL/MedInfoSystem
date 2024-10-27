using MedInfoSystem.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace MedInfoSystem.Data.DTO.Patient
{
    public class PatientCreateDTO
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public Gender Gender { get; set; }
    }
}

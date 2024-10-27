using System.ComponentModel.DataAnnotations;

namespace MedInfoSystem.Data.DTO.Speciality
{
    public class SpecialityDTO
    {
        public string? Name { get; set; }
        [Required]
        public Guid Id { get; set; }
        [Required]
        public DateTime CreateTime { get; set; }
    }
}

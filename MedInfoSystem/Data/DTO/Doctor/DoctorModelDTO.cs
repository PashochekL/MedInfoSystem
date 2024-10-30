using MedInfoSystem.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace MedInfoSystem.Data.DTO.Doctor
{
    public class DoctorModelDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime CreateTime { get; set; }
    }
}

using MedInfoSystem.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace MedInfoSystem.Data.Entities
{
    public class Doctor
    {
        public Guid Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [StringLength(15)]
        [RegularExpression(@"^\+?[0-9]{10,15}$", ErrorMessage = "Неверный формат номера телефона.")]
        public string Phone { get; set; }
        public DateTime CreateTime { get; set; }
        public string Password { get; set; }

        public List<Inspection> Inspection { get; set; }

        public Guid SpecialityId { get; set; }
        public Speciality speciality { get; set; }
    }
}

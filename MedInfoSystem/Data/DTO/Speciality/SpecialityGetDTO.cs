using MedInfoSystem.Data.DTO.Consultations;

namespace MedInfoSystem.Data.DTO.Speciality
{
    public class SpecialityGetDTO
    {
        public Guid Id { get; set; }
        public DateTime CreateTime { get; set; }
        public string Name { get; set; }
    }
}

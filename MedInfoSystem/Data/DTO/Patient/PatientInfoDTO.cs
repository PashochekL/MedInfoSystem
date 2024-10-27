using MedInfoSystem.Data.Entities.Enums;

namespace MedInfoSystem.Data.DTO.Patient
{
    public class PatientInfoDTO
    {
        public Guid Id { get; set; }
        public DateTime CreateTime { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
    }
}

using MedInfoSystem.Data.Entities.Enums;

namespace MedInfoSystem.Data.DTO.Diagnosis
{
    public class DiagnosisGetDTO
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DiagnosisType Type { get; set; }

        public DateTime CreateTime { get; set; }
    }
}

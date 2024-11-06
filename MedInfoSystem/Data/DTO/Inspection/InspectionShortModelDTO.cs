using MedInfoSystem.Data.DTO.Diagnosis;
using MedInfoSystem.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace MedInfoSystem.Data.DTO.Inspection
{
    public class InspectionShortModelDTO
    {
        public Guid Id { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime Date { get; set; }

        public List<DiagnosisGetDTO> Diagnoses { get; set; }
    }
}

using MedInfoSystem.Data.DTO.Consultations;
using MedInfoSystem.Data.DTO.Diagnosis;
using MedInfoSystem.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace MedInfoSystem.Data.DTO.Inspection
{
    public class InspectionCreateDTO
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [StringLength(5000, MinimumLength = 1)]
        public string Anamesis { get; set; }
        [Required]
        [StringLength(5000, MinimumLength = 1)]
        public string Complaints { get; set; }
        [Required]
        [StringLength(5000, MinimumLength = 1)]
        public string Treatment { get; set; }
        public Conclusion Conclusion { get; set; }
        public DateTime? NextVisitDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public Guid? PreviousInspectionId { get; set; }

        public List<DiagnosisCreateDTO> Diagnoses { get; set; }
        public List<ConsultationCreateDTO>? Consultations { get; set; }
    }
}

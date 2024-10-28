using MedInfoSystem.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;
namespace MedInfoSystem.Data.DTO.Diagnosis
{
    public class DiagnosisCreateDTO
    {
        [Required]
        public Guid IcdDiagnosisId { get; set; }
        [StringLength(5000)]
        public string Description { get; set; }
        [Required]
        public DiagnosisType Type { get; set; }
    }
}

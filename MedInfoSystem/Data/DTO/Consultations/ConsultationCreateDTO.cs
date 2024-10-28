using MedInfoSystem.Data.DTO.Inspection;
using System.ComponentModel.DataAnnotations;

namespace MedInfoSystem.Data.DTO.Consultations
{
    public class ConsultationCreateDTO
    {
        [Required]
        public Guid SpecialityId { get; set; }
        public List<InspectionCommentCreateDTO>? Comment { get; set; }
    }
}

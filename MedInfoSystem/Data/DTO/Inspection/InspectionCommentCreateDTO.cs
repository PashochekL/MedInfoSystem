using System.ComponentModel.DataAnnotations;

namespace MedInfoSystem.Data.DTO.Inspection
{
    public class InspectionCommentCreateDTO
    {
        [Required]
        [StringLength(1000, MinimumLength = 1)]
        public string Content { get; set; }
    }
}

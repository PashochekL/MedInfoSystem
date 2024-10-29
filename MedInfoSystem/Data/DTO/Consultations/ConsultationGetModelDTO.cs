using MedInfoSystem.Data.DTO.Comment;
using MedInfoSystem.Data.DTO.Speciality;

namespace MedInfoSystem.Data.DTO.Consultations
{
    public class ConsultationGetModelDTO
    {
        public Guid Id { get; set; }
        public DateTime CreateTime { get; set; }
        public Guid InspectionId { get; set; }

        public Guid SpecialityId { get; set; }
        public SpecialityGetDTO Speciality { get; set; }

        public List<CommentGetDTO>? Comments { get; set; }
    }
}

using MedInfoSystem.Data.DTO.Comment;
using MedInfoSystem.Data.DTO.Consultations;
using MedInfoSystem.Data.DTO.Inspection;

namespace MedInfoSystem.Services.IServices
{
    public interface IConsultationService
    {
        public Task<InspectionPageListDTO> GetListInspections(Guid doctorId, bool? groopedFlag, List<string> icdRoots, int page = 1, int size = 5);
        public Task<ConsultationGetModelDTO> GetConsultation(Guid consultationId);
        public Task<Guid> AddComment(Guid consultationId, Guid doctorId, CommentCreateDTO commentCreateDTO);
        public Task EditComment(Guid doctorId, Guid commentId, ConsultationEditCommentDTO consultationEditCommentDTO);
    }
}

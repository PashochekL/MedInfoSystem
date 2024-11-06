using MedInfoSystem.Data.DTO.Comment;
using MedInfoSystem.Data.DTO.Consultations;

namespace MedInfoSystem.Services.IServices
{
    public interface IConsultationService
    {
        public Task<ConsultationGetModelDTO> GetConsultation(Guid consultationId);
        public Task<Guid> AddComment(Guid consultationId, Guid doctorId, CommentCreateDTO commentCreateDTO);
        public Task EditComment(Guid commentId, ConsultationEditCommentDTO consultationEditCommentDTO);
    }
}

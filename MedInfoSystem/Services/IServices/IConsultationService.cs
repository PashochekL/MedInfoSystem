using MedInfoSystem.Data.DTO.Consultations;

namespace MedInfoSystem.Services.IServices
{
    public interface IConsultationService
    {
        public Task<ConsultationGetModelDTO> GetConsultation(Guid consultationId);
        public Task EditComment(Guid commentId, ConsultationEditCommentDTO consultationEditCommentDTO);
    }
}

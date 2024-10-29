using MedInfoSystem.Data;
using MedInfoSystem.Data.DTO.Comment;
using MedInfoSystem.Data.DTO.Consultations;
using MedInfoSystem.Data.DTO.Speciality;
using MedInfoSystem.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace MedInfoSystem.Services
{
    public class ConsultationService : IConsultationService
    {
        private readonly AppDBContext _dbContext;

        public ConsultationService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ConsultationGetModelDTO> GetConsultation(Guid consultationId)
        {
            var consultation = await _dbContext.Consultations
                .Include(c => c.Speciality)
                .Include(c => c.RootComment)
                .ThenInclude(comment => comment.Author)
                .FirstOrDefaultAsync(i => i.Id == consultationId);

            if (consultation == null)
            {
                throw new Exception("Consultation not found");
            }

            SpecialityGetDTO specialityGetDTO = new SpecialityGetDTO()
            {
                Id = consultation.SpecialityId,
                CreateTime = consultation.Speciality.CreateTime,
                Name = consultation.Speciality.Name
            };

            var commentDTOs = consultation.RootComment?.Select(comment => new CommentGetDTO
            {
                Id = comment.ID,
                Content = comment.Content,
                CreateTime = comment.CreateTime,
                ModifiedDate = comment.ModifyTime,
                AuthorId = comment.AuthorId,
                Author = comment.Author.speciality.Name,
                ParentId = comment.ParentId

            }).ToList() ?? new List<CommentGetDTO>();

            ConsultationGetModelDTO consultationGetModelDTO = new ConsultationGetModelDTO()
            {
                Id = consultationId,
                CreateTime = consultation.CreateTime,
                InspectionId = consultation.InspectionId,
                Speciality = specialityGetDTO,
                Comments = commentDTOs
            };
            return consultationGetModelDTO;
        }

        public async Task EditComment(Guid commentId, ConsultationEditCommentDTO consultationEditCommentDTO)
        {
            var comment = await _dbContext.Comments.FindAsync(commentId);

            if (comment == null)
            {
                throw new Exception("Comment not found");
            }

            comment.Content = consultationEditCommentDTO.content;
            comment.ModifyTime = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync();
        }
    }
}

using MedInfoSystem.Data;
using MedInfoSystem.Data.DTO.Comment;
using MedInfoSystem.Data.DTO.Consultations;
using MedInfoSystem.Data.DTO.Diagnosis;
using MedInfoSystem.Data.DTO.Inspection;
using MedInfoSystem.Data.DTO.Speciality;
using MedInfoSystem.Data.Entities;
using MedInfoSystem.Services.Exceptions;
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

        public async Task<InspectionPageListDTO> GetListInspections(Guid doctorId, bool? groopedFlag, List<string> icdRoots, int page = 1, int size = 5)
        {
            IQueryable<Inspection> inspections = _dbContext.Inspections.Include(i => i.Diagnoses).Where(i => i.DoctorId == doctorId);

            if (!inspections.Any())
            {
                throw new NotFoundException("Inspections not found");
            }

            if (icdRoots != null && icdRoots.Count != 0)
            {
                List<string> icdCodes = await _dbContext.ICDs.Where(icd => icdRoots
                                .Contains(icd.Id.ToString())).Select(icd => icd.CodeICD).ToListAsync();
                if (icdCodes != null)
                {
                    inspections = inspections.Where(inspection => inspection.Diagnoses.Any(d => icdCodes.Contains(d.Code)));
                }
                else
                {
                    throw new BadHttpRequestException("Invalid arguments for filtration/pagination");
                }
            }

            var count = await inspections.CountAsync();

            List<InspectionPreviewDTO> items = null;

            if (groopedFlag == null)
            {
                items = await inspections.Skip((page - 1) * size).Take(size).
                Select(i => new InspectionPreviewDTO
                {
                    Id = i.Id,
                    CreateTime = i.CreateTime,
                    Date = i.Date,
                    Conclusion = i.Conclusion,
                    DoctorId = i.DoctorId,
                    Doctor = i.Doctor.Name,
                    PatientId = i.PatientId,
                    Patient = i.Patient.Name,
                    Diagnosis = i.Diagnoses.Select(d => new DiagnosisGetDTO
                    {
                        Id = d.Id,
                        Code = d.Code,
                        Name = d.Name,
                        Description = d.Description,
                        Type = d.Type,
                        CreateTime = d.CreateTime

                    }).ToList(),
                    HasChain = inspections.Any(inner => inner.PreviousInspectionId == null),
                    HasNested = inspections.Any(inner => inner.PreviousInspectionId == i.Id)

                }).ToListAsync();
            }
            else if (groopedFlag == true)
            {
                var filteredInspections = inspections.Where(i => i.PreviousInspectionId == null);

                items = await filteredInspections.Skip((page - 1) * size).Take(size).
                Select(i => new InspectionPreviewDTO
                {
                    Id = i.Id,
                    CreateTime = i.CreateTime,
                    Date = i.Date,
                    Conclusion = i.Conclusion,
                    DoctorId = i.DoctorId,
                    Doctor = i.Doctor.Name,
                    PatientId = i.PatientId,
                    Patient = i.Patient.Name,
                    Diagnosis = i.Diagnoses.Select(d => new DiagnosisGetDTO
                    {
                        Id = d.Id,
                        Code = d.Code,
                        Name = d.Name,
                        Description = d.Description,
                        Type = d.Type,
                        CreateTime = d.CreateTime

                    }).ToList(),
                    HasChain = inspections.Any(inner => inner.PreviousInspectionId == null),
                    HasNested = inspections.Any(inner => inner.PreviousInspectionId == i.Id)

                }).ToListAsync();
            }
            else
            {
                var filteredInspections = inspections.Where(i => i.PreviousInspectionId != null);

                items = await filteredInspections.Skip((page - 1) * size).Take(size).
                Select(i => new InspectionPreviewDTO
                {
                    Id = i.Id,
                    CreateTime = i.CreateTime,
                    Date = i.Date,
                    Conclusion = i.Conclusion,
                    DoctorId = i.DoctorId,
                    Doctor = i.Doctor.Name,
                    PatientId = i.PatientId,
                    Patient = i.Patient.Name,
                    Diagnosis = i.Diagnoses.Select(d => new DiagnosisGetDTO
                    {
                        Id = d.Id,
                        Code = d.Code,
                        Name = d.Name,
                        Description = d.Description,
                        Type = d.Type,
                        CreateTime = d.CreateTime

                    }).ToList(),
                    HasChain = inspections.Any(inner => inner.PreviousInspectionId == null),
                    HasNested = inspections.Any(inner => inner.PreviousInspectionId == i.Id)

                }).ToListAsync();
            }

            List<InspectionPreviewDTO> inspectionPreviewDTO = items;

            Pagination pagination = new Pagination(count, page, size);
            InspectionPageListDTO inspectionPageListDTO = new InspectionPageListDTO
            {
                Pagination = pagination,
                Inspections = inspectionPreviewDTO
            };

            return inspectionPageListDTO;
        }

        public async Task<ConsultationGetModelDTO> GetConsultation(Guid consultationId)
        {
            var consultation = await _dbContext.Consultations
                .Include(c => c.Speciality)
                .Include(c => c.RootComment)
                    .ThenInclude(comment => comment.Author)
                        .ThenInclude(author => author.speciality)
                .FirstOrDefaultAsync(i => i.Id == consultationId);

            if (consultation == null)
            {
                throw new NotFoundException("Consultation not found");
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

        public async Task<Guid> AddComment(Guid consultationId, Guid doctorId, CommentCreateDTO commentCreateDTO)
        {
            var consultation = await _dbContext.Consultations.Include(c => c.RootComment).FirstOrDefaultAsync(i => i.Id == consultationId);
            var doctor = await _dbContext.Doctors.FirstOrDefaultAsync(i => i.Id ==  doctorId);

            if (consultation == null)
            {
                throw new NotFoundException("Consultation not found");
            }

            if (doctor.SpecialityId != consultation.SpecialityId)
            {
                throw new NotFoundUser("User doesn't have add comment to consultation");
            }

            Comment comment = new Comment()
            {
                ParentId = commentCreateDTO.ParentId,
                Content = commentCreateDTO.Content,
                AuthorId = doctor.Id,
                Author = doctor,
                CreateTime = DateTime.UtcNow,
                ConsultationId = consultation.Id
            };

            if (comment.ParentId.HasValue)
            {
                var parentComment = await _dbContext.Comments
                    .FirstOrDefaultAsync(c => c.ID == comment.ParentId.Value && c.ConsultationId == consultation.Id);

                if (parentComment == null)
                {
                    throw new NotFoundException("Parent comment not found");
                }
            }


            await _dbContext.Comments.AddAsync(comment);
            await _dbContext.SaveChangesAsync();

            consultation.RootComment.Add(comment);
            consultation.CommentsNumber++;

            await _dbContext.SaveChangesAsync();

            return comment.ID;
        }

        public async Task EditComment(Guid doctorId, Guid commentId, ConsultationEditCommentDTO consultationEditCommentDTO)
        {
            var comment = await _dbContext.Comments.FindAsync(commentId);

            if (comment == null)
            {
                throw new NotFoundException("Comment not found");
            }

            if (consultationEditCommentDTO.content == "")
            {
                throw new BadHttpRequestException("Invalid arguments");
            }

            if (comment.AuthorId != doctorId)
            {
                throw new NotFoundUser("User is not the author of the comment");
            }

            comment.Content = consultationEditCommentDTO.content;
            comment.ModifyTime = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync();
        }
    }
}

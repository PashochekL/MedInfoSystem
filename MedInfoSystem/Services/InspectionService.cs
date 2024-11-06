using MedInfoSystem.Data;
using MedInfoSystem.Data.DTO.Comment;
using MedInfoSystem.Data.DTO.Consultations;
using MedInfoSystem.Data.Entities.Enums;
using MedInfoSystem.Data.DTO.Diagnosis;
using MedInfoSystem.Data.DTO.Doctor;
using MedInfoSystem.Data.DTO.Inspection;
using MedInfoSystem.Data.DTO.Patient;
using MedInfoSystem.Data.DTO.Speciality;
using MedInfoSystem.Data.Entities;
using MedInfoSystem.Services.IServices;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MedInfoSystem.Services
{
    public class InspectionService : IInspectionService
    {
        private readonly AppDBContext _dbContext;

        public InspectionService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<InspectionGetDTO> GetFullInfInspection(Guid inspectionId)
        {
            var inspection = await _dbContext.Inspections
                .Include(i => i.Patient)
                .Include(i => i.Doctor)
                .Include(i => i.Diagnoses)
                .Include(i => i.Consultations)
                    .ThenInclude(c => c.RootComment)
                .Include(i => i.Consultations)
                    .ThenInclude(c => c.Speciality)
                .FirstOrDefaultAsync(i => i.Id == inspectionId);

            if (inspection == null)
            {
                throw new Exception("Inspection not found");
            }

            var consultation = inspection.Consultations.Select(c => new ConsultationGetDTO
            {
                Id = c.Id,
                CreateTime = c.CreateTime,
                InspectionId = inspectionId,
                Speciality = new SpecialityGetDTO
                {
                    Id = c.SpecialityId,
                    Name = c.Speciality.Name,
                    CreateTime = c.Speciality.CreateTime
                },
                Comments = c.RootComment.Select(comment => new CommentGetDTO
                {
                    Id = comment.ID,
                    CreateTime = comment.CreateTime,
                    ModifiedDate = comment.ModifyTime,
                    Content = comment.Content,
                    AuthorId = comment.AuthorId,
                    Author = comment.Author.Name,
                    ParentId = comment.ParentId
                }).ToList()
            }).ToList();

            var diagnosis = inspection.Diagnoses.Select(d => new DiagnosisGetDTO
            {
                Id= d.Id,
                Code = d.Code,
                CreateTime= d.CreateTime,
                Name = d.Name,
                Description = d.Description,
                Type = d.Type
            }).ToList();

            DoctorModelDTO doctorModelDTO = new DoctorModelDTO()
            {
                Id = inspection.DoctorId,
                Name = inspection.Doctor.Name,
                Birthday = inspection.Doctor.Birthday,
                Gender = inspection.Doctor.Gender,
                Email = inspection.Doctor.Email,
                Phone = inspection.Doctor.Phone,
                CreateTime = inspection.Doctor.CreateTime
            };

            PatientGetDTO patientGetDTO = new PatientGetDTO()
            { 
                Id = inspection.PatientId,
                CreateTime = inspection.Patient.CreateTime,
                Name = inspection.Patient.Name,
                Birthday= inspection.Patient.Birthday,
                Gender = inspection.Patient.Gender
            };

            InspectionGetDTO inspectionGetDTO = new InspectionGetDTO()
            {
                Id = inspection.Id,
                CreateTime = inspection.CreateTime,
                Date = inspection.Date,
                Anamnesis = inspection.Anamnesis,
                Complaints = inspection.Complaints,
                Treatment = inspection.Treatment,
                Conclusion = inspection.Conclusion,
                NextVisitDate = inspection.NextVisitDate,
                DeathDate = inspection.DeathDate,
                BaseInspectionId = inspection.BaseInspectionId,
                PreviousInspectionId = inspection.PreviousInspectionId,
                Patient = patientGetDTO,
                Doctor = doctorModelDTO,
                Diagnoses = diagnosis,
                Consultations = consultation
            };

            return inspectionGetDTO;
        }

        public async Task EditInspection(Guid inspectionId, InspectionEditModelDTO inspectionEditModelDTO)
        {
            var inspection = await _dbContext.Inspections.Include(i => i.Diagnoses).FirstOrDefaultAsync(i => i.Id == inspectionId);

            if (inspection == null)
            {
                throw new Exception("Inspection not found");
            }

            if (inspectionEditModelDTO.Conclusion == Conclusion.Disease)
            {
                inspection.Anamnesis = inspectionEditModelDTO.Anamesis;
                inspection.Complaints = inspectionEditModelDTO.Complaints;
                inspection.Treatment = inspectionEditModelDTO.Treatment;
                inspection.Conclusion = inspectionEditModelDTO.Conclusion;
                inspection.NextVisitDate = inspectionEditModelDTO.NextVisitDate;
            }
            else if (inspectionEditModelDTO.Conclusion == Conclusion.Death)
            {
                inspection.Anamnesis = inspectionEditModelDTO.Anamesis;
                inspection.Complaints = inspectionEditModelDTO.Complaints;
                inspection.Treatment = inspectionEditModelDTO.Treatment;
                inspection.Conclusion = inspectionEditModelDTO.Conclusion;
                inspection.DeathDate = inspectionEditModelDTO.DeathDate;
            }
            else
            {
                inspection.Anamnesis = inspectionEditModelDTO.Anamesis;
                inspection.Complaints = inspectionEditModelDTO.Complaints;
                inspection.Treatment = inspectionEditModelDTO.Treatment;
                inspection.Conclusion = inspectionEditModelDTO.Conclusion;
            }

            var newDiagnoses = inspectionEditModelDTO.Diagnoses;

            inspection.Diagnoses.RemoveAll(d => !newDiagnoses.Any(nd => nd.IcdDiagnosisId == d.InspectionId)); // перепроверить на 2+ диагноза записанных и приходящих в изменении

            foreach (var diagnoses in newDiagnoses)
            {
                var icdCode = await _dbContext.ICDs.Where(i => i.Id == diagnoses.IcdDiagnosisId).Select(i => i.CodeICD).ToListAsync();
                var icdName = await _dbContext.ICDs.Where(i => i.Id == diagnoses.IcdDiagnosisId).Select(i => i.Name).ToListAsync();

                if (icdCode == null)
                {
                    throw new Exception("Inspection not found");
                }

                var oldDiagnoses = inspection.Diagnoses.FirstOrDefault(d => d.Code == icdCode[0]);

                if (oldDiagnoses != null)
                {
                    oldDiagnoses.Description = diagnoses.Description;
                    oldDiagnoses.Type = diagnoses.Type;
                }
                else
                {
                    var newDiagn = new Diagnosis
                    {
                        Code = icdCode[0],
                        Type = diagnoses.Type,
                        Description = diagnoses.Description,
                        Name = icdName[0],
                        InspectionId = inspectionId,
                        CreateTime = DateTime.UtcNow
                    };
                    inspection.Diagnoses.Add(newDiagn);
                }
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task<InspectionRootGetDTO> GetRootInspection(Guid inspectionId)
        {
            var inspections = await _dbContext.Inspections
                .Include(i => i.Diagnoses)
                .Include(i => i.Doctor)
                .Include(i => i.Patient)
                .ToListAsync();

            if (!inspections.Any())
            {
                throw new Exception("Inspection not found");
            }

            bool chain = false;
            bool nested = false;
            DiagnosisGetDTO newDiagnosis;
            InspectionRootGetDTO inspectionRootGetDTO = null;

            foreach (var inspection in inspections)
            {
                if (inspection.PreviousInspectionId == inspectionId)
                {
                    nested = true;
                    break;
                }
            }

            foreach (var inspection in inspections)
            {
                if (inspection.Id == inspectionId)
                {
                    if (inspection.Id == inspection.BaseInspectionId)
                    {
                        chain = true;
                    }

                    var diagnoses = inspection.Diagnoses.ToList();
                    var mainDiagnosis = diagnoses.FirstOrDefault(d => d.Type == DiagnosisType.Main);

                    newDiagnosis = new DiagnosisGetDTO
                    {
                        Id = mainDiagnosis.Id,
                        Code = mainDiagnosis.Code,
                        Name = mainDiagnosis.Name,
                        CreateTime = mainDiagnosis.CreateTime,
                        Description = mainDiagnosis.Description,
                        Type = mainDiagnosis.Type
                    };

                    inspectionRootGetDTO = new InspectionRootGetDTO
                    {
                        Id = inspectionId,
                        CreateTime = inspection.CreateTime,
                        Date = inspection.Date,
                        Conclusion = inspection.Conclusion,
                        PreviousId = inspection.PreviousInspectionId,
                        DoctorId = inspection.DoctorId,
                        Doctor = inspection.Doctor.Name,
                        PatientId = inspection.PatientId,
                        Patient = inspection.Patient.Name,
                        Diagnosis = newDiagnosis,
                        HasChain = chain,
                        HasNested = nested
                    };
                    break;
                }
            }

            return inspectionRootGetDTO;
        }
    }
}

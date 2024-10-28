using MedInfoSystem.Data;
using MedInfoSystem.Data.DTO.Inspection;
using MedInfoSystem.Data.DTO.Patient;
using MedInfoSystem.Data.Entities;
using MedInfoSystem.Data.Entities.Enums;
using MedInfoSystem.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace MedInfoSystem.Services
{
    public class PatientService : IPatientService
    {
        private readonly AppDBContext _dbContext;

        public PatientService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> AddPatient(PatientCreateDTO patientCreateDTO)
        {
            if (patientCreateDTO == null)
            {
                throw new BadHttpRequestException("Empty request field");
            }

            Patient patient = new Patient()
            {
                Name = patientCreateDTO.Name,
                Birthday = patientCreateDTO.Birthday,
                Gender = patientCreateDTO.Gender,
                CreateTime = DateTime.UtcNow
            };
            _dbContext.Add(patient);
            await _dbContext.SaveChangesAsync();

            return patient.Id;
        }

        public async Task<Guid> AddInspectionForpatient(Guid patientId, InspectionCreateDTO inspectionCreateDTO)
        {
            if (patientId == Guid.Empty)
            {
                throw new BadHttpRequestException("Empty request field");
            }
            var specialityId = inspectionCreateDTO.Consultations.FirstOrDefault().SpecialityId;
            var patient = await _dbContext.Patients.FindAsync(patientId);
            var doctor = await _dbContext.Doctors.FirstOrDefaultAsync(d => d.SpecialityId == specialityId);

            if (doctor == null)
            {
                throw new BadHttpRequestException("Doctor with the specified speciality not found.");
            }

            Inspection inspection = new Inspection()
            {
                Anamnesis = inspectionCreateDTO.Anamesis,
                Complaints = inspectionCreateDTO.Complaints,
                Treatment = inspectionCreateDTO.Treatment,
                Conclusion = inspectionCreateDTO.Conclusion,
                NextVisitDate = inspectionCreateDTO.NextVisitDate,
                PatientId = patientId,
                DoctorId = doctor.Id,
                CreateTime = DateTime.UtcNow
            };

            if (inspectionCreateDTO.DeathDate.HasValue)
            {
                inspection.DeathDate = inspectionCreateDTO.DeathDate;
            }

            if (inspectionCreateDTO.PreviousInspectionId.HasValue)
            {
                inspection.PreviousInspectionId = inspectionCreateDTO.PreviousInspectionId;
            }

            await _dbContext.Inspections.AddAsync(inspection);
            await _dbContext.SaveChangesAsync();
            patient.Inspection.Add(inspection);
            doctor.Inspection.Add(inspection);

            if (inspectionCreateDTO.Consultations != null && inspectionCreateDTO.Consultations.Any())
            {
                foreach (var consultationDTO in inspectionCreateDTO.Consultations)
                {
                    int commentsCount = consultationDTO.Comment?.Count ?? 0;

                    List<Comment> comments = consultationDTO.Comment?.Select(commentDTO => new Comment
                    {
                        ParentId = null,
                        Content = commentDTO.Content,
                        AuthorId = doctor.Id,
                        CreateTime = DateTime.UtcNow,
                        ModifyTime = null
                    }).ToList() ?? new List<Comment>();

                    Consultation consultation = new Consultation
                    {
                        SpecialityId = consultationDTO.SpecialityId,
                        CreateTime = DateTime.UtcNow,
                        CommentsNumber = commentsCount, // пока что не понятно как и от чего зависит этот атрибут
                        InspectionId = inspection.Id,
                        RootComment = comments
                    };

                    inspection.Consultations.Add(consultation);
                }
            }

            if (inspectionCreateDTO.Diagnoses != null && inspectionCreateDTO.Diagnoses.Any())
            {
                foreach (var diagnosisDTO in inspectionCreateDTO.Diagnoses)
                {
                    var icd = await _dbContext.ICDs.FindAsync(diagnosisDTO.IcdDiagnosisId);

                    if (icd == null)
                    {
                        throw new BadHttpRequestException("Doctor with the specified speciality not found.");
                    }

                    Diagnosis diagnosis = new Diagnosis
                    {
                        Code = icd.CodeICD,
                        Name = icd.Name,
                        Description = diagnosisDTO.Description,
                        Type = diagnosisDTO.Type,
                        CreateTime = DateTime.UtcNow,
                        InspectionId = inspection.Id
                    };

                    inspection.Diagnoses.Add(diagnosis);
                }
            }
            await _dbContext.SaveChangesAsync();

            return inspection.Id;
        }

        public async Task<PatientInfoDTO> GetPatientById(Guid patientId)
        {
            var patient = await _dbContext.Patients.FindAsync(patientId);

            Console.WriteLine(patient);

            if (patient == null)
            {
                throw new Exception("Patient not found");
            }

            PatientInfoDTO patientInfoDTO = new PatientInfoDTO()
            {
                Id = patientId,
                CreateTime = patient.CreateTime,
                Name = patient.Name,
                Birthday = patient.Birthday,
                Gender = patient.Gender,
            };

            return patientInfoDTO;
        }
    }
}

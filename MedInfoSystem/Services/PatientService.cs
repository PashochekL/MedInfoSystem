using MedInfoSystem.Data;
using MedInfoSystem.Data.DTO.Diagnosis;
using MedInfoSystem.Data.DTO.Inspection;
using MedInfoSystem.Data.DTO.Patient;
using MedInfoSystem.Data.DTO.Speciality;
using MedInfoSystem.Data.Entities;
using MedInfoSystem.Data.Entities.Enums;
using MedInfoSystem.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

        public async Task<Guid> AddInspectionForPatient(Guid patientId, InspectionCreateDTO inspectionCreateDTO)
        {
            var allInspections = await _dbContext.Inspections.Where(i => i.PatientId == patientId).ToListAsync();

            if (patientId == Guid.Empty)
            {
                throw new BadHttpRequestException("Empty request field");
            }

            if (inspectionCreateDTO.NextVisitDate.HasValue && inspectionCreateDTO.Date >= inspectionCreateDTO.NextVisitDate.Value.Date)
            {
                throw new BadHttpRequestException("Bad request field");
            }

            var specialityId = inspectionCreateDTO.Consultations.FirstOrDefault().SpecialityId;
            var patient = await _dbContext.Patients.FindAsync(patientId);
            var doctor = await _dbContext.Doctors.FirstOrDefaultAsync(d => d.SpecialityId == specialityId);

            if (doctor == null)
            {
                throw new BadHttpRequestException("Doctor with the specified speciality not found.");
            }

            Inspection inspection = null;
            bool checkAddInspect = false;

            if (allInspections == null)
            {
                if (inspectionCreateDTO.Conclusion == Conclusion.Disease)
                {
                    inspection = new Inspection
                    {
                        Anamnesis = inspectionCreateDTO.Anamesis,
                        Complaints = inspectionCreateDTO.Complaints,
                        Treatment = inspectionCreateDTO.Treatment,
                        Conclusion = inspectionCreateDTO.Conclusion,
                        NextVisitDate = inspectionCreateDTO.NextVisitDate,
                        PatientId = patientId,
                        DoctorId = doctor.Id,
                        Date = inspectionCreateDTO.Date,
                        CreateTime = DateTime.UtcNow
                    };
                    await _dbContext.Inspections.AddAsync(inspection);
                    await _dbContext.SaveChangesAsync();
                    patient.Inspection.Add(inspection);
                    doctor.Inspection.Add(inspection);
                    inspection.BaseInspectionId = inspection.Id;
                    await _dbContext.SaveChangesAsync();
                }
                else if (inspectionCreateDTO.Conclusion == Conclusion.Death)
                {
                    inspection = new Inspection
                    {
                        Anamnesis = inspectionCreateDTO.Anamesis,
                        Complaints = inspectionCreateDTO.Complaints,
                        Treatment = inspectionCreateDTO.Treatment,
                        Conclusion = inspectionCreateDTO.Conclusion,
                        DeathDate = inspectionCreateDTO.DeathDate,
                        PatientId = patientId,
                        DoctorId = doctor.Id,
                        Date = inspectionCreateDTO.Date,
                        CreateTime = DateTime.UtcNow
                    };
                    await _dbContext.Inspections.AddAsync(inspection);
                    await _dbContext.SaveChangesAsync();
                    patient.Inspection.Add(inspection);
                    doctor.Inspection.Add(inspection);
                    inspection.BaseInspectionId = inspection.Id;
                    await _dbContext.SaveChangesAsync();
                }
                else if (inspectionCreateDTO.Conclusion == Conclusion.Recovery)
                {
                    inspection = new Inspection
                    {
                        Anamnesis = inspectionCreateDTO.Anamesis,
                        Complaints = inspectionCreateDTO.Complaints,
                        Treatment = inspectionCreateDTO.Treatment,
                        Conclusion = inspectionCreateDTO.Conclusion,
                        PatientId = patientId,
                        DoctorId = doctor.Id,
                        Date = inspectionCreateDTO.Date,
                        CreateTime = DateTime.UtcNow
                    };
                    await _dbContext.Inspections.AddAsync(inspection);
                    await _dbContext.SaveChangesAsync();
                    patient.Inspection.Add(inspection);
                    doctor.Inspection.Add(inspection);
                    inspection.BaseInspectionId = inspection.Id;
                    await _dbContext.SaveChangesAsync();
                }
            }

            else
            {
                foreach (var inspect in allInspections)
                {
                    if ((inspect.PreviousInspectionId != null && inspect.BaseInspectionId != null /*&& inspect.NextVisitDate.Value.Date == inspectionCreateDTO.Date*/
                        && inspect.Id == inspectionCreateDTO.PreviousInspectionId) || (inspect.BaseInspectionId != null
                        /*&& inspect.NextVisitDate.Value.Date == inspectionCreateDTO.Date*/ && inspect.Id == inspectionCreateDTO.PreviousInspectionId))
                    {
                        if (inspectionCreateDTO.Conclusion == Conclusion.Disease)
                        {
                            inspection = new Inspection
                            {
                                Anamnesis = inspectionCreateDTO.Anamesis,
                                Complaints = inspectionCreateDTO.Complaints,
                                Treatment = inspectionCreateDTO.Treatment,
                                Conclusion = inspectionCreateDTO.Conclusion,
                                NextVisitDate = inspectionCreateDTO.NextVisitDate,
                                PreviousInspectionId = inspect.Id,
                                PatientId = patientId,
                                DoctorId = doctor.Id,
                                BaseInspectionId = inspect.BaseInspectionId,
                                Date = inspectionCreateDTO.Date,
                                CreateTime = DateTime.UtcNow
                            };
                            await _dbContext.Inspections.AddAsync(inspection);
                            await _dbContext.SaveChangesAsync();

                            patient.Inspection.Add(inspection);
                            doctor.Inspection.Add(inspection);

                            checkAddInspect = true;

                            break;
                        }
                        else if (inspectionCreateDTO.Conclusion == Conclusion.Death)
                        {
                            inspection = new Inspection
                            {
                                Anamnesis = inspectionCreateDTO.Anamesis,
                                Complaints = inspectionCreateDTO.Complaints,
                                Treatment = inspectionCreateDTO.Treatment,
                                Conclusion = inspectionCreateDTO.Conclusion,
                                DeathDate = inspectionCreateDTO.DeathDate,  // по-сути можно проверять если нет даты смерти то ставить равной дате приема но это bruh
                                PreviousInspectionId = inspect.Id,
                                PatientId = patientId,
                                DoctorId = doctor.Id,
                                BaseInspectionId = inspect.BaseInspectionId,
                                Date = inspectionCreateDTO.Date,
                                CreateTime = DateTime.UtcNow
                            };
                            await _dbContext.Inspections.AddAsync(inspection);
                            await _dbContext.SaveChangesAsync();

                            patient.Inspection.Add(inspection);
                            doctor.Inspection.Add(inspection);

                            checkAddInspect = true;

                            break;
                        }
                        else if (inspectionCreateDTO.Conclusion == Conclusion.Recovery)
                        {
                            inspection = new Inspection
                            {
                                Anamnesis = inspectionCreateDTO.Anamesis,
                                Complaints = inspectionCreateDTO.Complaints,
                                Treatment = inspectionCreateDTO.Treatment,
                                Conclusion = inspectionCreateDTO.Conclusion,
                                PreviousInspectionId = inspect.Id,
                                PatientId = patientId,
                                DoctorId = doctor.Id,
                                BaseInspectionId = inspect.BaseInspectionId,
                                Date = inspectionCreateDTO.Date,
                                CreateTime = DateTime.UtcNow
                            };
                            await _dbContext.Inspections.AddAsync(inspection);
                            await _dbContext.SaveChangesAsync();

                            patient.Inspection.Add(inspection);
                            doctor.Inspection.Add(inspection);

                            checkAddInspect = true;

                            break;
                        }
                    }
                }
                if (inspectionCreateDTO.Conclusion != Conclusion.Death && inspectionCreateDTO.Conclusion != Conclusion.Recovery && checkAddInspect != true)
                {
                    inspection = new Inspection
                    {
                        Anamnesis = inspectionCreateDTO.Anamesis,
                        Complaints = inspectionCreateDTO.Complaints,
                        Treatment = inspectionCreateDTO.Treatment,
                        Conclusion = inspectionCreateDTO.Conclusion,
                        NextVisitDate = inspectionCreateDTO.NextVisitDate,
                        PatientId = patientId,
                        DoctorId = doctor.Id,
                        Date = inspectionCreateDTO.Date,
                        CreateTime = DateTime.UtcNow
                    };
                    await _dbContext.Inspections.AddAsync(inspection);
                    await _dbContext.SaveChangesAsync();
                    patient.Inspection.Add(inspection);
                    doctor.Inspection.Add(inspection);
                    inspection.BaseInspectionId = inspection.Id;
                    await _dbContext.SaveChangesAsync();
                }
                else if (inspectionCreateDTO.Conclusion == Conclusion.Death && checkAddInspect != true)
                {
                    inspection = new Inspection
                    {
                        Anamnesis = inspectionCreateDTO.Anamesis,
                        Complaints = inspectionCreateDTO.Complaints,
                        Treatment = inspectionCreateDTO.Treatment,
                        Conclusion = inspectionCreateDTO.Conclusion,
                        DeathDate = inspectionCreateDTO.DeathDate,  // по-сути можно проверять если нет даты смерти то ставить равной дате приема но это bruh
                        PatientId = patientId,
                        DoctorId = doctor.Id,
                        Date = inspectionCreateDTO.Date,
                        CreateTime = DateTime.UtcNow
                    };
                    await _dbContext.Inspections.AddAsync(inspection);
                    await _dbContext.SaveChangesAsync();
                    patient.Inspection.Add(inspection);
                    doctor.Inspection.Add(inspection);
                    inspection.BaseInspectionId = inspection.Id;
                    await _dbContext.SaveChangesAsync();
                }
                else if (inspectionCreateDTO.Conclusion == Conclusion.Recovery && checkAddInspect != true)
                {
                    inspection = new Inspection
                    {
                        Anamnesis = inspectionCreateDTO.Anamesis,
                        Complaints = inspectionCreateDTO.Complaints,
                        Treatment = inspectionCreateDTO.Treatment,
                        Conclusion = inspectionCreateDTO.Conclusion,
                        PatientId = patientId,
                        DoctorId = doctor.Id,
                        Date = inspectionCreateDTO.Date,
                        CreateTime = DateTime.UtcNow
                    };
                    await _dbContext.Inspections.AddAsync(inspection);
                    await _dbContext.SaveChangesAsync();
                    patient.Inspection.Add(inspection);
                    doctor.Inspection.Add(inspection);
                    inspection.BaseInspectionId = inspection.Id;
                    await _dbContext.SaveChangesAsync();
                }
            }

            if (inspectionCreateDTO.Consultations != null && inspectionCreateDTO.Consultations.Any())
            {
                foreach (var consultationDTO in inspectionCreateDTO.Consultations)
                {
                    int commentsCount = consultationDTO.newComment?.Count ?? 0;

                    List<Comment> comments = consultationDTO.newComment?.Select(commentDTO => new Comment
                    {
                        ParentId = null,
                        Content = commentDTO.Content,
                        AuthorId = doctor.Id,
                        Author = doctor,
                        CreateTime = DateTime.UtcNow,
                        ModifyTime = null
                    }).ToList() ?? new List<Comment>();

                    Consultation consultation = new Consultation
                    {
                        SpecialityId = consultationDTO.SpecialityId,
                        CreateTime = DateTime.UtcNow,
                        CommentsNumber = commentsCount,
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

        public async Task<InspectionPageListDTO> GetPatientInspections(Guid patientId, bool? groopedFlag, List<string> icdRoots, int page, int size)
        {
            IQueryable<Inspection> inspections = _dbContext.Inspections.Include(i => i.Diagnoses).Where(i => i.PatientId == patientId);

            if (!inspections.Any())
            {
                throw new Exception("Patient not found"); // заменить ошибку на свою самописную, чтобы сообщало об отсутствии у пациента осмотров.
            }

            if (icdRoots != null && icdRoots.Count != 0)
            {
                List<string> icdCodes = await _dbContext.Set<ICD>().Where(icd => icdRoots
                                .Contains(icd.Id.ToString())).Select(icd => icd.CodeICD).ToListAsync();
                if (icdCodes != null)
                {
                    inspections = inspections.Where(inspection => inspection.Diagnoses.Any(d => icdCodes.Contains(d.Code)));
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
                inspection = inspectionPreviewDTO
            };
            return inspectionPageListDTO;
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

        public async Task<List<InspectionShortModelDTO>> GetInspectionsWithoutChild(Guid patientId, string request)
        {
            var inspections = _dbContext.Inspections.Include(i => i.Diagnoses).Where(i => i.PatientId == patientId).ToList();

            if (inspections == null)
            {
                throw new Exception("Patient not found");
            }

            List<InspectionShortModelDTO> inspectionList = new List<InspectionShortModelDTO>();

            if (request == null)
            {
                foreach (var inspection in inspections)
                {
                    if (inspection.Id != inspection.BaseInspectionId)
                    {
                        var newInspection = new InspectionShortModelDTO
                        {
                            Id = inspection.Id,
                            Date = inspection.Date,
                            CreateTime = inspection.CreateTime,
                            Diagnoses = new List<DiagnosisGetDTO>()
                        };

                        foreach (var diagnosis in inspection.Diagnoses)
                        {
                            newInspection.Diagnoses.Add(new DiagnosisGetDTO
                            {
                                Id = diagnosis.Id,
                                CreateTime = diagnosis.CreateTime,
                                Code = diagnosis.Code,
                                Description = diagnosis.Description,
                                Name = diagnosis.Name,
                                Type = diagnosis.Type
                            });
                        }
                        inspectionList.Add(newInspection);
                    }
                }
            }
            else
            {
                foreach (var inspection in inspections)
                {
                    if (inspection.Id != inspection.BaseInspectionId)
                    {
                        bool flag = false;

                        var newInspection = new InspectionShortModelDTO
                        {
                            Id = inspection.Id,
                            Date = inspection.Date,
                            CreateTime = inspection.CreateTime,
                            Diagnoses = new List<DiagnosisGetDTO>()
                        };

                        foreach (var diagnosis in inspection.Diagnoses)
                        {
                            if (diagnosis.Code.Contains(request) || diagnosis.Name.Contains(request))
                            {
                                newInspection.Diagnoses.Add(new DiagnosisGetDTO
                                {
                                    Id = diagnosis.Id,
                                    CreateTime = diagnosis.CreateTime,
                                    Code = diagnosis.Code,
                                    Description = diagnosis.Description,
                                    Name = diagnosis.Name,
                                    Type = diagnosis.Type
                                });
                                flag = true;
                            }
                        }

                        if (flag)
                        {
                            inspectionList.Add(newInspection);
                        }
                    }
                }
            }

            return inspectionList;
        }
    }
}

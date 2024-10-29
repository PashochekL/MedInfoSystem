using MedInfoSystem.Data;
using MedInfoSystem.Data.DTO.Inspection;
using MedInfoSystem.Data.Entities;
using MedInfoSystem.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace MedInfoSystem.Services
{
    public class InspectionService : IInspectionService
    {
        private readonly AppDBContext _dbContext;

        public InspectionService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task EditInspection(Guid inspectionId, InspectionEditModelDTO inspectionEditModelDTO)
        {
            var inspection = await _dbContext.Inspections.Include(i => i.Diagnoses).FirstOrDefaultAsync(i => i.Id == inspectionId);

            if (inspection == null)
            {
                throw new Exception("Inspection not found");
            }

            inspection.Anamnesis = inspectionEditModelDTO.Anamesis;
            inspection.Complaints = inspectionEditModelDTO.Complaints;
            inspection.Treatment = inspectionEditModelDTO.Treatment;
            inspection.Conclusion = inspectionEditModelDTO.Conclusion;
            inspection.NextVisitDate = inspectionEditModelDTO.NextVisitDate;
            inspection.DeathDate = inspectionEditModelDTO.DeathDate;

            var newDiagnoses = inspectionEditModelDTO.Diagnoses;

            inspection.Diagnoses.RemoveAll(d => !newDiagnoses.Any(nd => nd.IcdDiagnosisId == d.InspectionId));

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
    }
}

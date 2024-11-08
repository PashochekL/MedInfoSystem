using MedInfoSystem.Data.DTO.Inspection;
using MedInfoSystem.Data.DTO.Patient;
using MedInfoSystem.Data.Entities.Enums;
using Microsoft.AspNetCore.Mvc;

namespace MedInfoSystem.Services.IServices
{
    public interface IPatientService
    {
        public Task<Guid> AddPatient(PatientCreateDTO patientCreateDTO);
        public Task<PatientPageListDTO> GetPatientsList(Guid doctorId, string? name, [FromQuery] List<Conclusion>? conclusions = null,
            Sorting? sorting = null, bool? scheduledVisits = null, bool? onlyMine = null, int page = 1, int size = 5);
        public Task<Guid> AddInspectionForPatient(Guid patientId, InspectionCreateDTO inspectionCreateDTO);
        public Task<InspectionPageListDTO> GetPatientInspections(Guid patientId, bool? groopedFlag, List<string> icdRoots, int page, int size);
        public Task<PatientInfoDTO> GetPatientById(Guid patientId);
        public Task<List<InspectionShortModelDTO>> GetInspectionsWithoutChild(Guid patientId, string request);
    }
}

using MedInfoSystem.Data.DTO.Inspection;
using MedInfoSystem.Data.DTO.Patient;

namespace MedInfoSystem.Services.IServices
{
    public interface IPatientService
    {
        public Task<Guid> AddPatient(PatientCreateDTO patientCreateDTO);
        public Task<Guid> AddInspectionForPatient(Guid patientId, InspectionCreateDTO inspectionCreateDTO);
        public Task<InspectionPageListDTO> GetPatientInspections(Guid patientId, bool? groopedFlag, List<string> icdRoots, int page, int size);
        public Task<PatientInfoDTO> GetPatientById(Guid patientId);
        public Task<List<InspectionShortModelDTO>> GetInspectionsWithoutChild(Guid patientId, string request);
    }
}

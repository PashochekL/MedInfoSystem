using MedInfoSystem.Data.DTO.Inspection;
using MedInfoSystem.Data.DTO.Patient;

namespace MedInfoSystem.Services.IServices
{
    public interface IPatientService
    {
        public Task<Guid> AddPatient(PatientCreateDTO patientCreateDTO);
        public Task<Guid> AddInspectionForPatient(Guid patientId, InspectionCreateDTO inspectionCreateDTO);
        public Task<PatientInfoDTO> GetPatientById(Guid patientId);

    }
}

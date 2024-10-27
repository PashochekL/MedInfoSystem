using MedInfoSystem.Data.DTO.Patient;

namespace MedInfoSystem.Services.IServices
{
    public interface IPatientService
    {
        public Task<Guid> AddPatient(PatientCreateDTO patientCreateDTO);
        public Task<PatientInfoDTO> GetPatientById(Guid patientId);

    }
}

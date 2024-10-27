using MedInfoSystem.Data;
using MedInfoSystem.Data.DTO.Patient;
using MedInfoSystem.Data.Entities;
using MedInfoSystem.Services.IServices;

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

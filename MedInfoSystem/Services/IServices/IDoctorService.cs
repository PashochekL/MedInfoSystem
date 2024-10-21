using MedInfoSystem.Data.DTO.Doctor;
using MedInfoSystem.Data.Entities;

namespace MedInfoSystem.Services.IServices
{
    public interface IDoctorService
    {
        public Task AddDoctor(DoctorDTO doctorDTO);
    }
}

using MedInfoSystem.Data.DTO.Doctor;
using MedInfoSystem.Data.Entities;

namespace MedInfoSystem.Services.IServices
{
    public interface IDoctorService
    {
        public Task AddDoctor(DoctorRegisterDTO doctorRegisterDTO);
        public Task<string> AutorizeDoctor(DoctorLoginDTO doctorLoginDTO);
        public Task<DoctorModelDTO> GetProfile(Guid doctorId);
        public Task EditProfile(Guid doctorId, DoctorEditDTO doctorEditDTO);
    }
}

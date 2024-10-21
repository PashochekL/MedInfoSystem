using MedInfoSystem.Data;
using MedInfoSystem.Data.DTO.Doctor;
using MedInfoSystem.Data.Entities;
using MedInfoSystem.Services.IServices;

namespace MedInfoSystem.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly AppDBContext _dbContext;

        public DoctorService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddDoctor(DoctorDTO doctorDTO)
        {
            if (doctorDTO == null && (doctorDTO.Name == "" || doctorDTO.Email == ""
                || doctorDTO.Birthday == null || doctorDTO.Gender == "" || doctorDTO.Phone == ""))
            {
                throw new BadHttpRequestException("Пустое поле запроса");
            }

            Doctor doctor = new Doctor() 
            { 
                Name = doctorDTO.Name,
                Email = doctorDTO.Email,
                Birthday = doctorDTO.Birthday,
                Gender = doctorDTO.Gender,
                Phone = doctorDTO.Phone,
            };
            _dbContext.Add(doctor);
            await _dbContext.SaveChangesAsync();
        }
    }
}

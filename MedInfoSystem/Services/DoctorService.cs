using DocumentFormat.OpenXml.Wordprocessing;
using MedInfoSystem.Data;
using MedInfoSystem.Data.DTO.Doctor;
using MedInfoSystem.Data.Entities;
using MedInfoSystem.Data.Entities.Enums;
using MedInfoSystem.Services.Exceptions;
using MedInfoSystem.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace MedInfoSystem.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly AppDBContext _dbContext;
        private readonly TokenService _tokenService;
        private readonly PasswordService _passwordService;

        public DoctorService(AppDBContext dbContext, TokenService tokenService, PasswordService passwordService)
        {
            _dbContext = dbContext;
            _tokenService = tokenService;
            _passwordService = passwordService;
        }

        public async Task<string> AddDoctor(DoctorRegisterDTO doctorRegisterDTO)
        {
            if (doctorRegisterDTO == null)
            {
                throw new BadHttpRequestException("Empty request field");
            }

            Doctor doctor = new Doctor()
            {
                Id = Guid.NewGuid(),
                Name = doctorRegisterDTO.Name,
                Email = doctorRegisterDTO.Email,
                Birthday = doctorRegisterDTO.Birthday.ToUniversalTime(),
                Gender = doctorRegisterDTO.Gender,
                Phone = doctorRegisterDTO.Phone,
                SpecialityId = doctorRegisterDTO.SpecialityId,
                Password = await _passwordService.HashPassword(doctorRegisterDTO.Password),
                CreateTime = DateTime.UtcNow
            };
            _dbContext.Add(doctor);
            await _dbContext.SaveChangesAsync();
            string token = _tokenService.GenerateToken(doctor.Id);

            return token;
        }

        public async Task<string> AutorizeDoctor(DoctorLoginDTO doctorLoginDTO)
        {
            if (doctorLoginDTO == null)
            {
                throw new BadHttpRequestException("Empty request field");
            }

            var doctors = await _dbContext.Doctors.Where(i => i.Email == doctorLoginDTO.Email).ToListAsync();

            if (doctors.Count == 0)
            {
                throw new BadHttpRequestException("Invalid email");
            }


            foreach (var newDoctor in doctors)
            {
                bool checker = await _passwordService.VerifyHashedPassword(newDoctor.Password, doctorLoginDTO.Password);

                if (checker)
                {
                    var doctorId = newDoctor.Id;
                    string token = _tokenService.GenerateToken(doctorId);

                    return token;
                }
            }

            throw new BadHttpRequestException("Invalid password");
        }

        public async Task<DoctorModelDTO> GetProfile(Guid doctorId)
        {
            var doctor = await _dbContext.Doctors.FindAsync(doctorId);

            if (doctor == null)
            {
                throw new NotFoundException("Doctor not found");
            }

            DoctorModelDTO doctorModelDTO = new DoctorModelDTO()
            {
                Name = doctor.Name,
                Birthday = doctor.Birthday,
                Gender = doctor.Gender,
                Email = doctor.Email,
                Phone = doctor.Phone,
                Id = doctor.Id,
                CreateTime = doctor.CreateTime
            };

            return doctorModelDTO;
        }

        public async Task EditProfile(Guid doctorId, DoctorEditDTO doctorEditDTO)
        {
            var doctor = await _dbContext.Doctors.FindAsync(doctorId);

            if (doctor == null)
            {
                throw new NotFoundException("Doctor not found");
            }

            if (doctorEditDTO == null)
            {
                throw new BadHttpRequestException("Empty request field");
            }

            doctor.Email = doctorEditDTO.Email;
            doctor.Name = doctorEditDTO.Name;
            doctor.Birthday = doctorEditDTO.Birthday;
            doctor.Gender = doctorEditDTO.Gender;
            doctor.Phone = doctorEditDTO.Phone;

            await _dbContext.SaveChangesAsync();
        }
    }
}

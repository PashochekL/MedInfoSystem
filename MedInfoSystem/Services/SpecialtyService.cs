using MedInfoSystem.Data;
using MedInfoSystem.Data.DTO.Speciality;
using MedInfoSystem.Data.Entities;
using MedInfoSystem.Services.Exceptions;
using MedInfoSystem.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace MedInfoSystem.Services
{
    public class SpecialtyService : ISpecialtyService
    {
        private readonly AppDBContext _dbContext;

        public SpecialtyService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SpecialityGetDTO>> GetAllSpecialtiesAsync()
        {
            var specialities =  await _dbContext.Specialities.ToListAsync();

            if (!specialities.Any())
            {
                throw new NotFoundException("Not found list of specialities");
            }

            var specialityDtos = specialities.Select(s => new SpecialityGetDTO
            {
                Id = s.Id,
                Name = s.Name,
                CreateTime = s.CreateTime
            }).ToList();

            return specialityDtos;
        }
    }
}

using MedInfoSystem.Data;
using MedInfoSystem.Data.Entities;
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

        public async Task<IEnumerable<Speciality>> GetAllSpecialtiesAsync()
        {
            return await _dbContext.Specialities.ToListAsync();
        }
    }
}

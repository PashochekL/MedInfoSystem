using MedInfoSystem.Data.Entities;

namespace MedInfoSystem.Services.IServices
{
    public interface ISpecialtyService
    {
        public Task<IEnumerable<Speciality>> GetAllSpecialtiesAsync();
    }
}

using MedInfoSystem.Data.DTO.Speciality;
using MedInfoSystem.Data.Entities;

namespace MedInfoSystem.Services.IServices
{
    public interface ISpecialtyService
    {
        public Task<List<SpecialityGetDTO>> GetAllSpecialtiesAsync();
    }
}

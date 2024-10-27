using MedInfoSystem.Data.Entities;

namespace MedInfoSystem.Data.DTO.Speciality

{
    public class SpecialitiesDTO
    {
        public IEnumerable<SpecialityDTO> Specialities { get; set; }
        public Pagination Pagination { get; set; }
    }
}

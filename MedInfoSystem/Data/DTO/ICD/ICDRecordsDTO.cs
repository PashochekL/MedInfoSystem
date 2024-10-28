using MedInfoSystem.Data.DTO.Speciality;
using MedInfoSystem.Data.Entities;

namespace MedInfoSystem.Data.DTO.ICD
{
    public class ICDRecordsDTO
    {
        public IEnumerable<ICDRecordModelDTO> Records { get; set; }
        public Pagination Pagination { get; set; }
    }
}

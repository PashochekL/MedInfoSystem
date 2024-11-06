using MedInfoSystem.Data.DTO.ICD;
using MedInfoSystem.Data.Entities;

namespace MedInfoSystem.Data.DTO.Inspection
{
    public class InspectionPageListDTO
    {
        public IEnumerable<InspectionPreviewDTO>? inspection { get; set; }
        public Pagination Pagination { get; set; }
    }
}

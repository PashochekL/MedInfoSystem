using MedInfoSystem.Data.DTO.ICD;
using MedInfoSystem.Data.Entities;

namespace MedInfoSystem.Data.DTO.Inspection
{
    public class InspectionPageListDTO
    {
        public IEnumerable<InspectionPreviewDTO>? Inspections { get; set; }
        public Pagination Pagination { get; set; }
    }
}

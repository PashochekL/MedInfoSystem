using MedInfoSystem.Data.DTO.Inspection;
using MedInfoSystem.Data.Entities;

namespace MedInfoSystem.Services.IServices
{
    public interface IInspectionService
    {
        public Task<InspectionGetDTO> GetFullInfInspection(Guid inspectionId);
        public Task EditInspection(Guid inspectionId, InspectionEditModelDTO inspectionEditModelDTO);
    }
}

using MedInfoSystem.Data.DTO.Inspection;

namespace MedInfoSystem.Services.IServices
{
    public interface IInspectionService
    {
        public Task EditInspection(Guid inspectionId, InspectionEditModelDTO inspectionEditModelDTO);
    }
}

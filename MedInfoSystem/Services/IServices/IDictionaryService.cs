using MedInfoSystem.Data.DTO.ICD;
using MedInfoSystem.Data.DTO.Speciality;

namespace MedInfoSystem.Services.IServices
{
    public interface IDictionaryService
    {
        public Task<SpecialitiesDTO> GetSpecialityList(string name, int page, int size);
        public Task<ICDRecordsDTO> SearchDiagnosesICD(string request, int page, int size);
        public Task<List<ICDRecordModelDTO>> GetICDRoots();
    }
}

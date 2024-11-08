using MedInfoSystem.Data.DTO;
using Microsoft.AspNetCore.Mvc;
using MedInfoSystem.Services;
using MedInfoSystem.Services.IServices;
using MedInfoSystem.Data.DTO.Speciality;
using DocumentFormat.OpenXml.Wordprocessing;
using MedInfoSystem.Data.DTO.ICD;

namespace MedInfoSystem.Controllers
{
    [ApiController]
    [Route("api/dictionary")]
    public class DictionaryController : ControllerBase
    {
        private readonly IDictionaryService _service;
        private readonly CsvDataLoaderService _csvDataLoaderService;

        public DictionaryController(IDictionaryService service, CsvDataLoaderService csvDataLoaderService)
        {
            _service = service;
            _csvDataLoaderService = csvDataLoaderService;
        }

        [HttpGet("speciality")]
        public async Task<ActionResult<SpecialitiesDTO>> GetSpecialityList(string? name, int page = 1, int size = 5)
        {
            var specialityList = await _service.GetSpecialityList(name, page, size);

            return Ok(specialityList);
        }

        [HttpGet("icd10")]
        public async Task<ActionResult<ICDRecordsDTO>> SearchDiagnoses(string? request, int page = 1, int size = 5)
        {
            var icdRoots = await _service.SearchDiagnosesICD(request, page, size);

            return Ok(icdRoots);
        }

        [HttpGet("icd10/roots")]
        public async Task<IActionResult> GetICD10Roots()
        {
            var listIcdroots = await _service.GetICDRoots();
            return Ok(listIcdroots);
        }
    }
}

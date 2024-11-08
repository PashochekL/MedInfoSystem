using MedInfoSystem.Data.DTO;
using Microsoft.AspNetCore.Mvc;
using MedInfoSystem.Services;
using MedInfoSystem.Services.IServices;
using MedInfoSystem.Data.DTO.Speciality;
using DocumentFormat.OpenXml.Wordprocessing;
using MedInfoSystem.Data.DTO.ICD;
using DocumentFormat.OpenXml.Office2016.Excel;
using System.Xml.Linq;

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

        /// <summary>
        /// Get specialities list
        /// </summary>
        /// <param name="name">part of the name for filtering</param>
        /// <param name="page">page number</param>
        /// <param name="size">required number of elements per page</param>
        /// <response code="200">Specialties paged list retrieved</response>
        /// <response code="400">Invalid arguments for filtration/pagination</response>
        /// <response code="500">InternalServerError</response>
        [HttpGet("speciality")]
        public async Task<ActionResult<SpecialitiesDTO>> GetSpecialityList(string? name, int page = 1, int size = 5)
        {
            var specialityList = await _service.GetSpecialityList(name, page, size);

            return Ok(specialityList);
        }

        /// <summary>
        /// Search for diagnoses in ICD-10 dictionary
        /// </summary>
        /// <param name="name">part of the diagnosis name or code</param>
        /// <param name="page">page number</param>
        /// <param name="size">required number of elements per page</param>
        /// <response code="200">Searching result extracted</response>
        /// <response code="400">Some fields in request are invalid</response>
        /// <response code="500">InternalServerError</response>
        [HttpGet("icd10")]
        public async Task<ActionResult<ICDRecordsDTO>> SearchDiagnoses(string? request, int page = 1, int size = 5)
        {
            var icdRoots = await _service.SearchDiagnosesICD(request, page, size);

            return Ok(new { icdRoots, message = "Searching result extracted" } );
        }

        /// <summary>
        /// Get root ICD-10 elements
        /// </summary>
        /// <param name="name">part of the diagnosis name or code</param>
        /// <param name="page">page number</param>
        /// <param name="size">required number of elements per page</param>
        /// <response code="200">Root ICD-10 elements retrieved</response>
        /// <response code="500">InternalServerError</response>
        [HttpGet("icd10/roots")]
        public async Task<ActionResult<ICDRecordModelDTO>> GetICD10Roots()
        {
            var listIcdroots = await _service.GetICDRoots();
            return Ok(listIcdroots);
        }
    }
}

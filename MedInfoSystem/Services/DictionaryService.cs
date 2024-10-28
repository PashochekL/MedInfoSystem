using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Wordprocessing;
using MedInfoSystem.Data;
using MedInfoSystem.Data.DTO.ICD;
using MedInfoSystem.Data.DTO.Speciality;
using MedInfoSystem.Data.Entities;
using MedInfoSystem.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace MedInfoSystem.Services
{
    public class DictionaryService : IDictionaryService
    {
        private readonly AppDBContext _dbContext;

        public DictionaryService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SpecialitiesDTO> GetSpecialityList(string name, int page, int size)
        {
            IQueryable<Speciality> source = _dbContext.Specialities;

            var count = await source.CountAsync();

            var items = await source.Skip((page - 1) * size).Take(size).
            Select(s => new SpecialityDTO
            {
                Id = s.Id,
                CreateTime = s.CreateTime,
                Name = s.Name
            })
            .ToListAsync();

            List<SpecialityDTO> listSpecialities;

            if (name ==  null)
            {
                listSpecialities = items;
            }
            else
            {
                listSpecialities = new List<SpecialityDTO>();

                foreach (var item in items)
                {
                    bool contrains = item.Name.Contains(name);

                    if (contrains)
                    {
                        listSpecialities.Add(item);
                    }
                }
            }
            
            Pagination pagination = new Pagination(count, page, size);
            SpecialitiesDTO specialityDTO = new SpecialitiesDTO
            {
                Pagination = pagination,
                Specialities = listSpecialities
            };
            return specialityDTO;
        }

        public async Task<ICDRecordsDTO> SearchDiagnosesICD(string request, int page, int size)
        {
            IQueryable<ICD> source = _dbContext.ICDs;

            var count = await source.CountAsync();

            var items = await source.Skip((page - 1) * size).Take(size).
            Select(s => new ICDRecordModelDTO
            {
                Id = s.Id,
                Code = s.CodeICD,
                CreateTime = s.CreateTime,
                Name = s.Name
            })
            .ToListAsync();

            List<ICDRecordModelDTO> icdRecordModelDTO;

            if (request == null)
            {
                icdRecordModelDTO = items;
            }

            else
            {
                icdRecordModelDTO = new List<ICDRecordModelDTO>();

                foreach (var item in items)
                {
                    bool contrains = item.Code.Contains(request);

                    if (contrains)
                    {
                        icdRecordModelDTO.Add(item);
                    }
                }
            }


            Pagination pagination = new Pagination(count, page, size);
            ICDRecordsDTO icsRecordsDTO = new ICDRecordsDTO
            {
                Records = icdRecordModelDTO,
                Pagination = pagination
            };
            return icsRecordsDTO;
        }

        public async Task<List<ICDRecordModelDTO>> GetICDRoots()
        {
            var list = await _dbContext.ICDs.Where(i => i.ParentId == null)
            .Select(i => new ICDRecordModelDTO
            {
                Id = i.Id,
                CreateTime = i.CreateTime,
                Code = i.CodeICD,
                Name = i.Name
            }).ToListAsync();
            return list;
        }

        public bool ContainsDigit(string input)
        {
            return Regex.IsMatch(input, @"\d");
        }
    }
}

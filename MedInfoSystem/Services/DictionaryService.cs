using DocumentFormat.OpenXml.InkML;
using MedInfoSystem.Data;
using MedInfoSystem.Data.DTO.ICD;
using MedInfoSystem.Data.DTO.Speciality;
using MedInfoSystem.Data.Entities;
using MedInfoSystem.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

        public async Task<List<ICDRecordModelDTO>> GetICDRoots()
        {
            var list = await _dbContext.ICDs.Where(i => i.ParentId == null)
            .Select(i => new ICDRecordModelDTO
            {
                ID = i.Id,
                CreateTime = i.CreateTime,
                Code = i.CodeICD,
                Name = i.Name
            }).ToListAsync();
            return list;
        }
    }
}

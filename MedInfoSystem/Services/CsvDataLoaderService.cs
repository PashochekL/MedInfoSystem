using CsvHelper;
using MedInfoSystem.Data;
using System;
using CsvHelper.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MedInfoSystem.Data.Entities;
using MedInfoSystem.Data.DTO.ICD;
using DocumentFormat.OpenXml.Math;

namespace MedInfoSystem.Services
{
    public class CsvDataLoaderService
    {
        private readonly AppDBContext _dbContext;

        public CsvDataLoaderService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task LoadCsvToDatabase(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ";",
                    HeaderValidated = null
                };

                using (var csv = new CsvReader(reader, config))
                {
                    var records = csv.GetRecords<ICDCreateDTO>().ToList();

                    var entities = records.Select(record => new ICD
                    {
                        Id = Guid.NewGuid(),
                        UniqueIdentifier = record.UniqueIdentifier,
                        FieldSort = record.FieldSort,
                        CodeICD = record.CodeICD,
                        Name = record.Name,
                        ParentId = record.ParentId,
                        AdditionalCode = record.AdditionalCode,
                        Actual = record.Actual,
                        Date = record.Date,
                        CreateTime = DateTime.UtcNow
                    }).ToList();

                    await _dbContext.ICDs.AddRangeAsync(entities);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}

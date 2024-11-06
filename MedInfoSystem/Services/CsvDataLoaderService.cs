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

                    foreach (var rootEntity in entities.Where(e => e.ParentId == null/* && IsLatinCode(e.CodeICD)*/))
                    {
                        var childEntities = entities
                            .Where(e => e.ParentId == rootEntity.UniqueIdentifier)
                            .OrderBy(e => e.CodeICD)
                            .ToList();

                        if (childEntities.Any())
                        {
                            var minCode = childEntities.First().CodeICD;
                            var maxCode = childEntities.Last().CodeICD;

                            rootEntity.CodeICD = $"{minCode}-{maxCode}";
                        }
                    }

                    await _dbContext.ICDs.AddRangeAsync(entities);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }

        private bool IsLatinCode(string code)
        {
            var latinCodes = new HashSet<string>
            {
                "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII", 
                "XIII", "XIV", "XV", "XVI", "XVII", "XVIII", "XIX", "XX", "XXI", "XXII"
            };

            return latinCodes.Contains(code);
        }
    }
}

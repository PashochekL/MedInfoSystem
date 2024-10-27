using CsvHelper.Configuration.Attributes;

namespace MedInfoSystem.Data.DTO.ICD
{
    public class ICDCreateDTO
    {
        [Name("ID")]
        public int UniqueIdentifier { get; set; }
        [Name("REC_CODE")]
        public string FieldSort { get; set; }
        [Name("MKB_CODE")]
        public string CodeICD { get; set; }
        [Name("MKB_NAME")]
        public string Name { get; set; }
        [Name("ID_PARENT")]
        public int? ParentId { get; set; }
        [Name("ADDL_CODE")]
        public int? AdditionalCode { get; set; }
        [Name("ACTUAL")]
        public int Actual { get; set; }
        [Name("DATE")]
        public string? Date { get; set; }
    }
}

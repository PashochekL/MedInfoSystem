using System.ComponentModel.DataAnnotations;

namespace MedInfoSystem.Data.Entities
{
    public class ICD
    {
        public Guid Id { get; set; }
        public int UniqueIdentifier { get; set; }
        public string FieldSort { get; set; }
        public string CodeICD { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public int? AdditionalCode { get; set; }
        public int Actual { get; set; }
        public string? Date { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
